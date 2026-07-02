using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class NpcTriggerSearchTargetSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public NpcBehaviour behaviour;

		[NonSerialized]
		public byte triggerStartSearch;

		[NonSerialized]
		public bool isMelee;

		public NpcTriggerSearchTargetSubroutine(NpcBehaviour _behaviour, byte _triggerStartSearch, float distToEnemy)
		{
		}

		public override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			return 0;
		}
	}
}
