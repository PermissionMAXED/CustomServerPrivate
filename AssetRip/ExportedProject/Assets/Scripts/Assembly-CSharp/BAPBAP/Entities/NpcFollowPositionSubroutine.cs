using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine.AI;

namespace BAPBAP.Entities
{
	public class NpcFollowPositionSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public NpcBehaviour npcBehaviour;

		[NonSerialized]
		public byte triggerFinished;

		[NonSerialized]
		public NavMeshAgent agent;

		[NonSerialized]
		public float stopMovingAngleThreshold;

		[NonSerialized]
		public float stopDistance;

		public NpcFollowPositionSubroutine(NpcBehaviour _npcBehaviour, byte _triggerFinished, float _stopDistance = 1f)
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
	}
}
