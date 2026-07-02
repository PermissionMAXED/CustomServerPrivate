using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;

namespace BAPBAP.Entities
{
	public class CancelSubroutine : NetworkedSimulationSubroutine
	{
		[NonSerialized]
		public Ability ability;

		[NonSerialized]
		public byte trigger;

		[NonSerialized]
		public float duration;

		[NonSerialized]
		public float timeElapsed;

		public CancelSubroutine(Ability ability, byte trigger, float duration)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			return 0;
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
