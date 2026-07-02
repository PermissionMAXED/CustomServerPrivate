using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SkullBlobLargeBehaviour : PathingNpcBehaviour
	{
		public class ClDestroyIndicatorSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SkullBlobLargeBehaviour behaviour;

			public ClDestroyIndicatorSubroutine(SkullBlobLargeBehaviour _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomSetAlertSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SkullBlobLargeBehaviour behaviour;

			[NonSerialized]
			public bool setEnabled;

			public CustomSetAlertSubroutine(SkullBlobLargeBehaviour _behaviour, bool _setEnabled)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomExplodeTriggerSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SkullBlobLargeBehaviour behaviour;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float targetHp;

			public CustomExplodeTriggerSubroutine(SkullBlobLargeBehaviour _behaviour, byte _trigger)
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

		[Header("Abilities")]
		[SerializeField]
		public AbilityTriggerData meleeAbility;

		[SerializeField]
		public AbilityTriggerData jumpAbility;

		[SerializeField]
		public AbilityTriggerData explodeAbility;

		[SerializeField]
		public bool useExplode;

		[SerializeField]
		[Header("Effects")]
		public GameObject alertVfxObj;

		[NonSerialized]
		public bool isInAlert;

		[NonSerialized]
		public NpcSkullBlobMeleeAbility blobMeleeAbility;

		[NonSerialized]
		public NpcSkullBlobBigSlamAbility blobJumpAbility;

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
