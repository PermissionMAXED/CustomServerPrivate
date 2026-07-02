using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class RoamingWolfBehaviour : PathingNpcBehaviour
	{
		public class CustomEnableAlertSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public RoamingWolfBehaviour behaviour;

			public CustomEnableAlertSubroutine(RoamingWolfBehaviour _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomDisableAlertSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public RoamingWolfBehaviour behaviour;

			public CustomDisableAlertSubroutine(RoamingWolfBehaviour _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[Header("Abilities")]
		[SerializeField]
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
