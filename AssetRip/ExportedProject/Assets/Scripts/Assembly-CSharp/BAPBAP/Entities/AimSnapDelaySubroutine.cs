using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class AimSnapDelaySubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public int frameLock;

		[NonSerialized]
		public int frameCount;

		[NonSerialized]
		public bool done;

		[NonSerialized]
		public bool snapAtStart;

		public AimSnapDelaySubroutine(Ability ability, int frameLock, bool snapAtStart)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			return 0;
		}
	}
}
