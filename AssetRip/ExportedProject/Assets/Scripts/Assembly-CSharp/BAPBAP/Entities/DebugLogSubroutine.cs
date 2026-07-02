using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class DebugLogSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public string log;

		[NonSerialized]
		public bool logOnEnter;

		[NonSerialized]
		public bool logOnTick;

		[NonSerialized]
		public bool logOnExit;

		public DebugLogSubroutine(string log, bool logOnEnter = true, bool logOnTick = false, bool logOnExit = false)
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
