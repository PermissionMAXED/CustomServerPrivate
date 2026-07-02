using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class EntityOnHitActivate : NetworkBehaviour
	{
		[NonSerialized]
		public CharHurtbox charHurtbox;

		[Header("Configs")]
		[Min(0f)]
		[SerializeField]
		public float cooldownDuration;

		[SerializeField]
		[Header("Activation Events")]
		public EntityActivateBase[] onHitActivations;

		[NonSerialized]
		public float cooldownTimer;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnDestroy()
		{
		}

		[ServerCallback]
		public void FixedUpdate()
		{
		}

		[ServerCallback]
		public void DoHit(Vector3 hitDir, int dmg, StatusEffectInfo[] statusEffects, int playerId, int teamId, Collider collider)
		{
		}

		public void Activate()
		{
		}

		public void Reset()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
