using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Teleport : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public float teleportTimePercent;

		[NonSerialized]
		public float originalDuration;

		[NonSerialized]
		public bool teleported;

		[NonSerialized]
		public float tpTimer;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_Teleport(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void Activate(float _duration, float _multiplier, int _otherPlayerId, Vector3 _direction)
		{
		}

		public override void Deactivate()
		{
		}

		public override void OnTick(float dt)
		{
		}

		public override void ClActivate(float _duration, float _multiplier)
		{
		}

		public override void ClDeactivate()
		{
		}

		[Server]
		public void TeleportChar()
		{
		}
	}
}
