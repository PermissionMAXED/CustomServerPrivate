using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class AimSnapSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		public AimSnapSubroutine(Ability ability)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
