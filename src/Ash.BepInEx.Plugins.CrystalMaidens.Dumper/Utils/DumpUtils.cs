using System;
using System.Collections.Generic;
using System.Linq;

namespace Ash.BepInEx.Plugins.CrystalMaidens.Dumper.Utils
{
	internal static class DumpUtils
	{
		public static string Dump(AbilityDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("abilityeffects", $"[{string.Join(", ", __instance.abilityeffects.Select(x => Dump(x)))}]"),
				KeyValueString("afterCastActDelay", $"{__instance.afterCastActDelay}"),
				KeyValueString("afterCastWalkDelay", $"{__instance.afterCastWalkDelay}"),
				KeyValueString("animationCrossFade", $"{__instance.animationCrossFade}"),
				KeyValueString("animationName", $"{__instance.animationName}"),
				KeyValueString("castingTime", $"{__instance.castingTime}"),
				KeyValueString("castRadius", $"{__instance.castRadius}"),
				KeyValueString("castType", $"{__instance.castType}"),
				KeyValueString("cooldown", $"{__instance.cooldown}"),
				KeyValueString("factionType", $"{__instance.factionType}"),
				KeyValueString("hitChance", $"{__instance.hitChance}"),
				KeyValueString("impactSoundPlayListName", $"{__instance.impactSoundPlayListName}"),
				KeyValueString("includeSelfAsTarget", $"{__instance.includeSelfAsTarget}"),
				KeyValueString("maxCastRange", $"{__instance.maxCastRange}"),
				KeyValueString("minCastRange", $"{__instance.minCastRange}"),
				KeyValueString("NumberOfTicks", $"{__instance.NumberOfTicks}"),
				KeyValueString("objectDuration", $"{__instance.objectDuration}"),
				KeyValueString("objectEachTargetAffectedOnlyOnce", $"{__instance.objectEachTargetAffectedOnlyOnce}"),
				KeyValueString("objectRadius", $"{__instance.objectRadius}"),
				KeyValueString("objectStartTime", $"{__instance.objectStartTime}"),
				KeyValueString("objectStepsPerTile", $"{__instance.objectStepsPerTile}"),
				KeyValueString("objectTickInterval", $"{__instance.objectTickInterval}"),
				KeyValueString("objectType", $"{__instance.objectType}"),
				KeyValueString("onCastPrefab", $"{__instance.onCastPrefab}"),
				KeyValueString("onPrecastPrefab", $"{__instance.onPrecastPrefab}"),
				KeyValueString("projectilePrefab", $"{__instance.projectilePrefab}"),
				KeyValueString("searchType", $"{__instance.searchType}"),
				KeyValueString("shotSoundPlayListName", $"{__instance.shotSoundPlayListName}"),
				KeyValueString("startingCharge", $"{__instance.startingCharge}"),
				KeyValueString("targetType", $"{__instance.targetType}"),
			});

