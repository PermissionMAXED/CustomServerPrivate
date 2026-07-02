using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class LookAtCmdWorldPosSubroutine : NetworkedSimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		public LookAtCmdWorldPosSubroutine(Ability _ability)
		{
		}

		public override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			return 0;
		}
	}
}
