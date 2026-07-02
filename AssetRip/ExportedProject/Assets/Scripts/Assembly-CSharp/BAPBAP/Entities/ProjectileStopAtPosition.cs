using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class ProjectileStopAtPosition : NetworkBehaviour
	{
		[NonSerialized]
		public Vector3 position;

		[SerializeField]
		public float distanceToStop;

		[SerializeField]
		public bool destroyOnStop;

		[NonSerialized]
		public HitboxBase hitbox;

		[NonSerialized]
		public ProjectileMove projectileMove;

		[NonSerialized]
		public bool firstFrame;

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
