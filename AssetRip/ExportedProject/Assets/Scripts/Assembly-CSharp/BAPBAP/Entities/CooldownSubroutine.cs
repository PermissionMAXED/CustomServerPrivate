using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;

namespace BAPBAP.Entities
{
	public class CooldownSubroutine : NetworkedSimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public byte trigger;

		[NonSerialized]
		public float duration;

		[NonSerialized]
		public bool applyCdMultiplier;

		[NonSerialized]
		public bool applyAtkSpeedMultiplier;

		[NonSerialized]
		public bool resetOnEnter;

		[NonSerialized]
		public bool ignoreReset;

		[NonSerialized]
		public float timeElapsed;

		public float TimeElapsed => 0f;

		public float Duration => 0f;

		public CooldownSubroutine(Ability ability, byte trigger, float duration, bool applyCdMultiplier, bool applyAtkSpeedMultiplier)
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

		public float GetAdjustedCooldownDuration()
		{
			return 0f;
		}

		public void SetTimeElapsed(float timeElapsed)
		{
		}

		public void IncrementTimeElapsed(float incr)
		{
		}

		public void SetCooldownDuration(float duration)
		{
		}

		public void ResetCooldownOnEnter(bool forced = false)
		{
		}

		public void SetIgnoreReset(bool ignoreReset = false)
		{
		}

		public void LowerCooldownByPercent(float percent)
		{
		}

		public void ReupdateCooldown()
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
