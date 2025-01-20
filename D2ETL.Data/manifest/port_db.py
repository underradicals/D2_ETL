import sqlite3

from settings import SQL_SCRIPT


def port_from_world_content():
    print("Starting port from world content")
    print("Connecting to database")
    conn = sqlite3.connect('world_content.db')
    c = conn.cursor()
    print(f"Opening File: {SQL_SCRIPT.name}")
    sql = SQL_SCRIPT.read_text(encoding='utf-8')
    print(f"Executing SQL: {sql}")
    c.executescript(sql)
    print(f"Closing File: {SQL_SCRIPT.name}")
    print("Closing connection")
    conn.close()
    print("Finished port from world content")
