using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class NpcSearchTargetSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public NpcBehaviour behaviour;

		[NonSerialized]
		public byte triggerFound;

		public NpcSearchTargetSubroutine(NpcBehaviour _behaviour, byte _triggerFound)
		{
		}

		public override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			return 0;
		}
	}
}
