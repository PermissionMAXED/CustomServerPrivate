using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[RequireComponent(typeof(EntityTriggerboxListener))]
	public class VFXTetherAreaSpawn : NetworkBehaviour
	{
		[NonSerialized]
		public Hitbox hitbox;

		[NonSerialized]
		public EntityTriggerboxListener triggerboxListener;

		[NonSerialized]
		[SyncVar]
		public EntityManager sourceEntity;

		[SerializeField]
		public GameObject tetherPrefab;

		[NonSerialized]
		public Dictionary<EntityManager, VFXTether> spawnedTethers;

		[NonSerialized]
		public NetworkBehaviourSyncVar ___sourceEntityNetId;

		public EntityManager NetworksourceEntity
		{
			get
			{
				return null;
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

		public void OnDisable()
		{
		}

		public void OnEnter(EntityManager entity)
		{
		}

		public void OnExit(EntityManager entity)
		{
		}

		public void SpawnTether(EntityManager entity)
		{
		}

		public void DestroyTether(EntityManager entity)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
