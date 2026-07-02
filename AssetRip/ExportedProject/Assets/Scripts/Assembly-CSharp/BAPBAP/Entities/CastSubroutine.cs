using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;

namespace BAPBAP.Entities
{
	public class CastSubroutine : NetworkedSimulationSubroutine
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
		public bool applyAtkSpeedMultiplier;

		[NonSerialized]
		public bool doTimeDilation;

		[NonSerialized]
		public bool isUlt;

		[NonSerialized]
		public bool isSuccess;

		[NonSerialized]
		public CastFlags castFlag;

		[NonSerialized]
		public float timeElapsed;

		[NonSerialized]
		public float castingTime;

		public CastSubroutine(Ability ability, byte finishTrigger, byte silenceTrigger, byte cancelTrigger, float castingTime, bool applyAtkSpeedMultiplier, bool doTimeDilation)
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

		public float GetAdjustedCastingTime()
		{
			return 0f;
		}

		public void SetCastTime(float ct)
		{
		}

		public float GetCastTime()
		{
			return 0f;
		}

		public void ReupdateCasting()
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
