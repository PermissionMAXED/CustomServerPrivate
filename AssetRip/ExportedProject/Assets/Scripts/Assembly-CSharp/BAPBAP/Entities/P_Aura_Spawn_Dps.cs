using System;
using System.Collections.Generic;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Aura_Spawn_Dps : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public int damage;

			public float damageRate;

			public float damageScaling;

			public float hitboxRadius;

			public float selfHpPercentDamage;

			public GameObject spellPrefab;

			public List<StatusEffectInfo> statusEffects;

			[Header("FX")]
			public GameObject vfxReadyPrefab;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public GameObject dpsObj;

		[NonSerialized]
		public GameObject vfxObj;

		[NonSerialized]
		public int vfxReadyId;

		public override PassiveConfiguration passiveConfig => null;

		public P_Aura_Spawn_Dps(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void Tick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void ClTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public bool IsEnabled()
		{
			return false;
		}

		public void SpawnDpsObject()
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
