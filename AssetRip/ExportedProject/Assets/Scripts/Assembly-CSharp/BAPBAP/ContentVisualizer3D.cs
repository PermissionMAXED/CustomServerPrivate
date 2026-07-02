using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP
{
	[ExecuteInEditMode]
	public class ContentVisualizer3D : MonoBehaviour
	{
		[Serializable]
		public class VisualizerSettings
		{
			public bool renderShadows;

			public float outlineSize;

			public Color outlineColor;

			public Color lightColor;

			public Vector3 lightDir;

			public float camDistance;

			public float camFoV;

			public Vector3 camEulerRot;

			public Vector3 camPosOffset;

			public VisualizerSettings()
			{
			}

			public VisualizerSettings(VisualizerSettings source)
			{
			}

			public void Reset()
			{
			}
		}

		[Header("Settings")]
		[SerializeField]
		public float cameraDistance;

		[SerializeField]
		public float camFoV;

		[SerializeField]
		public Vector3 camPosOffset;

		public static int prefabLayer;

		[Min(1f)]
		[Header("Thumbnail Settings")]
		[SerializeField]
		public int thumbResolution;

		[Header("References")]
		[SerializeField]
		public Transform rendererPivot;

		[SerializeField]
		public Camera cam;

		[SerializeField]
		public RenderTexture camRenderTexture;

		[NonSerialized]
		public RenderTexture currRenderTexture;

		[NonSerialized]
		public RawImage targetRawImage;

		[NonSerialized]
		public GameObject spawnedViewObj;

		public const string rendererBoundsTab = "3DContentVisBounds";

		public void Awake()
		{
		}

		public void Initialize()
		{
		}

		public void Despawn()
		{
		}

		public void SetEnabled(bool isEnabled)
		{
		}

		public void SetCameraSettings(VisualizerSettings camSettings)
		{
		}

		public void SpawnPrefab(GameObject prefab)
		{
		}

		public void SetPrefabInstance(GameObject instance)
		{
		}

		public void SetCameraPosition()
		{
		}

		public static void SetLayerRecursively(Transform transform)
		{
		}

		public Texture2D GetPrefabThumbnail(GameObject prefab, float camDistance = -1f)
		{
			return null;
		}
	}
}
