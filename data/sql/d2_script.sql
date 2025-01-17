attach database 'd2.db' as target;

-- Drop Tables
drop table if exists collectible_definition;
drop table if exists stat_definition;
drop table if exists weapon_socket_definition;
drop table if exists weapon_stat_definition;
drop table if exists plug_set_definition;
drop table if exists socket;
drop table if exists weapon;
drop table if exists ammo_type_definition;
drop table if exists damage_type_definition;
drop table if exists equipment_slot_definition;
drop table if exists lore_type_definition;
drop table if exists weapon_type_definition;
drop table if exists season_definition;
drop table if exists pbi_weapon_data;


-- Season Defs
create table if not exists target.season_definition
(
    id            integer not null,
    name          text    not null,
    description   text    not null,
    icon          text    not null,
    season_number integer not null,
    start_date    text    not null,
    end_date      text    not null,
    constraint season_definition_pk primary key (id)
);
create index target.season_definition_name_idx on season_definition (name);
create index target.season_definition_season_number_idx on season_definition (season_number);
create index target.season_definition_start_date_idx on season_definition (start_date);
create index target.season_definition_end_date_idx on season_definition (end_date);


insert into target.season_definition (id, name, description, icon, season_number, start_date, end_date)
select json -> 'hash'                                              as Id,
       json -> 'displayProperties' ->> 'name'                      as Name,
       coalesce(json -> 'displayProperties' ->> 'description', '') as Description,
       coalesce(json -> 'displayProperties' ->> 'icon', '')        as Icon,
       json ->> 'seasonNumber'                                     as SeasonNumber,
       coalesce(json ->> 'startDate', '')                          as StartDate,
       coalesce(json ->> 'endDate', '')                            as EndDate
from DestinySeasonDefinition
order by SeasonNumber;


-- Damage Type Defs
create table if not exists target.damage_type_definition
(
    id          integer not null,
    name        text    not null,
    description text    not null,
    icon        text    null default '',
    red         integer not null,
    green       integer not null,
    blue        integer not null,
    alpha       integer not null,
    constraint damage_type_definition_pk primary key (id)
);
create index target.damage_type_definition_name_idx on damage_type_definition (name);

insert into target.damage_type_definition (id, name, description, icon, red, green, blue, alpha)
select json ->> 'hash'                                      as Id,
       json -> 'displayProperties' ->> 'name'               as Name,
       json -> 'displayProperties' ->> 'description'        as Description,
       COALESCE(json -> 'displayProperties' ->> 'icon', '') as Icon,
       COALESCE(json -> 'color' ->> 'red', 255)             as Red,
       COALESCE(json -> 'color' ->> 'green', 255)           as Green,
       COALESCE(json -> 'color' ->> 'blue', 255)            as Blue,
       COALESCE(json -> 'color' ->> 'alpha', 0)             as Alpha
from DestinyDamageTypeDefinition;

-- Lore Type Defs
------------------------------------------------------------------------------------------------------------------------
create table if not exists target.lore_type_definition
(
    id          integer not null,
    name        text    not null,
    description text    not null,
    subtitle    text    not null,
    constraint lore_type_definition_pk primary key (id)
);
create index target.lore_type_definition_name_idx on lore_type_definition (name);

insert into target.lore_type_definition (id, name, description, subtitle)
select json ->> 'hash'                               as Id,
       json -> 'displayProperties' ->> 'name'        as Name,
       json -> 'displayProperties' ->> 'description' as Description,
       coalesce(json ->> 'subtitle', '')             as Subtitle
from DestinyLoreDefinition;


-- Stat Definition
create table if not exists target.stat_definition
(
    id          integer not null,
    name        text    not null,
    description text    not null,
    category    text    not null,
    constraint stat_definition_pk primary key (id)
);
create index target.stat_definition_name_idx on stat_definition (name);
create index target.stat_definition_category_idx on stat_definition (category);

insert into target.stat_definition (id, name, description, category)
select json ->> 'hash'                               as Id,
       json -> 'displayProperties' ->> 'name'        as Name,
       json -> 'displayProperties' ->> 'description' as Description,
       case json ->> 'statCategory'
           when 0 then 'Gameplay'
           when 1 then 'Weapon'
           when 2 then 'Defense'
           when 3 then 'Primary'
           end                                          StatCategory
