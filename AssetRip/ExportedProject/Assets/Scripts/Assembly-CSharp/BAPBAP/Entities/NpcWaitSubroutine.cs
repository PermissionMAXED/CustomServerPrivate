using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class NpcWaitSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public byte trigger;

		[NonSerialized]
		public float waitTime;

		[NonSerialized]
		public float timeElapsed;

		public NpcWaitSubroutine(byte trigger, float waitTime)
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
