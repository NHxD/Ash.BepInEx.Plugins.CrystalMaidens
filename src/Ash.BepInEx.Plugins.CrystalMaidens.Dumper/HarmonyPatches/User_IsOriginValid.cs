using HarmonyLib;
using System;

namespace Ash.BepInEx.Plugins.CrystalMaidens.Dumper.HarmonyPatches
{
	[HarmonyPatch(typeof(User), "IsOriginValid", new Type[] { typeof(OriginEnum) })]
	public class User_IsOriginValid
	{
		public static void Postfix(User __instance, ref object __result, OriginEnum dataOrigin)
			=> __result = true;// Plugin.Origin.Value == OriginEnum.All || (bool)__result;
	}
}
