using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class ClearRemainderDtSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		public ClearRemainderDtSubroutine(Ability ability)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
