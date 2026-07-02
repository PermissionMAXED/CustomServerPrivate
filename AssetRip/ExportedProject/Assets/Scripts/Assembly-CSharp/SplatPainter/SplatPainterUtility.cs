using System.Collections.Generic;
using BAPBAP.Maps;
using LevelEditor;
using UnityEngine;

namespace SplatPainter
{
	public static class SplatPainterUtility
	{
		public enum Channels
		{
			Red = 0,
			Green = 1,
			Blue = 2,
			Alpha = 3
		}

		public enum PaintMode
		{
			Normal = 0,
			Flow = 1,
			Biome = 2
		}

		public class SplatTarget
		{
			public GameObject gameObject;

			public Collider collider;

			public MeshFilter meshFilter;

			public MeshRenderer meshRenderer;

			public Material originalMaterial;

			public SplatTarget(GameObject gameObject, Collider collider, MeshFilter meshFilter, MeshRenderer meshRenderer, Material originalMaterial)
			{
			}
		}

		public class ActionPaint : History.Step
		{
			public Color[] prevPixels;

			public Color[] newPixels;

			public Texture2D texture;

			public ActionPaint(Color[] prevPixels, Color[] newPixels, Texture2D texture)
			{
			}

			public void Execute(bool revert)
			{
			}
		}

		public const string splatProperty = "_MaskTex";

		public const string editorResourcesPath = "Assets/Scripts/CustomLibs/SplatMapPainter/Editor/Resources";

		public const string brushesFolder = "/Brushes/";

		public static Material debugMaterial;

		public static string preExistingTextureAssetPath;

		public static Texture2D[] originalBrushes;

		public static List<int> layerNumbers;

		public static Material DebugMaterial => null;

		public static string IsObjectValidToPaint(GameObject go)
		{
			return null;
		}

		public static SplatTarget GetSplatTarget(GameObject go)
		{
			return null;
		}

		public static void DestroyDebugMaterial()
		{
		}

		public static void SoloChannel(Channels channel)
		{
		}

		public static void UnSolo()
		{
		}

		public static void SetDebugTexture(Texture2D texture)
		{
		}

		public static void Paint(Texture2D texture, GameObject targetObj, Texture2D brush, float brushOpacity, bool clampBrush, bool erase, Channels paintChannel, LayerMask paintObjLayer, Ray ray)
		{
		}

		public static void PaintBiome(Texture2D texture, GameObject targetObj, Texture2D brush, int biomeId, BiomeData biomeData, LayerMask paintObjLayer, Ray ray)
		{
		}

		public static void PaintFlow(Texture2D texture, GameObject targetObj, Texture2D brush, float brushOpacity, Vector3 avg, bool clampBrush, bool erase, Channels flowChannel1, Channels flowChannel2, LayerMask paintObjLayer, Ray ray)
		{
		}

		public static Texture2D GetPaintableTexture(Texture2D sourceTexture, int textureSize = -1)
		{
			return null;
		}

		public static void SetTexturePath(string path)
		{
		}

		public static void ClearTexturePath()
		{
		}

		public static void FillTexture(Texture2D tex, Color color)
		{
		}

		public static void Save(Texture2D texture, bool usePreExistingPath)
		{
		}

		public static Texture2D Load(int width, int height)
		{
			return null;
		}

		public static void LoadOriginalBrushes()
		{
		}

		public static void UnloadOriginalBrushes()
		{
		}

		public static Texture2D[] CreateScaledBrushes(int width, int height)
		{
			return null;
		}

		public static void DestroyScaledBrushes(ref Texture2D[] scaledBrushes)
		{
		}

		public static LayerMask LayerMaskField(string label, LayerMask layerMask)
		{
			return default(LayerMask);
		}
	}
}
