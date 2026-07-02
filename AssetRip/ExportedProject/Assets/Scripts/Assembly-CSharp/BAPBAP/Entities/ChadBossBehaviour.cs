using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;
using UnityEngine.AI;

namespace BAPBAP.Entities
{
	public class ChadBossBehaviour : PathingNpcBehaviour
	{
		public class CustomBossReturnSubroutine : SimulationSubroutine
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

			public CustomBossReturnSubroutine(PathingNpcBehaviour _npcBehaviour, byte _trigger)
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

		public class ClDestroyIndicatorSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public ChadBossBehaviour behaviour;

			public ClDestroyIndicatorSubroutine(ChadBossBehaviour _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomEnableAlertSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public ChadBossBehaviour behaviour;

			public CustomEnableAlertSubroutine(ChadBossBehaviour _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomDisableAlertSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public ChadBossBehaviour behaviour;

			public CustomDisableAlertSubroutine(ChadBossBehaviour _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomNpcCastAbilitySubroutine : NpcCastAbilitySubroutine
		{
			public CustomNpcCastAbilitySubroutine(NpcBehaviour _npcBehaviour, AbilityTriggerData _ability, byte _trigger)
				: base((NpcBehaviour)null, (AbilityTriggerData)null, (byte)0, 0f)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		[Header("Boss Settings")]
		[SerializeField]
		public int blobHealthSolo;

		[SerializeField]
		public int blobHealthDuo;

		[SerializeField]
		public int blobHealthTrio;

		[Header("Abilities")]
		[SerializeField]
		public AbilityTriggerData meleeAbility;

		[SerializeField]
		public AbilityTriggerData jumpAbility;

		[Header("Effects")]
		[SerializeField]
		public GameObject alertVfxObj;

		[NonSerialized]
		public bool isInAlert;

		[NonSerialized]
		public BossChadSequenceAbility sequenceAbility;

		[NonSerialized]
		public BossChadTeleportAbility teleportAbility;

		public override void Start()
		{
		}

		public override void PreAwake(EntityManager e)
		{
		}

		public override void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void ClSetIsInAlert(bool isInAlert)
		{
		}

		public override string PropertyName()
		{
			return null;
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
	}
}
