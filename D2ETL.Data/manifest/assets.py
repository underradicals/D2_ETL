import json
from concurrent.futures import ThreadPoolExecutor
from pathlib import Path

import backoff
import requests
from requests import Session

from settings import (
    BASE_ADDRESS,
    ASSETS_DIR, WORLD_DATA
)

total_number_of_images_per_hash = set()

session = Session()


def fatal_code(e):
    return 400 <= e.response.status_code < 500


def backoff_hdlr(details):
    print("Backing off {wait:0.1f} seconds after {tries} tries "
          "calling function {target} with args {args} and kwargs "
          "{kwargs}".format(**details))


onExceptions = (
    requests.exceptions.RequestException, requests.exceptions.HTTPError, requests.exceptions.ConnectionError,
    requests.exceptions.Timeout
)


@backoff.on_exception(backoff.expo, onExceptions, max_tries=3, jitter=backoff.random_jitter, on_backoff=backoff_hdlr)
def download_image(partial_url: str):
    path_name = ASSETS_DIR / partial_url[1:]
    if path_name.exists():
        print(f"File already exists: {path_name}")
        return
    else:
        path_name.parents[0].mkdir(parents=True, exist_ok=True)
        url = f'{BASE_ADDRESS}{partial_url}'
        response = session.get(url, stream=True)
        response.raise_for_status()
        print(f"Downloaded: {url}")
        path_name = ASSETS_DIR / partial_url[1:]
        with open(path_name, "wb") as f:
            for chunk in response.iter_content(chunk_size=8092):
                if chunk: f.write(chunk)
        print(f"Wrote {path_name}")


def walk_for_images(y: dict):
    def walk(x):
        if isinstance(x, dict):
            for k, v in x.items():
                walk(v)
        elif isinstance(x, list):
            for i, v in enumerate(x):
                walk(v)
        else:
            if isinstance(x, str) and (
                    x.lower().endswith('.png') or x.lower().endswith('.jpg') or x.lower().endswith('.jpeg')):
                total_number_of_images_per_hash.add(x)

    walk(y)


def iter_dir(dir_name: Path, exclude: list = None):
    for item in dir_name.iterdir():

        if item.name in exclude:
            continue
        if item.is_dir():
            yield from iter_dir(item, exclude)
        elif item.is_file() and item.name.lower().endswith('.json'):
            yield item


def get_all_images(filepath: Path):
    p = filepath.read_text(encoding='utf-8')
    return json.loads(p)


def create_dataframe(filepath: Path):
    json_data = get_all_images(filepath)
    walk_for_images(json_data)


def download_all_assets():
    exclude_list = ["Beta", "Alpha"]
    [create_dataframe(x) for x in iter_dir(WORLD_DATA, exclude_list)]
    with ThreadPoolExecutor(max_workers=5) as executor:
        executor.map(download_image, list(total_number_of_images_per_hash))
    session.close()


if __name__ == '__main__':
    download_all_assets()
