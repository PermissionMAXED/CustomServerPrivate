using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Blood_ExtraDmg : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public float baseCooldown;

			public float dmgModifier;

			public float bonusDmgPerHp;

			public float value;

			public string passiveName;

			public GameObject vfxReadyPrefab;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int vfxReadyId;

		[NonSerialized]
		public int baseHp;

		[NonSerialized]
		public int bonus;

		[NonSerialized]
		public int currentHpDif;

		[NonSerialized]
		public int totalBonuses;

		public override PassiveConfiguration passiveConfig => null;

		public P_Blood_ExtraDmg(EntityManager entityManager, Config config)
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

		public override void ActivatePassive()
		{
		}

		public override void Tick(float fixedDt, Command cmd, bool isResim)
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
