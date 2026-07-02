using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Debugging;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;
using UnityEngine.AI;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class EntityMovement : NetworkBehaviour, INetworkPredicted
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharAnimator charAnim;

		[NonSerialized]
		public Rigidbody rb;

		[NonSerialized]
		public GameNetworkManager gameNetManager;

		[NonSerialized]
		public CustomSpatialHashInterestManagement aoi;

		[NonSerialized]
		public NavMeshAgent agent;

		[NonSerialized]
		public CharacterController charController;

		[SerializeField]
		[Header("Stats")]
		public float moveAccel;

		[SerializeField]
		public float moveDecel;

		[SerializeField]
		public float baseRunSpeed;

		[SerializeField]
		public float baseWalkSpeed;

		[SerializeField]
		public float constantWalkSpeed;

		[SerializeField]
		public float constantGhostSpeed;

		[SerializeField]
		[Header("Out Of Combat")]
		public float outOfMovementCombatDuration;

		[SerializeField]
		public float outOfMovementCombatSpeedBonus;

		[SerializeField]
		public float additiveSpeedOutOfMovementCombatMultiplier;

		[SerializeField]
		public AnimationCurve outOfMovementCombatCurve;

		[SerializeField]
		public float outOfMovementCombatRampDuration;

		[SerializeField]
		[Tooltip("If this entity is not a character or npc with agent, should it manually be clamped to navmesh every time it moves?")]
		[Header("Config")]
		public bool otherEntityLockToNavMesh;

		[SerializeField]
		[Header("Caps")]
		public float maxRunSpeed;

		[SerializeField]
		public float maxOutOfCombatRunSpeed;

		[SerializeField]
		[Header("Slippery Configs")]
		public float slipperyAccel;

		[SerializeField]
		public float slipperyDecel;

		[SerializeField]
		public float slipperySpeed;

		[SerializeField]
		public float slipperyOtherDecelMult;

		[SerializeField]
		public float slipperyMaxSpeed;

		[SerializeField]
		public float slipperyCollisionFriction;

		[SerializeField]
		public float rbSlipperyDrag;

		[NonSerialized]
		public float additiveSpeed;

		[NonSerialized]
		public float slowPercent;

		[NonSerialized]
		public bool isOutOfMovementCombat;

		[NonSerialized]
		public float outOfMovementCombatTimer;

		[NonSerialized]
		public float outOfMovementCombatRampTimer;

		[NonSerialized]
		public Vector3 velocity;

		[NonSerialized]
		public Vector3 moveVel;

		[NonSerialized]
		public Vector3 otherVel;

		[NonSerialized]
		public float otherDecel;

		[NonSerialized]
		public bool isMoving;

		[NonSerialized]
		public byte constantWalkLocks;

		[NonSerialized]
		public byte walkLocks;

		[NonSerialized]
		public byte movementLocks;

		[NonSerialized]
		public byte slipperyLocks;

		[NonSerialized]
		public byte controllerLocks;

		[NonSerialized]
		public SortedDictionary<int, Vector3> trainVel;

		[NonSerialized]
		public bool ghostWalking;

		[NonSerialized]
		public bool isPushed;

		[NonSerialized]
		public bool hasMomentum;

		[NonSerialized]
		public float runSpeed;

		[NonSerialized]
		public float walkSpeed;

		[NonSerialized]
		public Vector3 forceVel;

		[NonSerialized]
		public bool ccEnabled;

		[NonSerialized]
		public float rbBaseDrag;

		[NonSerialized]
		public bool asleep;

		[NonSerialized]
		public bool hasRb;

		[NonSerialized]
		public Vector3 prevPos;

		[NonSerialized]
		public LayerMask obstacleMask;

		[NonSerialized]
		public DebugGameplayManager debugGameplayM;

		public CharacterController CharacterController => null;

		public byte SlipperyLocks => 0;

		public byte ControllerLocks => 0;

		public float RunSpeed => 0f;

		public float WalkSpeed => 0f;

		public Vector3 Velocity => default(Vector3);

		public Vector3 MoveVel => default(Vector3);

		public void PreAwake(EntityManager e)
		{
		}

		public void Start()
		{
		}

		public void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void Move(float fixedDt, Vector3 cmdDir)
		{
		}

		public Vector3 ApplyInputDirModifications(Vector3 inputDir)
		{
			return default(Vector3);
		}

		public void OnControllerColliderHit(ControllerColliderHit hit)
		{
		}

		public void AddSlipperyLocks()
		{
		}

		public void RemoveSlipperyLocks()
		{
		}

		public void ApplySlippery()
		{
		}

		public void DeactivateSlippery()
		{
		}

		public void ApplyImpulse(Vector3 vel, float decel)
		{
		}

		public void ApplyContinuousForce(Vector3 vel)
		{
		}

		public void StopVelocity()
		{
		}

		public void AddOrModifyTrainVelocity(Vector3 vel, int id)
		{
		}

		public void RemoveTrainVelocity(int id)
		{
		}

		public void PostMove(Vector3 deltaPos, PostMoveTypes moveType, bool isResim = false)
		{
		}

		public void AddControllerLocks()
		{
		}

		public void RemoveControllerLocks()
		{
		}

		public void SetControllerEnabled()
		{
		}

		public void UpdateOutOfMovementCombat(float fixedDt)
		{
		}

		public void TriggerInMovementCombat()
		{
		}

		public void TriggerOutOfMovementCombat()
		{
		}

		public Vector3 GetDirectionals(Vector3 cmdDir)
		{
			return default(Vector3);
		}

		public Vector3 GetCharacterVelocity()
		{
			return default(Vector3);
		}

		public void OnMoveVelChanged()
		{
		}

		public void OnIsMovingChanged()
		{
		}

		public void OnWalkLocksChanged()
		{
		}

		public void OnSlipperyLocksChanged()
		{
		}

		public void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public bool OnNetDebugCompare(NetworkReader netReader)
		{
			return false;
		}

		public void OnNetDebugLog(StringBuilder sb)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
