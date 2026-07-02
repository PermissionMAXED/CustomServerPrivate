using System;
using Mirror;
using UnityEngine;
using UnityEngine.Serialization;

namespace BAPBAP.Entities
{
	public class ColliderEnableNet : NetworkBehaviour
	{
		[NonSerialized]
		public float ttl;

		[FormerlySerializedAs("hitboxColliders")]
		[SerializeField]
		public Collider[] colliders;

		[SerializeField]
		public bool doSetEnabled;

		[NonSerialized]
		public float time;

		[NonSerialized]
		public bool isEnabled;

		public override void OnStartServer()
		{
		}

		[ServerCallback]
		public void FixedUpdate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
