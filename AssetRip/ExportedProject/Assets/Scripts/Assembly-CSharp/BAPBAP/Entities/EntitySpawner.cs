using System;
using System.Runtime.InteropServices;
using BAPBAP.Maps;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntitySpawner : NetworkBehaviour, IEntityDataProperty
	{
		[Header("References")]
		[SerializeField]
		public Transform spawnTransform;

		[SerializeField]
		public SpriteRenderer ringRenderer;

		[SerializeField]
		[Header("Spawn Prefabs")]
		public GameObject entityPrefab;

		[SerializeField]
		public float altEntityChance;

		[SerializeField]
		public GameObject altEntityPrefab;

		[SerializeField]
		[Header("Settings")]
		public float respawnDuration;

		[SerializeField]
		public bool pushable;

		[SerializeField]
		public bool consumable;

		[Header("FX")]
		[SerializeField]
		public GameObject spawnVfxPrefab;

		[Header("Editor")]
		[SerializeField]
		public GameObject editorMesh;

		[NonSerialized]
		public GameObject _spawedEntity;

		[NonSerialized]
		public GameObject _currentObj;

		[NonSerialized]
		public bool _nonDamageable;

		[NonSerialized]
		public bool _respawnAble;

		[NonSerialized]
		public bool _hideHpBar;

		[SyncVar(hook = "OnRespawnTimerChanged")]
		[NonSerialized]
		public float _respawnTimer;

		public Action<float, float> _Mirror_SyncVarHookDelegate__respawnTimer;

		public GameObject CurrentObj => null;

		public float Network_respawnTimer
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		public void Awake()
		{
		}

		public void Start()
		{
		}

		[ServerCallback]
		public void Update()
		{
		}

		[Server]
		public void StartCooldown()
		{
		}

		[Server]
		public void SpawnEntity()
		{
		}

		[ClientRpc]
		public void RpcCreateSpawnVfx()
		{
		}

		public void OnRespawnTimerChanged(float oldValue, float newValue)
		{
		}

		public void SetProgressRing(float percentage)
		{
		}

		[ServerCallback]
		public void OnDestroy()
		{
		}

		public virtual string PropertyName()
		{
			return null;
		}

		public MapEntityData.Property.Field[] GetPropertyFields()
		{
			return null;
		}

		public void CopyProperties(IEntityDataProperty _source)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcCreateSpawnVfx()
		{
		}

		public static void InvokeUserCode_RpcCreateSpawnVfx(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static EntitySpawner()
		{
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
