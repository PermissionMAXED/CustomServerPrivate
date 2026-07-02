using System;
using System.Collections.Generic;
using BAPBAP.Network.EventData;
using UnityEngine;

namespace BAPBAP.Local
{
	public class VfxManager : MonoBehaviour
	{
		[Serializable]
		public class PrefabConfig
		{
			public GameObject prefab;

			public float destroyDelay;
		}

		[SerializeField]
		public PrefabConfig[] vfxPrefabConfigs;

		[NonSerialized]
		public Dictionary<GameObject, int> vfxPrefabToId;

		[NonSerialized]
		public Dictionary<int, List<ActiveVfxData>> activeVfxDataByNetId;

		[SerializeField]
		[Header("Shared Entity Materials")]
		public Material frozenMaterial;

		[SerializeField]
		public Material metalMaterial;

		[SerializeField]
		public Material petrifyMaterial;

		[SerializeField]
		public Material untargetableMaterial;

		[Header("Shared Entity Shaders")]
		[SerializeField]
		public Shader charOpaqueShader;

		[SerializeField]
		public Shader charTransparentShader;

		[SerializeField]
		[Header("Shared Entity Colors")]
		public Color ghostAllyColor;

		[SerializeField]
		public Color ghostEnemyColor;

		[Header("Shared Entity Vfx Prefabs")]
		[SerializeField]
		public GameObject healVFXPrefab;

		[SerializeField]
		public GameObject killedVFXPrefab;

		[SerializeField]
		public GameObject killedVFXLastPlayerPrefab;

		[SerializeField]
		public GameObject charDisconnectFXPrefab;

		[SerializeField]
		public GameObject downedVFXPrefab;

		[SerializeField]
		public GameObject downedLocalFXPrefab;

		[SerializeField]
		public GameObject downedRespawnVfxPrefab;

		[SerializeField]
		public GameObject vfxExecutePrefab;

		[SerializeField]
		public GameObject cementedVfxPrefab;

		[SerializeField]
		public GameObject vfxThornsPrefab;

		[SerializeField]
		public GameObject vfxChainHitPrefab;

		[SerializeField]
		public GameObject vfxAirborneLandPrefab;

		public static VfxManager Instance => null;

		public void Awake()
		{
		}

		public int GetPredVfxId(GameObject prefab)
		{
			return 0;
		}

		public GameObject GetPredVfx(int id)
		{
			return null;
		}

		public int SpawnVfx(VfxEventData eventData, uint netId)
		{
			return 0;
		}

		public void DestroyOldestVfx(VfxEventData eventData, uint netId)
		{
		}

		public bool DestroyVfx(VfxEventData eventData, uint netId)
		{
			return false;
		}

		public GameObject SpawnVfxInstance(GameObject vfxPrefab, Transform parent, Vector3 position, Quaternion rotation, float destroyDelay = 0f)
		{
			return null;
		}

		public GameObject SpawnVfxInstance(GameObject vfxPrefab, Vector3 position, Quaternion rotation, float destroyDelay = 0f)
		{
			return null;
		}

		public void DespawnVfxInstance(GameObject vfxPrefab, GameObject vfxInstance, float delay = 0f)
		{
		}
	}
}
