using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;

namespace BAPBAP.Entities
{
	public class ComboCooldownSubroutine : NetworkedSimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public byte triggerFinished;

		[NonSerialized]
		public byte triggerSilenced;

		[NonSerialized]
		public float cooldownTime;

		[NonSerialized]
		public bool applyAtkSpeedMultiplier;

		[NonSerialized]
		public float timeElapsed;

		public ComboCooldownSubroutine(Ability ability, byte triggerFinished, byte triggerSilenced, float cooldownTime, bool applyAtkSpeedMultiplier)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			return 0;
		}

		public float GetAdjustedCooldownTime()
		{
			return 0f;
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
