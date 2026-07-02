using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class AimLockSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public InputSystem inputSystem;

		[NonSerialized]
		public Ability ability;

		public AimLockSubroutine(Ability ability)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void OnExit(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
