using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Buff_DamageOnHPLoss : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public float baseCooldown;

			public float cap;

			public float dmgIncreaseByHealthPercent;

			public float atkSpeedIncreaseByHealthPercent;

			public float vampIncreaseByHealthPercent;

			[Header("FX Config")]
			public GameObject vfxFollowPrefab;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public bool isReady;

		[NonSerialized]
		public int prevHealth;

		[NonSerialized]
		public float currentDmgBonus;

		[NonSerialized]
		public float currentAtkSpeedBonus;

		[NonSerialized]
		public float currentVampBonus;

		[NonSerialized]
		public int vfxFollowId;

		public override PassiveConfiguration passiveConfig => null;

		public P_Buff_DamageOnHPLoss(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void Tick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void ResetStatBonus()
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
