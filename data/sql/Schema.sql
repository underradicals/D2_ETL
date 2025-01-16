drop table if exists collectible_definition;
drop table if exists stat_definition;
drop table if exists weapon_socket_definition;
drop table if exists weapon_stat_definition;
drop table if exists socket;
drop table if exists weapon;
drop table if exists ammo_type_definition;
drop table if exists damage_type_definition;
drop table if exists equipment_slot_definition;
drop table if exists lore_type_definition;
drop table if exists weapon_type_definition;

create table if not exists damage_type_definition
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



create table if not exists lore_type_definition
(
    id          integer not null,
    name        text    not null,
    description text    not null,
    subtitle    text    not null,
    constraint lore_type_definition_pk primary key (id)
);

create table if not exists stat_definition
(
    id          integer not null,
    name        text    not null,
    description text    not null,
    category    text    not null,
    constraint stat_definition_pk primary key (id)
);

create table if not exists collectible_definition
(
    id            integer not null,
    name          text    not null,
    source_string text    not null,
    constraint collectible_definition_pk primary key (id)
);

create table if not exists ammo_type_definition
(
    id          integer not null,
    name        text    not null,
    description text    not null,
    constraint ammo_type_definition_pk primary key (id)

);

create table if not exists weapon_type_definition
(
    id   integer not null,
    name text    not null,
    constraint weapon_type_definition_pk primary key (id)
);

create table if not exists equipment_slot_definition
(
    id          integer not null,
    name        text    not null,
    description text    not null,
    constraint equipment_slot_definition_pk primary key (id)
);

create table if not exists weapon
(
    id                integer not null,
    name              text    not null,
    description       text    not null,
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

create table if not exists socket
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

create table if not exists weapon_stat_definition
(
    weapon_id integer not null,
    stat_id   integer not null,
    value     integer not null,
    constraint weapon_stat_definition_weapon_id_fk foreign key (weapon_id) references weapon (id),
    constraint weapon_stat_definition_stat_id_fk foreign key (stat_id) references socket (id),
    constraint weapon_stat_definition_pk primary key (weapon_id, stat_id)
);

create table if not exists weapon_socket_definition
(
    weapon_id    integer not null,
    socket_id    integer not null,
    curated_roll integer not null,
    constraint weapon_socket_definition_weapon_id_fk foreign key (weapon_id) references weapon (id),
    constraint weapon_socket_definition_socket_id_fk foreign key (socket_id) references socket (id),
    constraint weapon_socket_definition_pk primary key (weapon_id, socket_id)
);