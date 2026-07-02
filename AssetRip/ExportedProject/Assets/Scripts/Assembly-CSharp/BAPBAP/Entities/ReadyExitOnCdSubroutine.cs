using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class ReadyExitOnCdSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public float cdTime;

		public ReadyExitOnCdSubroutine(Ability ability, float cdTime)
		{
		}

		public override void OnExit(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