from DestinyStatDefinition;


-- Collectible Defs
create table if not exists target.collectible_definition
(
    id            integer not null,
    name          text    not null,
    icon          text    not null,
    source_string text    not null,
    constraint collectible_definition_pk primary key (id)
);
create index target.collectible_definition_name_idx on collectible_definition (name);

insert into target.collectible_definition (id, name, icon, source_string)
select json ->> 'hash'                                      as Id,
       json -> 'displayProperties' ->> 'name'               as Name,
       coalesce(json -> 'displayProperties' ->> 'icon', '') as Icon,
       json ->> 'sourceString'                              as SourceString
from DestinyCollectibleDefinition;


-- Ammo Type Defs
create table if not exists target.ammo_type_definition
(
    id          integer not null,
    name        text    not null,
    description text    not null,
    icon        text    not null,
    constraint ammo_type_definition_pk primary key (id)
);
create index target.ammo_type_definition_name_idx on ammo_type_definition (name);

insert into target.ammo_type_definition (id, name, description, icon)
select distinct json -> 'equippingBlock' ->> 'ammoType' as Id,
                case json -> 'equippingBlock' ->> 'ammoType'
                    when 1 then 'Primary'
                    when 2 then 'Special'
                    when 3 then 'Heavy'
                    end                                 as Name,
                case json -> 'equippingBlock' ->> 'ammoType'
                    when 1 then 'Weapons that consume white ammo.'
                    when 2 then 'Weapons that consume green ammo.'
                    when 3 then 'Weapons that consume purple ammo.'
                    end                                 as Description,
                case json -> 'equippingBlock' ->> 'ammoType'
                    when 1 then '/common/destiny2_content/icons/99f3733354862047493d8550e46a45ec.png'
                    when 2 then '/common/destiny2_content/icons/d920203c4fd4571ae7f39eb5249eaecb.png'
                    when 3 then '/common/destiny2_content/icons/78ef0e2b281de7b60c48920223e0f9b1.png'
                    end                                 as Icon
from DestinyInventoryItemDefinition
where Description is not null
order by Id;


-- Weapon Type Defs
create table if not exists target.weapon_type_definition
(
    id   integer not null,
    name text    not null,
    constraint weapon_type_definition_pk primary key (id)
);
create index target.weapon_type_definition_name_idx on weapon_type_definition (name);


insert into target.weapon_type_definition (id, name)
select distinct json ->> 'itemSubType' as Id,
                json ->> 'itemTypeDisplayName'
from DestinyInventoryItemDefinition
where json ->> 'itemType' = 3
order by Id;

-- Equipment Slot Defs
create table if not exists target.equipment_slot_definition
(
    id          integer not null,
    name        text    not null,
    description text    not null,
    constraint equipment_slot_definition_pk primary key (id)
);
create index target.equipment_slot_definition_name_idx on equipment_slot_definition (name);

insert into target.equipment_slot_definition (id, name, description)
select distinct json ->> 'hash'                               as Id,
                json -> 'displayProperties' ->> 'name'        as Name,
                json -> 'displayProperties' ->> 'description' as Description
from DestinyEquipmentSlotDefinition;


-- Weapon Defs
create table if not exists target.weapon
(
    id                integer not null,
    name              text    not null,
    icon              text    null default '',
    watermark         text    not null,
    screenshot        text    not null,
    flavor_text       text    not null,
    display_name      text    not null,
    tier_type         integer not null,
    ammo_type_id      integer not null,
    equipment_slot_id integer not null,
    lore_id           integer not null,
    damage_type_id    integer not null,
    constraint weapon_ammo_type_fk foreign key (ammo_type_id) references ammo_type_definition (id),
    constraint weapon_equipment_slot_id_fk foreign key (equipment_slot_id) references equipment_slot_definition (id),
    constraint weapon_lore_id_fk foreign key (lore_id) references lore_type_definition (id),
    constraint weapon_damage_type_id foreign key (damage_type_id) references damage_type_definition (id),
    constraint weapon_pk primary key (id)
);
create index target.weapon_name_idx on weapon (name);
create index target.weapon_display_name_idx on weapon (display_name);
create index target.weapon_tier_type_idx on weapon (tier_type);

