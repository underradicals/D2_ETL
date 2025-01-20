-- Get Stats for Weapon with id=231031173
select wsd.weapon_id, sd.name, sd.description, sd.category
from weapon_stat_definition wsd
         inner join stat_definition sd on wsd.stat_id = sd.id
where wsd.weapon_id = 42351395
  and sd.category = 'Weapon';


-- Get Sockets for Weapon
select wsd.weapon_id, psd.inventory_item_id, ss.name, ss.display_name
from weapon_socket_definition wsd
         inner join plug_set_definition psd
                    on wsd.socket_id = psd.plug_set_id
         inner join socket ss on ss.id = psd.inventory_item_id
where wsd.weapon_id = 42351395
  and (ss.display_name != 'Shader' and ss.display_name != '');