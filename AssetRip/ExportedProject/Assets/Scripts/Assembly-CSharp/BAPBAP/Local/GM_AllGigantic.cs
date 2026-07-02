using System;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_AllGigantic : GameModifier
	{
		[Serializable]
		public class Config : GameModifierConfiguration
		{
			[Header("Custom Config")]
			public int hpIncreaseAmount;

			public PassiveSO giganticPassive;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int giganticPassiveId;

		public GM_AllGigantic(Config _config = null)
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
