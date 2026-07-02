using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class HitboxHp : NetworkBehaviour
	{
		[NonSerialized]
		public Hitbox myHitbox;

		[Header("References")]
		[SerializeField]
		public Renderer meshRenderer;

		[Header("Settings")]
		[Tooltip("If this hitbox has a SpawnHitboxOnDestroy component, should it spawn it when destroyed by ttl?")]
		[SerializeField]
		public bool doSpawnHitboxOnDestroy;

		[SerializeField]
		public bool playDestroyFX;

		[NonSerialized]
		public int hp;

		[NonSerialized]
		public float hitAmount;

		public void Awake()
		{
		}

		public override void OnStartServer()
		{
		}

		public void OnCollisionTrigger(Collider collider)
		{
		}

		public void DestroyHitbox()
		{
		}

		public void Update()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
