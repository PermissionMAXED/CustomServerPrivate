using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class TransitionSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public byte trigger;

		public TransitionSubroutine(byte trigger)
		{
		}

		public override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			return 0;
		}
	}
}
