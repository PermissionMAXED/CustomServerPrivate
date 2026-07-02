using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class NpcWanderingPosSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public NpcBehaviour behaviour;

		public NpcWanderingPosSubroutine(NpcBehaviour _behaviour)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public virtual void GetWanderingPositionToMove(float maxDistFromCurrentPos = 50f)
		{
		}

		public Vector3 GetRandomWanderPositionInBRZone(float maxDistFromCurrentPos = 50f)
		{
			return default(Vector3);
		}

		public Vector3 GetRandomWanderPosition(float maxDistFromCurrentPos = 50f)
		{
			return default(Vector3);
		}
	}
}
