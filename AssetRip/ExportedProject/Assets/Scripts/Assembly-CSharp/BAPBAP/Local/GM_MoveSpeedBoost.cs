using System;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_MoveSpeedBoost : GameModifier
	{
		[Serializable]
		public class Config : GameModifierConfiguration
		{
			[Header("Custom Config")]
			public float moveSpeedIncrease;
		}

		[NonSerialized]
		public Config config;

		public GM_MoveSpeedBoost(Config _config = null)
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
