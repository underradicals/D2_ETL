import json
from zipfile import ZipFile

from requests import Session

from manifest_models import Manifest
from settings import WORLD_DATA, BASE_ADDRESS, SQL_DIR, MANIFEST_PATH, SETTINGS_PATH, ENVIRONMENT, LANGUAGE, \
    WORLD_CONTENT_ZIP, WORLD_CONTENT_DB


def get_db_url(manifest: Manifest, lang: str) -> str:
    match lang:
        case "en":
            return manifest.Response.mobile_world_content_paths.en
        case "fr":
            return manifest.Response.mobile_world_content_paths.fr
        case "es":
            return manifest.Response.mobile_world_content_paths.es
        case "es-mx":
            return manifest.Response.mobile_world_content_paths.esmx
        case "de":
            return manifest.Response.mobile_world_content_paths.de
        case "it":
            return manifest.Response.mobile_world_content_paths.it
        case "ja":
            return manifest.Response.mobile_world_content_paths.ja
        case "pt-br":
            return manifest.Response.mobile_world_content_paths.ptbr
        case "ru":
            return manifest.Response.mobile_world_content_paths.ru
        case "pl":
            return manifest.Response.mobile_world_content_paths.pl
        case "ko":
            return manifest.Response.mobile_world_content_paths.ko
        case "zh-cht":
            return manifest.Response.mobile_world_content_paths.zhcht
        case "zh-chs":
            return manifest.Response.mobile_world_content_paths.zhchs
        case _:
            return manifest.Response.mobile_world_content_paths.en


def get_json_urls(manifest: Manifest, lang: str) -> list:
    match lang:
        case "en":
            return [(f'{x}.json', y) for x, y in
                    manifest.Response.json_world_component_content_paths.en.to_dict().items()]
        case "fr":
            return [(f'{x}.json', y) for x, y in
                    manifest.Response.json_world_component_content_paths.fr.to_dict().items()]
        case "es":
            return [(f'{x}.json', y) for x, y in
                    manifest.Response.json_world_component_content_paths.es.to_dict().items()]
        case "es-mx":
            return [(f'{x}.json', y) for x, y in
                    manifest.Response.json_world_component_content_paths.esmx.to_dict().items()]
        case "de":
            return [(f'{x}.json', y) for x, y in
                    manifest.Response.json_world_component_content_paths.de.to_dict().items()]
        case "it":
            return [(f'{x}.json', y) for x, y in
                    manifest.Response.json_world_component_content_paths.it.to_dict().items()]
        case "ja":
            return [(f'{x}.json', y) for x, y in
                    manifest.Response.json_world_component_content_paths.ja.to_dict().items()]
        case "pt-br":
            return [(f'{x}.json', y) for x, y in
                    manifest.Response.json_world_component_content_paths.ptbr.to_dict().items()]
        case "ru":
            return [(f'{x}.json', y) for x, y in
                    manifest.Response.json_world_component_content_paths.ru.to_dict().items()]
        case "pl":
            return [(f'{x}.json', y) for x, y in
                    manifest.Response.json_world_component_content_paths.pl.to_dict().items()]
        case "ko":
            return [(f'{x}.json', y) for x, y in
                    manifest.Response.json_world_component_content_paths.ko.to_dict().items()]
        case "zh-cht":
            return [(f'{x}.json', y) for x, y in
                    manifest.Response.json_world_component_content_paths.zhcht.to_dict().items()]
        case "zh-chs":
            return [(f'{x}.json', y) for x, y in
                    manifest.Response.json_world_component_content_paths.zhchs.to_dict().items()]
        case _:
            return [(f'{x}.json', y) for x, y in
                    manifest.Response.json_world_component_content_paths.en.to_dict().items()]


def download_d2_json(s: Session, iterable: list, dev: bool = False):
    p = WORLD_DATA.joinpath(iterable[0])
    if dev and p.exists():
        print(f'{p.name} already exists')
        return

    r = s.get(f'{BASE_ADDRESS}{iterable[1]}')
    r.raise_for_status()

    if str(p).endswith("zip"):
        p.write_bytes(r.content)
    else:
        p.write_text(r.text, encoding='utf-8')
    print(f'{iterable[1]} downloaded to {p.name}')


def update_manifest(manifest_json, http_session):
    manifest = Manifest(manifest_json)
    db_url = get_db_url(manifest, LANGUAGE)
    json_urls = get_json_urls(manifest, LANGUAGE)
    json_urls.append(["world_content.zip", db_url])
    for item in json_urls:
        download_d2_json(http_session, item, dev=True)
    with ZipFile(WORLD_CONTENT_ZIP) as zip64:
        archive_item_name = zip64.namelist()[0]
        archive_content = zip64.open(archive_item_name, "r")
        content = archive_content.read()
        WORLD_CONTENT_DB.write_bytes(content)
        archive_content.close()
    WORLD_CONTENT_ZIP.unlink(missing_ok=True)
    http_session.close()


def manifest():
    WORLD_DATA.mkdir(parents=True, exist_ok=True)
    SQL_DIR.mkdir(parents=True, exist_ok=True)
    MANIFEST_PATH.touch(exist_ok=True)
    settings_content = SETTINGS_PATH.read_text(encoding='utf-8')
    settings_json = json.loads(settings_content)
    http_session = Session()
    if ENVIRONMENT != 'DEVELOPMENT':
        http_session.headers.update(
            {'Content-Type': 'application/json', 'Accept': 'application/json', 'Accept-Charset': 'UTF-8',
             'Accept-Encoding': 'gzip, deflate', 'X-Api-Key': settings_json['apikey']})
        response = http_session.get(f"{BASE_ADDRESS}/platform/destiny2/manifest")
        response.raise_for_status()
        manifest_json = response.json()
        MANIFEST_PATH.write_text(json.dumps(manifest_json, indent=2, ensure_ascii=False))

        for file in WORLD_DATA.iterdir():
            if file.is_file():
                file.unlink(missing_ok=True)

        update_manifest(manifest_json, http_session)
    else:
        manifest_text = MANIFEST_PATH.read_text(encoding='utf-8')
        manifest_json = json.loads(manifest_text)

        update_manifest(manifest_json, http_session)
