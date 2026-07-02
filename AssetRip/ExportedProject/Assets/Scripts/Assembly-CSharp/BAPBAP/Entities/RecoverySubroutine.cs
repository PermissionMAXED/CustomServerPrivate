using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;

namespace BAPBAP.Entities
{
	public class RecoverySubroutine : NetworkedSimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public byte triggerFinished;

		[NonSerialized]
		public byte triggerSilenced;

		[NonSerialized]
		public float duration;

		[NonSerialized]
		public bool applyAtkSpeedMultiplier;

		[NonSerialized]
		public float timeElapsed;

		public RecoverySubroutine(Ability ability, byte triggerFinished, byte triggerSilenced, float duration, bool applyAtkSpeedMultiplier)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			return 0;
		}

		public float GetAdjustedRecoveryDuration()
		{
			return 0f;
		}

		public void SetRecoveryDuration(float duration)
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
