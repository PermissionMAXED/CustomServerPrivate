using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;

namespace BAPBAP.Entities
{
	public class CastDilationSubroutine : NetworkedSimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public byte triggerFinished;

		[NonSerialized]
		public byte triggerSilenced;

		[NonSerialized]
		public float timeElapsed;

		public CastDilationSubroutine(Ability ability, byte triggerFinished, byte triggerSilenced)
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

		public override void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public override void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public override bool OnNetDebugCompare(NetworkReader netReader)
		{
			return false;
		}

		public override void OnNetDebugLog(StringBuilder sb)
		{
		}
	}
}
