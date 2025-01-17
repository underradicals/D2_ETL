import sqlite3
from pathlib import Path

from polars import read_database
from xlsxwriter import Workbook

from settings import DATA_ASSETS


def write_data(table_name: str, schema_overrides: dict = None):
    DATA_ASSETS.mkdir(parents=True, exist_ok=True)

    def filename(name: str, ext: str) -> Path:
        child_dir = DATA_ASSETS / name
        child_dir.mkdir(parents=True, exist_ok=True)
        return DATA_ASSETS / name / f"{name}.{ext}"

    connection = sqlite3.connect('d2.db')
    sql = f"""select * from {table_name}"""

    df = read_database(
        sql,
        connection,
        schema_overrides=schema_overrides,
    )

    df.write_csv(filename(table_name, 'csv'))
    df.write_json(filename(table_name, 'json'))
    df.write_parquet(filename(table_name, 'parquet'))
    with Workbook(filename(table_name, 'xlsx')) as workbook:
        worksheet = workbook.add_worksheet(table_name)
        df.write_excel(
            workbook=workbook,
            worksheet=worksheet,
            table_style="Table Style Light 16",
            autofit=True
        )


def write_all_tables():
    connection = sqlite3.connect('d2.db')
    cursor = connection.cursor()
    sql = "select name from sqlite_master where type='table'"
    rows = cursor.execute(sql).fetchall()
    for row in rows:
        write_data(row[0])
        print("Wrote Dataframe: ", row[0])


if __name__ == '__main__':
    write_all_tables()
