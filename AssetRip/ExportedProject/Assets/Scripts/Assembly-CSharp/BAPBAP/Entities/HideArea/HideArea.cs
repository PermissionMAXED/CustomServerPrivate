using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities.HideArea
{
	[DefaultExecutionOrder(0)]
	public class HideArea : MonoBehaviour
	{
		[NonSerialized]
		public BushManager bushManager;

		[NonSerialized]
		public HideAreaBiomeColor biomeColor;

		[Header("References")]
		[SerializeField]
		[Tooltip("Dont create material instances of these materials for bush alpha changes")]
		public Material[] excludedMaterials;

		[SerializeField]
		[Header("Prefabs")]
		public GameObject bushInteractVFXPrefab;

		[Header("Settings")]
		[SerializeField]
		public float hiddenAlpha;

		[NonSerialized]
		public GameObject bushFowOcclusionObj;

		[NonSerialized]
		public float alpha;

		[NonSerialized]
		public bool isTransparent;

		[NonSerialized]
		public float alphaLerpTimer;

		[NonSerialized]
		public float alphaLerpDuration;

		[NonSerialized]
		public Material[] matInstances;

		[NonSerialized]
		public int id;

		[NonSerialized]
		public Bounds bounds;

		public Action<float> onAlphaChanged;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void InitializeMaterials()
		{
		}

		public void OnTriggerEnter(Collider other)
		{
		}

		public void Update()
		{
		}

		public void OnDestroy()
		{
		}

		public void OnBushStateChanged(bool isOnBush)
		{
		}

		public void ToggleTransparent(bool isTransparent)
		{
		}

		public void SetMaterialAlpha(float alpha)
		{
		}

		public void SpawnBushInteractVFX(Vector3 position)
		{
		}
	}
}
