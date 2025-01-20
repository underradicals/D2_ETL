drop table if exists pbi_weapon_data;

create table if not exists pbi_weapon_data
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

insert into pbi_weapon_data (id, name, display_name, tier_type, ammo_type, equipment_slot, damage_type)
select w.id, w.name, w.display_name, w.tier_type, atd.name, esd.name, dtd.name
from weapon as w
         inner join ammo_type_definition atd on w.ammo_type_id = atd.id
         inner join equipment_slot_definition esd on w.equipment_slot_id = esd.id
         inner join damage_type_definition dtd on w.damage_type_id = dtd.id;