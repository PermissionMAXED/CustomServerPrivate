using System;
using BAPBAP.Local;
using BAPBAP.Maps;
using BAPBAP.Network;
using UnityEngine;
using UnityEngine.AI;

namespace BAPBAP.Entities
{
	public class PathingNpcBehaviour : NpcBehaviour, IEntityDataProperty
	{
		public class ChangeDirectionSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public PathingNpcBehaviour behaviour;

			[NonSerialized]
			public byte triggerWander;

			[NonSerialized]
			public float elapsedTime;

			[NonSerialized]
			public bool reachedPosition;

			public ChangeDirectionSubroutine(PathingNpcBehaviour _behaviour, byte _triggerWander)
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

		public class NpcPathingWanderingPosSubroutine : NpcWanderingPosSubroutine
		{
			[NonSerialized]
			public new PathingNpcBehaviour behaviour;

			[NonSerialized]
			public bool firstFrame;

			[NonSerialized]
			public byte triggerTransition;

			[NonSerialized]
			public byte triggerIdle;

			public NpcPathingWanderingPosSubroutine(PathingNpcBehaviour _behaviour, byte _triggerTransition, byte _triggerIdle)
				: base(null)
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

			public override void GetWanderingPositionToMove(float maxDistFromCurrentPos = 50f)
			{
			}
		}

		public class CustomNpcReturnSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public PathingNpcBehaviour npcBehaviour;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public NavMeshAgent agent;

			[NonSerialized]
			public float originalStoppingDistance;

			[NonSerialized]
			public bool destinationPendingSet;

			public CustomNpcReturnSubroutine(PathingNpcBehaviour _npcBehaviour, byte _trigger)
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

		[Header("Npc Config")]
		[Tooltip("How much distance until this npc has had enough and starts targeting close players")]
		[SerializeField]
		[Min(0f)]
		public float minDistanceTargetAgro;

		[Tooltip("How much distance this npc will chase a player for. If the npc surpasses the distance, he losses his target and returns to his origin position")]
		[SerializeField]
		[Min(0f)]
		public float maxDistanceFromOrigin;

		[SerializeField]
		[Min(0f)]
		[Tooltip("How much distance to track a target for. If surpassed this distance, lose the target")]
		public float maxDistanceToTarget;

		[Tooltip("The distance this npc will try to be from the current target")]
		[SerializeField]
		[Min(0f)]
		public float followDistance;

		[Header("Pathing Settings")]
		[Tooltip("Should the npc roam around the map randomly?")]
		[SerializeField]
		public bool isRoamingNpc;

		[Tooltip("If roaming: try to stay in the BR zone.")]
		[SerializeField]
		public bool stayInZone;

		[SerializeField]
		[Tooltip("Should the npc stop when reaching the final pathing position?")]
		public bool isLooping;

		[NonSerialized]
		public float timeToWaitAtPosition;

		[NonSerialized]
		public Vector2[] pathingPositions;

		[NonSerialized]
		public int pathingIndex;

		[NonSerialized]
		public bool isPathing;

		[NonSerialized]
		public bool initialized;

		public override void Start()
		{
		}

		public override void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void TrySetAggro(Transform target)
		{
		}

		public Vector3 GetPathingPosition(int pIndex)
		{
			return default(Vector3);
		}

		public virtual string PropertyName()
		{
			return null;
		}

		public MapEntityData.Property.Field[] GetPropertyFields()
		{
			return null;
		}

		public void CopyProperties(IEntityDataProperty _source)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
