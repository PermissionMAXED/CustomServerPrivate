using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class CatJumpAbility : Ability
	{
		public class CustomJumpSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public CatJumpAbility ability;

			public CustomJumpSubroutine(CatJumpAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomResetSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public CatJumpAbility ability;

			public CustomResetSubroutine(CatJumpAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public CatJumpAbility ability;

			public CustomShootSubroutine(CatJumpAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomFloatSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public CatJumpAbility ability;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float jumpTime;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public Vector3 originalPos;

			[NonSerialized]
			public Vector3 landingPos;

			public CustomFloatSubroutine(CatJumpAbility _ability, byte _trigger, float _jumpTime)
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

		[Header("General")]
		[SerializeField]
		public GameObject spellPrefab;

		[SerializeField]
		public Transform firingPoint;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public RotationLockType jumpRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[Header("State-related")]
		[SerializeField]
		public float hitboxRadius;

		[SerializeField]
		public float ttl;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float jumpTime;

		[SerializeField]
		public float floatTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[Header("Misc")]
		[SerializeField]
		public AnimationCurve jumpLerpCurve;

		[SerializeField]
		public AnimationCurve baseShadowAlphaCurve;

		[SerializeField]
		public float jumpDistance;

		[SerializeField]
		public float jumpRadiusCheck;

		[Header("Effects")]
		[SerializeField]
		public float camShakeTrauma;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxJumpPrefab;

		[SerializeField]
		public GameObject vfxLandPrefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxCast;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public byte EXT_TRIGGER_RESET;

		[NonSerialized]
		public int jumpCount;

		[NonSerialized]
		public bool hit;

		public override void PreAwake(EntityManager _charManager)
		{
		}

		public void Shoot(Vector3 landingPoint, Vector3 dir, int predTickNum)
		{
		}

		[Server]
		public override void OnTargetHit(EntityManager cM, HitboxBase hitboxBase)
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
