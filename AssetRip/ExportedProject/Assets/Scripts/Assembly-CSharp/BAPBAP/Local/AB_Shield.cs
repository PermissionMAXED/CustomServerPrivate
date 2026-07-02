using System;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_Shield : AB_Consumable_Base_Use
	{
		[Serializable]
		public new class Config : AB_Consumable_Base_Use.Config
		{
			[Header("Custom Config")]
			public int shieldAmount;

			public float percentHpShield;

			public float shieldDuration;
		}

		[NonSerialized]
		public new Config config;

		public AB_Shield(Config _config = null)
			: base(null)
		{
		}

		public override void DoUseConsumable(EntityManager cM)
		{
		}
	}
}
