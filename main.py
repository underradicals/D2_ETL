import json
import sqlite3
from pathlib import Path
from time import perf_counter_ns

from manifest import port_from_world_content, write_all_tables, manifest, download_all_assets
from settings import WORLD_DATA, INVENTORY_ITEM_PATH, SEASON_DATA, INVENTORY_ITEM_LITE_PATH

connection = sqlite3.connect('world_content.db')
cursor = connection.cursor()

create_table_script_list = []
drop_table_script_list = []


def drop_table(table_name: str):
    drop_table = f"""DROP TABLE IF EXISTS {table_name};"""
    return drop_table


def create_table(table_name: str):
    create_table = f"""create table if not exists {table_name} (id integer not null,json blob not null,constraint {table_name.lower()}_pk primary key (id));"""
    return create_table


def init_custom_world_content_db():
    for item in WORLD_DATA.iterdir():
        table_name = item.name.split('.')[0]
        create_sql = create_table(table_name)
        drop_sql = drop_table(table_name)
        create_table_script_list.append(create_sql)
        drop_table_script_list.append(drop_sql)

    drop_table_script = '\n'.join(drop_table_script_list)
    create_table_script = '\n'.join(create_table_script_list)

    cursor.executescript(drop_table_script + '\n' + create_table_script)
    connection.commit()


def port_json_to_db():
    for item in WORLD_DATA.iterdir():
        list_of_tuples = []
        table_name = item.name.split('.')[0]
        file_content = item.read_text(encoding='utf-8')
        file_json = json.loads(file_content)
        print(f'Processing {item.name}')
        for k, v in file_json.items():
            key = int(k)
            data = json.dumps(v, ensure_ascii=False)
            list_of_tuples.append((key, data))
        insert_sql = f"insert into {table_name} (id, json) values (?, ?);"
        cursor.executemany(insert_sql, list_of_tuples)
        print("Running Insert Statement")
        print(f'Finished inserting {item.name}')
        print()
    print("Committing")
    connection.commit()


def run_build_database():
    start = perf_counter_ns()
    init_custom_world_content_db()
    port_json_to_db()
    end = perf_counter_ns()
    total_time = (end - start) / 1000000000
    return total_time


def update_inventory_item(season_data, watermark, v):
    season = season_data[watermark]
    year = season['Year']
    season_num = season['Season']
    season_name = season['SeasonName']
    v['seasonYear'] = year
    v['seasonNumber'] = season_num
    v['seasonName'] = season_name


def update_inventory_items(path: Path, season_data: dict):
    json_content = json.loads(path.read_text(encoding='utf-8'))
    for k, v in json_content.items():
        if 'iconWatermark' not in v:
            continue
        watermark = v['iconWatermark']
        if watermark not in season_data:
            continue
        update_inventory_item(season_data, watermark, v)
    path.write_text(json.dumps(json_content), encoding="utf-8")


def insert_season_data():
    season_data = json.loads(SEASON_DATA.read_text(encoding='utf-8'))
    print("Adding Season Data")
    update_inventory_items(INVENTORY_ITEM_PATH, season_data)
    update_inventory_items(INVENTORY_ITEM_LITE_PATH, season_data)
    print("Finished Adding Season Data")


if __name__ == '__main__':
    start_time = perf_counter_ns()
    manifest()
    insert_season_data()
    total_time = run_build_database()
    port_from_world_content()
    download_all_assets()
    end_time = perf_counter_ns()
    cursor.close()
    connection.close()
    write_all_tables()
    print('Total time:', (end_time - start_time) / 1000000000)
    print(f'Database Migration: {total_time}s')
