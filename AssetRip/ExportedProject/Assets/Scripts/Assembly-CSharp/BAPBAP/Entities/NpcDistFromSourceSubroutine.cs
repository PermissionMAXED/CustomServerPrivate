using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class NpcDistFromSourceSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public byte trigger;

		[NonSerialized]
		public bool getSourcePosOnEnter;

		[NonSerialized]
		public Vector3 sourcePos;

		[NonSerialized]
		public float maxDistanceSqr;

		public NpcDistFromSourceSubroutine(NpcBehaviour _npcBehaviour, byte _trigger, float maxDistance)
		{
		}

		public NpcDistFromSourceSubroutine(NpcBehaviour _npcBehaviour, byte _trigger, float maxDistance, Vector3 _sourcePos)
		{
		}

		public NpcDistFromSourceSubroutine(EntityManager _entityManager, byte _trigger, float maxDistance)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			return 0;
		}
	}
}