		public static string Dump(AbilityEffectDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("abilityid", $"{__instance.abilityid}"),
				KeyValueString("data", $"{__instance.data}"),
				KeyValueString("doeffectprefab", $"{__instance.doeffectprefab}"),
				KeyValueString("factionType", $"{__instance.factionType}"),
				KeyValueString("hitChance", $"{__instance.hitChance}"),
				KeyValueString("type", $"{__instance.type}"),
			});

		public static string Dump(AchievementDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("amount", $"{__instance.amount}"),
				KeyValueString("isTest", $"{__instance.isTest}"),
				KeyValueString("rewardtype", $"{__instance.rewardtype}"),
				KeyValueString("targetvalue", $"{__instance.targetvalue}"),
				KeyValueString("variableid", $"{__instance.variableid}"),
			});

		public static string Dump(BuildingDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("buildingid", $"{__instance.buildingid}"),
				KeyValueString("enabled", $"{__instance.enabled}"),
				KeyValueString("isTest", $"{__instance.isTest}"),
				KeyValueString("prefab", $"{__instance.prefab}"),
				KeyValueString("rewardidentifier", $"{__instance.rewardidentifier}"),
				KeyValueString("upgradeCosts", Dump(__instance.upgradeCosts)),
				KeyValueString("upgradeRequiredAccountLevels", Dump(__instance.upgradeRequiredAccountLevels)),
				KeyValueString("upgradeTimes", Dump(__instance.upgradeTimes)),
				KeyValueString("values", Dump(__instance.values)),
			});

		public static string Dump(CampaignGroupDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				$"campaigns={Dump(__instance.campaigns, item => $"{item.Key}={item.Value?.id}")}",
				KeyValueString("craftExpirationDatetime", $"{__instance.craftExpirationDatetime}"),
				KeyValueString("expirationdDatetime", $"{__instance.expirationdDatetime}"),
				KeyValueString("hasCloud", $"{__instance.hasCloud}"),
				KeyValueString("iconID", $"{__instance.iconID}"),
				KeyValueString("isTest", $"{__instance.isTest}"),
				KeyValueString("isVisible", $"{__instance.isVisible}"),
				KeyValueString("maxTriesPerDay", $"{__instance.maxTriesPerDay}"),
				KeyValueString("origin", $"{__instance.origin}"),
				KeyValueString("requiredAccountLevel", $"{__instance.requiredAccountLevel}"),
				KeyValueString("sortID", $"{__instance.sortID}"),
				KeyValueString("startDatetime", $"{__instance.startDatetime}"),
				KeyValueString("type", $"{__instance.type}"),
			});

		public static string Dump(CampaignDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("backgroundPath", $"{__instance.backgroundPath}"),
				KeyValueString("campaignGroupdbo", $"{__instance.campaignGroupdbo?.id}"),
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("isTest", $"{__instance.isTest}"),
				KeyValueString("lastMapID", $"{__instance.lastMapID}"),
				KeyValueString("lastVisibleMapID", $"{__instance.lastVisibleMapID}"),
				KeyValueString($"maps", Dump(__instance.maps, kvp => $"{kvp.Key}={kvp.Value?.id}")),
				KeyValueString("requiredCampaignID", $"{__instance.requiredCampaignID}"),
				KeyValueString("sortID", $"{__instance.sortID}"),
				KeyValueString("worldChunks", $"{__instance.worldChunks}"),
				KeyValueString("worldChunkSize", $"{__instance.worldChunkSize}"),
			});

		public static string Dump(CharacterEventDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("ID", $"{__instance.ID}"),
				KeyValueString("Conditions", $"{__instance.Conditions}"),
				KeyValueString("ContributionReward", $"{__instance.ContributionReward}"),
				KeyValueString("ContributionRewardGoal", $"{__instance.ContributionRewardGoal}"),
				KeyValueString("DailyObjectivesCount", $"{__instance.DailyObjectivesCount}"),
				KeyValueString("Enabled", $"{__instance.Enabled}"),
				KeyValueString("ExpirationDateTime", $"{__instance.ExpirationDateTime}"),
				KeyValueString("ExtraObjectivesCount", $"{__instance.ExtraObjectivesCount}"),
				KeyValueString("GlobalObjectiveID", $"{__instance.GlobalObjectiveID}"),
				KeyValueString("GlobalRewards", Dump(__instance.GlobalRewards, item => $"{item.Key}={item.Value}")),
				KeyValueString("Goal", $"{__instance.Goal}"),
				KeyValueString("HeroID", $"{__instance.HeroID}"),
				KeyValueString("IsCurrentlyActive", $"{__instance.IsCurrentlyActive}"),
				KeyValueString("isTest", $"{__instance.isTest}"),
				KeyValueString("origin", $"{__instance.origin}"),
				KeyValueString("Rewards", Dump(__instance.Rewards, item => $"{item.Key}={item.Value}")),
				KeyValueString("SpecialRewards", Dump(__instance.SpecialRewards, item => $"{item.Key}={item.Value}")),
				KeyValueString("StartDateTime", $"{__instance.StartDateTime}"),
				KeyValueString("UnlockExtraObjectivesPrice", $"{__instance.UnlockExtraObjectivesPrice}"),
			});

		public static string Dump(CharacterEventObjectiveDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("Id", $"{__instance.Id}"),
				KeyValueString("Category", $"{__instance.Category}"),
				KeyValueString("Goal", $"{__instance.Goal}"),
				KeyValueString("GoalScript", $"{__instance.GoalScript}"),
				KeyValueString("Reward", $"{__instance.Reward}"),
				KeyValueString("Type", $"{__instance.Type}"),
			});

		public static string Dump(ChunkBlockerDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("campaignID", $"{__instance.campaignID}"),
				KeyValueString("enabled", $"{__instance.enabled}"),
				KeyValueString("expirationDatetime", $"{__instance.expirationDatetime}"),
				KeyValueString("isVisible", $"{__instance.isVisible}"),
				KeyValueString("lastMapID", $"{__instance.lastMapID}"),
				KeyValueString("origin", $"{__instance.origin}"),
				KeyValueString("sortID", $"{__instance.sortID}"),
				KeyValueString("width", $"{__instance.width}"),
			});

		public static string Dump(CraftDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("campaigngroupid", $"{__instance.campaigngroupid}"),
				KeyValueString("isExclusive", $"{__instance.isExclusive}"),
				KeyValueString("isMasterRecipe", $"{__instance.isMasterRecipe}"),
				KeyValueString("requiredItemId", $"{__instance.requiredItemId}"),
				KeyValueString("requirements", $"{__instance.requirements}"),
				KeyValueString("Requirements", Dump(__instance.Requirements, x => Dump(x))),
				KeyValueString("rewardidentifier", $"{__instance.rewardidentifier}"),
				KeyValueString("successrate", $"{__instance.successrate}"),
			});

		public static string Dump(CraftRequirementInfo __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("count", $"{__instance.count}"),
				KeyValueString("craftdbo", $"{__instance.craftdbo?.id}"),
				KeyValueString("rarity", $"{__instance.rarity}"),
				KeyValueString("requirementType", $"{__instance.requirementType}"),
			});

		public static string Dump(GalleryDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("animationname", $"{__instance.animationname}"),
				KeyValueString("heroid", $"{__instance.heroid}"),
				KeyValueString("imageprefabpath", $"{__instance.imageprefabpath}"),
				KeyValueString("isTest", $"{__instance.isTest}"),
				KeyValueString("origin", $"{__instance.origin}"),
				KeyValueString("previewpath", $"{__instance.previewpath}"),
				KeyValueString("romanceindex", $"{__instance.romanceindex}"),
			});

		public static string Dump(GameConfigDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("description", $"{__instance.description}"),
				KeyValueString("key", $"{__instance.key}"),
				KeyValueString("type", $"{__instance.type}"),
				KeyValueString("val", $"{__instance.val}"),
			});

		public static string Dump(AbilityTriggerData __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("abilityId", $"{__instance.abilityId}"),
				KeyValueString("comparisonSymbol", $"{__instance.comparisonSymbol}"),
				KeyValueString("duration", $"{__instance.duration}"),
				KeyValueString("everyXHits", $"{__instance.everyXHits}"),
				KeyValueString("everyXSteps", $"{__instance.everyXSteps}"),
				KeyValueString("maxTimes", $"{__instance.maxTimes}"),
				KeyValueString("overrideTargetToAttacker", $"{__instance.overrideTargetToAttacker}"),
				KeyValueString("overrideTargetToLastTarget", $"{__instance.overrideTargetToLastTarget}"),
				KeyValueString("resetTimesOnDeath", $"{__instance.resetTimesOnDeath}"),
				KeyValueString("startStep", $"{__instance.startStep}"),
				KeyValueString("threshold", $"{__instance.threshold}"),
				KeyValueString("Threshold", $"{__instance.Threshold}"),
				KeyValueString("type", $"{__instance.type}"),
			});

		public static string Dump(AbilityPassiveData __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("condition", $"{__instance.condition}"),
				KeyValueString("IsAlwaysActive", $"{__instance.IsAlwaysActive}"),
				KeyValueString("statsAffected", $"{__instance.statsAffected}"),
			});

		public static string Dump(HeroDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("AbilityTriggers", Dump(__instance.AbilityTriggers, x => Dump(x))),
				KeyValueString("AllPassives", Dump(__instance.AllPassives, x => Dump(x))),
				KeyValueString("AlwaysActivePassives", $"{__instance.AlwaysActivePassives}"),
				KeyValueString("attackSpeed", $"{__instance.attackSpeed}"),
				KeyValueString("ConditionalPassives", Dump(__instance.ConditionalPassives, x => Dump(x))),
				KeyValueString("cooldownreducperlevel", $"{__instance.cooldownreducperlevel}"),
				KeyValueString("critical", $"{__instance.critical}"),
				KeyValueString("defense", $"{__instance.defense}"),
				KeyValueString("dmgCoefficient", $"{__instance.dmgCoefficient}"),
				KeyValueString("dodge", $"{__instance.dodge}"),
				KeyValueString("dragcooldown", $"{__instance.dragcooldown}"),
				KeyValueString("element", $"{__instance.element}"),
				KeyValueString("enabledOrigin", $"{__instance.enabledOrigin}"),
				KeyValueString("endgameondead", $"{__instance.endgameondead}"),
				KeyValueString("eventpackdroprate", $"{__instance.eventpackdroprate}"),
				KeyValueString("flirtPerRomance", $"{__instance.flirtPerRomance}"),
				KeyValueString("eventpackdroprate", $"{__instance.HeroClass}"),
				KeyValueString("heroclass", $"{__instance.heroclass}"),
				KeyValueString("HeroElement", $"{__instance.HeroElement}"),
				KeyValueString("hp", $"{__instance.hp}"),
				KeyValueString("hpCoefficient", $"{__instance.hpCoefficient}"),
				KeyValueString("hpperlevel", $"{__instance.hpperlevel}"),
				KeyValueString("iconid", $"{__instance.iconid}"),
				KeyValueString("immunities", $"{__instance.immunities}"),
				KeyValueString("IsGuardian", $"{__instance.IsGuardian}"),
				KeyValueString("isTest", $"{__instance.isTest}"),
				KeyValueString("NPCAbilities", Dump(__instance.NPCAbilities, item => $"{item.Key}={item.Value}")),
				KeyValueString("npcAbilities", $"{__instance.npcAbilities}"),
				KeyValueString("objectRadius", $"{__instance.objectRadius}"),
				KeyValueString("onrespawnprefab", $"{__instance.onrespawnprefab}"),
				KeyValueString("onspawnprefab", $"{__instance.onspawnprefab}"),
				KeyValueString("packdroprate", $"{__instance.packdroprate}"),
				KeyValueString("passives", $"{__instance.passives}"),
				KeyValueString("PCAbilities", Dump(__instance.PCAbilities, item => $"{item.Key}={item.Value}")),
				KeyValueString("pcAbilities", $"{__instance.pcAbilities}"),
				KeyValueString("Prefab", $"{__instance.Prefab}"),
				KeyValueString("promotesrequirement", Dump(__instance.promotesrequirement)),
				KeyValueString("rarity", $"{__instance.rarity}"),
				KeyValueString("Rarity", $"{__instance.Rarity}"),
				KeyValueString("respawnCooldown", $"{__instance.respawnCooldown}"),
				KeyValueString("shardsOnDuplicate", $"{__instance.shardsOnDuplicate}"),
				KeyValueString("shardsRequirements", Dump(__instance.shardsRequirements)),
				KeyValueString("skillCoefficient", $"{__instance.skillCoefficient}"),
				KeyValueString("SpawnerHeroes", Dump(__instance.SpawnerHeroes, x => Dump(x))),
				KeyValueString("SpawnerIds", Dump(__instance.SpawnerIds)),
				KeyValueString("spawnerIds", $"{__instance.spawnerIds}"),
				KeyValueString("spawnerWaveInterval", $"{__instance.spawnerWaveInterval}"),
				KeyValueString("spawnerWaveIntervalType", $"{__instance.spawnerWaveIntervalType}"),
				KeyValueString("stepspertile", $"{__instance.stepspertile}"),
				KeyValueString("triggerCoefficient", $"{__instance.triggerCoefficient}"),
				KeyValueString("triggers", $"{__instance.triggers}"),
				KeyValueString("type", $"{__instance.type}"),
				KeyValueString("visibleOrigin", $"{__instance.visibleOrigin}"),
				KeyValueString("visionDistance", $"{__instance.visionDistance}"),
			});

		public static string Dump(IconDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("isTest", $"{__instance.isTest}"),
				KeyValueString("origin", $"{__instance.origin}"),
				KeyValueString("resourcePath", $"{__instance.resourcePath}"),
				KeyValueString("visible", $"{__instance.visible}"),
			});

		public static string Dump(ItemDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("enabledOrigin", $"{__instance.enabledOrigin}"),
				KeyValueString("eventpackdroprate", $"{__instance.eventpackdroprate}"),
				KeyValueString("heroclass", $"{__instance.heroclass}"),
				KeyValueString("heroid", $"{__instance.heroid}"),
				KeyValueString("ingredientType", $"{__instance.ingredientType}"),
				KeyValueString("IsFodder", $"{__instance.IsFodder}"),
				KeyValueString("IsStackable", $"{__instance.IsStackable}"),
				KeyValueString("isTest", $"{__instance.isTest}"),
				KeyValueString("IsWearable", $"{__instance.IsWearable}"),
				KeyValueString("itemslot", $"{__instance.itemslot}"),
				KeyValueString("maxlevel", $"{__instance.maxlevel}"),
				KeyValueString("packdroprate", $"{__instance.packdroprate}"),
				KeyValueString("price", $"{__instance.price}"),
				KeyValueString("rarityStats", Dump(__instance.rarityStats, kvp => Dump(kvp.Value))),
				KeyValueString("rewardidentifier", $"{__instance.rewardidentifier}"),
				KeyValueString("spriteName", $"{__instance.spriteName}"),
				KeyValueString("statsperlevelrarity1", Dump(__instance.statsperlevelrarity1, item => $"{item.Key}={item.Value}")),
				KeyValueString("statsperlevelrarity2", Dump(__instance.statsperlevelrarity2, item => $"{item.Key}={item.Value}")),
				KeyValueString("statsperlevelrarity3", Dump(__instance.statsperlevelrarity3, item => $"{item.Key}={item.Value}")),
				KeyValueString("statsperlevelrarity4", Dump(__instance.statsperlevelrarity4, item => $"{item.Key}={item.Value}")),
				KeyValueString("statsperlevelraritysetitem", Dump(__instance.statsperlevelraritysetitem, item => $"{item.Key}={item.Value}")),
				KeyValueString("statsrarity1", Dump(__instance.statsrarity1, item => $"{item.Key}={item.Value}")),
				KeyValueString("statsrarity2", Dump(__instance.statsrarity2, item => $"{item.Key}={item.Value}")),
				KeyValueString("statsrarity3", Dump(__instance.statsrarity3, item => $"{item.Key}={item.Value}")),
				KeyValueString("statsrarity4", Dump(__instance.statsrarity4, item => $"{item.Key}={item.Value}")),
				KeyValueString("statsraritysetitem", Dump(__instance.statsraritysetitem, item => $"{item.Key}={item.Value}")),
				KeyValueString("visibleOrigin", $"{__instance.visibleOrigin}"),
			});

		public static string Dump(LootTableDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("ActualMax", $"{__instance.ActualMax}"),
				KeyValueString("ActualMin", $"{__instance.ActualMin}"),
				KeyValueString("amountMax", $"{__instance.amountMax}"),
				KeyValueString("amountMin", $"{__instance.amountMin}"),
				KeyValueString("conditionsScript", $"{__instance.conditionsScript}"),
				KeyValueString("identifier", $"{__instance.identifier}"),
				KeyValueString("individualRolls", $"{__instance.individualRolls}"),
				KeyValueString("isSpecialRoll", $"{__instance.isSpecialRoll}"),
				KeyValueString("isTest", $"{__instance.isTest}"),
				KeyValueString("origin", $"{__instance.origin}"),
				KeyValueString("rewardIdentifier", $"{__instance.rewardIdentifier}"),
				KeyValueString("weight", $"{__instance.weight}"),
			});

		public static string Dump(MapDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("Autoplayable", $"{__instance.Autoplayable}"),
				KeyValueString("campaigndbo", $"{__instance.campaigndbo?.id}"),
				KeyValueString("campaignid", $"{__instance.campaignid}"),
				KeyValueString("challengerequirements", $"{__instance.challengerequirements}"),
				KeyValueString("crystaltype", $"{__instance.crystaltype}"),
				KeyValueString("delaybetweentwoplays", $"{__instance.delaybetweentwoplays}"),
				KeyValueString("delayonunlocked", $"{__instance.delayonunlocked}"),
				KeyValueString("enemiestokill", $"{__instance.enemiestokill}"),
				KeyValueString("EnergyCost", $"{__instance.EnergyCost}"),
				KeyValueString("energycost", $"{__instance.energycost}"),
				KeyValueString("gamemode", $"{__instance.gamemode}"),
				KeyValueString("leveltype", $"{__instance.leveltype}"),
				KeyValueString("LevelType", $"{__instance.LevelType}"),
				KeyValueString("maxsteptime", $"{__instance.maxsteptime}"),
				KeyValueString("maxTier", $"{__instance.maxTier}"),
				KeyValueString("newRewards", $"{__instance.newRewards}"),
				KeyValueString("posx", $"{__instance.posx}"),
				KeyValueString("posy", $"{__instance.posy}"),
				KeyValueString("prefabid", $"{__instance.prefabid}"),
				KeyValueString("requiredMapId", $"{__instance.requiredMapId}"),
				KeyValueString("requirements", $"{__instance.requirements}"),
				KeyValueString("rewardheroexp", $"{__instance.rewardheroexp}"),
				KeyValueString("rewardidentifier", $"{__instance.rewardidentifier}"),
				KeyValueString("rewardsoftcurrency", $"{__instance.rewardsoftcurrency}"),
				KeyValueString("rewarduserexp", $"{__instance.rewarduserexp}"),
				KeyValueString("scriptTierHeroLevelCalculator", $"{__instance.scriptTierHeroLevelCalculator}"),
				KeyValueString("scriptTierSkillLevelCalculator", $"{__instance.scriptTierSkillLevelCalculator}"),
				KeyValueString("towerHeroLevelIncrement", $"{__instance.towerHeroLevelIncrement}"),
				KeyValueString("towerHeroLevelInterval", $"{__instance.towerHeroLevelInterval}"),
				KeyValueString("towerNumberOfWaves", $"{__instance.towerNumberOfWaves}"),
				KeyValueString("towerSkillLevelIncrement", $"{__instance.towerSkillLevelIncrement}"),
				KeyValueString("towerSkillLevelInterval", $"{__instance.towerSkillLevelInterval}"),
				KeyValueString("TowerSpawnBlockAtWave", Dump(__instance.TowerSpawnBlockAtWave)),
				KeyValueString("towerSpawnBlockAtWave", $"{__instance.towerSpawnBlockAtWave}"),
			});

		public static string Dump(MapInteractiveDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("aicastbehaviour", $"{__instance.aicastbehaviour}"),
				KeyValueString("behaviourType", $"{__instance.behaviourType}"),
				KeyValueString("endgameondead", $"{__instance.endgameondead}"),
				KeyValueString("heroid", $"{__instance.heroid}"),
				KeyValueString("herolevel", $"{__instance.herolevel}"),
				KeyValueString("herolevelscript", $"{__instance.herolevelscript}"),
				KeyValueString("mapid", $"{__instance.mapid}"),
				KeyValueString("movementtype", $"{__instance.movementtype}"),
				KeyValueString("promotionlevel", $"{__instance.promotionlevel}"),
				KeyValueString("q", $"{__instance.q}"),
				KeyValueString("r", $"{__instance.r}"),
				KeyValueString("skilllevel", $"{__instance.skilllevel}"),
				KeyValueString("skilllevelscript", $"{__instance.skilllevelscript}"),
				KeyValueString("spawndelay", $"{__instance.spawndelay}"),
				KeyValueString("statsBonus", $"{__instance.statsBonus}"),
				KeyValueString("team", $"{__instance.team}"),
				KeyValueString("userHeroMasteryManager", Dump(__instance.userHeroMasteryManager)),
			});

		public static string Dump(MapPathDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("mapid", $"{__instance.mapid}"),
				KeyValueString("q", $"{__instance.q}"),
				KeyValueString("r", $"{__instance.r}"),
				KeyValueString("type", $"{__instance.type}"),
			});

		public static string Dump(MapStaticDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("mapid", $"{__instance.mapid}"),
				KeyValueString("prefabname", $"{__instance.prefabname}"),
				KeyValueString("x", $"{__instance.x}"),
				KeyValueString("yrotation", $"{__instance.yrotation}"),
				KeyValueString("z", $"{__instance.z}"),
			});

		public static string Dump(MasteryDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("crystalCost", $"{__instance.crystalCost}"),
				KeyValueString("desc", $"{__instance.desc}"),
				KeyValueString("heroClass", $"{__instance.heroClass}"),
				KeyValueString("iconPath", $"{__instance.iconPath}"),
				KeyValueString("isLocked", $"{__instance.isLocked}"),
				KeyValueString("isMutuallyExclusive", $"{__instance.isMutuallyExclusive}"),
				KeyValueString("level1Passives", $"{__instance.level1Passives}"),
				KeyValueString("level1Triggers", $"{__instance.level1Triggers}"),
				KeyValueString("level2Passives", $"{__instance.level2Passives}"),
				KeyValueString("level2Triggers", $"{__instance.level2Triggers}"),
				KeyValueString("level3Passives", $"{__instance.level3Passives}"),
				KeyValueString("level3Triggers", $"{__instance.level3Triggers}"),
				KeyValueString("level4Passives", $"{__instance.level4Passives}"),
				KeyValueString("level4Triggers", $"{__instance.level4Triggers}"),
				KeyValueString("level5Passives", $"{__instance.level5Passives}"),
				KeyValueString("level5Triggers", $"{__instance.level5Triggers}"),
				KeyValueString("maxLevel", $"{__instance.maxLevel}"),
				KeyValueString("requirements", $"{__instance.requirements}"),
				KeyValueString("tier", $"{__instance.tier}"),
				KeyValueString("type", $"{__instance.type}"),
			});

		public static string Dump(MiniEventDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("endDate", $"{__instance.endDate}"),
				KeyValueString("IsActive", $"{__instance.IsActive}"),
				KeyValueString("origin", $"{__instance.origin}"),
				KeyValueString("startDate", $"{__instance.startDate}"),
				KeyValueString("type", $"{__instance.type}"),
			});

		public static string Dump(PVPDivisionDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("elorequired", $"{__instance.elorequired}"),
				KeyValueString("eloreset", $"{__instance.eloreset}"),
				KeyValueString("maxGamesLossPerDay", $"{__instance.maxGamesLossPerDay}"),
				KeyValueString("pointsAttackLoss", $"{__instance.pointsAttackLoss}"),
				KeyValueString("pointsAttackWin", $"{__instance.pointsAttackWin}"),
				KeyValueString("pointsDefenseLoss", $"{__instance.pointsDefenseLoss}"),
				KeyValueString("pointsDefenseWin", $"{__instance.pointsDefenseWin}"),
				KeyValueString("pointsWinStreakReward", $"{__instance.pointsWinStreakReward}"),
				KeyValueString("rankRequired", $"{__instance.rankRequired}"),
				KeyValueString("rewardDailyIdentifier", $"{__instance.rewardDailyIdentifier}"),
				KeyValueString("rewardDivisionUpIdentifier", $"{__instance.rewardDivisionUpIdentifier}"),
				KeyValueString("rewardidentifier", $"{__instance.rewardidentifier}"),
				KeyValueString("rewardWinAttack", $"{__instance.rewardWinAttack}"),
				KeyValueString("rewardWinDefense", $"{__instance.rewardWinDefense}"),
			});

		public static string Dump(QuestDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("crown", $"{__instance.crown}"),
				KeyValueString("isHard", $"{__instance.isHard}"),
				KeyValueString("require", $"{__instance.require}"),
			});

		public static string Dump(RandomMapStaticObjectsDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("mapPrefab", $"{__instance.mapPrefab}"),
				KeyValueString("minCount", $"{__instance.minCount}"),
				KeyValueString("staticObjectPrefab", $"{__instance.staticObjectPrefab}"),
				KeyValueString("weight", $"{__instance.weight}"),
			});

		public static string Dump(RewardDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("count", $"{__instance.count}"),
				KeyValueString("identifier", $"{__instance.identifier}"),
				KeyValueString("isTest", $"{__instance.isTest}"),
				KeyValueString("level", $"{__instance.level}"),
				KeyValueString("maxQuality", $"{__instance.maxQuality}"),
				KeyValueString("minQuality", $"{__instance.minQuality}"),
				KeyValueString("openInGacha", $"{__instance.openInGacha}"),
				KeyValueString("origin", $"{__instance.origin}"),
				KeyValueString("rarity", $"{__instance.rarity}"),
				KeyValueString("rewardid", $"{__instance.rewardid}"),
				KeyValueString("script", $"{__instance.script}"),
				KeyValueString("sortID", $"{__instance.sortID}"),
				KeyValueString("type", $"{__instance.type}"),
			});

		public static string Dump(SetItemsDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("desc", $"{__instance.desc}"),
				KeyValueString("isTest", $"{__instance.isTest}"),
				KeyValueString("itemIds", $"{__instance.itemIds}"),
				KeyValueString("origin", $"{__instance.origin}"),
				KeyValueString("setBonus1", $"{__instance.setBonus1}"),
				KeyValueString("setBonus2", $"{__instance.setBonus2}"),
				KeyValueString("setBonus3", $"{__instance.setBonus3}"),
				KeyValueString("setBonus4", $"{__instance.setBonus4}"),
				KeyValueString("setBonus5", $"{__instance.setBonus5}"),
				KeyValueString("setBonus6", $"{__instance.setBonus6}"),
			});

		public static string Dump(ShopItemDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("conditions", $"{__instance.conditions}"),
				KeyValueString("discountpercentage", $"{__instance.discountpercentage}"),
				KeyValueString("duration", $"{__instance.duration}"),
				KeyValueString("endDate", $"{__instance.endDate}"),
				KeyValueString("imageurl", $"{__instance.imageurl}"),
				KeyValueString("isPopup", $"{__instance.isPopup}"),
				KeyValueString("isTest", $"{__instance.isTest}"),
				KeyValueString("isvisible", $"{__instance.isvisible}"),
				KeyValueString("origin", $"{__instance.origin}"),
				KeyValueString("pricescript", $"{__instance.pricescript}"),
				KeyValueString("quantityAvailable", $"{__instance.quantityAvailable}"),
				KeyValueString("rewardidentifier", $"{__instance.rewardidentifier}"),
				KeyValueString("shopid", $"{__instance.shopid}"),
				KeyValueString("shopImage", $"{__instance.shopImage}"),
				KeyValueString("sortid", $"{__instance.sortid}"),
				KeyValueString("startDate", $"{__instance.startDate}"),
				KeyValueString("type", $"{__instance.type}"),
			});

		public static string Dump(StatsCapDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("desc", $"{__instance.desc}"),
				KeyValueString("hardCapMax", $"{__instance.hardCapMax}"),
				KeyValueString("hardCapMin", $"{__instance.hardCapMin}"),
				KeyValueString("softCapMax", $"{__instance.softCapMax}"),
				KeyValueString("softCapMin", $"{__instance.softCapMin}"),
				KeyValueString("stat", $"{__instance.stat}"),
			});

		public static string Dump(StoryDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("conditionsScript", $"{__instance.conditionsScript}"),
				KeyValueString("isTest", $"{__instance.isTest}"),
				KeyValueString("origin", $"{__instance.origin}"),
				KeyValueString("paymentCategory", $"{__instance.paymentCategory}"),
				KeyValueString("paymentSubCategory", $"{__instance.paymentSubCategory}"),
				KeyValueString("playAsDialog", $"{__instance.playAsDialog}"),
				KeyValueString("preview", $"{__instance.preview}"),
				KeyValueString("price", $"{__instance.price}"),
				KeyValueString("storytype", $"{__instance.storytype}"),
				KeyValueString("tags", $"{__instance.tags}"),
				KeyValueString("typetrigger", $"{__instance.typetrigger}"),
			});

		public static string Dump(StoryPageDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("bgtexturepath", $"{__instance.bgtexturepath}"),
				KeyValueString("commands", $"{__instance.commands}"),
				KeyValueString("herotexturepath", $"{__instance.herotexturepath}"),
				KeyValueString("name", $"{__instance.name}"),
				KeyValueString("playflash", $"{__instance.playflash}"),
				KeyValueString("position", $"{__instance.position}"),
				KeyValueString("sequenceid", $"{__instance.sequenceid}"),
				KeyValueString("storyid", $"{__instance.storyid}"),
				KeyValueString("textkey", $"{__instance.textkey}"),
			});

		public static string Dump(StorySpecialGroupsDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("origin", $"{__instance.origin}"),
				KeyValueString("stories", $"{__instance.stories}"),
				KeyValueString($"StoriesIDs", Dump(__instance.StoriesIDs)),
			});

		public static string Dump(VIPDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("bonuses", $"{__instance.bonuses}"),
				KeyValueString("level", $"{__instance.level}"),
				KeyValueString("viperquired", $"{__instance.viperquired}"),
			});

		public static string Dump(WorldBossEventDBObject __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("ID", $"{__instance.ID}"),
				KeyValueString("ClaimableGlobalObjectivesRewards", Dump(__instance.ClaimableGlobalObjectivesRewards)),
				KeyValueString("ExpirationDateTime", $"{__instance.ExpirationDateTime}"),
				KeyValueString("FutureEvent", $"{__instance.FutureEvent}"),
				KeyValueString("GetBossHeroes", Dump(__instance.GetBossHeroes(), value => $"{value?.id}")),
				KeyValueString("GetRankingRewards0", Dump(__instance.GetRankingRewards(0), value => $"{value}")),
				KeyValueString("GetRankingRewards1", Dump(__instance.GetRankingRewards(1), value => $"{value}")),
				KeyValueString("GetRankingRewards2", Dump(__instance.GetRankingRewards(2), value => $"{value}")),
				KeyValueString("GetRankingRewards3", Dump(__instance.GetRankingRewards(3), value => $"{value}")),
				KeyValueString("GetRankingRewards4", Dump(__instance.GetRankingRewards(4), value => $"{value}")),
				KeyValueString("GlobalObjectivesCheckpoint", $"{__instance.GlobalObjectivesCheckpoint}"),
				KeyValueString("GlobalObjectivesRewards", Dump(__instance.GlobalObjectivesRewards, item => $"{item.Key}={item.Value}")),
				KeyValueString("HeroIDs", Dump(__instance.HeroIDs, value => $"{value}")),
				KeyValueString("IsAlive", $"{__instance.IsAlive}"),
				KeyValueString("IsCurrentlyActive", $"{__instance.IsCurrentlyActive}"),
				KeyValueString("IsIncomingSoon", $"{__instance.IsIncomingSoon}"),
				KeyValueString("MapID", $"{__instance.MapID}"),
				KeyValueString("MaxHealth", $"{__instance.MaxHealth}"),
				KeyValueString("origin", $"{__instance.origin}"),
				KeyValueString("RankingRewards", Dump(__instance.RankingRewards, item => $"{item.Key}={Dump(item.Value)}")),
				KeyValueString("StartDateTime", $"{__instance.StartDateTime}"),
				KeyValueString("TierRewards", Dump(__instance.TierRewards, item => $"{item.Key}={item.Value}")),
			});

		public static string Dump(UserBuilding __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("Id", $"{__instance.Id}"),
				KeyValueString("BuildingDefinition", $"{__instance.BuildingDefinition?.id}"),
				KeyValueString("LastRewardClaimTime", $"{__instance.LastRewardClaimTime}"),
				KeyValueString("Level", $"{__instance.Level}"),
				KeyValueString("ReadyTime", $"{__instance.ReadyTime}"),
				KeyValueString("StartTime", $"{__instance.StartTime}"),
			});

		public static string Dump(UserCharacterEvent __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("characterEventdboID", $"{__instance.characterEventdboID}"),
				KeyValueString("contribution", $"{__instance.contribution}"),
				KeyValueString("contributionRewardClaimed", $"{__instance.contributionRewardClaimed}"),
				KeyValueString("currentObjectiveGoal", $"{__instance.currentObjectiveGoal}"),
				KeyValueString("currentObjectiveID", $"{__instance.currentObjectiveID}"),
				KeyValueString("currentObjectiveIndex", $"{__instance.currentObjectiveIndex}"),
				KeyValueString("currentObjectiveProgression", $"{__instance.currentObjectiveProgression}"),
				KeyValueString("extraDailyObjectivesPurchased", $"{__instance.extraDailyObjectivesPurchased}"),
				KeyValueString("extraDailyObjectivesPurchasedTime", $"{__instance.extraDailyObjectivesPurchasedTime}"),
				KeyValueString("globalRewardsClaimedPositions", Dump(__instance.globalRewardsClaimedPositions)),
				KeyValueString("lastTimeDailyObjectiveRefresh", $"{__instance.lastTimeDailyObjectiveRefresh}"),
				KeyValueString("nbBypassPurchased", $"{__instance.nbBypassPurchased}"),
				KeyValueString("nextObjectiveRefreshDateTicks", $"{__instance.nextObjectiveRefreshDateTicks}"),
				KeyValueString("numberOfDailyObjectives", $"{__instance.numberOfDailyObjectives}"),
				KeyValueString("numberOfDailyObjectivesExtra", $"{__instance.numberOfDailyObjectivesExtra}"),
				KeyValueString("rewardsClaimedPositions", Dump(__instance.rewardsClaimedPositions)),
				KeyValueString("specialRewardsClaimedPositions", Dump(__instance.specialRewardsClaimedPositions)),
				KeyValueString("specialRewardsUnlocked", $"{__instance.specialRewardsUnlocked}"),
				KeyValueString("totalProgression", $"{__instance.totalProgression}"),
				KeyValueString("userID", $"{__instance.userID}"),
			});

		public static string Dump(UserHero __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("DefenseRating", $"{__instance.DefenseRating}"),
				KeyValueString("endlessTowerHealth", $"{__instance.endlessTowerHealth}"),
				KeyValueString("endlessTowerRoundCount", $"{__instance.endlessTowerRoundCount}"),
				KeyValueString("Experience", $"{__instance.Experience}"),
				KeyValueString("experienceGained", $"{__instance.experienceGained}"),
				KeyValueString("FlirtLevel", $"{__instance.FlirtLevel}"),
				KeyValueString("freeMasteryRespecs", $"{__instance.freeMasteryRespecs}"),
				KeyValueString("PVPRefreshPrice", $"{__instance.GetPVPRefreshPrice()}"),
				KeyValueString("RequiredLevelToUpgradeSkill", $"{__instance.GetRequiredLevelToUpgradeSkill()}"),
				KeyValueString("IsExhausted", $"{__instance.IsExhausted}"),
				KeyValueString("isFavorite", $"{__instance.isFavorite}"),
				KeyValueString("IsTired", $"{__instance.IsTired}"),
				KeyValueString("Level", $"{__instance.Level}"),
				KeyValueString("MasteryPointAvailable", $"{__instance.MasteryPointAvailable}"),
				KeyValueString("MasteryPointSpent", $"{__instance.MasteryPointSpent}"),
				KeyValueString("nextStaminaPoint", $"{__instance.nextStaminaPoint}"),
				KeyValueString("OffenseRating", $"{__instance.OffenseRating}"),
				KeyValueString("PowerRating", $"{__instance.PowerRating}"),
				KeyValueString("refreshedTimes", $"{__instance.refreshedTimes}"),
				KeyValueString("RomanceLevel", $"{__instance.RomanceLevel}"),
				KeyValueString("selectedItemPreset", $"{__instance.selectedItemPreset}"),
				KeyValueString("selectedMaidenImage", $"{__instance.selectedMaidenImage}"),
				KeyValueString("shardExperience", $"{__instance.shardExperience}"),
				KeyValueString("SkillExperience", $"{__instance.SkillExperience}"),
				KeyValueString("SkillLevel", $"{__instance.SkillLevel}"),
				KeyValueString("SkillRating", $"{__instance.SkillRating}"),
				KeyValueString("staminaPoints", $"{__instance.staminaPoints}"),
				KeyValueString("Status", $"{__instance.Status}"),
				KeyValueString("TotalMasteryPoints", $"{__instance.TotalMasteryPoints}"),
			});

		public static string Dump(UserItem __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("count", $"{__instance.count}"),
				KeyValueString("equipped", $"{__instance.equipped}"),
				KeyValueString("experience", $"{__instance.experience}"),
				KeyValueString("itemdbo", $"{__instance.itemdbo?.id}"),
				KeyValueString("level", $"{__instance.level}"),
				KeyValueString("locked", $"{__instance.locked}"),
				KeyValueString("qualities", Dump(__instance.qualities)),
				KeyValueString("Rarity", $"{__instance.Rarity}"),
				KeyValueString("rarity", $"{__instance.rarity}"),
				KeyValueString("selected", $"{__instance.selected}"),
			});

		public static string Dump(UserMap __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("ChallengeCompleted", $"{__instance.ChallengeCompleted}"),
				KeyValueString("chunkblockerrewardearned", $"{__instance.chunkblockerrewardearned}"),
				KeyValueString("highestTierCompleted", $"{__instance.highestTierCompleted}"),
				KeyValueString("lastcompletedtime", $"{__instance.lastcompletedtime}"),
				KeyValueString("losecount", $"{__instance.losecount}"),
				KeyValueString("mapdbo", $"{__instance.mapdbo?.id}"),
				KeyValueString("MaxTierAvailable", $"{__instance.MaxTierAvailable}"),
				KeyValueString("nextUnlock", $"{__instance.nextUnlock}"),
				KeyValueString("previousStar", $"{__instance.previousStar}"),
				KeyValueString("stars", $"{__instance.stars}"),
				KeyValueString("topscore", $"{__instance.topscore}"),
				KeyValueString("wincount", $"{__instance.wincount}"),
			});

		public static string Dump(UserObjective __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("CharacterEventObjectiveDBO", $"{__instance.CharacterEventObjectiveDBO?.Id}"),
				KeyValueString("claimed", $"{__instance.claimed}"),
				KeyValueString("Completed", $"{__instance.Completed}"),
				KeyValueString("objectiveId", $"{__instance.objectiveId}"),
				KeyValueString("progress", $"{__instance.progress}"),
				KeyValueString("userId", $"{__instance.userId}"),
			});

		public static string Dump(UserShopItem __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("CanPurchase", $"{__instance.CanPurchase}"),
				KeyValueString("data", Dump(__instance.data)),
				KeyValueString("finishtime", $"{__instance.finishtime}"),
				KeyValueString("firstPurchase", $"{__instance.firstPurchase}"),
				KeyValueString("GetTimeLeft", $"{__instance.GetTimeLeft()}"),
				KeyValueString("ispurchased", $"{__instance.ispurchased}"),
				KeyValueString("purchaseCounter", $"{__instance.purchaseCounter}"),
				KeyValueString("shopItemdbo", $"{__instance.shopItemdbo?.id}"),
			});

		public static string Dump(UserShopItem.CustomData __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("alreadyShown", $"{__instance.alreadyShown}"),
				KeyValueString("MappedRewards", Dump(__instance.MappedRewards, value => Dump(value))),
				KeyValueString("Price", $"{__instance.Price}"),
			});

		public static string Dump(UserShopItem.CustomData.MappedReward __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("rewardId", $"{__instance.rewardId}"),
				KeyValueString("type", $"{__instance.type}"),
				KeyValueString("valueId", $"{__instance.valueId}"),
			});

		public static string Dump(UserStory __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("favorite", $"{__instance.favorite}"),
			});

		public static string Dump(UserWorldBoss __instance)
			=> __instance is null ? "(null)" : string.Join(Plugin.DumpItemSeparator.Value, new string[] {
				KeyValueString("id", $"{__instance.id}"),
				KeyValueString("claimedRewards", $"{__instance.claimedRewards}"),
				KeyValueString("damageDealt", $"{__instance.damageDealt}"),
				KeyValueString("highestDamage", $"{__instance.highestDamage}"),
				KeyValueString("highestRank", $"{__instance.highestRank}"),
				KeyValueString("highestTotalDamage", $"{__instance.highestTotalDamage}"),
				KeyValueString("iconid", $"{__instance.iconid}"),
				KeyValueString("team", $"{__instance.team}"),
				KeyValueString("userid", $"{__instance.userid}"),
				KeyValueString("username", $"{__instance.username}"),
				KeyValueString("worldBossid", $"{__instance.worldBossid}"),
			});

		public static string Dump<T>(IEnumerable<T> collection)
			=> collection is null
				? "(null)"
				: string.Join(",", collection);

		public static string Dump<T>(IEnumerable<T> collection, Func<T, string> selector)
			=> collection is null
				? "(null)"
				: $"[{string.Join(",", collection.Select(x => selector(x)))}]";

		private static string KeyValueString(string key, string value)
			=> $"{key}{Plugin.DumpKeyValueSeparator.Value}{value}";
	}
}
