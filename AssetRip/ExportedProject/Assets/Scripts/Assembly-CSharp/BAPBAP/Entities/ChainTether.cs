using System;
using System.Runtime.InteropServices;
using BAPBAP.Local;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class ChainTether : NetworkBehaviour
	{
		[SyncVar]
		[NonSerialized]
		public EntityManager sourceChar;

		[SyncVar]
		[NonSerialized]
		public EntityManager target;

		[NonSerialized]
		public float applyTtl;

		[NonSerialized]
		public int applyDamage;

		[NonSerialized]
		public StatusEffectInfo[] applyStatusEffects;

		[NonSerialized]
		public float rangeSqr;

		[NonSerialized]
		public float time;

		[SerializeField]
		public AudioClipData sfxData;

		[NonSerialized]
		public NetworkBehaviourSyncVar ___sourceCharNetId;

		[NonSerialized]
		public NetworkBehaviourSyncVar ___targetNetId;

		public EntityManager NetworksourceChar
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

		public EntityManager Networktarget
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

		public void Initialize(EntityManager sourceChar, EntityManager target, float range, float applyTtl, int applyDamage, StatusEffectInfo[] applyStatusEffects)
		{
		}

		public void Update()
		{
		}

		public void FixedUpdate()
		{
		}

		[Server]
		public void Deactivate()
		{
		}

		[Server]
		public void Apply()
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
