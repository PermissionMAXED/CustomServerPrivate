using System;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_BrainFreeze : AB_Consumable_Base_Use
	{
		[Serializable]
		public new class Config : AB_Consumable_Base_Use.Config
		{
			[Header("Custom Config")]
			public float freezeDuration;
		}

		[NonSerialized]
		public new Config config;

		public AB_BrainFreeze(Config _config = null)
			: base(null)
		{
		}

		public override void DoUseConsumable(EntityManager cM)
		{
		}
	}
}
