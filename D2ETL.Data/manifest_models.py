import json
from types import new_class


class Destiny2Tables:

    def __init__(self, table_dict: dict):
        self.DestinyArtDyeChannelDefinition = table_dict["DestinyArtDyeChannelDefinition"]
        self.DestinyArtDyeReferenceDefinition = table_dict["DestinyArtDyeReferenceDefinition"]
        self.DestinyPlaceDefinition = table_dict["DestinyPlaceDefinition"]
        self.DestinyActivityDefinition = table_dict["DestinyActivityDefinition"]
        self.DestinyActivityTypeDefinition = table_dict["DestinyActivityTypeDefinition"]
        self.DestinyClassDefinition = table_dict["DestinyClassDefinition"]
        self.DestinyGenderDefinition = table_dict["DestinyGenderDefinition"]
        self.DestinyInventoryBucketDefinition = table_dict["DestinyInventoryBucketDefinition"]
        self.DestinyRaceDefinition = table_dict["DestinyRaceDefinition"]
        self.DestinyUnlockDefinition = table_dict["DestinyUnlockDefinition"]
        self.DestinyStatGroupDefinition = table_dict["DestinyStatGroupDefinition"]
        self.DestinyProgressionMappingDefinition = table_dict["DestinyProgressionMappingDefinition"]
        self.DestinyFactionDefinition = table_dict["DestinyFactionDefinition"]
        self.DestinyVendorGroupDefinition = table_dict["DestinyVendorGroupDefinition"]
        self.DestinyRewardSourceDefinition = table_dict["DestinyRewardSourceDefinition"]
        self.DestinyUnlockValueDefinition = table_dict["DestinyUnlockValueDefinition"]
        self.DestinyRewardMappingDefinition = table_dict["DestinyRewardMappingDefinition"]
        self.DestinyRewardSheetDefinition = table_dict["DestinyRewardSheetDefinition"]
        self.DestinyItemCategoryDefinition = table_dict["DestinyItemCategoryDefinition"]
        self.DestinyDamageTypeDefinition = table_dict["DestinyDamageTypeDefinition"]
        self.DestinyActivityModeDefinition = table_dict["DestinyActivityModeDefinition"]
        self.DestinyMedalTierDefinition = table_dict["DestinyMedalTierDefinition"]
        self.DestinyAchievementDefinition = table_dict["DestinyAchievementDefinition"]
        self.DestinyActivityGraphDefinition = table_dict["DestinyActivityGraphDefinition"]
        self.DestinyActivityInteractableDefinition = table_dict["DestinyActivityInteractableDefinition"]
        self.DestinyBondDefinition = table_dict["DestinyBondDefinition"]
        self.DestinyCharacterCustomizationCategoryDefinition = table_dict[
            "DestinyCharacterCustomizationCategoryDefinition"]
        self.DestinyCharacterCustomizationOptionDefinition = table_dict["DestinyCharacterCustomizationOptionDefinition"]
        self.DestinyCollectibleDefinition = table_dict["DestinyCollectibleDefinition"]
        self.DestinyDestinationDefinition = table_dict["DestinyDestinationDefinition"]
        self.DestinyEntitlementOfferDefinition = table_dict["DestinyEntitlementOfferDefinition"]
        self.DestinyEquipmentSlotDefinition = table_dict["DestinyEquipmentSlotDefinition"]
        self.DestinyEventCardDefinition = table_dict["DestinyEventCardDefinition"]
        self.DestinyFireteamFinderActivityGraphDefinition = table_dict["DestinyFireteamFinderActivityGraphDefinition"]
        self.DestinyFireteamFinderActivitySetDefinition = table_dict["DestinyFireteamFinderActivitySetDefinition"]
        self.DestinyFireteamFinderLabelDefinition = table_dict["DestinyFireteamFinderLabelDefinition"]
        self.DestinyFireteamFinderLabelGroupDefinition = table_dict["DestinyFireteamFinderLabelGroupDefinition"]
        self.DestinyFireteamFinderOptionDefinition = table_dict["DestinyFireteamFinderOptionDefinition"]
        self.DestinyFireteamFinderOptionGroupDefinition = table_dict["DestinyFireteamFinderOptionGroupDefinition"]
        self.DestinyStatDefinition = table_dict["DestinyStatDefinition"]
        self.DestinyInventoryItemDefinition = table_dict["DestinyInventoryItemDefinition"]
        self.DestinyInventoryItemLiteDefinition = table_dict["DestinyInventoryItemLiteDefinition"]
        self.DestinyItemTierTypeDefinition = table_dict["DestinyItemTierTypeDefinition"]
        self.DestinyLoadoutColorDefinition = table_dict["DestinyLoadoutColorDefinition"]
        self.DestinyLoadoutIconDefinition = table_dict["DestinyLoadoutIconDefinition"]
        self.DestinyLoadoutNameDefinition = table_dict["DestinyLoadoutNameDefinition"]
        self.DestinyLocationDefinition = table_dict["DestinyLocationDefinition"]
        self.DestinyLoreDefinition = table_dict["DestinyLoreDefinition"]
        self.DestinyMaterialRequirementSetDefinition = table_dict["DestinyMaterialRequirementSetDefinition"]
        self.DestinyMetricDefinition = table_dict["DestinyMetricDefinition"]
        self.DestinyObjectiveDefinition = table_dict["DestinyObjectiveDefinition"]
        self.DestinySandboxPerkDefinition = table_dict["DestinySandboxPerkDefinition"]
        self.DestinyPlatformBucketMappingDefinition = table_dict["DestinyPlatformBucketMappingDefinition"]
        self.DestinyPlugSetDefinition = table_dict["DestinyPlugSetDefinition"]
        self.DestinyPowerCapDefinition = table_dict["DestinyPowerCapDefinition"]
        self.DestinyPresentationNodeDefinition = table_dict["DestinyPresentationNodeDefinition"]
        self.DestinyProgressionDefinition = table_dict["DestinyProgressionDefinition"]
        self.DestinyProgressionLevelRequirementDefinition = table_dict["DestinyProgressionLevelRequirementDefinition"]
        self.DestinyRecordDefinition = table_dict["DestinyRecordDefinition"]
        self.DestinyRewardAdjusterPointerDefinition = table_dict["DestinyRewardAdjusterPointerDefinition"]
        self.DestinyRewardAdjusterProgressionMapDefinition = table_dict["DestinyRewardAdjusterProgressionMapDefinition"]
        self.DestinyRewardItemListDefinition = table_dict["DestinyRewardItemListDefinition"]
        self.DestinySackRewardItemListDefinition = table_dict["DestinySackRewardItemListDefinition"]
        self.DestinySandboxPatternDefinition = table_dict["DestinySandboxPatternDefinition"]
        self.DestinySeasonDefinition = table_dict["DestinySeasonDefinition"]
        self.DestinySeasonPassDefinition = table_dict["DestinySeasonPassDefinition"]
        self.DestinySocialCommendationDefinition = table_dict["DestinySocialCommendationDefinition"]
        self.DestinySocketCategoryDefinition = table_dict["DestinySocketCategoryDefinition"]
        self.DestinySocketTypeDefinition = table_dict["DestinySocketTypeDefinition"]
        self.DestinyTraitDefinition = table_dict["DestinyTraitDefinition"]
        self.DestinyUnlockCountMappingDefinition = table_dict["DestinyUnlockCountMappingDefinition"]
        self.DestinyUnlockEventDefinition = table_dict["DestinyUnlockEventDefinition"]
        self.DestinyUnlockExpressionMappingDefinition = table_dict["DestinyUnlockExpressionMappingDefinition"]
        self.DestinyVendorDefinition = table_dict["DestinyVendorDefinition"]
        self.DestinyMilestoneDefinition = table_dict["DestinyMilestoneDefinition"]
        self.DestinyActivityModifierDefinition = table_dict["DestinyActivityModifierDefinition"]
        self.DestinyReportReasonCategoryDefinition = table_dict["DestinyReportReasonCategoryDefinition"]
        self.DestinyArtifactDefinition = table_dict["DestinyArtifactDefinition"]
        self.DestinyBreakerTypeDefinition = table_dict["DestinyBreakerTypeDefinition"]
        self.DestinyChecklistDefinition = table_dict["DestinyChecklistDefinition"]
        self.DestinyEnergyTypeDefinition = table_dict["DestinyEnergyTypeDefinition"]
        self.DestinySocialCommendationNodeDefinition = table_dict["DestinySocialCommendationNodeDefinition"]
        self.DestinyGuardianRankDefinition = table_dict["DestinyGuardianRankDefinition"]
        self.DestinyGuardianRankConstantsDefinition = table_dict["DestinyGuardianRankConstantsDefinition"]
        self.DestinyLoadoutConstantsDefinition = table_dict["DestinyLoadoutConstantsDefinition"]
        self.DestinyFireteamFinderConstantsDefinition = table_dict["DestinyFireteamFinderConstantsDefinition"]
        self.DestinyGlobalConstantsDefinition = table_dict["DestinyGlobalConstantsDefinition"]
    
    
    def to_dict(self):
        return {
            "DestinyArtDyeChannelDefinition": self.DestinyArtDyeChannelDefinition,
            "DestinyArtDyeReferenceDefinition": self.DestinyArtDyeReferenceDefinition,
            "DestinyPlaceDefinition": self.DestinyPlaceDefinition,
            "DestinyActivityDefinition": self.DestinyActivityDefinition,
            "DestinyActivityTypeDefinition": self.DestinyActivityTypeDefinition,
            "DestinyClassDefinition": self.DestinyClassDefinition,
            "DestinyGenderDefinition": self.DestinyGenderDefinition,
            "DestinyInventoryBucketDefinition": self.DestinyInventoryBucketDefinition,
            "DestinyRaceDefinition": self.DestinyRaceDefinition,
            "DestinyUnlockDefinition": self.DestinyUnlockDefinition,
            "DestinyStatGroupDefinition": self.DestinyStatGroupDefinition,
            "DestinyProgressionMappingDefinition": self.DestinyProgressionMappingDefinition,
            "DestinyFactionDefinition": self.DestinyFactionDefinition,
            "DestinyVendorGroupDefinition": self.DestinyVendorGroupDefinition,
            "DestinyRewardSourceDefinition": self.DestinyRewardSourceDefinition,
            "DestinyUnlockValueDefinition": self.DestinyUnlockValueDefinition,
            "DestinyRewardMappingDefinition": self.DestinyRewardMappingDefinition,
            "DestinyRewardSheetDefinition": self.DestinyRewardSheetDefinition,
            "DestinyItemCategoryDefinition": self.DestinyItemCategoryDefinition,
            "DestinyDamageTypeDefinition": self.DestinyDamageTypeDefinition,
            "DestinyActivityModeDefinition": self.DestinyActivityModeDefinition,
            "DestinyMedalTierDefinition": self.DestinyMedalTierDefinition,
            "DestinyAchievementDefinition": self.DestinyAchievementDefinition,
            "DestinyActivityGraphDefinition": self.DestinyActivityGraphDefinition,
            "DestinyActivityInteractableDefinition": self.DestinyActivityInteractableDefinition,
            "DestinyBondDefinition": self.DestinyBondDefinition,
            "DestinyCharacterCustomizationCategoryDefinition": self.DestinyCharacterCustomizationCategoryDefinition,
            "DestinyCharacterCustomizationOptionDefinition": self.DestinyCharacterCustomizationOptionDefinition,
            "DestinyCollectibleDefinition": self.DestinyCollectibleDefinition,
            "DestinyDestinationDefinition": self.DestinyDestinationDefinition,
            "DestinyEntitlementOfferDefinition": self.DestinyEntitlementOfferDefinition,
            "DestinyEquipmentSlotDefinition": self.DestinyEquipmentSlotDefinition,
            "DestinyEventCardDefinition": self.DestinyEventCardDefinition,
            "DestinyFireteamFinderActivityGraphDefinition": self.DestinyFireteamFinderActivityGraphDefinition,
            "DestinyFireteamFinderActivitySetDefinition": self.DestinyFireteamFinderActivitySetDefinition,
            "DestinyFireteamFinderLabelDefinition": self.DestinyFireteamFinderLabelDefinition,
            "DestinyFireteamFinderLabelGroupDefinition": self.DestinyFireteamFinderLabelGroupDefinition,
            "DestinyFireteamFinderOptionDefinition": self.DestinyFireteamFinderOptionDefinition,
            "DestinyFireteamFinderOptionGroupDefinition": self.DestinyFireteamFinderOptionGroupDefinition,
            "DestinyStatDefinition": self.DestinyStatDefinition,
            "DestinyInventoryItemDefinition": self.DestinyInventoryItemDefinition,
            "DestinyInventoryItemLiteDefinition": self.DestinyInventoryItemLiteDefinition,
            "DestinyItemTierTypeDefinition": self.DestinyItemTierTypeDefinition,
            "DestinyLoadoutColorDefinition": self.DestinyLoadoutColorDefinition,
            "DestinyLoadoutIconDefinition": self.DestinyLoadoutIconDefinition,
            "DestinyLoadoutNameDefinition": self.DestinyLoadoutNameDefinition,
            "DestinyLocationDefinition": self.DestinyLocationDefinition,
            "DestinyLoreDefinition": self.DestinyLoreDefinition,
            "DestinyMaterialRequirementSetDefinition": self.DestinyMaterialRequirementSetDefinition,
            "DestinyMetricDefinition": self.DestinyMetricDefinition,
            "DestinyObjectiveDefinition": self.DestinyObjectiveDefinition,
            "DestinySandboxPerkDefinition": self.DestinySandboxPerkDefinition,
            "DestinyPlatformBucketMappingDefinition": self.DestinyPlatformBucketMappingDefinition,
            "DestinyPlugSetDefinition": self.DestinyPlugSetDefinition,
            "DestinyPowerCapDefinition": self.DestinyPowerCapDefinition,
            "DestinyPresentationNodeDefinition": self.DestinyPresentationNodeDefinition,
            "DestinyProgressionDefinition": self.DestinyProgressionDefinition,
            "DestinyProgressionLevelRequirementDefinition": self.DestinyProgressionLevelRequirementDefinition,
            "DestinyRecordDefinition": self.DestinyRecordDefinition,
            "DestinyRewardAdjusterPointerDefinition": self.DestinyRewardAdjusterPointerDefinition,
            "DestinyRewardAdjusterProgressionMapDefinition": self.DestinyRewardAdjusterProgressionMapDefinition,
            "DestinyRewardItemListDefinition": self.DestinyRewardItemListDefinition,
            "DestinySackRewardItemListDefinition": self.DestinySackRewardItemListDefinition,
            "DestinySandboxPatternDefinition": self.DestinySandboxPatternDefinition,
            "DestinySeasonDefinition": self.DestinySeasonDefinition,
            "DestinySeasonPassDefinition": self.DestinySeasonPassDefinition,
            "DestinySocialCommendationDefinition": self.DestinySocialCommendationDefinition,
            "DestinySocketCategoryDefinition": self.DestinySocketCategoryDefinition,
            "DestinySocketTypeDefinition": self.DestinySocketTypeDefinition,
            "DestinyTraitDefinition": self.DestinyTraitDefinition,
            "DestinyUnlockCountMappingDefinition": self.DestinyUnlockCountMappingDefinition,
            "DestinyUnlockEventDefinition": self.DestinyUnlockEventDefinition,
            "DestinyUnlockExpressionMappingDefinition": self.DestinyUnlockExpressionMappingDefinition,
            "DestinyVendorDefinition": self.DestinyVendorDefinition,
            "DestinyMilestoneDefinition": self.DestinyMilestoneDefinition,
            "DestinyActivityModifierDefinition": self.DestinyActivityModifierDefinition,
            "DestinyReportReasonCategoryDefinition": self.DestinyReportReasonCategoryDefinition,
            "DestinyArtifactDefinition": self.DestinyArtifactDefinition,
            "DestinyBreakerTypeDefinition": self.DestinyBreakerTypeDefinition,
            "DestinyChecklistDefinition": self.DestinyChecklistDefinition,
            "DestinyEnergyTypeDefinition": self.DestinyEnergyTypeDefinition,
            "DestinySocialCommendationNodeDefinition": self.DestinySocialCommendationNodeDefinition,
            "DestinyGuardianRankDefinition": self.DestinyGuardianRankDefinition,
            "DestinyGuardianRankConstantsDefinition": self.DestinyGuardianRankConstantsDefinition,
            "DestinyLoadoutConstantsDefinition": self.DestinyLoadoutConstantsDefinition,
            "DestinyFireteamFinderConstantsDefinition": self.DestinyFireteamFinderConstantsDefinition,
            "DestinyGlobalConstantsDefinition": self.DestinyGlobalConstantsDefinition,
        }

