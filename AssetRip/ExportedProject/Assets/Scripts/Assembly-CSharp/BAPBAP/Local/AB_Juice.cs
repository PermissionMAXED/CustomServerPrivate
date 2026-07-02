using System;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_Juice : AB_Consumable_Base_Use
	{
		[Serializable]
		public new class Config : AB_Consumable_Base_Use.Config
		{
			[Tooltip("The percentage of maxHp to heal for the given entity")]
			[Header("Custom Config")]
			[Range(0f, 1f)]
			public float healHpPercent;
		}

		[NonSerialized]
		public new Config config;

		public AB_Juice(Config _config = null)
			: base(null)
		{
		}

		public override void DoUseConsumable(EntityManager cM)
		{
		}
	}
}
