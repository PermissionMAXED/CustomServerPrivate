using System;
using UnityEngine;

namespace LevelEditor
{
	[ExecuteInEditMode]
	public class EditorThumbnailCameraScript : MonoBehaviour
	{
		[Serializable]
		public class CameraSettings
		{
			public bool ortographic;

			public Vector3 rotation;
		}

		public const int prefabLayer = 2;

		public int thumbResolution;

		[SerializeField]
		public Camera snapshotCamera;

		[SerializeField]
		public CameraSettings defaultCamSettings;

		public void Awake()
		{
		}

		public Texture2D GetPrefabThumbnail(GameObject prefab)
		{
			return null;
		}

		public void ApplyDefaultCameraSettings()
		{
		}

		public void ApplyCameraSettings(CameraSettings camSettings)
		{
		}

		public Texture2D TakeSnapshot(GameObject subject)
		{
			return null;
		}

		public void SetLayerRecursively(Transform transform, int layer)
		{
		}
	}
}