class MobileGearCDN:

    def __init__(self, mobile_gear_cdn: dict):
        self.Geometry = mobile_gear_cdn["Geometry"]
        self.Texture = mobile_gear_cdn["Texture"]
        self.PlateRegion = mobile_gear_cdn["PlateRegion"]
        self.Gear = mobile_gear_cdn["Gear"]
        self.Shader = mobile_gear_cdn["Shader"]
        
    def to_dict(self):
        return {
            "Geometry": self.Geometry,
            "Texture": self.Texture,
            "PlateRegion": self.PlateRegion,
            "Gear": self.Gear,
            "Shader": self.Shader,
        }


class MobileWorldContentPaths:

    def __init__(self, world_content_paths: dict):
        self.en = world_content_paths['en']
        self.fr = world_content_paths['fr']
        self.es = world_content_paths['es']
        self.esmx = world_content_paths['es-mx']
        self.de = world_content_paths['de']
        self.it = world_content_paths['it']
        self.ja = world_content_paths['ja']
        self.ptbr = world_content_paths['pt-br']
        self.ru = world_content_paths['ru']
        self.pl = world_content_paths['pl']
        self.ko = world_content_paths['ko']
        self.zhcht = world_content_paths['zh-cht']
        self.zhchs = world_content_paths['zh-chs']

    def to_dict(self):
        return {
            "en": self.en,
            "fr": self.fr,
            "es": self.es,
            "es-mx": self.esmx,
            "de": self.de,
            "it": self.it,
            "ja": self.ja,
            "pt-br": self.ptbr,
            "ru": self.ru,
            "pl": self.pl,
            "ko": self.ko,
            "zh-cht": self.zhcht,
            "zh-chs": self.zhchs,
        }


