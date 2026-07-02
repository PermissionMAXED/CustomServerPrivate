using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;
using UnityEngine.AI;

namespace BAPBAP.Entities
{
	public class NpcFollowTargetSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public NpcBehaviour npcBehaviour;

		[NonSerialized]
		public byte triggerTargetLost;

		[NonSerialized]
		public NavMeshAgent agent;

		[NonSerialized]
		public float maxDistFromSelfSqr;

		[NonSerialized]
		public float stopMovingAngleThreshold;

		[NonSerialized]
		public float followDistSqr;

		[NonSerialized]
		public float followDistMarginSqr;

		[NonSerialized]
		public bool doPivotAroundTarget;

		[NonSerialized]
		public int pivotAxisDir;

		[NonSerialized]
		public bool doRetreat;

		[NonSerialized]
		public bool doRetreatCollisionDetection;

		[NonSerialized]
		public float distToEdgeSqr;

		[NonSerialized]
		public Vector3 edgeNormal;

		[NonSerialized]
		public Vector3 edgeDirLerp;

		[NonSerialized]
		public bool edgeCollision;

		[NonSerialized]
		public float edgeDir;

		[NonSerialized]
		public bool justEnteredEdge;

		public NpcFollowTargetSubroutine(NpcBehaviour _npcBehaviour, byte _triggerTargetLost, float _maxDistFromSelf, float _followDist = 0f, float followDistMargin = 2f, bool _doPivotAroundTarget = false)
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

		public void PivotAroundTarget(float fixedDt)
		{
		}

		public void RetreatCollisionDetection(ref Vector3 dir, float fixedDt)
		{
		}
	}
}
