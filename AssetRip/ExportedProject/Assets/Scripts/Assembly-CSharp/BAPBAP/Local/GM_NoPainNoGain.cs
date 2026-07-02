using System;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_NoPainNoGain : GameModifier
	{
		[Serializable]
		public class Config : GameModifierConfiguration
		{
			[Header("Custom Config")]
			public float lifestealAmount;

			public PassiveSO permaBurnPassive;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int permaBurnPassiveId;

		public GM_NoPainNoGain(Config _config = null)
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
