using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class SnapRotationSubroutine : NetworkedSimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		public SnapRotationSubroutine(Ability _ability)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
