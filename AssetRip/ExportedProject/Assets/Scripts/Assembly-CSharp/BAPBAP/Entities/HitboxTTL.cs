using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class HitboxTTL : NetworkBehaviour
	{
		[Header("Settings")]
		[SerializeField]
		public float ttl;

		[NonSerialized]
		public HitboxBase hitbox;

		[NonSerialized]
		public float time;

		public override void OnStartServer()
		{
		}

		public void Awake()
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
