using System;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_MoneyIsPower : GameModifier
	{
		[Serializable]
		public class Config : GameModifierConfiguration
		{
			[Header("Custom Config")]
			public PassiveSO moneyIsPowerPassive;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int moneyIsPowerPassiveId;

		public GM_MoneyIsPower(Config _config = null)
		{
		}

		public override void Activate()
		{
		}

		public override void Deactivate()
		{
		}

		public override void OnPlayerCharSpawned(EntityManager entityManager)
		{
		}

		public void OnDisable(EntityManager entityManager)
		{
		}
	}
}
