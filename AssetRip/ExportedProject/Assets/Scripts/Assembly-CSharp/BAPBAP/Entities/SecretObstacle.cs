using System;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;
using UnityEngine.Serialization;

namespace BAPBAP.Entities
{
	public class SecretObstacle : NetworkBehaviour
	{
		[SerializeField]
		public MeshFilter meshFilter;

		[SerializeField]
		public CharHpBar charHpBar;

		[SerializeField]
		public BoxCollider collider;

		[SerializeField]
		public Mesh[] meshes;

		[SerializeField]
		[FormerlySerializedAs("explosiveBarrelSpawnerReset")]
		public EntitySpawnerReset entitySpawnerReset;

		[SyncVar(hook = "OnNonDamagableChanged")]
		[NonSerialized]
		public bool _nonDamageable;

		[SyncVar(hook = "OnHideHpBarChanged")]
		[NonSerialized]
		public bool _hideHpBar;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate__nonDamageable;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate__hideHpBar;

		public bool Network_nonDamageable
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public bool Network_hideHpBar
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public void Setup(bool nonDamageable, bool respawnAble, bool hideHpBar)
		{
		}

		public void OnNonDamagableChanged(bool oldValue, bool newValue)
		{
		}

		public void OnHideHpBarChanged(bool oldValue, bool newValue)
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
