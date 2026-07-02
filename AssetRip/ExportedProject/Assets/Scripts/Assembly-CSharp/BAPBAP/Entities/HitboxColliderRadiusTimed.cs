using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class HitboxColliderRadiusTimed : NetworkBehaviour
	{
		[SerializeField]
		public SphereCollider sphereCollider;

		[NonSerialized]
		public float ttl;

		[NonSerialized]
		public float radius;

		[NonSerialized]
		public float time;

		public override void OnStopServer()
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
