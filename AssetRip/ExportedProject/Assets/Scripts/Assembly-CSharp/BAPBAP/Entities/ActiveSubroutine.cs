using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class ActiveSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		public ActiveSubroutine(Ability ability)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
