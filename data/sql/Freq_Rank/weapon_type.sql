-- count frequency of a column by some measure:
-- Formula [Single select parameter]
-- select <f-col>, count(measure) from table_name group by 1;

-- How many weapons by WeaponType:
-- Counts the Frequency of each Weapon by Weapon Type
select display_name, count(name) as Frequency
from weapon
group by 1;

-- How many weapons by Tier Type
-- Counts the Frequency of each Weapon by Tier Type
select tier_type, count(name) as Frequency
from weapon
group by 1;

-- count frequency of a column when the <f-col> is a FK, and the data is in another table.

-- How many weapons by Damage Type
-- Counts the Frequency of Weapons by their Damage Type
select dtd.name, count(w.name) as Frequency
from weapon w
         inner join damage_type_definition dtd on w.damage_type_id = dtd.id
group by 1;


-- How many weapons by Damage Type Ranked by Frequency
-- Counts the Frequency of Weapons by their Damage Type and Ranks them by their Frequency from highest to lowest
select dtd.name,
       count(w.name)                             as Frequency,
       rank() over (order by count(w.name) desc) as Foo
from weapon w
         inner join damage_type_definition dtd on w.damage_type_id = dtd.id
group by 1;


-- How many weapons by Weapon Type and Tier Type
-- Counts the Frequency of each weapon by Weapon Type and Tier Type
-- There are 4 Auto Rifles which also are of Common tier type
-- There are 11 Auto Rifles which also are of Exotic tier type
select display_name, tier_type, count(name) as No_Of
from weapon
group by tier_type, display_name
order by tier_type;


-- How many weapons by Weapon Type and Damage Type
-- Counts the Frequency of each weapon by Weapon Type and Damage Type
-- There are 16 Auto Rifles which also are of Void damage type
-- There are 6 Auto Rifles which also are of Strand damage type
select display_name, dtd.name, count(w.name) as Freq
from weapon w
         inner join damage_type_definition dtd on w.damage_type_id = dtd.id
group by display_name, dtd.name
order by dtd.name desc;

-- Counts the Frequency of WeaponType and Ranks them by Weapon Type in the Column`RankByWeaponType`
-- and also Ranks them by Damage Type in Column `RankWeaponTypeByDamageType`
select display_name,
       dtd.name,
       count(w.name)                             as                    Freq,
       rank() over (order by count(w.name) desc) as                    RankByWeaponType,
       rank() over (partition by dtd.name order by count(w.name) desc) RankWeaponTypeByDamageType
from weapon w
         inner join damage_type_definition dtd on w.damage_type_id = dtd.id
group by display_name, dtd.name
order by dtd.name desc;