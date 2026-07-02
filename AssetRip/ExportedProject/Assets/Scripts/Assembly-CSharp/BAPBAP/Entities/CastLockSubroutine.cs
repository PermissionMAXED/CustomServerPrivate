using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class CastLockSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public CastFlags castFlag;

		[NonSerialized]
		public CastLockAction castLockAction;

		public CastLockSubroutine(Ability ability, CastLockAction castLockAction)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
