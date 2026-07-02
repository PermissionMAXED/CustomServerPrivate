using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class NpcClearCurrentTargetSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public NpcBehaviour behaviour;

		public NpcClearCurrentTargetSubroutine(NpcBehaviour _behaviour)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
