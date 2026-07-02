using System;
using BAPBAP.Items;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnAirborne_Sprint : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float sprintDuration;

			public float sprintMultiplier;

			public Item jumpPadItem;

			public Item jumpPadInvisItem;

			public float castTimeReductionAmount;

			public PassiveSO additionalPassiveToActivate;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public ItemManager itemManager;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnAirborne_Sprint(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnItemsChanged(EntityManager cM)
		{
		}

		public override void OnStatusEffectAppliedToSelfTrigger(int statusEffectId)
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
