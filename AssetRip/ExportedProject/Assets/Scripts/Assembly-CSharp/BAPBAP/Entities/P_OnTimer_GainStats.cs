using System;
using System.Collections.Generic;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class P_OnTimer_GainStats : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			public float timer;

			public ItemStat[] timedStats;
		}

		public class CustomGainStatsSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnTimer_GainStats passive;

			[NonSerialized]
			public byte trigger;

			public CustomGainStatsSubroutine(P_OnTimer_GainStats _ability, byte _trigger)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public List<ItemStat> allStats;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnTimer_GainStats(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void DeactivatePassive()
		{
		}
	}
}
