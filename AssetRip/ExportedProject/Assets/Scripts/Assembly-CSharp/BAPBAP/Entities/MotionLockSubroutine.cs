using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class MotionLockSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public MotionLockAction motionLockAction;

		[NonSerialized]
		public MotionLockType motionLockType;

		[NonSerialized]
		public bool onExit;

		public MotionLockSubroutine(Ability ability, MotionLockAction motionLockAction, MotionLockType motionLockType, bool onExit = false)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void OnExit(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void MotionLock()
		{
		}
	}
}
