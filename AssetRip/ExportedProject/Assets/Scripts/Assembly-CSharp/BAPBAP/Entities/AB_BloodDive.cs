using System;

namespace BAPBAP.Entities
{
	public class AB_BloodDive : AbilityBehaviour
	{
		[Serializable]
		public class Config : AbilityBehaviourConfig
		{
		}

		[NonSerialized]
		public Config config;

		public AB_BloodDive(Config config)
		{
		}
	}
}
