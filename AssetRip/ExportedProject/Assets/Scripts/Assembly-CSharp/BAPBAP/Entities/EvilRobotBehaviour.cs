using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EvilRobotBehaviour : PathingNpcBehaviour
	{
		public class CustomSetAlertSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public EvilRobotBehaviour behaviour;

			[NonSerialized]
			public bool setEnabled;

			public CustomSetAlertSubroutine(EvilRobotBehaviour _behaviour, bool _setEnabled)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomSetTargetDestinationSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcBehaviour npcBehaviour;

			public CustomSetTargetDestinationSubroutine(NpcBehaviour _npcBehaviour)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		[SerializeField]
		[Header("Abilities")]
		public AbilityTriggerData meleeAbility;

		[SerializeField]
		public AbilityTriggerData dashAbility;

		[Header("Effects")]
		public GameObject alertVfxObj;

		public AudioPlayRandom audioPlayRandom;

		[NonSerialized]
		public bool isInAlert;

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
