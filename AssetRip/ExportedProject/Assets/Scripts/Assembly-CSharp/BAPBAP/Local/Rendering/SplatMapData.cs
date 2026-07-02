using System;
using UnityEngine;

namespace BAPBAP.Local.Rendering
{
	[Serializable]
	[CreateAssetMenu(fileName = "SplatPaintData", menuName = "Rendering/PaintingSystem/SplatPaintData", order = 1)]
	public class SplatMapData : ScriptableObject
	{
		public string levelName;

		public Texture2D splatMap;

		public static Texture2D NewSplatMapTex(Color[,] colors)
		{
			return null;
		}

		public static Texture2D NewSplatMapTex(Vector2Int size, Color[] colors = null)
		{
			return null;
		}

		public void SetSplatMap(string levelName, Texture2D existingData)
		{
		}

		public static void ClearSplatMap(Texture2D splatMapTex)
		{
		}

		public static Rect GetPixelRectFromLevelRect(Vector2Int centerPos, Vector2Int size)
		{
			return default(Rect);
		}

		public static Rect GetPixelRectFromLevelRect(Rect levelRect)
		{
			return default(Rect);
		}

		public Color[] GetPixelsFromLevelRect(Rect sourceRect)
		{
			return null;
		}

		public void CopyPixels(Rect sourceRect, Rect destinationRect)
		{
		}

		public void CopyPixels(Color[] sourcePixels, Rect destinationRect)
		{
		}

		public Texture2D Resize(Texture2D source, int newWidth, int newHeight)
		{
			return null;
		}
	}
}