class JsonWorldContentPaths(MobileWorldContentPaths):
    pass


class JsonWorldComponentContentPaths:

    def __init__(self, world_component_content_paths: dict):
        self.en = Destiny2Tables(world_component_content_paths['en'])
        self.fr = Destiny2Tables(world_component_content_paths['fr'])
        self.es = Destiny2Tables(world_component_content_paths['es'])
        self.esmx = Destiny2Tables(world_component_content_paths['es-mx'])
        self.de = Destiny2Tables(world_component_content_paths['de'])
        self.it = Destiny2Tables(world_component_content_paths['it'])
        self.ja = Destiny2Tables(world_component_content_paths['ja'])
        self.ptbr = Destiny2Tables(world_component_content_paths['pt-br'])
        self.ru = Destiny2Tables(world_component_content_paths['ru'])
        self.pl = Destiny2Tables(world_component_content_paths['pl'])
        self.ko = Destiny2Tables(world_component_content_paths['ko'])
        self.zhcht = Destiny2Tables(world_component_content_paths['zh-cht'])
        self.zhchs = Destiny2Tables(world_component_content_paths['zh-chs'])
        
    def to_dict(self):
        return {
            "en": self.en.to_dict(),
            "fr": self.fr.to_dict(),
            "es": self.es.to_dict(),
            "es-mx": self.esmx.to_dict(),
            "de": self.de.to_dict(),
            "it": self.it.to_dict(),
            "ja": self.ja.to_dict(),
            "pt-br": self.ptbr.to_dict(),
            "ru": self.ru.to_dict(),
            "pl": self.pl.to_dict(),
            "ko": self.ko.to_dict(),
            "zh-cht": self.zhcht.to_dict(),
            "zh-chs": self.zhchs.to_dict(),
        }


