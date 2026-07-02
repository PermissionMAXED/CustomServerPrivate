using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_AbilityCrit : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public CommandId[] targetAbilities;

			[Header("FX Config")]
			public GameObject vfxLoopPrefab;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public bool[] abilitiesToApply;

		[NonSerialized]
		public int vfxLoopId;

		public override PassiveConfiguration passiveConfig => null;

		public P_AbilityCrit(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public void ApplyAbilityCrit(bool doEnable)
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
