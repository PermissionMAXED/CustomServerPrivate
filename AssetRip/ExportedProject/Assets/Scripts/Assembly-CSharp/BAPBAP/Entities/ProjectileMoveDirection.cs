using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class ProjectileMoveDirection : NetworkBehaviour
	{
		[NonSerialized]
		public HitboxBase hitbox;

		[SerializeField]
		public Vector3 dir;

		[SerializeField]
		public float speed;

		[SerializeField]
		public float interpolationDuration;

		[NonSerialized]
		public float time;

		public void Awake()
		{
		}

		public override void OnStartServer()
		{
		}

		public void FixedUpdate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
