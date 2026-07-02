using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class AimSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public byte finishedTrigger;

		[NonSerialized]
		public byte interruptTrigger;

		[NonSerialized]
		public CastFlags castFlag;

		public AimSubroutine(Ability ability, byte finishedTrigger, byte interruptTrigger)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			return 0;
		}

		public override void OnExit(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
