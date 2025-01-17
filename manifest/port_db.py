import sqlite3

from settings import SQL_SCRIPT


def port_from_world_content():
    conn = sqlite3.connect('world_content.db')
    c = conn.cursor()

    sql = SQL_SCRIPT.read_text(encoding='utf-8')
    c.executescript(sql)