insert into target.weapon (id, name, icon, watermark, screenshot, flavor_text, display_name, tier_type, ammo_type_id,
                           equipment_slot_id, lore_id, damage_type_id)
select json ->> 'hash'                                      as Id,
       json -> 'displayProperties' ->> 'name'               as Name,
       coalesce(json -> 'displayProperties' ->> 'icon', '') as Icon,
       coalesce(json ->> 'iconWatermark', '')               as Watermark,
       coalesce(json ->> 'screenshot', '')                  as Screenshot,
       json ->> 'flavorText'                                as FlavorText,
       json ->> 'itemTypeDisplayName'                       as DisplayName,
       json -> 'inventory' ->> 'tierTypeName'               as TierType,
       json -> 'equippingBlock' ->> 'ammoType'              as AmmoType,
       json -> 'equippingBlock' ->> 'equipmentSlotTypeHash' as EquipmentSlot,
       coalesce(json ->> 'loreHash', 0)                     as LoreHash,
       json ->> 'defaultDamageTypeHash'                     as DamageTypeHash
from DestinyInventoryItemDefinition
where json ->> 'itemType' = 3;

create table if not exists target.socket
(
    id           integer not null,
    name         text    not null,
    description  text    not null,
    icon         text    null default '',
    flavor_text  text    not null,
    display_name text    not null,
    tier_type    integer not null,
    constraint weapon_pk primary key (id)
);
create index target.socket_name_idx on socket (name);
create index target.socket_display_name_idx on socket (display_name);
create index target.socket_tier_type_idx on socket (tier_type);

insert into target.socket (id, name, description, icon, flavor_text, display_name, tier_type)
select json ->> 'hash'                                          as Id,
       json -> 'displayProperties' ->> 'name'                   as Name,
       json -> 'displayProperties' ->> 'description'            as Description,
       coalesce(json -> 'displayProperties' ->> 'icon', '')     as Icon,
       json ->> 'flavorText'                                    as FlavorText,
       json ->> 'itemTypeDisplayName'                           as DisplayName,
       coalesce(json -> 'inventory' ->> 'tierTypeName', 'None') as TierType
from DestinyInventoryItemDefinition
where json ->> 'itemType' = 19;


-- Weapon Stat Defs
create table if not exists target.weapon_stat_definition
(
    weapon_id integer not null,
    stat_id   integer not null,
    value     integer not null,
    constraint weapon_stat_definition_weapon_id_fk foreign key (weapon_id) references weapon (id),
    constraint weapon_stat_definition_stat_id_fk foreign key (stat_id) references socket (id),
    constraint weapon_stat_definition_pk primary key (weapon_id, stat_id)
);
create index target.weapon_stat_definition_value_idx on weapon_stat_definition (value);

insert into target.weapon_stat_definition (weapon_id, stat_id, value)
with cte as (select DestinyInventoryItemDefinition.json ->> 'hash' as WeaponId,
                    value
             from DestinyInventoryItemDefinition, json_each(DestinyInventoryItemDefinition.json -> 'investmentStats')
             where DestinyInventoryItemDefinition.json ->> 'itemType' = 3)
select WeaponId, value ->> 'statTypeHash' as StatTypeIdm, value ->> 'value' as DamageValue
from cte
order by WeaponId;


-- WeaponPlugSet Hash Defs
create table if not exists target.weapon_socket_definition
(
    weapon_id    integer not null,
    socket_id    integer not null,
    curated_roll integer not null,
    constraint weapon_socket_definition_weapon_id_fk foreign key (weapon_id) references weapon (id),
    constraint weapon_socket_definition_socket_id_fk foreign key (socket_id) references socket (id),
    constraint weapon_socket_definition_pk primary key (weapon_id, socket_id)
);
create index target.weapon_socket_definition_curated_roll_idx on weapon_socket_definition (curated_roll);


