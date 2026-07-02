using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class ShadowArcherBehaviour : NpcBehaviour
	{
		public class CustomNpcLookAtTargetSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcBehaviour npcBehaviour;

			public CustomNpcLookAtTargetSubroutine(NpcBehaviour _npcBehaviour)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomAlertStateSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public ShadowArcherBehaviour npcBehaviour;

			[NonSerialized]
			public byte targetLostTrigger;

			public CustomAlertStateSubroutine(ShadowArcherBehaviour _behaviour, byte _targetLostTrigger)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomEnableAlertSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public ShadowArcherBehaviour behaviour;

			public CustomEnableAlertSubroutine(ShadowArcherBehaviour _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomDisableAlertSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public ShadowArcherBehaviour behaviour;

			public CustomDisableAlertSubroutine(ShadowArcherBehaviour _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomDropAgroSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public ShadowArcherBehaviour npcBehaviour;

			[NonSerialized]
			public byte targetLostTrigger;

			[NonSerialized]
			public byte nextTrigger;

			[NonSerialized]
			public float timer;

			[NonSerialized]
			public float time;

			[NonSerialized]
			public float maxDistFromSelfSqr;

			public CustomDropAgroSubroutine(ShadowArcherBehaviour _behaviour, byte _targetLostTrigger, byte _nextTrigger, float _time, float _maxDistFromSelf)
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

		[SerializeField]
		public int healthSolo;

		[SerializeField]
		public int healthDuo;

		[SerializeField]
		public int healthTrio;

		[SerializeField]
		[Tooltip("How much distance until this npc has had enough and starts targeting close players")]
		[Header("Idle State")]
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
		public AbilityTriggerData arrowAbility;

		[SerializeField]
		public AbilityTriggerData rainAbility;

		[SerializeField]
		public AbilityTriggerData recoilAbility;

		[Header("Effects")]
		public GameObject alertVfxObj;

		public AudioPlayRandom audioPlayRandom;

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
	}
}
