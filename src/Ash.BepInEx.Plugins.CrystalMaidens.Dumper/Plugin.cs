using Ash.BepInEx.Plugins.CrystalMaidens.Dumper.ExtensionMethods;
using Ash.BepInEx.Plugins.CrystalMaidens.Dumper.Utils;
using AssetBundles;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using VandalFramework;
using VandalFramework.UI;

namespace Ash.BepInEx.Plugins.CrystalMaidens.Dumper
{
	[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
	public class Plugin : BaseUnityPlugin
	{
		public ConfigEntry<KeyboardShortcut> DumpAllDatabaseObjectsShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> OpenAdminPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> UnlockAllAlbumsShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> UnlockAllGalleriesShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> UnlockAllHeroesShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> UnlockAllIconsShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> UnlockAllItemsShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> UnlockAllStoriesShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> CloseTopMostPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ExpLevelMinAllHeroesShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ExpLevelMaxAllHeroesShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> FlirtLevelMinAllHeroesShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> FlirtLevelMaxAllHeroesShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> UnlockCurrentHeroShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ExpLevelMinCurrentHeroShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ExpLevelMaxCurrentHeroShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> FlirtLevelMinCurrentHeroShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> FlirtLevelMaxCurrentHeroShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> SelectRomanceImage1Shortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> SelectRomanceImage2Shortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> SelectRomanceImage3Shortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> SelectRomanceImage4Shortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> SelectRomanceImage5Shortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> SelectRomanceImage6Shortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> SelectPreviousAlbumGroupShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> SelectNextAlbumGroupShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ViewSceneShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> SelectPreviousHeroShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> SelectNextHeroShortcut { get; set; }

		public ConfigEntry<KeyboardShortcut> ToggleSettingsPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ToggleMaidensPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ToggleGalleryPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ToggleUserIconsPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ToggleInventoryPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ToggleBossCraftingPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ToggleShopPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ToggleCampaignPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ToggleArenaPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ToggleBossPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> TogglePortalPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ToggleTrophiesPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ToggleQuestsPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ToggleDailyObjectivesPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ToggleDaiyRewardPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ToggleDaiyLoginRewardsPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ToggleWeeklyEventPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ToggleLimitedOffersPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ToggleVipPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ToggleArenaLeaderboardPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> ToggleNewsPanelShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> DumpAllGalleryAssetsShortcut { get; set; }
		public ConfigEntry<KeyboardShortcut> WriteUsageShortcut { get; set; }

		public static ConfigEntry<OriginEnum> Origin { get; set; }
		public static ConfigEntry<HeroFilterType> HeroUnlockFilter { get; set; }
		public static ConfigEntry<bool> ExportWithAssetBundleName { get; set; }
		public static ConfigEntry<bool> DumpImagesOnLoad { get; set; }
		public static ConfigEntry<DumpFormatTypes> DumpFormats { get; set; }
		public static ConfigEntry<string> DumpItemSeparator { get; set; }
		public static ConfigEntry<string> DumpKeyValueSeparator { get; set; }
		public static ConfigEntry<bool> EnableAssetBundleLog { get; set; }
		public static ConfigEntry<string> DownloadAllAssetBundlesOutputDirectory { get; set; }
		public static ConfigEntry<string> DownloadAllAssetBundlesCdn { get; set; }
		public static ConfigEntry<bool> DumpHashesOnLoad { get; set; }

		[Flags]
		public enum DumpFormatTypes
		{
			None = 0,
			PlainText = 1,
			Json = 2,
		}

		[Flags]
		public enum HeroFilterType
		{
			None = 0,
			Maiden = 1,
			Guardian = 2,
			Other = 4,
		}

		private Plugin()
		{
			DumpAllDatabaseObjectsShortcut = Config.Bind("Shortcuts", "Dump All Database Objects", new KeyboardShortcut(KeyCode.D, KeyCode.LeftControl), $"Shortcut to dump all database infos to folder `{InfosDumpPath}`");
			CloseTopMostPanelShortcut = Config.Bind("Shortcuts", "Close Top-Most Panel", new KeyboardShortcut(KeyCode.W, KeyCode.LeftControl), "Shortcut to close active panel");
			ToggleMaidensPanelShortcut = Config.Bind("Shortcuts", "Toggle Maidens Panel", new KeyboardShortcut(KeyCode.M, KeyCode.LeftControl), "Shortcut to toggle the maidens panel");
			ToggleGalleryPanelShortcut = Config.Bind("Shortcuts", "Toggle Gallery Panel", new KeyboardShortcut(KeyCode.G, KeyCode.LeftControl), "Shortcut to toggle the gallery panel");
			ToggleUserIconsPanelShortcut = Config.Bind("Shortcuts", "Toggle Avatar Panel", new KeyboardShortcut(KeyCode.I, KeyCode.LeftControl), "Shortcut to toggle the avatar panel");
			ToggleInventoryPanelShortcut = Config.Bind("Shortcuts", "Toggle Inventory Panel", new KeyboardShortcut(KeyCode.I, KeyCode.LeftControl), "Shortcut to toggle the inventory panel");
			ToggleBossCraftingPanelShortcut = Config.Bind("Shortcuts", "Toggle Boss Crafting Panel", new KeyboardShortcut(KeyCode.X, KeyCode.LeftControl), "Shortcut to toggle the boss crafting panel");
			ToggleShopPanelShortcut = Config.Bind("Shortcuts", "Toggle Shop Panel", new KeyboardShortcut(KeyCode.S, KeyCode.LeftControl), "Shortcut to toggle the shop panel");
			ToggleCampaignPanelShortcut = Config.Bind("Shortcuts", "Toggle Campaign Panel", new KeyboardShortcut(KeyCode.C, KeyCode.LeftControl), "Shortcut to toggle the campaign panel");
			ToggleArenaPanelShortcut = Config.Bind("Shortcuts", "Toggle Arena Panel", new KeyboardShortcut(KeyCode.A, KeyCode.LeftControl), "Shortcut to toggle the arena panel");
			ToggleBossPanelShortcut = Config.Bind("Shortcuts", "Toggle Boss Panel", new KeyboardShortcut(KeyCode.B, KeyCode.LeftControl), "Shortcut to toggle the boss panel");
			TogglePortalPanelShortcut = Config.Bind("Shortcuts", "Toggle Portal Panel", new KeyboardShortcut(KeyCode.P, KeyCode.LeftControl), "Shortcut to toggle the portal panel");
			ToggleTrophiesPanelShortcut = Config.Bind("Shortcuts", "Toggle Trophies Panel", new KeyboardShortcut(KeyCode.T, KeyCode.LeftControl), "Shortcut to toggle the trophies panel");
			ToggleQuestsPanelShortcut = Config.Bind("Shortcuts", "Toggle Quests Panel", new KeyboardShortcut(KeyCode.Q, KeyCode.LeftControl), "Shortcut to toggle the quests panel");
			ToggleDailyObjectivesPanelShortcut = Config.Bind("Shortcuts", "Toggle Daily Objectives Panel", new KeyboardShortcut(KeyCode.O, KeyCode.LeftControl), "Shortcut to toggle the daily objectives panel");
			ToggleDaiyRewardPanelShortcut = Config.Bind("Shortcuts", "Toggle Daily Reward Panel", new KeyboardShortcut(KeyCode.R, KeyCode.LeftControl), "Shortcut to toggle the daily reward panel");
			ToggleDaiyLoginRewardsPanelShortcut = Config.Bind("Shortcuts", "Toggle Daily Login Rewards Panel", new KeyboardShortcut(KeyCode.R, KeyCode.LeftControl), "Shortcut to toggle the daily login rewards panel");
			ToggleWeeklyEventPanelShortcut = Config.Bind("Shortcuts", "Toggle Weekly Events Panel", new KeyboardShortcut(KeyCode.F, KeyCode.LeftControl), "Shortcut to toggle the E panel");
			ToggleLimitedOffersPanelShortcut = Config.Bind("Shortcuts", "Toggle Limited Offers Panel", new KeyboardShortcut(KeyCode.Y, KeyCode.LeftControl), "Shortcut to toggle the limited offers panel");
			ToggleVipPanelShortcut = Config.Bind("Shortcuts", "Toggle VIP Panel", new KeyboardShortcut(KeyCode.V, KeyCode.LeftControl), "Shortcut to toggle the VIP panel");
			ToggleArenaLeaderboardPanelShortcut = Config.Bind("Shortcuts", "Toggle Arena Leaderboard Panel", new KeyboardShortcut(KeyCode.K, KeyCode.LeftControl), "Shortcut to toggle the arena leaderboard panel");
			ToggleNewsPanelShortcut = Config.Bind("Shortcuts", "Toggle News Panel", new KeyboardShortcut(KeyCode.N, KeyCode.LeftControl), "Shortcut to toggle the news panel");
			ToggleSettingsPanelShortcut = Config.Bind("Shortcuts", "Toggle Settings Panel", new KeyboardShortcut(KeyCode.E, KeyCode.LeftControl), "Shortcut to toggle the settings panel");
			OpenAdminPanelShortcut = Config.Bind("Shortcuts", "Open Admin Panel", new KeyboardShortcut(KeyCode.BackQuote, KeyCode.LeftControl), "Shortcut to toggle the admin panel");

			UnlockAllAlbumsShortcut = Config.Bind("Shortcuts", "Unlock All Albums", new KeyboardShortcut(KeyCode.A, KeyCode.LeftControl, KeyCode.LeftShift), "Shortcut to unlock all albums");
			UnlockAllGalleriesShortcut = Config.Bind("Shortcuts", "Unlock All Galleries", new KeyboardShortcut(KeyCode.G, KeyCode.LeftControl, KeyCode.LeftShift), "Shortcut to unlock all galleries");
			UnlockAllIconsShortcut = Config.Bind("Shortcuts", "Unlock All Icons", new KeyboardShortcut(KeyCode.E, KeyCode.LeftControl, KeyCode.LeftShift), "Shortcut to unlock all icons");
			UnlockAllItemsShortcut = Config.Bind("Shortcuts", "Unlock All Items", new KeyboardShortcut(KeyCode.I, KeyCode.LeftControl, KeyCode.LeftShift), "Shortcut to unlock all items");
			UnlockAllStoriesShortcut = Config.Bind("Shortcuts", "Unlock All Stories", new KeyboardShortcut(KeyCode.S, KeyCode.LeftControl, KeyCode.LeftShift), "Shortcut to unlock all stories");

			UnlockAllHeroesShortcut = Config.Bind("Shortcuts", "Unlock All Heroes", new KeyboardShortcut(KeyCode.U, KeyCode.LeftControl, KeyCode.LeftShift), "Shortcut to unlock all heroes");
			ExpLevelMinAllHeroesShortcut = Config.Bind("Shortcuts", "Level Down All Heroes", new KeyboardShortcut(KeyCode.L, KeyCode.LeftAlt, KeyCode.LeftControl, KeyCode.LeftShift), "Shortcut to reset level of all heroes");
			ExpLevelMaxAllHeroesShortcut = Config.Bind("Shortcuts", "Level Max All Heroes", new KeyboardShortcut(KeyCode.L, KeyCode.LeftControl, KeyCode.LeftShift), "Shortcut to level up all heroes");
			FlirtLevelMinAllHeroesShortcut = Config.Bind("Shortcuts", "Flirt Min All Heroes", new KeyboardShortcut(KeyCode.F, KeyCode.LeftAlt, KeyCode.LeftControl, KeyCode.LeftShift), "Shortcut to reset flirt level of all heroes");
			FlirtLevelMaxAllHeroesShortcut = Config.Bind("Shortcuts", "Flirt Max All Heroes", new KeyboardShortcut(KeyCode.F, KeyCode.LeftControl, KeyCode.LeftShift), "Shortcut to flirt up all heroes");

			UnlockCurrentHeroShortcut = Config.Bind("Shortcuts", "Unlock Current Hero", new KeyboardShortcut(KeyCode.U, KeyCode.LeftControl), "Shortcut to unlock currently selected hero");
			ExpLevelMinCurrentHeroShortcut = Config.Bind("Shortcuts", "Level Down Current Hero", new KeyboardShortcut(KeyCode.L, KeyCode.LeftAlt, KeyCode.LeftControl), "Shortcut to reset level of currently selected hero");
			ExpLevelMaxCurrentHeroShortcut = Config.Bind("Shortcuts", "Level Max Current Hero", new KeyboardShortcut(KeyCode.L, KeyCode.LeftControl), "Shortcut to level up currently selected hero");
			FlirtLevelMinCurrentHeroShortcut = Config.Bind("Shortcuts", "Flirt Min Current Hero", new KeyboardShortcut(KeyCode.F, KeyCode.LeftAlt), "Shortcut to flirt level of currently selected hero");
			FlirtLevelMaxCurrentHeroShortcut = Config.Bind("Shortcuts", "Flirt Max Current Hero", new KeyboardShortcut(KeyCode.F, KeyCode.LeftControl), "Shortcut to flirt up currently selected hero");
			SelectRomanceImage1Shortcut = Config.Bind("Shortcuts", "Select Romance Image 1", new KeyboardShortcut(KeyCode.Alpha1), "Shortcut to quickjump to the first romance image");
			SelectRomanceImage2Shortcut = Config.Bind("Shortcuts", "Select Romance Image 2", new KeyboardShortcut(KeyCode.Alpha2), "Shortcut to quickjump to the second romance image");
			SelectRomanceImage3Shortcut = Config.Bind("Shortcuts", "Select Romance Image 3", new KeyboardShortcut(KeyCode.Alpha3), "Shortcut to quickjump to the third romance image");
			SelectRomanceImage4Shortcut = Config.Bind("Shortcuts", "Select Romance Image 4", new KeyboardShortcut(KeyCode.Alpha4), "Shortcut to quickjump to the fourth romance image (if available)");
			SelectRomanceImage5Shortcut = Config.Bind("Shortcuts", "Select Romance Image 5", new KeyboardShortcut(KeyCode.Alpha5), "Shortcut to quickjump to the fifth romance image (if available)");
			SelectRomanceImage6Shortcut = Config.Bind("Shortcuts", "Select Romance Image 6", new KeyboardShortcut(KeyCode.Alpha6), "Shortcut to quickjump to the sixth romance image (if available)");
			ViewSceneShortcut = Config.Bind("Shortcuts", "View Scene", new KeyboardShortcut(KeyCode.Alpha0), "Shortcut to view the currently selected scene");
			SelectPreviousHeroShortcut = Config.Bind("Shortcuts", "Select Previous Hero", new KeyboardShortcut(KeyCode.Q), "Shortcut to jump to previous hero");
			SelectNextHeroShortcut = Config.Bind("Shortcuts", "Select Next Hero", new KeyboardShortcut(KeyCode.E), "Shortcut to jump to next hero");
			SelectPreviousAlbumGroupShortcut = Config.Bind("Shortcuts", "Select Previous Album Group", new KeyboardShortcut(KeyCode.Alpha7), "Shortcut to jump to previous album group");
			SelectNextAlbumGroupShortcut = Config.Bind("Shortcuts", "Select Next Album Group", new KeyboardShortcut(KeyCode.Alpha8), "Shortcut to jump to next album group");
			DumpAllGalleryAssetsShortcut = Config.Bind("Shortcuts", "Dump All Galleries Assets", new KeyboardShortcut(KeyCode.D, KeyCode.LeftControl, KeyCode.LeftShift), "Shortcut to save all galleries assets (DO NOT USE)");
			WriteUsageShortcut = Config.Bind("Shortcuts", "Write Usage to File", new KeyboardShortcut(KeyCode.F1, KeyCode.LeftShift), $"Shortcut to write usage to `{DumpBasePath}`");

			Origin = Config.Bind("Variables", "Origin", OriginEnum.All, "The origin");
			HeroUnlockFilter = Config.Bind("Variables", "Hero Unlock Filter", HeroFilterType.Maiden | HeroFilterType.Guardian, "Specifies the type of hero to unlock");
			ExportWithAssetBundleName = Config.Bind("Variables", "Export With Asset Bundle Name", false, "If enabled, include the bundle name in the export path");
			DumpImagesOnLoad = Config.Bind("Variables", "Dump Images On Load", false, "If enabled, save images locally as they are being loaded");
			DumpFormats = Config.Bind("Variables", "Database Dump - Formats", DumpFormatTypes.PlainText | DumpFormatTypes.Json, "The formats to use when dumping databases");
			DumpItemSeparator = Config.Bind("Variables", "Database Dump - Item Separator", " | ", "The delimiter to use to separate items when dumping in plain text");
			DumpKeyValueSeparator = Config.Bind("Variables", "Database Dump - Key/Value Separator", "=", "The delimiter to use to separate keys and values when dumping in plain text");
			EnableAssetBundleLog = Config.Bind("Variables", "Enable Asset Bundle Logging", false, "If enabled, log asset bundle operations");
			EnableAssetBundleLog.SettingChanged += EnableAssetBundleLog_SettingChanged;

			SetEnableAssetBundleLog(EnableAssetBundleLog.Value);

			DownloadAllAssetBundlesOutputDirectory = Config.Bind("Variables", "Download All Asset Bundles - Output Directory", $"{Application.persistentDataPath}/AssetBundles/", "The output directory to use when downloading asset bundles");
			DownloadAllAssetBundlesCdn = Config.Bind("Variables", "Download All Asset Bundles - CDN", "https://cdn-crystal-maidens.nutaku.net/streamingassets/Win/", "The address to the asset bundles CDN");
			DumpHashesOnLoad = Config.Bind("Variables", "Dump Hashes On Load", false, "If enabled, dump hashes as they are being loaded");

			ResetOrigin();
		}

		// FIXME: Overriding the origin at startup causes a null reference exception to be thrown in CM's BlueprintsLoader.LoadItems(),
		// likely because it tries to access the id property of defaultFodderItem,
		// which could happen to be null because of the origin filtering.
		/*
		NullReferenceException: Object reference not set to an instance of an object
		at BlueprintsLoader+<LoadItems>d__11.MoveNext () [0x0010e] in <aff4dd640f8742e58d6b7559d8cc458a>:0 
		at UnityEngine.SetupCoroutine.InvokeMoveNext (System.Collections.IEnumerator enumerator, System.IntPtr returnValueAddress) [0x00027] in <2774ccc3e0de4aef8525f5fbd178bef1>:0 
		*/
		private static void ResetOrigin()
		{
			Origin.Value = OriginEnum.All;
		}

		private void EnableAssetBundleLog_SettingChanged(object sender, EventArgs e)
			=> SetEnableAssetBundleLog(EnableAssetBundleLog.Value);

		private void SetEnableAssetBundleLog(bool show)
			=> AssetsManager.Instance.ShowDebug = show;
		
		private void Awake()
		{
			var harmony = new Harmony(Info.Metadata.GUID);

			harmony.PatchAll();
		}

		private void Update()
		{
			try
			{
				if (IsInputBusy())
				{
					return;
				}
			}
			catch { }

			try
			{
				if (DumpAllDatabaseObjectsShortcut.Value.IsDown())
				{
					DumpAbilityEffectInfos();
					DumpAbilityInfos();
					DumpAchievementInfos();
					DumpBuildingInfos();
					DumpCampaignGroupsInfos();
					DumpCampaignInactiveInfos();
					DumpCharacterEventsGlobalObjectivesInfos();
					DumpCharacterEventsInfos();
					DumpCharacterEventsObjectivesInfos();
					DumpChunkBlockerInfos();
					DumpCraftInfos();
					DumpDailyObjectivesInfos();
					DumpEventInfos();
					DumpGalleryInfos();
					DumpGuardianInfos();
					DumpHeroesInfos();
					DumpIconInfos();
					DumpItemInfos();
					DumpMaidensInfos();
					DumpMapInfosAll();
					DumpMasteriesInfos();
					DumpPvpDivisionInfos();
					DumpQuestInfos();
					DumpRewardInfos();
					DumpShopItemsInfos();
					DumpStatsCapInfos();
					DumpStorySpecialGroupInfos();
					DumpStoryInfos();
					DumpWeeklyObjectivesInfos();
					DumpWorldBossEvents();

					DumpUserCharacterEvent();
					DumpUserHeroes();
					DumpUserIcons();
					DumpUserItems();
					DumpUserMaps();
					DumpUserObjectives();
					DumpUserShopItems();
					DumpUserStories();
					DumpUserWorldBoss();

					DumpAssetBundleNameHashes();

					DumpAssetBundleNames();
					DumpAssetBundleNamesWithVariant();
					DumpAllAssetBundlesUrls();

					WriteAssetBundlesCurlCommand();
					WriteAssetBundlesCurlConfig();
				}
				else if (OpenAdminPanelShortcut.Value.IsDown())
				{
					OpenAdminPanel();
				}
				else if (CloseTopMostPanelShortcut.Value.IsDown())
				{
					CloseAllPanels();
				}
				else if (ToggleSettingsPanelShortcut.Value.IsDown())
				{
					ToggleSettingsPanel();
				}
				else if (ToggleMaidensPanelShortcut.Value.IsDown())
				{
					ToggleMaidensPanel();
				}
				else if (ToggleGalleryPanelShortcut.Value.IsDown())
				{
					ToggleGalleryPanel();
				}
				else if (ToggleUserIconsPanelShortcut.Value.IsDown())
				{
					ToggleUserIconsPanel();
				}
				else if (ToggleInventoryPanelShortcut.Value.IsDown())
				{
					ToggleInventoryPanel();
				}
				else if (ToggleBossCraftingPanelShortcut.Value.IsDown())
				{
					ToggleBossCraftingPanel();
				}
				else if (ToggleShopPanelShortcut.Value.IsDown())
				{
					ToggleShopPanel();
				}
				else if (ToggleCampaignPanelShortcut.Value.IsDown())
				{
					ToggleCampaignPanel();
				}
				else if (ToggleArenaPanelShortcut.Value.IsDown())
				{
					ToggleArenaPanel();
				}
				else if (ToggleBossPanelShortcut.Value.IsDown())
				{
					ToggleBossPanel();
				}
				else if (TogglePortalPanelShortcut.Value.IsDown())
				{
					TogglePortalPanel();
				}
				else if (ToggleTrophiesPanelShortcut.Value.IsDown())
				{
					ToggleTrophiesPanel();
				}
				else if (ToggleQuestsPanelShortcut.Value.IsDown())
				{
					ToggleQuestsPanel();
				}
				else if (ToggleDailyObjectivesPanelShortcut.Value.IsDown())
				{
					ToggleDailyObjectivesPanel();
				}
				else if (ToggleDaiyRewardPanelShortcut.Value.IsDown())
				{
					ToggleDaiyRewardPanel();
				}
				else if (ToggleDaiyLoginRewardsPanelShortcut.Value.IsDown())
				{
					ToggleDaiyLoginRewardsPanel();
				}
				else if (ToggleWeeklyEventPanelShortcut.Value.IsDown())
				{
					ToggleWeeklyEventPanel();
				}
				else if (ToggleLimitedOffersPanelShortcut.Value.IsDown())
				{
					ToggleLimitedOffersPanel();
				}
				else if (ToggleVipPanelShortcut.Value.IsDown())
				{
					ToggleVipPanel();
				}
				else if (ToggleArenaLeaderboardPanelShortcut.Value.IsDown())
				{
					ToggleArenaLeaderboardPanel();
				}
				else if (ToggleNewsPanelShortcut.Value.IsDown())
				{
					ToggleNewsPanel();
				}
				else if (SelectPreviousHeroShortcut.Value.IsDown())
				{
					SelectPreviousHero();
					SelectPreviousGuardian();
				}
				else if (SelectNextHeroShortcut.Value.IsDown())
				{
					SelectNextHero();
					SelectNextGuardian();
				}
				else if (UnlockAllItemsShortcut.Value.IsDown())
				{
					UnlockAllItems();
				}
				else if (UnlockAllIconsShortcut.Value.IsDown())
				{
					UnlockAllIcons();
				}
				else if (UnlockAllStoriesShortcut.Value.IsDown())
				{
					UnlockAllStories();
				}
				else if (UnlockAllHeroesShortcut.Value.IsDown())
				{
					UnlockAllHeroes();
				}
				else if (UnlockCurrentHeroShortcut.Value.IsDown())
				{
					UnlockCurrentMaiden();
					//UnlockCurrentGuardian();
				}
				else if (SelectRomanceImage1Shortcut.Value.IsDown())
				{
					ForceShowMaidenPreviewImage(0);
					ForceShowGuardianPreviewImage(0);
					ForceShowGalleryScene(0);
					ForceSelectAlbumStory(0);
				}
				else if (SelectRomanceImage2Shortcut.Value.IsDown())
				{
					ForceShowMaidenPreviewImage(1);
					ForceShowGuardianPreviewImage(1);
					ForceShowGalleryScene(1);
					ForceSelectAlbumStory(1);
				}
				else if (SelectRomanceImage3Shortcut.Value.IsDown())
				{
					ForceShowMaidenPreviewImage(2);
					ForceShowGuardianPreviewImage(2);
					ForceShowGalleryScene(2);
					ForceSelectAlbumStory(2);
				}
				else if (SelectRomanceImage4Shortcut.Value.IsDown())
				{
					ForceShowMaidenPreviewImage(3);
					ForceShowGuardianPreviewImage(3);
					ForceShowGalleryScene(3);
					ForceSelectAlbumStory(3);
				}
				else if (SelectRomanceImage5Shortcut.Value.IsDown())
				{
					//ForceShowMaidenPreviewImage(4);
					//ForceShowGuardianPreviewImage(4);
					ForceShowGalleryScene(4);
					ForceSelectAlbumStory(4);
				}
				else if (SelectRomanceImage6Shortcut.Value.IsDown())
				{
					//ForceShowMaidenPreviewImage(5);
					//ForceShowGuardianPreviewImage(5);
					ForceShowGalleryScene(5);
					ForceSelectAlbumStory(5);
				}
				else if (ViewSceneShortcut.Value.IsDown())
				{
					ViewMaidenScene();
					ViewGuardianScene();
				}
				else if (UnlockAllGalleriesShortcut.Value.IsDown())
				{
					UnlockAllGalleries();
				}
				else if (UnlockAllAlbumsShortcut.Value.IsDown())
				{
					UnlockAllAlbums();
				}
				else if (SelectPreviousAlbumGroupShortcut.Value.IsDown())
				{
					SelectPreviousAlbumStoryGroup();
					ActivateSelectedAlbumStory(0);
				}
				else if (SelectNextAlbumGroupShortcut.Value.IsDown())
				{
					SelectNextAlbumStoryGroup();
					ActivateSelectedAlbumStory(0);
				}
				else if (FlirtLevelMinAllHeroesShortcut.Value.IsDown())
				{
					FlirtLevelMinAllHeroes();
				}
				else if (FlirtLevelMinCurrentHeroShortcut.Value.IsDown())
				{
					FlirtLevelMinCurrentHero();
				}
				else if (FlirtLevelMaxAllHeroesShortcut.Value.IsDown())
				{
					FlirtLevelMaxAllHeroes();
				}
				else if (FlirtLevelMaxCurrentHeroShortcut.Value.IsDown())
				{
					FlirtLevelMaxCurrentHero();
				}
				else if (ExpLevelMinAllHeroesShortcut.Value.IsDown())
				{
					ExpLevelMinAllHeroes();
				}
				else if (ExpLevelMinCurrentHeroShortcut.Value.IsDown())
				{
					ExpLevelMinCurrentHero();
				}
				else if (ExpLevelMaxAllHeroesShortcut.Value.IsDown())
				{
					ExpLevelMaxAllHeroes();
				}
				else if (ExpLevelMaxCurrentHeroShortcut.Value.IsDown())
				{
					ExpLevelMaxCurrentHero();
				}
				else if (DumpAllGalleryAssetsShortcut.Value.IsDown())
				{
					DumpAllGalleryAssets();
				}
				else if (WriteUsageShortcut.Value.IsDown())
				{
					WriteUsage();
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning(ex);
			}
		}

		private bool IsInputBusy()
			=> UnityEngine.EventSystems.EventSystem
				.current?
				.currentSelectedGameObject?
				.GetComponentInChildren<InputField>() != null;  // NOTE: throws an exception sometimes.

		private void WriteUsage()
		{
			var path = $"{DumpBasePath}/{"USAGE"}{".md"}";

			var stringBuilder = new StringBuilder();

			stringBuilder.AppendLine("## Shortcuts");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("| Name          | Description   | Default Value |");
			stringBuilder.AppendLine("| ------------- | ------------- | ------------- |");

			foreach (var config in Config.Where(setting => setting.Key.Section.Equals("Shortcuts")))
			{
				stringBuilder.AppendLine($"| {config.Key.Key} | {config.Value.Description.Description} | {FormatSettingValue(config.Value.DefaultValue)} |");
			}

			stringBuilder.AppendLine();

			stringBuilder.AppendLine("## Variables");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("| Name          | Description   | Default Value |");
			stringBuilder.AppendLine("| ------------- | ------------- | ------------- |");

			foreach (var config in Config.Where(setting => setting.Key.Section.Equals("Variables")))
			{
				stringBuilder.AppendLine($"| {config.Key.Key} | {config.Value.Description.Description} | {FormatSettingValue(config.Value.DefaultValue)} |");
			}

			File.WriteAllText(path, stringBuilder.ToString());
		}

		private static object FormatSettingValue(object value)
		{
			if (value is null)
			{
				return "";
			}

			if (value is KeyboardShortcut)
			{
				var tokens = value.ToString().Split(new char[] { ' ' });

				return string.Join(" ", tokens.Select(x => x == "+" ? x : $"`{x.Trim()}`"));
			}
			else if (value.GetType().GetCustomAttributes(typeof(FlagsAttribute), inherit: false).Length > 0)
			{
				var tokens = value.ToString().Split(new char[] { ',' });

				return string.Join(", ", tokens.Select(x => $"`{x.Trim()}`"));
			}

			return $"`{value.ToString().Replace("|", "\\|")}`";
		}

		private void ToggleVipPanel()
			=> TogglePanel<PanelVIP>();

		private void ToggleLimitedOffersPanel()
			=> TogglePanel<PanelLimitedOffers>();

		private void ToggleWeeklyEventPanel()
			=> TogglePanel<PanelWeeklyEvent>();

		private void ToggleQuestsPanel()
			=> TogglePanel<PanelQuests>();

		private void ToggleDaiyRewardPanel()
			=> TogglePanel<PanelDailyReward>();

		private void ToggleDaiyLoginRewardsPanel()
			=> TogglePanel<PanelDailyLoginRewards>();

		private void ToggleDailyObjectivesPanel()
			=> TogglePanel<PanelDailyObjectives>();

		private void ToggleTrophiesPanel()
			=> TogglePanel<PanelTrophies>();

		private void TogglePortalPanel()
			=> TogglePanel<PanelEndlessTower>();

		private void ToggleBossPanel()
		{ /* TODO */ }

		private void ToggleArenaPanel()
			=> TogglePanel<PanelPVPAsync>();

		private void ToggleCampaignPanel()
			=> TogglePanel<PanelChooseCampaign>();

		private void ToggleShopPanel()
			=> TogglePanel<PanelShop>();

		private void ToggleBossCraftingPanel()
			=> TogglePanel<PanelBossCampaignRecipes>();

		private void ToggleUserIconsPanel()
			=> TogglePanel<PanelUserIcons>();

		private void ToggleInventoryPanel()
			=> TogglePanel<PanelInventory>();

		private void ToggleGalleryPanel()
			=> TogglePanel<PanelAlbum>();

		private void ToggleMaidensPanel()
			=> TogglePanel<PanelHeroes>();

		private void ToggleArenaLeaderboardPanel()
			=> TogglePanel<PanelLeaderboard>();

		private void ToggleNewsPanel()
			=> TogglePanel<PanelNews>();

		private void ToggleSettingsPanel()
			=> TogglePanel<PanelSettings>();

		private void OpenAdminPanel()
			=> UIManager.Instance.OpenPanel<PanelAdmin>(null, null);

		private void TogglePanel<T>(bool forceCloseAll = true) where T : Panel
		{
			var panel = UIManager.Instance.GetPanel<T>();

			if (panel is null)
			{
				return;
			}

			if (panel.IsActive()
				&& panel.isOpen)
			{
				panel.ForceClose();
			}
			else
			{
				if (forceCloseAll)
				{
					CloseAllPanels();
				}

				UIManager.Instance.OpenPanel<T>();
			}
		}

		private static readonly List<Type> corePanelTypes = new()
		{
			typeof(PanelLoading),
			typeof(PanelReconnecting),
			typeof(PanelSlidingMenu),
			typeof(PanelSideEvents),
			typeof(LobbyHeaderPanel),
			typeof(PanelLeftSideMenu),
		};

		public static void CloseAllPanels()
		{
			foreach (var panel in UIManager.Instance.GetPanels())
			{
				if (corePanelTypes.Contains(panel.GetType()))
				{
					continue;
				}

				panel.ForceClose();
			}
		}

		private void SelectPreviousHero()
			=> ((Button)FindObjectOfType<PanelHeroDescription>()?
				.GetType()
				.GetField("navigateLeftButton", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelHeroDescription>()))?
					.onClick.Invoke();

		private void SelectNextHero()
			=> ((Button)FindObjectOfType<PanelHeroDescription>()?
				.GetType()
				.GetField("navigateRightButton", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelHeroDescription>()))?
					.onClick.Invoke();

		private void SelectPreviousGuardian()
			=> ((Button)FindObjectOfType<PanelGuardianDescription>()?
				.GetType()
				.GetField("navigateLeftButton", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelGuardianDescription>()))?
					.onClick.Invoke();

		private void SelectNextGuardian()
			=> ((Button)FindObjectOfType<PanelGuardianDescription>()?
				.GetType()
				.GetField("navigateRightButton", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelGuardianDescription>()))?
					.onClick.Invoke();

		private void ViewMaidenScene()
			=> ((Button)FindObjectOfType<PanelHeroDescription>()?
				.GetType()
				.GetField("viewScenesButton", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelHeroDescription>()))?
					.onClick.Invoke();

		private void ViewGuardianScene()
			=> ((Button)FindObjectOfType<PanelGuardianDescription>()?
				.GetType()
				.GetField("viewScenesButton", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelGuardianDescription>()))?
					.onClick.Invoke();

		private void ExpLevelMinAllHeroes()
		{
			using (new NotificationChangeScope<OnUserHeroPowerRatingChangedEvent>(enable: false))
			{
				foreach (var kvp in QuickAccess.User?.heroes)
				{
					try { kvp.Value.SetExperience(QuickAccess.User, 0U); }
					catch { }
				}
			}
		}

		private void ExpLevelMinCurrentHero()
		{
			var currentHero = GetCurrentHero();

			using (new NotificationChangeScope<OnUserHeroPowerRatingChangedEvent>(enable: false))
			{
				if (currentHero != null)
				{
					try { currentHero.SetExperience(QuickAccess.User, 0U); }
					catch { }
				}
			}
		}

		private static void FlirtLevelMinAllHeroes()
		{
			foreach (var kvp in QuickAccess.User?.heroes)
			{
				kvp.Value.FlirtLevel = 0;
			}
		}

		private static void FlirtLevelMinCurrentHero()
		{
			var currentUserHero = GetCurrentHero();

			if (currentUserHero != null)
			{
				currentUserHero.FlirtLevel = 0;
			}
		}

		private static void FlirtLevelMaxAllHeroes()
		{
			foreach (var kvp in QuickAccess.User?.heroes)
			{
				kvp.Value.FlirtLevel = 15;
			}
		}

		private static void FlirtLevelMaxCurrentHero()
		{
			var currentUserHero = GetCurrentHero();

			if (currentUserHero != null)
			{
				currentUserHero.FlirtLevel = 15;
			}
		}

		private void ExpLevelMaxAllHeroes()
		{
			using (new NotificationChangeScope<OnUserHeroPowerRatingChangedEvent>(enable: false))
			{
				foreach (var kvp in QuickAccess.User?.heroes)
				{
					ApplyMaidenMaxLevel(kvp.Value);
				}
			}
		}

		private void UnlockAllGalleries()
		{
		}

		private void UnlockAllIcons()
		{
			if (GameConfiguration.Instance is null
				|| QuickAccess.User is null)
			{
				return;
			}

			foreach (var kvp in GameConfiguration.Instance.iconInfos)
			{
				if (kvp.Value.visible != 0
					&& !QuickAccess.User.icons.Contains(kvp.Key))
				{
					QuickAccess.User.icons.Add(kvp.Key);
				}
			}
		}

		private void UnlockAllItems()
		{
			if (GameConfiguration.Instance is null
				|| QuickAccess.User is null)
			{
				return;
			}

			foreach (var item in GameConfiguration.Instance.itemInfos)
			{
				if (!QuickAccess.User.GetItem(item.Key, out var _))
				{
					try
					{
						if (item.Value.IsWearable)
						{
							//foreach (var kvp in item.Value.rarityStats)
							{
								var rarity = item.Value.rarityStats is null || item.Value.rarityStats.Count == 0 ? Rarity.unidentified : item.Value.rarityStats.Keys.Last();

								QuickAccess.User.AddUserItemWearable(item.Key, item.Key, rarity, item.Value.maxlevel, 1, bypassStorageCapacity: true);
							}
						}
						else
						{
							QuickAccess.User.AddUserItem(new UserItem(item.Value), bypassStorageCapacity: true);
						}
					}
					catch (Exception ex)
					{
						Debug.LogWarning($"{ex}");
					}
				}
			}
		}

		private void UnlockAllStories()
		{
			if (GameConfiguration.Instance is null
				|| QuickAccess.User is null)
			{
				return;
			}

			foreach (var story in GameConfiguration.Instance.storyInfos)
			{
				if (!QuickAccess.User.stories.Contains(new UserStory(story.Key)))
				{
					QuickAccess.User.stories.Add(new UserStory(story.Key));
				}
			}
		}

		private void UnlockAllAlbums()
		{
			var panel = FindObjectOfType<PanelAlbum>();

			if (panel is null)
			{
				return;
			}

			ShowAlbumToggleSexButton(true);
			ShowAlbumWatchButton(true);
			ShowAlbumDescriptionPanel(true);
			//ShowAlbumBuyButton(true);

			foreach (var toggle in ((Transform)panel
				.GetType()
				.GetField("_contextButtons", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(panel)).GetComponentsInChildren<Toggle>())
			{
				toggle.interactable = true;
			}

			foreach (var albumStoryGroupElement in FindObjectsOfType<AlbumStoryGroupElement>())
			{
				var albumStoryGridParent = albumStoryGroupElement.GetComponentInChildren<AlbumStoryGridParent>();

				foreach (var albumStoryElement in albumStoryGridParent.GetComponentsInChildren<AlbumStoryElement>())
				{
					albumStoryElement.SetSelected(true);
					albumStoryElement.UpdateElement();
				}
			}
		}

		private void ShowAlbumWatchButton(bool show)
			=> ((Button)FindObjectOfType<PanelAlbum>()?
				.GetType()
				.GetField("_watchButton", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelAlbum>()))?
					.gameObject.SetActive(show);

		private void ShowAlbumToggleSexButton(bool show)
			=> ((Toggle)FindObjectOfType<PanelAlbum>()?
				.GetType()
				.GetField("toggleSexButton", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelAlbum>()))?
					.gameObject.SetActive(show);

		private void ShowAlbumDescriptionPanel(bool show)
			=> ((GameObject)FindObjectOfType<PanelAlbum>()?
				.GetType()
				.GetField("descriptionPanel", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelAlbum>()))?
					.SetActive(show);

		private void ExpLevelMaxCurrentHero()
		{
			using (new NotificationChangeScope<OnUserHeroPowerRatingChangedEvent>(enable: false))
			{
				ApplyMaidenMaxLevel(GetCurrentHero() ?? GetCurrentGuardianHero());
			}
		}

		private void ApplyMaidenMaxLevel(UserHero userHero)
		{
			if (userHero is null)
			{
				return;
			}

			userHero.SetExperience(QuickAccess.User, 46400000U);
			userHero.FlirtLevel = 15;
		}

		private void CreateUserHeroForCurrentMaiden()
		{
			var currentHeroDefinition = GetCurrentHeroDefinition();

			if (currentHeroDefinition is null)
			{
				return;
			}

			// NOTE: no idea what number to give it.
			var userHeroId = currentHeroDefinition.id;
			var userHero = CreateUserHero(userHeroId, currentHeroDefinition.id);

			QuickAccess.User?.AddNewUserHero(userHero);
		}

		private Coroutine galleryAssetDumpCoroutine;
		private static int galleryExportCompleted;

		private void DumpAllGalleryAssets()
		{
			if (galleryAssetDumpCoroutine != null)
			{
				return;
			}

			galleryAssetDumpCoroutine = StartCoroutine(DumpAllGalleryAssetsAsync());
		}

		private IEnumerator DumpAllGalleryAssetsAsync()
		{
			foreach (var item in GameConfiguration.Instance.galleryInfos)
			{
				if (item.Value is null)
				{
					continue;
				}

				var paths = new string[]
				{
					item.Value.imageprefabpath,
					item.Value.previewpath,
				};

				for (var i = 0; i < paths.Length; ++i)
				{
					var path = paths[i];
					var extension = Path.GetExtension(path);

					Debug.Log($"Processing {item.Key} ({extension}) : {path}");

					galleryExportCompleted = 0;

					if (extension.Equals(".prefab", StringComparison.OrdinalIgnoreCase))
					{
						var splitPaths = path.Split(new char[] { '/' }, 2);

						if (splitPaths.Length == 2)
						{
							galleryExportCompleted |= 1;

							AssetsManager.Instance?.GetAssetGameObject(splitPaths[0], splitPaths[1], addToCache: true, new Action<GameObject>(OnImagePrefabGameObjectLoaded));
						}
					}
					else if (extension.Equals(".png", StringComparison.OrdinalIgnoreCase)
						|| extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase)
						|| extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase))
					{
						galleryExportCompleted |= 2;

						AssetsManager.Instance?.GetTexture(path, new Action<Texture2D, object>(OnImagePrefabImageLoaded), addToCache: true, new object[] { item.Value, path });
					}

					yield return new WaitUntil(() => galleryExportCompleted == 0);
				}
			}

			galleryAssetDumpCoroutine = null;
		}

		private static void OnImagePrefabGameObjectLoaded(GameObject gameObject)
		{
			if (gameObject is null)
			{
				return;
			}

			galleryExportCompleted &= ~1;
		}

		private static void OnImagePrefabImageLoaded(UnityEngine.Object sprite, object data)
		{
			if (sprite is null)
			{
				return;
			}

			Texture2D texture = null;

			try
			{
				var objects = (object[])data;
				var galleryInfo = (GalleryDBObject)objects[0];
				var context = (string)objects[1];
				var path = TextureUtils.GetExportPath(context);

				if (!File.Exists(path))
				{
					texture = TextureUtils.CopyTexture((Texture2D)sprite);
					var bytes = TextureUtils.EncodeBasedOnFileExtension(texture, context);

					//Debug.Log("writing " + path);

					Directory.CreateDirectory(Path.GetDirectoryName(path));
					File.WriteAllBytes(path, bytes);
				}
				else
				{
					//Debug.Log("skipping existing " + path);
				}
			}
			catch (Exception ex)
			{
				Debug.Log($"{ex}");
			}
			finally
			{
				Texture2D.Destroy(texture);
			}

			galleryExportCompleted &= ~2;
		}

		private void DumpAllAssetBundlesUrls()
		{
			var assetBundleManifest = (AssetBundleManifest)(FindObjectOfType<AssetBundleManager>()?
				.GetType()
				.GetField("m_AssetBundleManifest", BindingFlags.NonPublic | BindingFlags.Static)
				.GetValue(null));

			if (assetBundleManifest is null)
			{
				return;
			}

			var allAssetBundleNames = assetBundleManifest.GetAllAssetBundles();
			var allAssetBundleNamesWithDependency = new List<string>();

			allAssetBundleNamesWithDependency.AddRange(allAssetBundleNames);

			foreach (var assetBundleName in allAssetBundleNames)
			{
				allAssetBundleNamesWithDependency.AddRange(assetBundleManifest.GetAllDependencies(assetBundleName));
			}

			DumpInfosToFile("AssetBundlesUrls", allAssetBundleNamesWithDependency, (value) => $"{DownloadAllAssetBundlesCdn.Value}{value}", includeIndex: false);
		}

		private void WriteAssetBundlesCurlCommand()
		{
			var content = string.Join(" ", new string[]
			{
				"curl",
				"--parallel",
				"--ssl-no-revoke",
				"--raw",
				string.IsNullOrEmpty(DownloadAllAssetBundlesOutputDirectory.Value)
					? ""
					: $"--create-dirs --output-dir \"{DownloadAllAssetBundlesOutputDirectory.Value}\"",
				$"--config \"{InfosDumpPath}/{"AssetBundlesCurlConfig"}{".txt"}\"",
			});

			var path = $"{DumpBasePath}/{"AssetBundlesDownloadWithCurl"}{".cmd"}";

			Directory.CreateDirectory(Path.GetDirectoryName(path));
			File.WriteAllText(path, content);
		}

		private void WriteAssetBundlesCurlConfig()
		{
			var assetBundleManifest = (AssetBundleManifest)(FindObjectOfType<AssetBundleManager>()?
				.GetType()
				.GetField("m_AssetBundleManifest", BindingFlags.NonPublic | BindingFlags.Static)
				.GetValue(null));

			if (assetBundleManifest is null)
			{
				return;
			}

			var allAssetBundleNames = assetBundleManifest.GetAllAssetBundles();
			var allAssetBundleNamesWithDependency = new List<string>();

			allAssetBundleNamesWithDependency.AddRange(allAssetBundleNames);

			foreach (var assetBundleName in allAssetBundleNames)
			{
				allAssetBundleNamesWithDependency.AddRange(assetBundleManifest.GetAllDependencies(assetBundleName));
			}

			DumpInfosToFile("AssetBundlesCurlConfig", allAssetBundleNamesWithDependency, (value) => string.Join(Environment.NewLine, new string[] { $"--output {new Uri($"{DownloadAllAssetBundlesCdn.Value}{value}", UriKind.Absolute).GetComponents(UriComponents.AbsoluteUri & ~UriComponents.Scheme, UriFormat.UriEscaped)}", $"url = {DownloadAllAssetBundlesCdn.Value}{value}", }), includeIndex: false);
		}

		private void DumpAssetBundleNameHashes()
			=> DumpInfosToFile("AssetBundleNameHashes", AssetsManager.hashedBundleNameList, null, includeIndex: false);

		private void DumpAssetBundleNames()
			=> DumpInfosToFile("AssetBundlesNames",
				((AssetBundleManifest)(FindObjectOfType<AssetBundleManager>()?
					.GetType()
					.GetField("m_AssetBundleManifest", BindingFlags.NonPublic | BindingFlags.Static)
					.GetValue(null)))?
						.GetAllAssetBundles().ToList(), null, includeIndex: false);

		private void DumpAssetBundleNamesWithVariant()
			=> DumpInfosToFile("AssetBundlesWithVariant",
				((AssetBundleManifest)(FindObjectOfType<AssetBundleManager>()?
					.GetType()
					.GetField("m_AssetBundleManifest", BindingFlags.NonPublic | BindingFlags.Static)
					.GetValue(null)))?
						.GetAllAssetBundlesWithVariant().ToList(), null, includeIndex: false);


		private void DumpUserCharacterEvent()
		{
			var userCharacterEvents = new List<UserCharacterEvent>();

			if (QuickAccess.User != null)
			{
				foreach (var characterEvent in GameConfiguration.Instance?.characterEventsInfos)
				{
					if (QuickAccess.User.characterEventManager.TryGetCharacterEvent(characterEvent.Value.ID, out var userCharacterEvent))
					{
						userCharacterEvents.Add(userCharacterEvent);
					}
				}
			}

			DumpInfosToFile("UserCharacterEvents", userCharacterEvents, value => DumpUtils.Dump(value));
		}

		private void DumpUserHeroes()
			=> DumpInfosToFile("UserHeroes", QuickAccess.User?.heroes, (value) => $"{LanguageManager.instance.GetText("hero_name_" + value.HeroDBO.id, null, null)} / {LanguageManager.instance?.GetText("hero_title_" + value.HeroDBO?.id, null, null)} / {DumpUtils.Dump(value)}");

		private void DumpUserIcons()
			=> DumpInfosToFile("UserIcons", QuickAccess.User?.icons?.ToList());

		private void DumpUserItems()
			=> DumpInfosToFile("UserItems", QuickAccess.User?.items, value => DumpUtils.Dump(value));

		private void DumpUserMaps()
			=> DumpInfosToFile("UserMaps", QuickAccess.User?.maps, value => DumpUtils.Dump(value));

		private void DumpUserObjectives()
			=> DumpInfosToFile("UserObjectives", QuickAccess.User?.objectives, value => DumpUtils.Dump(value));

		private void DumpUserShopItems()
			=> DumpInfosToFile("UserShopItems", QuickAccess.User?.shopItems, value => DumpUtils.Dump(value));

		private void DumpUserStories()
			=> DumpInfosToFile("UserStories", QuickAccess.User?.stories, value => DumpUtils.Dump(value));

		private void DumpUserWorldBoss()
		{ /* TODO? */ }

		private void DumpAbilityEffectInfos()
			=> DumpInfosToFile("AbilityEffectInfos", GameConfiguration.Instance?.abilityEffectInfos, value => DumpUtils.Dump(value));

		private void DumpAbilityInfos()
			=> DumpInfosToFile("AbilityInfos", GameConfiguration.Instance?.abilityInfos, value => DumpUtils.Dump(value));

		private void DumpAchievementInfos()
			=> DumpInfosToFile("AchievementInfos", GameConfiguration.Instance?.achievementInfos, value => DumpUtils.Dump(value));

		private void DumpBuildingInfos()
			=> DumpInfosToFile("BuildingInfos", GameConfiguration.Instance?.buildingInfos, value => DumpUtils.Dump(value));

		private void DumpCampaignGroupsInfos()
			=> DumpInfosToFile("CampaignGroupsInfos", GameConfiguration.Instance?.campaignGroupsInfos, value => DumpUtils.Dump(value));

		private void DumpCampaignInactiveInfos()
			=> DumpInfosToFile("CampaignInactiveInfos", GameConfiguration.Instance?.campaignInactiveInfos, value => DumpUtils.Dump(value));

		private void DumpCharacterEventsGlobalObjectivesInfos()
			=> DumpInfosToFile("CharacterEventsGlobalObjectivesInfos", GameConfiguration.Instance?.characterEventsGlobalObjectivesInfos, value => DumpUtils.Dump(value));

		private void DumpCharacterEventsInfos()
			=> DumpInfosToFile("CharacterEventsInfos", GameConfiguration.Instance?.characterEventsInfos, value => DumpUtils.Dump(value));

		private void DumpCharacterEventsObjectivesInfos()
			=> DumpInfosToFile("CharacterEventsObjectivesInfos", GameConfiguration.Instance?.characterEventsObjectivesInfos, value => DumpUtils.Dump(value));

		private void DumpChunkBlockerInfos()
			=> DumpInfosToFile("ChunkBlockerInfos", GameConfiguration.Instance?.chunkBlockerInfos, value => DumpUtils.Dump(value, kvp => kvp.Key + "=" + DumpUtils.Dump(kvp.Value)));

		private void DumpCraftInfos()
			=> DumpInfosToFile("CraftInfos", GameConfiguration.Instance?.craftInfos, value => DumpUtils.Dump(value));

		private void DumpDailyObjectivesInfos()
			=> DumpInfosToFile("DailyObjectivesInfos", GameConfiguration.Instance?.dailyObjectivesInfos, value => DumpUtils.Dump(value));

		private void DumpEventInfos()
			=> DumpInfosToFile("EventInfos", GameConfiguration.Instance?.eventInfos, value => DumpUtils.Dump(value));

		private void DumpIconInfos()
			=> DumpInfosToFile("IconInfos", GameConfiguration.Instance?.iconInfos, value => DumpUtils.Dump(value));

		private void DumpItemInfos()
			=> DumpInfosToFile("ItemInfos", GameConfiguration.Instance?.itemInfos, value => DumpUtils.Dump(value));

		private void DumpMapInfosAll()
			=> DumpInfosToFile("MapInfosAll", GameConfiguration.Instance?.mapInfosAll, value => DumpUtils.Dump(value));

		private void DumpMasteriesInfos()
			=> DumpInfosToFile("MasteriesInfos", GameConfiguration.Instance?.masteriesInfos, value => DumpUtils.Dump(value));

		private void DumpPvpDivisionInfos()
			=> DumpInfosToFile("PvpDivisionInfos", GameConfiguration.Instance?.pvpDivisionInfos, value => DumpUtils.Dump(value));

		private void DumpQuestInfos()
			=> DumpInfosToFile("QuestInfos", GameConfiguration.Instance?.questInfos, value => DumpUtils.Dump(value));
		
		private void DumpRewardInfos()
			=> DumpInfosToFile("RewardInfos", GameConfiguration.Instance?.rewardInfos, value => DumpUtils.Dump(value));

		private void DumpShopItemsInfos()
			=> DumpInfosToFile("ShopItemsInfos", GameConfiguration.Instance?.shopItemsInfos, value => DumpUtils.Dump(value));

		private void DumpStatsCapInfos()
			=> DumpInfosToFile("StatsCapInfos", GameConfiguration.Instance?.statsCapInfos, value => DumpUtils.Dump(value));

		private void DumpStorySpecialGroupInfos()
			=> DumpInfosToFile("StorySpecialGroupsInfos", GameConfiguration.Instance?.storySpecialGroupsInfos, value => DumpUtils.Dump(value));

		private void DumpStoryInfos()
			=> DumpInfosToFile("StoryInfos", GameConfiguration.Instance?.storyInfos, value => DumpUtils.Dump(value));

		private void DumpWeeklyObjectivesInfos()
			=> DumpInfosToFile("WeeklyObjectivesInfos", GameConfiguration.Instance?.weeklyObjectivesInfos, value => DumpUtils.Dump(value));

		private void DumpHeroesInfos()
			=> DumpInfosToFile("HeroesInfos", GameConfiguration.Instance?.HeroesInfos, (value) => $"{LanguageManager.instance.GetText("hero_name_" + value.id, null, null)} / {LanguageManager.instance.GetText("hero_title_" + value.id, null, null)} / {value}");

		private void DumpGuardianInfos()
			=> DumpInfosToFile("GuardianInfos", GameConfiguration.Instance?.guardianInfos, (value) => $"{LanguageManager.instance.GetText("hero_name_" + value.id, null, null)} / {LanguageManager.instance.GetText("hero_title_" + value.id, null, null)} / {DumpUtils.Dump(value)}");

		private void DumpGalleryInfos()
			=> DumpInfosToFile("GalleryInfos", GameConfiguration.Instance?.galleryInfos, value => DumpUtils.Dump(value));

		private void DumpMaidensInfos()
			=> DumpInfosToFile("MaidensInfos", GameConfiguration.Instance?.maidensInfos, (value) => $"{LanguageManager.instance.GetText("hero_name_" + value.id, null, null)} / {LanguageManager.instance.GetText("hero_title_" + value.id, null, null)} / {DumpUtils.Dump(value)}");

		private void DumpWorldBossEvents()
			=> DumpInfosToFile("WorldBossEvents", GameConfiguration.Instance?.worldBossEvents, (value) => DumpUtils.Dump(value));

		private string DumpBasePath => $"{Application.persistentDataPath}";
		private string InfosDumpPath => $"{DumpBasePath}/Infos";

		private void DumpInfosToFile<T>(string fileName, List<T> dictionary)
			=> DumpInfosToFile(fileName, dictionary, null);

		private void DumpInfosToFile<T>(string fileName, List<T> list, Func<T, string> formatter, bool includeIndex = true)
		{
			if (list is null)
			{
				return;
			}

			if (DumpFormats.Value.HasFlag(DumpFormatTypes.Json))
			{
				var content = "";

				try
				{
					content = JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings
					{
						PreserveReferencesHandling = PreserveReferencesHandling.Objects,
						ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
					});
				}
				catch (Exception ex)
				{
					Debug.LogError(ex.ToString());
				}

				DumpToFile(fileName, content, ".json");
			}

			if (DumpFormats.Value.HasFlag(DumpFormatTypes.PlainText))
			{
				var stringBuilder = new StringBuilder();

				for (var i = 0; i < list.Count; ++i)
				{
					var value = list[i];

					if (includeIndex)
					{
						stringBuilder.Append($"{i + 1} = ");
					}

					stringBuilder.AppendLine($"{(formatter is null ? value : formatter.Invoke(value))}");
				}

				var content = stringBuilder.ToString();

				DumpToFile(fileName, content, ".txt");
			}
		}

		private void DumpInfosToFile<TKey, TValue>(string fileName, Dictionary<TKey, TValue> dictionary)
			=> DumpInfosToFile(fileName, dictionary, null);

		private void DumpInfosToFile<TKey, TValue>(string fileName, Dictionary<TKey, TValue> dictionary, Func<TValue, string> formatter, bool includeKey = true)
		{
			if (dictionary is null)
			{
				return;
			}

			if (DumpFormats.Value.HasFlag(DumpFormatTypes.Json))
			{
				var content = "";

				try
				{
					content = JsonConvert.SerializeObject(dictionary, Formatting.Indented, new JsonSerializerSettings
					{
						PreserveReferencesHandling = PreserveReferencesHandling.Objects,
						ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
					});
				}
				catch (Exception ex)
				{
					Debug.LogError(ex.ToString());
				}

				DumpToFile(fileName, content, ".json");
			}

			if (DumpFormats.Value.HasFlag(DumpFormatTypes.PlainText))
			{
				var stringBuilder = new StringBuilder();

				foreach (var kvp in dictionary)
				{
					if (includeKey)
					{
						stringBuilder.Append($"{kvp.Key} = ");
					}

					stringBuilder.AppendLine($"{(formatter is null ? kvp.Value : formatter.Invoke(kvp.Value))}");
				}

				var content = stringBuilder.ToString();

				DumpToFile(fileName, content, ".txt");
			}
		}

		private void DumpToFile(string fileName, string content, string fileExtension)
		{
			var path = Path.ChangeExtension($"{InfosDumpPath}/{fileName}", fileExtension);

			Directory.CreateDirectory(Path.GetDirectoryName(path));
			File.WriteAllText(path, content);
		}

		private void IncreaseFlirtLevel()
			=> GetCurrentHero().FlirtLevel = (byte)Math.Min(15, GetCurrentHero().FlirtLevel + 1);

		private void DecreaseFlirtLevel()
			=> GetCurrentHero().FlirtLevel = (byte)Math.Max(0, GetCurrentHero().FlirtLevel - 1);

		private void ForceShowMaidenPreviewImage(int romanceLevel)
		{
			var panel = FindObjectOfType<PanelHeroDescription>();

			if (panel is null)
			{
				return;
			}

			try { panel.GetType().GetMethod("ShowPromotePanel", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(panel, new object[] { }); } catch { }
			try { panel.GetType().GetMethod("ShowHeroScenesButtonsPanel", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(panel, new object[] { romanceLevel }); } catch { }

			ShowMaidenPreviewImageAndRomanceLocks(romanceLevel);

			((Button)GameObject.FindObjectOfType<PanelHeroDescription>().GetType().GetField("viewScenesButton", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(GameObject.FindObjectOfType<PanelHeroDescription>())).onClick.RemoveAllListeners();
			((Button)GameObject.FindObjectOfType<PanelHeroDescription>().GetType().GetField("viewScenesButton", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(GameObject.FindObjectOfType<PanelHeroDescription>())).onClick.AddListener(delegate ()
			{
				OnViewRomanceStoryClicked(romanceLevel);
			});

			ShowRomanceLocks(false);
			ShowViewScenesButton(true);
			ShowFavoriteToggle(true);
			ShowViewScenesButton(true);
			ShowScenesUIElements(true);
			ShowPromotePanel(true);
			ShowGalleryButton(true);
			ShowDarkOverlays(false);
			ResetMaidenPreviewImageColor();

			ShowRomanceButton(false);
			ShowAvailabilityPanel(false);
			ShowGetMoreMaidensButton(false);

			panel.currentUserHero.selectedMaidenImage = (uint)romanceLevel;
			this.Execute(new SwitchSelectedUserHeroMaidenImageCommand(panel.currentUserHero));
		}

		private void ShowMaidenPreviewImageAndRomanceLocks(int romanceLevel)
			=> ShowMaidenPreviewImageAndRomanceLocks(romanceLevel, false);

		private void ShowMaidenPreviewImageAndRomanceLocks(int romanceLevel, bool justGotPromoted)
			=> FindObjectOfType<PanelHeroDescription>()?
				.ShowHeroPicturesAndLocks(romanceLevel, justGotPromoted);

		private void ResetMaidenPreviewImageColor()
			=> ((Image)FindObjectOfType<PanelHeroDescription>()?
				.GetType()
				.GetField("_heroImage", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelHeroDescription>()))?
					.SetColor(Color.white);

		private static readonly string[] heroDarkBackgrounds = new string[]
		{
			"maidenDescDarkBg",
			"leftStatsDarkBg",
			"rightStatsDarkBg",
			"skillDescDarkBg",
			"skillSliderDarkBg",
			"basicAttackDarkPanel",
			"passiveDarkPanel",
			"equipHeadDarkBg",
			"equipArmorDarkBg",
			"equipWeaponDarkBg",
			"equipShieldDarkBg",
			"equipFeetDarkBg",
			"equipAccessoryDarkBg",
			"MasteriesLockedImage"
		};

		private void ShowDarkOverlays(bool show)
		{
			foreach (var darkBg in heroDarkBackgrounds)
			{
				((GameObject)FindObjectOfType<PanelHeroDescription>()?
					.GetType()
					.GetField(darkBg, BindingFlags.NonPublic | BindingFlags.Instance)
					.GetValue(FindObjectOfType<PanelHeroDescription>()))?
						.SetActive(show);
			}
		}

		private void ShowRomanceLocks(bool show)
			=> ((Transform)FindObjectOfType<PanelHeroDescription>()?
				.GetType()
				.GetField("romanceLocksParent", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelHeroDescription>()))?
					.gameObject.SetActive(show);

		private void ShowFavoriteToggle(bool show)
			=> ((Toggle)FindObjectOfType<PanelHeroDescription>()?
				.GetType()
				.GetField("favoriteToggle", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelHeroDescription>()))?
					.gameObject.SetActive(show);

		private void ShowViewScenesButton(bool show)
			=> ((Button)FindObjectOfType<PanelHeroDescription>()?
				.GetType()
				.GetField("viewScenesButton", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelHeroDescription>()))?
					.gameObject.SetActive(show);

		private void ShowScenesUIElements(bool show)
			=> ((Transform)FindObjectOfType<PanelHeroDescription>()?
				.GetType()
				.GetField("scenesButtonsParent", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelHeroDescription>()))?
					.gameObject.SetActive(show);

		private void ShowPromotePanel(bool show)
			=> ((GameObject)FindObjectOfType<PanelHeroDescription>()?
				.GetType()
				.GetField("promotePanel", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelHeroDescription>()))?
					.gameObject.SetActive(show);

		private void ShowAvailabilityPanel(bool show)
			=> ((GameObject)FindObjectOfType<PanelHeroDescription>()?
				.GetType()
				.GetField("availabilityPanel", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelHeroDescription>()))?
					.gameObject.SetActive(show);

		private void ShowGalleryButton(bool show)
			=> ((Button)FindObjectOfType<PanelHeroDescription>()?
				.GetType()
				.GetField("galleryButton", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelHeroDescription>()))?
					.gameObject.SetActive(show);

		private void ShowRomanceButton(bool show)
			=> ((Button)FindObjectOfType<PanelHeroDescription>()?
				.GetType()
				.GetField("romanceButton", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelHeroDescription>()))?
					.gameObject.SetActive(show);

		private void ShowGetMoreMaidensButton(bool show)
			=> ((Button)FindObjectOfType<PanelHeroDescription>()?
				.GetType()
				.GetField("getMoreMaidensButton", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelHeroDescription>()))?
					.gameObject.SetActive(show);

		private void ForceShowGuardianPreviewImage(int romanceLevel)
		{
			var panel = FindObjectOfType<PanelGuardianDescription>();

			if (panel is null)
			{
				return;
			}

			try { panel.GetType().GetMethod("SetHeroPromotionsPanel", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(panel, new object[] { true }); } catch { }
			try { panel.GetType().GetMethod("ShowHeroScenesButtonsPanel", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(panel, new object[] { romanceLevel }); } catch { }

			ShowGuardianPreviewImageAndRomanceLocks(romanceLevel);

			((Button)panel.GetType().GetField("viewScenesButton", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(panel)).onClick.RemoveAllListeners();
			((Button)panel.GetType().GetField("viewScenesButton", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(panel)).onClick.AddListener(delegate ()
			{
				OnViewRomanceStoryClicked(romanceLevel);
			});

			ShowGuardianRomanceLocks(false);
			ShowGuardianViewScenesButton(true);
			ShowGuardianFavoriteToggle(true);
			ShowGuardianViewScenesButton(true);
			ShowGuardianScenesUIElements(true);
			ShowGuardianPromotePanel(true);
			//ShowGuardianGalleryButton(true);

			ShowGuardianRomanceButton(false);
			ShowGuardianTemporaryAvailabilityPanel(false);
			ShowGuardianUnavailabilityPanel(false);
			ShowGuardianDarkOverlays(false);
			ResetGuardianPreviewImageColor();

			var currentUserHero = GetCurrentGuardianHero();

			currentUserHero.selectedMaidenImage = (uint)romanceLevel;
			this.Execute(new SwitchSelectedUserHeroMaidenImageCommand(currentUserHero));
			//((UserHero)panel.GetType().GetField("currentUserHero", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(panel)).selectedMaidenImage = (uint)romanceLevel;
			//this.Execute(new SwitchSelectedUserHeroMaidenImageCommand(((UserHero)panel.GetType().GetField("currentUserHero", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(panel))));
		}

		private void ShowGuardianPreviewImageAndRomanceLocks(int romanceLevel)
			=> ShowGuardianPreviewImageAndRomanceLocks(romanceLevel, false);

		private void ShowGuardianPreviewImageAndRomanceLocks(int romanceLevel, bool justGotPromoted)
			=> FindObjectOfType<PanelGuardianDescription>()?
				.ShowHeroPicturesAndLocks(romanceLevel, justGotPromoted);

		private void ResetGuardianPreviewImageColor()
			=> ((Image)FindObjectOfType<PanelGuardianDescription>()?
				.GetType()
				.GetField("guardianImage", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelGuardianDescription>()))?
					.SetColor(Color.white);

		private static readonly string[] GuardianDarkBackgrounds = new string[]
		{
			"maidenDescDarkBg",
			"leftStatsDarkBg",
			"rightStatsDarkBg"
		};

		private void ShowGuardianDarkOverlays(bool show)
		{
			foreach (var darkBg in GuardianDarkBackgrounds)
			{
				((GameObject)FindObjectOfType<PanelGuardianDescription>()?
					.GetType()
					.GetField(darkBg, BindingFlags.NonPublic | BindingFlags.Instance)
					.GetValue(FindObjectOfType<PanelGuardianDescription>()))?
						.SetActive(show);
			}
		}

		private void ShowGuardianRomanceLocks(bool show)
			=> ((Transform)FindObjectOfType<PanelGuardianDescription>()?
				.GetType()
				.GetField("romanceLocksParent", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelGuardianDescription>()))?
					.gameObject.SetActive(show);

		private void ShowGuardianFavoriteToggle(bool show)
			=> ((Toggle)FindObjectOfType<PanelGuardianDescription>()?
				.GetType()
				.GetField("favoriteToggle", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelGuardianDescription>()))?
					.gameObject.SetActive(show);

		private void ShowGuardianViewScenesButton(bool show)
			=> ((Button)FindObjectOfType<PanelGuardianDescription>()?
				.GetType()
				.GetField("viewScenesButton", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelGuardianDescription>()))?
					.gameObject.SetActive(show);

		private void ShowGuardianScenesUIElements(bool show)
			=> ((Transform)FindObjectOfType<PanelGuardianDescription>()?
				.GetType()
				.GetField("scenesButtonsParent", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelGuardianDescription>()))?
					.gameObject.SetActive(show);

		private void ShowGuardianPromotePanel(bool show)
			=> ((GameObject)FindObjectOfType<PanelGuardianDescription>()?
				.GetType()
				.GetField("promotePanel", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelGuardianDescription>()))?
					.gameObject.SetActive(show);

		private void ShowGuardianTemporaryAvailabilityPanel(bool show)
			=> ((GameObject)FindObjectOfType<PanelGuardianDescription>()?
				.GetType()
				.GetField("temporarilyAvailablePanel", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelGuardianDescription>()))?
					.gameObject.SetActive(show);

		private void ShowGuardianUnavailabilityPanel(bool show)
			=> ((GameObject)FindObjectOfType<PanelGuardianDescription>()?
				.GetType()
				.GetField("currentlyUnavailablePanel", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelGuardianDescription>()))?
					.gameObject.SetActive(show);

		private void ShowGuardianRomanceButton(bool show)
			=> ((Button)FindObjectOfType<PanelGuardianDescription>()?
				.GetType()
				.GetField("romanceButton", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelGuardianDescription>()))?
					.gameObject.SetActive(show);

		private void ForceShowGalleryScene(int sceneIndex)
		{
			var panel = FindObjectOfType<PanelGallery>();

			if (panel is null)
			{
				return;
			}

			// TODO
		}

		private void ForceSelectAlbumStory(int sceneIndex)
		{
			//try { panel.GetType().GetMethod("AlbumStoryButtonValidationClicked", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(panel, new object[] { (BaseListElement<StoryDBObject>)??? }); } catch { }
			//try { panel.GetType().GetMethod("SetAlbumStoryClicked", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(panel, new object[] { (BaseListElement<StoryDBObject>)??? }); } catch { }
			//try { panel.GetType().GetMethod("OnWatchButtonClicked", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(panel, new object[] { }); } catch { }

			var panel = FindObjectOfType<PanelAlbum>();

			if (panel is null)
			{
				return;
			}

			ShowAlbumToggleSexButton(true);
			ShowAlbumWatchButton(true);
			ShowAlbumDescriptionPanel(true);
			//ShowAlbumBuyButton(true);

			foreach (var toggle in ((Transform)panel.GetType().GetField("_contextButtons", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(panel)).GetComponentsInChildren<Toggle>())
			{
				toggle.interactable = true;
			}

			if (currentAlbumStoryGroupElement is null)
			{
				SelectFirstAlbumStoryGroup();
			}

			ActivateSelectedAlbumStory(sceneIndex);
		}

		private void ActivateSelectedAlbumStory(int sceneIndex)
			=> FindObjectOfType<PanelAlbum>()?
				.AlbumStoryButtonValidationClicked(currentAlbumStoryGroupElement?
					.GetComponentInChildren<AlbumStoryGridParent>()?
						.GetWidgets()?[sceneIndex]);

		private void SelectNextAlbumStoryGroup()
			=> SelectNextAlbumStoryGroup(wrapAround: true);

		private void SelectNextAlbumStoryGroup(bool wrapAround)
		{
			if (currentAlbumStoryGroupElement is null)
			{
				SelectFirstAlbumStoryGroup();
				return;
			}

			var items = FindObjectsOfType<AlbumStoryGroupElement>();
			var index = currentAlbumStoryGroupElement.transform.GetSiblingIndex();

			if (index < items.Length - 1)
			{
				currentAlbumStoryGroupElement = items[index + 1];
			}
			else if (wrapAround)
			{
				SelectFirstAlbumStoryGroup();
			}
		}

		private void SelectPreviousAlbumStoryGroup()
			=> SelectPreviousAlbumStoryGroup(wrapAround: false);

		private void SelectPreviousAlbumStoryGroup(bool wrapAround)
		{
			if (currentAlbumStoryGroupElement is null)
			{
				SelectFirstAlbumStoryGroup();
				return;
			}

			var items = FindObjectsOfType<AlbumStoryGroupElement>();
			var index = currentAlbumStoryGroupElement.transform.GetSiblingIndex();

			if (index > 0)
			{
				currentAlbumStoryGroupElement = items[index - 1];
			}
			else if (wrapAround)
			{
				SelectLastAlbumStoryGroup();
			}
		}

		private void SelectFirstAlbumStoryGroup()
			=> currentAlbumStoryGroupElement = FindObjectsOfType<AlbumStoryGroupElement>().First();

		private void SelectLastAlbumStoryGroup()
			=> currentAlbumStoryGroupElement = FindObjectsOfType<AlbumStoryGroupElement>().Last();

		private AlbumStoryGroupElement currentAlbumStoryGroupElement;

		private void OnViewRomanceStoryClicked(int romanceLevel)
		{
			var panel = (Panel)FindObjectOfType<PanelHeroDescription>() ?? FindObjectOfType<PanelGuardianDescription>();
			var currentHeroDefinition = GetCurrentHeroDefinition() ?? GetGuardianCurrentHeroDefinition();

			if (currentHeroDefinition != null)
			{
				string text = LanguageManager.instance.GetText("hero_name_" + currentHeroDefinition.id, null, null);

				Assets.Main.Scripts.DDNAHelper.RecordRomance("ViewStoryButton", romanceLevel.ToString(), currentHeroDefinition.id.ToString(), text);
			}

			var viewScenesButtons = (Button)panel
				.GetType()
				.GetField("viewScenesButton", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(panel);

			this.Publish(new OnSelectButtonPressed(viewScenesButtons));

			if (currentHeroDefinition != null)
			{
				var storyType = romanceLevel switch
				{
					1 => StoryDBObject.StoryType.PROMOTION1COMPLETED,
					2 => StoryDBObject.StoryType.PROMOTION2COMPLETED,
					3 => StoryDBObject.StoryType.PROMOTION3COMPLETED,
					4 => StoryDBObject.StoryType.PROMOTION4COMPLETED,
					5 => StoryDBObject.StoryType.PROMOTION5COMPLETED,
					_ => StoryDBObject.StoryType.UNLOCKHERO,
				};

				this.Execute(new PlayStoryCommand(storyType, (int)currentHeroDefinition.id, delegate () { }, false));
			}
		}

		private void UnlockCurrentMaiden()
		{
			var currentUserHero = GetCurrentHero();

			if (currentUserHero is null)
			{
				var currentHeroDefinition = GetCurrentHeroDefinition() ?? GetGuardianCurrentHeroDefinition();
				// NOTE: don't know what number to give it...
				var userHeroID = currentHeroDefinition.id;

				currentUserHero = CreateUserHero(userHeroID, currentHeroDefinition.id);

				if (currentUserHero != null)
				{
					QuickAccess.User.heroes[currentHeroDefinition.id] = currentUserHero;

					Debug.Log($"Created {currentHeroDefinition.id}: {LanguageManager.instance.GetText("hero_name_" + currentHeroDefinition.id)}");
				}
				else
				{
					Debug.Log($"Ignored {currentHeroDefinition.id}: {LanguageManager.instance.GetText("hero_name_" + currentHeroDefinition.id)}");
				}
			}
			else
			{
				currentUserHero.Locked = false;

				Debug.Log($"Unlocked {currentUserHero.HeroDBO.id}: {LanguageManager.instance.GetText("hero_name_" + currentUserHero.HeroDBO.id)}");
			}

			//ApplyMaidenMaxLevel(currentUserHero);
		}

		public void UnlockAllHeroes()
		{
			using (new NotificationChangeScope<OnUserHeroPowerRatingChangedEvent>(enable: false))
			{
				foreach (var kvp in GameConfiguration.Instance.HeroesInfos)
				{
					try
					{
						var userHero = QuickAccess.User.GetHeroByID(kvp.Key);

						if (userHero is null
							|| !QuickAccess.User.HeroesInfos.TryGetValue(kvp.Key, out var result))
						{
							// NOTE: don't know what number to give it...
							userHero = CreateUserHero(kvp.Key, kvp.Key);

							if (userHero != null)
							{
								QuickAccess.User.AddNewUserHero(userHero);

								Debug.Log($"Created {kvp.Key}: {LanguageManager.instance.GetText("hero_name_" + kvp.Key)}");
							}
							else
							{
								Debug.Log($"Ignored {kvp.Key}: {LanguageManager.instance.GetText("hero_name_" + kvp.Key)}");
							}
						}
						else
						{
							userHero.Locked = false;

							Debug.Log($"Unlocked {kvp.Key}: {LanguageManager.instance.GetText("hero_name_" + kvp.Key)}");
						}

						ApplyMaidenMaxLevel(userHero);
					}
					catch //(Exception ex)
					{
						//Debug.LogWarning(ex);
					}
				}
			}
		}

		private static readonly List<RangeInt> knownMaidenHeroIdRanges = new()
		{
			new RangeInt(1, 159)
		};

		private static readonly List<RangeInt> knownGuardianHeroIdRanges = new()
		{
			new RangeInt(7001, 8)
		};

		private static UserHero CreateUserHero(uint num, uint key)
		{
			var skip = true;

			if (HeroUnlockFilter.Value.HasFlag(HeroFilterType.Maiden))
			{
				if (knownMaidenHeroIdRanges.Any(that => key >= that.start && key <= that.end - 1))
				{
					skip = false;
				}
			}

			if (HeroUnlockFilter.Value.HasFlag(HeroFilterType.Guardian))
			{
				if (knownGuardianHeroIdRanges.Any(that => key >= that.start && key <= that.end - 1))
				{
					skip = false;
				}
			}

			if (skip)
			{
				if (!HeroUnlockFilter.Value.HasFlag(HeroFilterType.Other))
				{
					return null;
				}
			}

			var userHero = new UserHero(GameConfiguration.Instance.HeroesInfos[key], flirtLevel: 0, skillLevel: 0)	//15,30
			{
				id = num
			};

			userHero.SetExperience(user: null, newExperience: 0U);  //46400000U
			userHero.SkillExperience = 0;
			userHero.endlessTowerHealth = 10000;
			userHero.endlessTowerRoundCount = 0;
			userHero.shardExperience = 0;   //99999
			userHero.selectedMaidenImage = 0;
			userHero.selectedItemPreset = 1;
			userHero.freeMasteryRespecs = 0;
			userHero.Locked = false;
			userHero.equippedItems = new Dictionary<ItemType, uint>();
			userHero.nextStaminaPoint = null;
			userHero.refreshedTimes = 0;
			userHero.staminaPoints = 5;
			userHero.isFavorite = false;
			userHero.userHeroMasteryManager = new UserHeroMasteryManager(key);
			userHero.userHeroItemPresetManager = new UserHeroItemPresetManager();

			return userHero;
		}

		private static HeroDBObject GetCurrentHeroDefinition()
			=> (HeroDBObject)(FindObjectOfType<PanelHeroDescription>()?
				.GetType()
				.GetField("currentHeroDefinition", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelHeroDescription>()));

		private static HeroDBObject GetGuardianCurrentHeroDefinition()
			=> (HeroDBObject)(FindObjectOfType<PanelGuardianDescription>()?
				.GetType()
				.GetField("currentHeroDefinition", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(FindObjectOfType<PanelGuardianDescription>()));

		private static UserHero GetCurrentHero()
		{
			var panel = FindObjectOfType<PanelHeroDescription>();

			if (panel is null)
			{
				return null;
			}

			var currentUserHero = panel.currentUserHero;

			if (currentUserHero is null)
			{
				var currentHeroDefinition = (HeroDBObject)(panel
					.GetType()
					.GetField("currentHeroDefinition", BindingFlags.NonPublic | BindingFlags.Instance)
					.GetValue(panel));

				if (currentHeroDefinition is null)
				{
					return null;
				}

				currentUserHero = QuickAccess.User?.GetHeroByID(currentHeroDefinition.id);
			}

			return currentUserHero;
		}

		private static UserHero GetCurrentGuardianHero()
		{
			var panel = FindObjectOfType<PanelGuardianDescription>();

			if (panel is null)
			{
				return null;
			}

			var currentUserHero = (UserHero)(panel
				.GetType()
				.GetField("currentUserHero", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(panel));

			if (currentUserHero is null)
			{
				var currentHeroDefinition = (HeroDBObject)(panel
					.GetType()
					.GetField("currentHeroDefinition", BindingFlags.NonPublic | BindingFlags.Instance)
					.GetValue(panel));

				if (currentHeroDefinition is null)
				{
					return null;
				}

				currentUserHero = QuickAccess.User?.GetHeroByID(currentHeroDefinition.id);
			}

			return currentUserHero;
		}
	}
}
