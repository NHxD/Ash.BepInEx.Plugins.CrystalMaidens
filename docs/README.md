
This client mod for the video game Crystal Maidens (NSFW: [Steam](https://store.steampowered.com/app/957830/Crystal_Maidens/), [Nutaku](https://www.nutaku.net/games/crystal-maidens/), [DMM](https://games.dmm.co.jp/detail/crystalmaidens/)) can be used to dump game assets, databases, and unlock various things.

## Installation

1. Download [BepInEx v5.4.21.0 (x86)](https://github.com/BepInEx/BepInEx/releases/download/v5.4.21/BepInEx_x86_5.4.21.0.zip)
2. Extract its contents to your game root folder (e.g., `C:\Program Files (x86)\Steam\steamapps\common\Crystal Maidens\`)
3. (Optional) Download the latest version of BepInEx Configuration Manager from its [releases](https://github.com/BepInEx/BepInEx.ConfigurationManager/releases) page
4. (Optional) Extract its contents to your game root folder
5. Download the latest version of the mod from the [releases](https://github.com/NHxD/Ash.BepInEx.Plugins.CrystalMaidens/releases) page
6. Extract its contents to your game root folder
7. If all done correctly, you should now have a `\Crystal Maidens\BepInEx\plugins\Ash.BepInEx.Plugins.CrystalMaidens.Dumper\` subfolder
8. Start the game

## Example Usage

- Press `F1` to configure mod settings (only if you installed the Configuration Manager described above)
- Press `U` + `LeftShift` + `LeftControl` (by default) to unlock every maidens and guardians (note that it'll take a couple of seconds to actually unlock everything)
- Press `D` + `LeftControl` (by default) to dump the game databases and user info to `%APPDATA%/LocalLow/SuperHippo/Crystal Maidens/Infos`
- Enable `Dump Images On Load`, open the maiden panel, select a maiden, and play one of her scene, the associated image assets will be dumped to `%APPDATA%/LocalLow/SuperHippo/Crystal Maidens/Exported` (by default).

> When dumping databases, asset bundles URLs will be dumped to `%APPDATA%/LocalLow/SuperHippo/Crystal Maidens/AssetBundlesUrls.txt` and a batch script will also be created in `%APPDATA%/LocalLow/SuperHippo/Crystal Maidens/AssetBundlesDownloadWithCurl.cmd`, you can run this if you want to download every asset bundle

## Notes

- Some commands aren't actually implemented because they're redundant
- Story unlocking works but lacks visual cues so it can be a bit awkward to use
- Origin switching / hero / item filtering is bugged in this release (it was previously working...)

## Shortcuts

| Name          | Description   | Default Value |
| ------------- | ------------- | ------------- |
| Dump All Database Objects | Shortcut to dump all database infos to folder `%APPDATA%/LocalLow/SuperHippo/Crystal Maidens/Infos` | `D` + `LeftControl` |
| Close Top-Most Panel | Shortcut to close active panel | `W` + `LeftControl` |
| Toggle Maidens Panel | Shortcut to toggle the maidens panel | `M` + `LeftControl` |
| Toggle Gallery Panel | Shortcut to toggle the gallery panel | `G` + `LeftControl` |
| Toggle Avatar Panel | Shortcut to toggle the avatar panel | `I` + `LeftControl` |
| Toggle Inventory Panel | Shortcut to toggle the inventory panel | `I` + `LeftControl` |
| Toggle Boss Crafting Panel | Shortcut to toggle the boss crafting panel | `X` + `LeftControl` |
| Toggle Shop Panel | Shortcut to toggle the shop panel | `S` + `LeftControl` |
| Toggle Campaign Panel | Shortcut to toggle the campaign panel | `C` + `LeftControl` |
| Toggle Arena Panel | Shortcut to toggle the arena panel | `A` + `LeftControl` |
| Toggle Boss Panel | Shortcut to toggle the boss panel | `B` + `LeftControl` |
| Toggle Portal Panel | Shortcut to toggle the portal panel | `P` + `LeftControl` |
| Toggle Trophies Panel | Shortcut to toggle the trophies panel | `T` + `LeftControl` |
| Toggle Quests Panel | Shortcut to toggle the quests panel | `Q` + `LeftControl` |
| Toggle Daily Objectives Panel | Shortcut to toggle the daily objectives panel | `O` + `LeftControl` |
| Toggle Daily Reward Panel | Shortcut to toggle the daily reward panel | `R` + `LeftControl` |
| Toggle Daily Login Rewards Panel | Shortcut to toggle the daily login rewards panel | `R` + `LeftControl` |
| Toggle Weekly Events Panel | Shortcut to toggle the E panel | `F` + `LeftControl` |
| Toggle Limited Offers Panel | Shortcut to toggle the limited offers panel | `Y` + `LeftControl` |
| Toggle VIP Panel | Shortcut to toggle the VIP panel | `V` + `LeftControl` |
| Toggle Arena Leaderboard Panel | Shortcut to toggle the arena leaderboard panel | `K` + `LeftControl` |
| Toggle News Panel | Shortcut to toggle the news panel | `N` + `LeftControl` |
| Toggle Settings Panel | Shortcut to toggle the settings panel | `E` + `LeftControl` |
| Open Admin Panel | Shortcut to toggle the admin panel | `BackQuote` + `LeftControl` |
| Unlock All Albums | Shortcut to unlock all albums | `A` + `LeftShift` + `LeftControl` |
| Unlock All Galleries | Shortcut to unlock all galleries | `G` + `LeftShift` + `LeftControl` |
| Unlock All Icons | Shortcut to unlock all icons | `E` + `LeftShift` + `LeftControl` |
| Unlock All Items | Shortcut to unlock all items | `I` + `LeftShift` + `LeftControl` |
| Unlock All Stories | Shortcut to unlock all stories | `S` + `LeftShift` + `LeftControl` |
| Unlock All Heroes | Shortcut to unlock all heroes | `U` + `LeftShift` + `LeftControl` |
| Level Down All Heroes | Shortcut to reset level of all heroes | `L` + `LeftShift` + `LeftControl` + `LeftAlt` |
| Level Max All Heroes | Shortcut to level up all heroes | `L` + `LeftShift` + `LeftControl` |
| Flirt Min All Heroes | Shortcut to reset flirt level of all heroes | `F` + `LeftShift` + `LeftControl` + `LeftAlt` |
| Flirt Max All Heroes | Shortcut to flirt up all heroes | `F` + `LeftShift` + `LeftControl` |
| Unlock Current Hero | Shortcut to unlock currently selected hero | `U` + `LeftControl` |
| Level Down Current Hero | Shortcut to reset level of currently selected hero | `L` + `LeftControl` + `LeftAlt` |
| Level Max Current Hero | Shortcut to level up currently selected hero | `L` + `LeftControl` |
| Flirt Min Current Hero | Shortcut to flirt level of currently selected hero | `F` + `LeftAlt` |
| Flirt Max Current Hero | Shortcut to flirt up currently selected hero | `F` + `LeftControl` |
| Select Romance Image 1 | Shortcut to quickjump to the first romance image | `Alpha1` |
| Select Romance Image 2 | Shortcut to quickjump to the second romance image | `Alpha2` |
| Select Romance Image 3 | Shortcut to quickjump to the third romance image | `Alpha3` |
| Select Romance Image 4 | Shortcut to quickjump to the fourth romance image (if available) | `Alpha4` |
| Select Romance Image 5 | Shortcut to quickjump to the fifth romance image (if available) | `Alpha5` |
| Select Romance Image 6 | Shortcut to quickjump to the sixth romance image (if available) | `Alpha6` |
| View Scene | Shortcut to view the currently selected scene | `Alpha0` |
| Select Previous Hero | Shortcut to jump to previous hero | `Q` |
| Select Next Hero | Shortcut to jump to next hero | `E` |
| Select Previous Album Group | Shortcut to jump to previous album group | `Alpha7` |
| Select Next Album Group | Shortcut to jump to next album group | `Alpha8` |
| Dump All Galleries Assets | Shortcut to save all galleries assets (DO NOT USE) | `D` + `LeftShift` + `LeftControl` |
| Write Usage to File | Shortcut to write usage to `%APPDATA%/LocalLow/SuperHippo/Crystal Maidens` | `F1` + `LeftShift` |

## Variables

| Name          | Description   | Default Value |
| ------------- | ------------- | ------------- |
| Origin | The origin | `All` |
| Hero Unlock Filter | Specifies the type of hero to unlock | `Maiden`, `Guardian` |
| Export With Asset Bundle Name | If enabled, include the bundle name in the export path | `False` |
| Dump Images On Load | If enabled, save images locally as they are being loaded | `False` |
| Database Dump - Formats | The formats to use when dumping databases | `PlainText`, `Json` |
| Database Dump - Item Separator | The delimiter to use to separate items when dumping in plain text | ` \| ` |
| Database Dump - Key/Value Separator | The delimiter to use to separate keys and values when dumping in plain text | `=` |
| Enable Asset Bundle Logging | If enabled, log asset bundle operations | `False` |
| Download All Asset Bundles - Output Directory | The output directory to use when downloading asset bundles | `%APPDATA%/LocalLow/SuperHippo/Crystal Maidens/AssetBundles/` |
| Download All Asset Bundles - CDN | The address to the asset bundles CDN | `https://cdn-crystal-maidens.nutaku.net/streamingassets/Win/` |
| Dump Hashes On Load | If enabled, dump hashes as they are being loaded | `False` |
