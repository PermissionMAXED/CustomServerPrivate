using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;

namespace BAPBAP.Entities
{
	public class ChannelingSubroutine : NetworkedSimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public byte finishTrigger;

		[NonSerialized]
		public byte silenceTrigger;

		[NonSerialized]
		public byte cancelTrigger;

		[NonSerialized]
		public float channelingTime;

		[NonSerialized]
		public bool applyAtkSpeedMultiplier;

		[NonSerialized]
		public bool isUlt;

		[NonSerialized]
		public bool isSuccess;

		[NonSerialized]
		public float timeElapsed;

		public ChannelingSubroutine(Ability ability, byte finishTrigger, byte silenceTrigger, byte cancelTrigger, float channelingTime, bool applyAtkSpeedMultiplier)
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

		public float GetAdjustedChannelingTime()
		{
			return 0f;
		}

		public void ReupdateChanneling()
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
