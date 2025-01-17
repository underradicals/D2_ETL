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

create index damage_type_definition_name_idx on damage_type_definition (name);


create table if not exists lore_type_definition
(
    id          integer not null,
    name        text    not null,
    description text    not null,
    subtitle    text    not null,
    constraint lore_type_definition_pk primary key (id)
);
create index lore_type_definition_name_idx on lore_type_definition (name);



create table if not exists stat_definition
(
    id          integer not null,
    name        text    not null,
    description text    not null,
    category    text    not null,
    constraint stat_definition_pk primary key (id)
);
create index stat_definition_name_idx on stat_definition (name);
create index stat_definition_category_idx on stat_definition (category);


create table if not exists collectible_definition
(
    id            integer not null,
    name          text    not null,
    source_string text    not null,
    constraint collectible_definition_pk primary key (id)
);
create index collectible_definition_name_idx on collectible_definition (name);



create table if not exists ammo_type_definition
(
    id          integer not null,
    name        text    not null,
    description text    not null,
    constraint ammo_type_definition_pk primary key (id)
);
create index ammo_type_definition_name_idx on ammo_type_definition (name);


create table if not exists weapon_type_definition
(
    id   integer not null,
    name text    not null,
    constraint weapon_type_definition_pk primary key (id)
);
create index weapon_type_definition_name_idx on weapon_type_definition (name);



create table if not exists equipment_slot_definition
(
    id          integer not null,
    name        text    not null,
    description text    not null,
    constraint equipment_slot_definition_pk primary key (id)
);
create index equipment_slot_definition_name_idx on equipment_slot_definition (name);


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
create index weapon_name_idx on weapon (name);
create index weapon_display_name_idx on weapon (display_name);
create index weapon_tier_type_idx on weapon (tier_type);


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
create index socket_name_idx on socket (name);
create index socket_display_name_idx on socket (display_name);
create index socket_tier_type_idx on socket (tier_type);


create table if not exists weapon_stat_definition
(
    weapon_id integer not null,
    stat_id   integer not null,
    value     integer not null,
    constraint weapon_stat_definition_weapon_id_fk foreign key (weapon_id) references weapon (id),
    constraint weapon_stat_definition_stat_id_fk foreign key (stat_id) references socket (id),
    constraint weapon_stat_definition_pk primary key (weapon_id, stat_id)
);
create index weapon_stat_definition_value_idx on weapon_stat_definition (value);


create table if not exists weapon_socket_definition
(
    weapon_id    integer not null,
    socket_id    integer not null,
    curated_roll integer not null,
    constraint weapon_socket_definition_weapon_id_fk foreign key (weapon_id) references weapon (id),
    constraint weapon_socket_definition_socket_id_fk foreign key (socket_id) references socket (id),
    constraint weapon_socket_definition_pk primary key (weapon_id, socket_id)
);
create index weapon_socket_definition_curated_roll_idx on weapon_socket_definition (curated_roll);


create table if not exists plug_set_definition
(
    plug_set_id       integer not null,
    inventory_item_id integer not null,
    constraint plug_set_definition_pk primary key (plug_set_id, inventory_item_id)
)
