using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Blood_OnKill_GainGold : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public float baseCooldown;

			public int goldAmount;

			public float value;

			public string passiveName;

			public GameObject vfxReadyPrefab;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int vfxReadyId;

		public override PassiveConfiguration passiveConfig => null;

		public P_Blood_OnKill_GainGold(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override float GetValue()
		{
			return 0f;
		}

		public override string GetPassiveName()
		{
			return null;
		}

		public override void OnKillTrigger(EntityManager otherCharManager)
		{
		}

		public override void ActivatePassive()
		{
		}

		public override void DeactivatePassive()
		{
		}

		public override void ClActivatePassive()
		{
		}

		public override void ClDeactivatePassive()
		{
		}
	}
}
