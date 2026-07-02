using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor
{
	public static class ReferenceImages
	{
		public class ReferenceImageWrapper
		{
			public List<ReferenceImage> ReferenceImages;

			public ReferenceImageWrapper(List<ReferenceImage> referenceImages)
			{
			}
		}

		[Serializable]
		public class ReferenceImage
		{
			public int selectedRef;

			public float x;

			public float z;

			public float y;

			public float scale;

			public float alpha;

			public float rotation;

			public bool active;

			[NonSerialized]
			public Sprite sprite;

			[NonSerialized]
			public SpriteRenderer spriteRenderer;

			public void SetValuesFromSave(ReferenceImage referenceImage)
			{
			}
		}

		public static bool showReferenceImageGUI;

		public static int saveSlots;

		public static List<ReferenceImage> referenceImages;

		public static GUIContent[] referenceImageContent;

		public static List<Sprite> loadedRefs;

		public static bool showRefsInSimpleView;

		public static Configuration Config => null;

		public static void Initialize()
		{
		}

		public static void SetUpReferenceImageContent()
		{
		}

		public static SpriteRenderer SetupReferenceSpriteRenderer()
		{
			return null;
		}

		public static void SetSpriteRendererLayer(SpriteRenderer spriteRenderer)
		{
		}

		public static void DrawReferenceImageGUI(ReferenceImage reference, int i)
		{
		}

		public static void OnSelectedRefChange(ReferenceImage reference, int newSelectedRef)
		{
		}

		public static void UpdateReferenceSpriteRenderer(ReferenceImage reference)
		{
		}

		public static void DrawRepeatOrRegularButton(ref float floatField, string label, float regularIncrement, float repeatIncrement, float buttonWidth, float buttonHeight, bool repeat)
		{
		}

		public static void DrawSlider(ref float floatField, float leftVal, float rightVal, string label, float roundIncrement, bool round)
		{
		}

		public static void DrawReferenceImagesGUI(bool onDock = false)
		{
		}

		public static void SaveReferenceImages()
		{
		}

		public static void LoadReferenceImages()
		{
		}
	}
}
