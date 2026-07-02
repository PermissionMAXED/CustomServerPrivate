using System;
using System.Text;
using BAPBAP.Entities.TargetDetection;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.UI;
using Mirror;
using UnityEngine;
using UnityEngine.AI;

namespace BAPBAP.Entities
{
	public class NpcBehaviour : NetworkBehaviour, INetworkPredicted
	{
		[SerializeField]
		[Header("Debug")]
		public bool doDebugLogs;

		[SerializeField]
		public bool showDebugGizmos;

		[SerializeField]
		[Header("Target Settings")]
		[Tooltip("Should this npc get aggro by other attacking characters on hit?")]
		public bool doAggroByHit;

		[Tooltip("When this npc searches for a missing target, should it only try to find that target instead of others? Note that when enabled, make sure npc finds targets while in searching state")]
		[SerializeField]
		public bool searchForOtherTargets;

		[SerializeField]
		[Tooltip("How much time until a new aggroing target can be selected")]
		public float aggroDuration;

		[SerializeField]
		[Tooltip("When a character is hidden by a bush, how much time to keep engaging the target until removing it from the current target")]
		public float targetHiddenDuration;

		[Tooltip("Rate at which line of sight checks will be performed. The lower the value, the more expensive to run; a value of around 0.5 is ideal.")]
		[SerializeField]
		public float lineOfSightUpdateRate;

		[Header("General Settings")]
		[Tooltip("Speed to which the target distance value will be lerped. Since this adds some delay, melee characters benefit from having a higher speed, while ranged look more natural with slower speed")]
		[SerializeField]
		public float distLerpSpeed;

		[SerializeField]
		[Tooltip("Speed to which the target velocity value will be lerped")]
		public float targetVelLerpSpeed;

		[Tooltip("General damage multiplier for this npc. Any output damage wil be multiplied by this amount")]
		[SerializeField]
		public float damageMultiplier;

		[Tooltip("Damage multiplier for players. Any output damage wil be multiplied by this amount only for players")]
		[SerializeField]
		public float damageToPlayersMultiplier;

		[Tooltip("When this character gets silenced, how much global cooldown to add to all abilities.")]
		[SerializeField]
		public float silencedAbilityGlobalCd;

		[NonSerialized]
		public Vector3 dirToTarget;

		[NonSerialized]
		public float distToCurrentTargetSqr;

		[NonSerialized]
		public float distToCurrentTargetSqrLerped;

		[NonSerialized]
		public Vector3 currentTargetVelocityLerped;

		[NonSerialized]
		public Vector3 currentTargetPosition;

		[NonSerialized]
		public bool hasLineOfSightWithTarget;

		[NonSerialized]
		[NonSerialized]
		public float targetHiddenTimer;

		[NonSerialized]
		[NonSerialized]
		public float aggroTimer;

		[NonSerialized]
		public float abilityGlobalCdTime;

		[NonSerialized]
		public Vector3 startingPos;

		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharAbilities charAbilities;

		[NonSerialized]
		public EntityMovement charMove;

		[NonSerialized]
		public CharAim charAim;

		[NonSerialized]
		public CharAnimator charAnim;

		[NonSerialized]
		public CharHurtbox charHurtbox;

		[NonSerialized]
		public CharEvents charEvents;

		[NonSerialized]
		public CharHpRegen charHpRegen;

		[NonSerialized]
		public CharItems charItems;

		[NonSerialized]
		public NavMeshAgent agent;

		[NonSerialized]
		public BAPBAP.Entities.TargetDetection.TargetDetection targetDetection;

		[NonSerialized]
		public ItemManager itemManager;

		[NonSerialized]
		public BattleRoyaleZone brZone;

		[NonSerialized]
		public LayerMask obstaclesLayer;

		[NonSerialized]
		public Transform currentTargetTransform;

		[NonSerialized]
		public EntityManager currentTargetEntityManager;

		[NonSerialized]
		public float lineOfSightTimer;

		[NonSerialized]
		public bool hasAgent;

		[NonSerialized]
		public SimulationFsm fsm;

		[NonSerialized]
		public byte stateId;

		[NonSerialized]
		public byte triggerId;

		[NonSerialized]
		public Vector3 debugWorldCmdPos;

		public Transform CurrentTarget
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public EntityManager CurrentTargetEntity => null;

		public virtual void PreAwake(EntityManager e)
		{
		}

		public virtual void Start()
		{
		}

		public virtual void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public virtual void TrySetAggro(Transform target)
		{
		}

		public void SetCurrentTarget(Transform newTarget)
		{
		}

		public void UpdateTarget(float fixedDt)
		{
		}

		public void TrackTarget(float fixedDt)
		{
		}

		public void TickTarget(float fixedDt)
		{
		}

		[ClientRpc]
		public void RpcShowEmotionStateMark(UIManager.EmotionState state)
		{
		}

		public void OnSilenced()
		{
		}

		public bool RaycastObstacleDir(Vector3 startPos, Vector3 direction, float length = 1.5f)
		{
			return false;
		}

		public bool TryGetBattleRoyaleZone()
		{
			return false;
		}

		public virtual void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public virtual void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public virtual bool OnNetDebugCompare(NetworkReader netReader)
		{
			return false;
		}

		public virtual void OnNetDebugLog(StringBuilder sb)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcShowEmotionStateMark__EmotionState(UIManager.EmotionState state)
		{
		}

		public static void InvokeUserCode_RpcShowEmotionStateMark__EmotionState(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static NpcBehaviour()
		{
		}
	}
}
