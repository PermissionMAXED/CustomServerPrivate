using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class ReadySubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		public ReadySubroutine(Ability ability)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
