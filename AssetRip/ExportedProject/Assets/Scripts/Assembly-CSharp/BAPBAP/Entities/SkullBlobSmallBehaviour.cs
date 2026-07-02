using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SkullBlobSmallBehaviour : PathingNpcBehaviour
	{
		public class CustomSetAlertSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SkullBlobSmallBehaviour behaviour;

			[NonSerialized]
			public bool setEnabled;

			public CustomSetAlertSubroutine(SkullBlobSmallBehaviour _behaviour, bool _setEnabled)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomNpcFollowTargetSubroutine : NpcFollowTargetSubroutine
		{
			[NonSerialized]
			public new SkullBlobSmallBehaviour npcBehaviour;

			[NonSerialized]
			public float maxRetreatElapsedTime;

			public CustomNpcFollowTargetSubroutine(SkullBlobSmallBehaviour _npcBehaviour, byte _triggerTargetLost, float _maxDistFromSelf, float _followDist = 0f, float followDistMargin = 2f, bool _doPivotAroundTarget = false)
				: base(null, 0, 0f, 0f, 0f)
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

		[Header("Skull Blob Config")]
		[Tooltip("Stop moving away from player after this time has passed since entering the state")]
		[SerializeField]
		public float timeToMove;

		[Header("Abilities")]
		[SerializeField]
		public AbilityTriggerData shootAbility;

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
