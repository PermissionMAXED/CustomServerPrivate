using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class AnimLockSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public bool applyLocks;

		[NonSerialized]
		public bool applicable;

		public AnimLockSubroutine(Ability ability, bool applyLocks, float castingTime, bool silenceable, bool cancelable)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
