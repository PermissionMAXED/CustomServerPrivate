using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class BigEvilRobotBehaviour : PathingNpcBehaviour
	{
		public class CustomSetAlertSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public BigEvilRobotBehaviour behaviour;

			[NonSerialized]
			public bool setEnabled;

			public CustomSetAlertSubroutine(BigEvilRobotBehaviour _behaviour, bool _setEnabled)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomCancelAbilityOnTargetLostSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcBehaviour behaviour;

			[NonSerialized]
			public Ability ability;

			[NonSerialized]
			public bool canceled;

			[NonSerialized]
			public float lostDelayTime;

			[NonSerialized]
			public float delayTimer;

			public CustomCancelAbilityOnTargetLostSubroutine(NpcBehaviour _behaviour, Ability _ability, float _lostDelayTime = 0.5f)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}

			public void TriggerLost()
			{
			}
		}

		[Header("Abilities")]
		[SerializeField]
		public AbilityTriggerData meleeAbility;

		[SerializeField]
		public AbilityTriggerData shotgunAbility;

		[SerializeField]
		public AbilityTriggerData flamethrowerAbility;

		[Header("Effects")]
		public GameObject alertVfxObj;

		public AudioPlayRandom audioPlayRandom;

		[NonSerialized]
		public bool isInAlert;

		public override void PreAwake(EntityManager e)
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
