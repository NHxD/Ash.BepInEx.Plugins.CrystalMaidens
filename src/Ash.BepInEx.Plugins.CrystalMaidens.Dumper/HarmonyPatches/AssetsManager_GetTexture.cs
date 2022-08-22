using Ash.BepInEx.Plugins.CrystalMaidens.Dumper.Utils;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Ash.BepInEx.Plugins.CrystalMaidens.Dumper.HarmonyPatches
{
	[HarmonyPatch(typeof(AssetsManager), "GetTexture", new Type[] { typeof(string), typeof(Action<Texture2D, object>), typeof(bool), typeof(object) })]
	public class AssetsManager_GetTexture
	{
		public static bool Prefix(AssetsManager __instance, string path, Action<Texture2D, object> textureCallback, bool addToCache, object data = null)
		{
			if (Plugin.DumpImagesOnLoad.Value)
			{
				Debug.Log($"AssetsManager.GetTexture: {addToCache} | {path} | {AssetsManager.HashPath(path)}");

				var hashedPath = AssetsManager.HashPath(path);
				var trimmedPath = path.TrimStart(new char[] { '/' });
				var splitPath = trimmedPath.Split(new char[] { '/' }, 2);

				if (splitPath.Length == 2)
				{
					void callback(List<Texture2D> textureList, object userParam)
					{
						if (textureList.Count == 0)
						{
							return;
						}

						var result = textureList.First<Texture2D>();

						if (result is null || result.width == 0)
						{
							return;
						}

						Texture2D texture = null;

						try
						{
							var path = TextureUtils.GetExportPath(trimmedPath);

							if (!File.Exists(path))
							{
								texture = TextureUtils.CopyTexture(result);
								var bytes = TextureUtils.EncodeBasedOnFileExtension(texture, trimmedPath);

								Directory.CreateDirectory(Path.GetDirectoryName(path));
								File.WriteAllBytes(path, bytes);

								//Debug.Log($"Exported texture {path}");
							}
							else
							{
								//Debug.Log($"Skipped texture {path}");
							}
						}
						catch (Exception ex)
						{
							Debug.Log($"{ex}");

							// annoyingly close everything to notify user that the game is out of video memory.
							Plugin.CloseAllPanels();
						}
						finally
						{
							Texture2D.Destroy(texture);
						}
					}

					AssetsManager.Instance.Get<Texture2D>(hashedPath, callback, false, data, "");
				}
			}

			return true;
		}
	}
}
