using System;
using System.IO;
using UnityEngine;

namespace Ash.BepInEx.Plugins.CrystalMaidens.Dumper.Utils
{
	internal static class TextureUtils
	{
		public static string GetExportPath(string path)
			=> $"{Application.persistentDataPath}/Exported/{(Plugin.ExportWithAssetBundleName.Value ? path : path.Split(new char[] { '/' }, 2)[1])}";

		public static byte[] EncodeBasedOnFileExtension(Texture2D texture, string path)
			=> Path.GetExtension(path).Equals(".png", StringComparison.OrdinalIgnoreCase)
			? ImageConversion.EncodeToPNG(texture)
			: ImageConversion.EncodeToJPG(texture);

		public static Texture2D CopyTexture(Texture2D sourceTexture)
		{
			if (sourceTexture is null)
			{
				return null;
			}

			var textureCopy = new Texture2D(sourceTexture.width, sourceTexture.height);
			var tempRenderTexture = RenderTexture.GetTemporary(sourceTexture.width, sourceTexture.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);

			Graphics.Blit(sourceTexture, tempRenderTexture);

			RenderTexture previous = RenderTexture.active;
			RenderTexture.active = tempRenderTexture;

			textureCopy.ReadPixels(new Rect(0, 0, tempRenderTexture.width, tempRenderTexture.height), 0, 0);
			textureCopy.Apply();

			RenderTexture.active = previous;
			RenderTexture.ReleaseTemporary(tempRenderTexture);

			return textureCopy;
		}
	}
}
