-- DestinyDamageTypeDefinition
select json ->> 'hash'                                      as Id,
       json -> 'displayProperties' ->> 'name'               as Name,
       json -> 'displayProperties' ->> 'description'        as Description,
       COALESCE(json -> 'displayProperties' ->> 'icon', '') as Icon
from DestinyDamageTypeDefinition;


-- DestinyLoreDefinition
select json ->> 'hash'                               as Id,
       json -> 'displayProperties' ->> 'name'        as Name,
       json -> 'displayProperties' ->> 'description' as Description,
       coalesce(json ->> 'subtitle', '')             as Subtitle
from DestinyLoreDefinition;


-- DestinyStatDefinition
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


-- DestinyCollectibleDefinition
select json ->> 'hash'                               as Id,
       json -> 'displayProperties' ->> 'description' as Description,
       json -> 'displayProperties' ->> 'icon'        as Icon,
       json ->> 'sourceString'                       as SourceString
from DestinyCollectibleDefinition;


-- AmmoTypeDefinition
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

-- WeaponTypeDefinition
select distinct json ->> 'itemSubType' as Id,
                json ->> 'itemTypeDisplayName'
from DestinyInventoryItemDefinition
where json ->> 'itemType' = 3
order by Id;

-- DestinyEquipmentSlotDefinition
select distinct json ->> 'hash'                               as Id,
                json -> 'displayProperties' ->> 'name'        as Name,
                json -> 'displayProperties' ->> 'description' as Description
from DestinyEquipmentSlotDefinition;


-- WeaponItem Definition
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


-- SocketItem Definition
select json ->> 'hash'                                      as Id,
       json -> 'displayProperties' ->> 'name'               as Name,
       coalesce(json -> 'displayProperties' ->> 'icon', '') as Icon,
       coalesce(json ->> 'iconWatermark', '')               as Watermark,
       coalesce(json ->> 'screenshot', '')                  as Screenshot,
       json ->> 'flavorText'                                as FlavorText,
       json ->> 'itemTypeDisplayName'                       as DisplayName,
       json -> 'inventory' ->> 'tierTypeName'               as TierType
from DestinyInventoryItemDefinition
where json ->> 'itemType' = 19;


-- WeaponStatDefinition
with cte as (select DestinyInventoryItemDefinition.json ->> 'hash' as WeaponId,
                    value
             from DestinyInventoryItemDefinition, json_each(DestinyInventoryItemDefinition.json -> 'investmentStats')
             where DestinyInventoryItemDefinition.json ->> 'itemType' = 3)
select WeaponId, value ->> 'statTypeHash' as StatTypeIdm, value ->> 'value' as DamageValue
from cte
order by WeaponId;


-- WeaponSocketDefinition
with cte1 as (select DestinyInventoryItemDefinition.json ->> 'hash' as WeaponId, value as Value
              from DestinyInventoryItemDefinition, json_tree(DestinyInventoryItemDefinition.json ->> 'sockets')
              where DestinyInventoryItemDefinition.json ->> 'itemType' = 3
                and key = 'socketEntries')
select WeaponId,
       coalesce(
               json_each.value ->> 'reusablePlugSetHash',
               json_each.value ->> 'randomizedPlugSetHash',
               'NaN'
       )                                           as PlugsetHash,
       json_each.value ->> 'singleInitialItemHash' as SingleInitialItemHash
from cte1, json_each(cte1.Value)
order by WeaponId;

-- Plug-set Hash Definition
select distinct DestinyPlugSetDefinition.json ->> 'hash' as Id,
                json_each.value ->> 'plugItemHash'       as InventoryItemId
from DestinyPlugSetDefinition, json_each(DestinyPlugSetDefinition.json ->> 'reusablePlugItems')
order by Id;