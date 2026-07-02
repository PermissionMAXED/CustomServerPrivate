using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class DigitalDashCloneAbility : Ability
	{
		public class CustomDashSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public DigitalDashCloneAbility ability;

			[NonSerialized]
			public byte triggerFinished;

			public CustomDashSubroutine(DigitalDashCloneAbility ability, byte triggerFinished)
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

		[Header("General")]
		[SerializeField]
		public float jumpTime;

		[SerializeField]
		public AnimationCurve dashCurve;

		[NonSerialized]
		public byte EXTERNAL_TRIGGER_CAST;

		[NonSerialized]
		public Vector3 originalPos;

		[NonSerialized]
		public Vector3 targetPos;

		[NonSerialized]
		public float timeElapsed;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void DoDash(Vector3 startPos, Vector3 goalPos)
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
