using UnityEngine;
using UnityEngine.UI;

namespace Ash.BepInEx.Plugins.CrystalMaidens.Dumper.ExtensionMethods
{
	public static partial class ImageExtensionMethods
	{
		public static void SetColor(this Image image, Color value)
		{
			image.color = value;
		}
	}
}
