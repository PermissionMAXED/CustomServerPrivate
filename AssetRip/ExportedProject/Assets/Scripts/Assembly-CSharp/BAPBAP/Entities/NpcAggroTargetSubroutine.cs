using System;
using BAPBAP.Local;
using BAPBAP.Network;

namespace BAPBAP.Entities
{
	public class NpcAggroTargetSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public NpcBehaviour behaviour;

		[NonSerialized]
		public byte trigger;

		[NonSerialized]
		public bool showEmotion;

		[NonSerialized]
		public bool firstFrame;

		public NpcAggroTargetSubroutine(NpcBehaviour _behaviour, byte _trigger, bool _showEmotion = true)
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