class MobileGearAssetDatabaseItem:

    def __init__(self, mobile_gear_asset_item: dict):
        self.version = mobile_gear_asset_item["version"]
        self.path = mobile_gear_asset_item["path"]
    
    
    def to_dict(self):
        return {
            "version": self.version,
            "path": self.path,
        }


class ManifestResponse:

    def __init__(self, manifest_response: dict):
        self.version = manifest_response['version']
        self.mobile_asset_content_path = manifest_response['mobileAssetContentPath']
        self.mobile_gear_asset_data_bases = [MobileGearAssetDatabaseItem(x) for x in
                                             manifest_response['mobileGearAssetDataBases']]
        self.mobile_world_content_paths = MobileWorldContentPaths(manifest_response['mobileWorldContentPaths'])
        self.json_world_content_paths = JsonWorldContentPaths(manifest_response['jsonWorldContentPaths'])
        self.json_world_component_content_paths = JsonWorldComponentContentPaths(
            manifest_response['jsonWorldComponentContentPaths'])
        self.mobile_clan_banner_database_path = manifest_response['mobileClanBannerDatabasePath']
        self.mobile_gear_cdn = MobileGearCDN(manifest_response['mobileGearCDN'])
        self.icon_image_pyramid_info = []
    
    def to_dict(self):
        return {
            "version": self.version,
            "mobile_asset_content_path": self.mobile_asset_content_path,
            "mobile_gear_asset_data_bases": [x.to_dict() for x in self.mobile_gear_asset_data_bases],
            "mobile_world_content_paths": self.mobile_world_content_paths.to_dict(),
            "json_world_content_paths": self.json_world_content_paths.to_dict(),
            "json_world_component_content_paths": self.json_world_component_content_paths.to_dict(),
            "mobile_clan_banner_database_path": self.mobile_clan_banner_database_path,
            "mobile_gear_cdn": self.mobile_gear_cdn.to_dict(),
            "icon_image_pyramid_info": []
        }

class Manifest:

    def __init__(self, manifest_json: dict):
        self.Response = ManifestResponse(manifest_json["Response"])
        self.ErrorCode = manifest_json["ErrorCode"]
        self.ThrottleSeconds = manifest_json["ThrottleSeconds"]
        self.ErrorStatus = manifest_json["ErrorStatus"]
        self.Message = manifest_json["Message"]
        self.MessageData = manifest_json["MessageData"]
    
    def to_dict(self):
        return {
            "Response": self.Response.to_dict(),
            "ErrorCode": self.ErrorCode,
            "ThrottleSeconds": self.ThrottleSeconds,
            "ErrorStatus": self.ErrorStatus,
            "Message": self.Message,
            "MessageData": self.MessageData
        }
    
    def to_string(self):
        return json.dumps(self.to_dict(), indent=4)