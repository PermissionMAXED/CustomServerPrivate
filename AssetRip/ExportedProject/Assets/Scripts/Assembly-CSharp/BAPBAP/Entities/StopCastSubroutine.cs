using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class StopCastSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public CastFlags castFlag;

		[NonSerialized]
		public bool onExit;

		public StopCastSubroutine(Ability ability, bool onExit = false)
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
