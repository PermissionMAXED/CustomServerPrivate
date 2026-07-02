using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Buff_Gold_DmgReduction : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public float baseCooldown;

			public float dmgReductionPerGold;

			public int maxGoldAmount;

			public GameObject vfxReadyPrefab;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public bool isReady;

		[NonSerialized]
		public int prevGold;

		[NonSerialized]
		public float currentDmgReduction;

		[NonSerialized]
		public int vfxReadyId;

		public override PassiveConfiguration passiveConfig => null;

		public P_Buff_Gold_DmgReduction(EntityManager entityManager, Config config)
			: base(null)
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