insert into target.weapon_socket_definition (weapon_id, socket_id, curated_roll)
with cte1 as (select distinct DestinyInventoryItemDefinition.json ->> 'hash' as WeaponId, value as Value
              from DestinyInventoryItemDefinition, json_tree(DestinyInventoryItemDefinition.json ->> 'sockets')
              where DestinyInventoryItemDefinition.json ->> 'itemType' = 3
                and key = 'socketEntries')
select WeaponId,
       coalesce(
               json_each.value ->> 'reusablePlugSetHash',
               json_each.value ->> 'randomizedPlugSetHash',
               ''
       )                                           as PlugsetHash,
       json_each.value ->> 'singleInitialItemHash' as SingleInitialItemHash
from cte1, json_each(cte1.Value)
where PlugsetHash != ''
order by WeaponId;


-- Plug Set Defs
create table if not exists target.plug_set_definition
(
    plug_set_id       integer not null,
    inventory_item_id integer not null,
    constraint plug_set_definition_pk primary key (plug_set_id, inventory_item_id)
);


insert into target.plug_set_definition (plug_set_id, inventory_item_id)
select distinct DestinyPlugSetDefinition.json ->> 'hash' as Id,
                json_each.value ->> 'plugItemHash'       as InventoryItemId
from DestinyPlugSetDefinition, json_each(DestinyPlugSetDefinition.json ->> 'reusablePlugItems')
order by Id;


-- Update Season Definition
update target.season_definition
set name       = 'The Red War',
    start_date = '2017-09-06T17:00:00Z',
    end_date   = '2017-12-05T17:00:00Z'
where id = 965757574;


-- Curse of Osiris
update target.season_definition
set start_date = '2017-12-05T17:00:00Z',
    end_date   = '2018-05-08T17:00:00Z'
where id = 2973407602;

-- Warmind
update target.season_definition
set name       = 'Resurgence (Warmind)',
    start_date = '2018-05-08T17:00:00Z',
    end_date   = '2018-09-04T17:00:00Z'
where id = 4033618594;


-- Season of the Outlaw
update target.season_definition
set start_date = '2018-09-04T17:00:00Z',
    end_date   = '2018-12-04T17:00:00Z'
where id = 2026773320;


-- Season of the Forge
update target.season_definition
set start_date = '2018-12-04T17:00:00Z',
    end_date   = '2019-03-05T17:00:00Z'
where id = 2236269318;


-- Season of the Drifter
update target.season_definition
set start_date = '2019-03-05T17:00:00Z',
    end_date   = '2019-06-04T17:00:00Z'
where id = 2891088360;


-- Season of Opulence
update target.season_definition
set start_date = '2019-06-04T17:00:00Z',
    end_date   = '2019-09-30T17:00:00Z'
where id = 4275747712;


-- Test PowerBI Table
create table if not exists target.pbi_weapon_data
(
    id             integer not null,
    name           text    not null,
    display_name   text    not null,
    tier_type      text    not null,
    ammo_type      text    not null,
    equipment_slot text    not null,
    damage_type    text    not null,
    constraint pbi_weapon_data_pk primary key (id)
);
create index target.pbi_weapon_data_name_idx on pbi_weapon_data (name);
create index target.pbi_weapon_data_display_name_idx on pbi_weapon_data (display_name);
create index target.pbi_weapon_data_tier_type_idx on pbi_weapon_data (tier_type);
create index target.pbi_weapon_data_ammo_type_idx on pbi_weapon_data (ammo_type);
create index target.pbi_weapon_data_equipment_slot_idx on pbi_weapon_data (equipment_slot);
create index target.pbi_weapon_data_damage_type_idx on pbi_weapon_data (damage_type);


insert into target.pbi_weapon_data (id, name, display_name, tier_type, ammo_type, equipment_slot, damage_type)
select distinct w.id, w.name, w.display_name, w.tier_type, atd.name, esd.name, dtd.name
from weapon as w
         inner join ammo_type_definition atd on w.ammo_type_id = atd.id
         inner join equipment_slot_definition esd on w.equipment_slot_id = esd.id
         inner join damage_type_definition dtd on w.damage_type_id = dtd.id;


detach target;