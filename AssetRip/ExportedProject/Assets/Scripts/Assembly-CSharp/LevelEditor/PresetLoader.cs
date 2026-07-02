using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor
{
	public static class PresetLoader
	{
		public enum MaterialNames
		{
			White = 0,
			Gray = 1,
			Black = 2,
			Red = 3,
			Blue = 4,
			Green = 5,
			Yellow = 6,
			Purple = 7,
			Orange = 8,
			Pink = 9
		}

		public enum BashObjectNames
		{
			Box = 0,
			Cylinder = 1,
			Sphere = 2,
			Dome = 3,
			Wedge = 4,
			Pyramid = 5,
			Gabled = 6
		}

		public static List<GameObject> presetObjects;

		public static List<Material> presetOpaqueMaterials;

		public static List<Material> presetAlphaOccludedMaterials;

		public static List<GameObject> PresetObjects => null;

		public static List<Material> PresetOpaqueMaterials => null;

		public static List<Material> PresetAlphaOccludedMaterials => null;

		public static void LoadMaterial(string color, bool alphaOccluded, ref List<Material> materials)
		{
		}

		public static void LoadObject(string objectName, ref List<GameObject> objects)
		{
		}
	}
}
