using System;
using BAPBAP.Entities;

namespace BAPBAP.Local
{
	public class GM_XCOM : GameModifier
	{
		[Serializable]
		public class Config : GameModifierConfiguration
		{
		}

		[NonSerialized]
		public Config config;

		public GM_XCOM(Config _config = null)
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
