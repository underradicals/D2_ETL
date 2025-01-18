from pathlib import Path

ROOT = Path.cwd()
SETTINGS_PATH = ROOT / 'settings.json'
MANIFEST_PATH = ROOT / 'manifest.json'
ENVIRONMENT = "PRODUCTION"
LANGUAGE = "en"
BASE_ADDRESS = 'https://www.bungie.net'

DATA_DIR = ROOT / 'data'
SQL_DIR = DATA_DIR / 'sql'
WORLD_DATA = DATA_DIR / 'world_content_data'
WORLD_CONTENT_ZIP = WORLD_DATA / 'world_content.zip'
WORLD_CONTENT_DB = ROOT / 'world_content.db'
ASSETS_DIR = DATA_DIR / 'assets'
SQL_SCRIPT = SQL_DIR / 'd2_script.sql'
DATA_ASSETS = DATA_DIR / 'data_assets'
SEASON_DATA = SQL_DIR / 'season.json'
WATERMARKS_DIR = DATA_DIR / 'watermarks'
INVENTORY_ITEM_PATH = WORLD_DATA / 'DestinyInventoryItemDefinition.json'
INVENTORY_ITEM_LITE_PATH = WORLD_DATA / 'DestinyInventoryItemLiteDefinition.json'
