using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class RotationLockSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public RotationLockAction action;

		[NonSerialized]
		public RotationLockType rotationLockType;

		public RotationLockSubroutine(Ability ability, RotationLockAction action, RotationLockType rotationLockType)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void SetRotationLockType(RotationLockType newType)
		{
		}
	}
}
