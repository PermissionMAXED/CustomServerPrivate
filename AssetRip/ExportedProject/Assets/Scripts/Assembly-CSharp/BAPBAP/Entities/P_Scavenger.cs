using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Scavenger : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float damageFromZoneModifer;

			public float damageTakenModifer;

			public float moveSpeedAmount;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public bool applied;

		public override PassiveConfiguration passiveConfig => null;

		public P_Scavenger(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnZoneEnter()
		{
		}

		public override void OnZoneExit()
		{
		}

		public void ApplyEffect()
		{
		}

		public void RevertEffect()
		{
		}

		public override void ActivatePassive()
		{
		}

		public override void DeactivatePassive()
		{
		}
	}
}
