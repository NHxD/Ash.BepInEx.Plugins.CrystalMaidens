using HarmonyLib;

namespace Ash.BepInEx.Plugins.CrystalMaidens.Dumper.HarmonyPatches
{
	[HarmonyPatch(typeof(User), "GetOrigin")]
	public class User_GetOrigin
	{
		public static void Postfix(User __instance, ref object __result)
			=> __result = Plugin.Origin.Value;
	}
}
