using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;

namespace BAPBAP.Entities
{
	public class P_CooldownSubroutine : NetworkedSimulationSubroutine
	{
		[NonSerialized]
		public Passive passive;

		[NonSerialized]
		public byte trigger;

		[NonSerialized]
		public bool applyCdMultiplier;

		[NonSerialized]
		public bool applyAtkSpeedMultiplier;

		[NonSerialized]
		public bool showCooldownUI;

		[NonSerialized]
		public bool iconDisabledOnCooldown;

		[NonSerialized]
		public bool activeByDefault;

		[NonSerialized]
		public float timeElapsed;

		[NonSerialized]
		public float time;

		public P_CooldownSubroutine(Passive passive, byte trigger, float time, bool applyCdMultiplier, bool applyAtkSpeedMultiplier, bool showCooldownUI = true, bool iconDisabledOnCooldown = true, bool activeByDefault = true)
		{
		}

		public void SetShowCooldown(bool s)
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

		public float GetAdjustedCooldownTime()
		{
			return 0f;
		}

		public void SetCooldownTime(float cooldownTime)
		{
		}

		public void SetTimeElapsed(float timeElapsed)
		{
		}

		public float GetTimeElapsed()
		{
			return 0f;
		}

		public void UpdateCooldown()
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
