using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class NpcIdleStateSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public NpcBehaviour behaviour;

		[NonSerialized]
		public Vector2 startLookRot;

		public NpcIdleStateSubroutine(NpcBehaviour _npcBehaviour)
		{
		}

		public override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			return 0;
		}
	}
}
