using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Network;
using JigglePhysics;
using Mirror;
using UnityEngine;
using UnityEngine.AI;

namespace BAPBAP.Entities
{
	public class SlimeBossBehaviour : NpcBehaviour
	{
		public class CustomEnableAlertSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossBehaviour behaviour;

			public CustomEnableAlertSubroutine(SlimeBossBehaviour _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomDisableAlertSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossBehaviour behaviour;

			public CustomDisableAlertSubroutine(SlimeBossBehaviour _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class NpcCustomSetCmdAimWorldPosSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossBehaviour behaviour;

			public NpcCustomSetCmdAimWorldPosSubroutine(SlimeBossBehaviour _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomSlowTrailSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossBehaviour behaviour;

			[NonSerialized]
			public Vector3 lastSlowPosition;

			[NonSerialized]
			public float slowSpawnDistanceSqr;

			public CustomSlowTrailSubroutine(SlimeBossBehaviour _behaviour)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class ChangeDirectionSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossBehaviour behaviour;

			[NonSerialized]
			public byte triggerWander;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public bool atPosition;

			[NonSerialized]
			public float agroMinDistanceSqr;

			public ChangeDirectionSubroutine(SlimeBossBehaviour _behaviour, byte _triggerWander)
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

		public class NpcWanderingPosSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossBehaviour behaviour;

			[NonSerialized]
			public byte triggerTransition;

			[NonSerialized]
			public float timeElapsed;

			public NpcWanderingPosSubroutine(SlimeBossBehaviour _behaviour, byte _triggerTransition)
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

		public class NpcFollowMovePositionSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossBehaviour npcBehaviour;

			[NonSerialized]
			public byte triggerFinished;

			[NonSerialized]
			public NavMeshAgent agent;

			[NonSerialized]
			public float stopDistance;

			public NpcFollowMovePositionSubroutine(SlimeBossBehaviour _npcBehaviour, byte _triggerFinished, float _stopDistance = 1f)
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

		public class CustomMoveJumpTriggerSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcBehaviour npcBehaviour;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float cdDuration;

			[NonSerialized]
			public float cdTimeElapsed;

			public CustomMoveJumpTriggerSubroutine(NpcBehaviour _npcBehaviour, byte _triggerJump, float moveJumpCdTime)
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

		public class CustomNpcReturnSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcBehaviour npcBehaviour;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public NavMeshAgent agent;

			[NonSerialized]
			public Vector3 startingPos;

			[NonSerialized]
			public float originalStoppingDistance;

			[NonSerialized]
			public bool destinationPendingSet;

			public CustomNpcReturnSubroutine(NpcBehaviour _npcBehaviour, byte _trigger)
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

		public class CustomDividedSlimesCastLockSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossBehaviour behaviour;

			public CustomDividedSlimesCastLockSubroutine(SlimeBossBehaviour _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomSubdivideTriggerSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossBehaviour behaviour;

			[NonSerialized]
			public byte trigger;

			public CustomSubdivideTriggerSubroutine(SlimeBossBehaviour _behaviour, byte _trigger)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		[NonSerialized]
		public SlimeBossSubdivideAbility subdivideAbility;

		[NonSerialized]
		public SlimeBossDashAbility slimeDashAbility;

		[NonSerialized]
		public SlimeBossJumpAbility slimeJumpAbility;

		[Header("GameMode Team Size Config")]
		[SerializeField]
		public int blobHealthSolo;

		[SerializeField]
		public int blobHealthDuo;

		[SerializeField]
		public int blobHealthTrio;

		[Tooltip("How much distance until this npc has had enough and starts targeting close players")]
		[Header("Idle State")]
		[SerializeField]
		public float minDistanceTargetAgro;

		[Header("Alert State")]
		[Tooltip("How much distance this npc will chase a player for. If the npc surpasses the distance, he losses his target and returns to his origin position")]
		[SerializeField]
		public float maxDistanceFromOrigin;

		[Tooltip("How much distance to track a target for. If surpassed this distance, lose the target")]
		[SerializeField]
		[Min(0f)]
		public float maxDistanceToTarget;

		[Tooltip("The distance this npc will try to be from the current target")]
		[SerializeField]
		public float followDistance;

		[Header("Abilities")]
		[SerializeField]
		public AbilityTriggerData jumpAbility;

		[SerializeField]
		public AbilityTriggerData dashAbility;

		[Header("Future Predict Settings")]
		[Tooltip("How much future predictions will overshoot/stay short. 0 = no prediction, 1 = perfect prediction, 2 = overshooted prediction")]
		[SerializeField]
		public float futurePredictMultiplier;

		[Range(0f, 1f)]
		[SerializeField]
		[Tooltip("How accurate future predictions will be. 0 = perfect future prediction, 1 = future prediction will be randomized, meaning the prediction will be offseted by the random given amount (will fall short or overshoot the prediction)")]
		public float futurePredictUnaccuracy;

		[Header("Pathing Settings")]
		[Tooltip("Do you want the npc to move and not be idle all the time?")]
		[SerializeField]
		public bool isPathingNpc;

		[SerializeField]
		public float timeToWaitAtPosition;

		[Tooltip("Direction of path to move in. Returns to starting position and loops after. If 0,0 it will randomly roam around the area.")]
		[SerializeField]
		public Vector2 pathingDirectionScale;

		[NonSerialized]
		public bool isRoamingNpc;

		[Tooltip("Bypass all pathing to try to stay in the BR zone.")]
		[SerializeField]
		public bool stayInZone;

		[SerializeField]
		public float minDistAmount;

		[SerializeField]
		public float maxDistAmount;

		[Header("Divide Config")]
		[SerializeField]
		public bool isOriginalSlime;

		[SerializeField]
		public bool isLastSlimeTier;

		[SerializeField]
		public ItemDrops finalItemRandomDrops;

		[SerializeField]
		[Header("Effects")]
		public GameObject alertVfxObj;

		[SerializeField]
		public AudioPlayRandom audioPlayRandom;

		[SerializeField]
		public JiggleRigBuilder jiggleRig;

		[Header("Music")]
		[SerializeField]
		public AudioProximityMusicPlay musicPlayer;

		[SerializeField]
		public AudioProximityMusicPlay musicPlayEndPrefab;

		[SerializeField]
		public AudioClipData musicPlayEnd;

		[SerializeField]
		public int musicPlayEndPriority;

		[SerializeField]
		public float musicPlayEndFadeDuration;

		[SerializeField]
		public float musicPlayEndDuration;

		[Header("Slime Puddles Settings")]
		[SerializeField]
		public GameObject slowPrefab;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[SerializeField]
		public float slowTtl;

		[SerializeField]
		public float slowSpawnDistance;

		[SerializeField]
		public AudioPlayRandomReference jumpMoveAudio;

		[NonSerialized]
		public Vector3 currentTargetMovePosition;

		[NonSerialized]
		public LayerMask obstacleMask;

		[NonSerialized]
		public bool finalLootEnabled;

		[NonSerialized]
		public List<SlimeBossBehaviour> dividedSlimes;

		[NonSerialized]
		public int slimeKillCounter;

		[NonSerialized]
		public bool isInAlert;

		public override void PreAwake(EntityManager e)
		{
		}

		public override void Start()
		{
		}

		public override void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void TrySetAggro(Transform target)
		{
		}

		[Server]
		public void SvOnSlimeDefeated()
		{
		}

		[ClientRpc]
		public void RpcOnBossDefeated()
		{
		}

		public void ClOnBossDefeated()
		{
		}

		public void OnParachuteUpdateLandedState(bool isDropping)
		{
		}

		public void SpawnSlowArea()
		{
		}

		public void ClSetIsInAlert(bool isInAlert)
		{
		}

		public void OnIsInAlertChanged()
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

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcOnBossDefeated()
		{
		}

		public static void InvokeUserCode_RpcOnBossDefeated(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static SlimeBossBehaviour()
		{
		}
	}
}
