using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class DownedDashAbility : Ability
	{
		public class CustomTeleportLerpSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public DownedDashAbility ability;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float waitTime;

			[NonSerialized]
			public float adjustedTime;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public Vector3 originalPos;

			[NonSerialized]
			public Vector3 targetPos;

			public CustomTeleportLerpSubroutine(DownedDashAbility _ability, byte _trigger, float _waitTime)
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
		}

		[SerializeField]
		[Header("General")]
		public InputType inputType;

		[SerializeField]
		[Header("Indicator")]
		public GameObject indicatorPrefab;

		[SerializeField]
		public Vector2 indicatorHalfScale;

		[SerializeField]
		public Vector2 indicatorOffset;

		[SerializeField]
		public bool indicatorDoCollision;

		[SerializeField]
		public bool indicatorClampToMouse;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float teleportLerpTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		[Header("Misc")]
		public AnimationCurve jumpLerpCurve;

		[SerializeField]
		public float teleportMaxDistance;

		[SerializeField]
		public float teleportRadiusCheck;

		[SerializeField]
		[Header("Effects")]
		public float camShakeTrauma;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxDashCastPrefab;

		[SerializeField]
		public GameObject vfxDashFollowPrefab;

		[SerializeField]
		[Header("SFX")]
		public AudioClipData sfxDashCast;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public override string GetTooltipDescription()
		{
			return null;
		}

		public override string GetTooltipExpandedDescription()
		{
			return null;
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
