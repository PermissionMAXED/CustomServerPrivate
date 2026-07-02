using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_AO_CatPolymorph : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public bool applyAtkSpeedMultiplier;

			public bool applyCooldownMultiplier;

			public InputType inputType;

			public MotionLockType motionLockType;

			public RotationLockType rotationLockType;

			public float equipTime;

			public float castTime;

			public float dashTime;

			public float dashDistance;

			public AnimationCurve dashLerpCurve;

			public float additiveSpeed;

			public float inputBufferDuration;

			public CommandId targetAbility;

			[Header("Anim/FX Config")]
			public GameObject catSwapPrefab;

			public GameObject transformFxPrefab;

			public string catDashState;

			public string catWalkState;

			[Header("UI Config")]
			public string titleTranslationKey;

			public string descTranslationKey;

			public Color iconColor;

			public Color titleColor;
		}

		public class CustomStopSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_AO_CatPolymorph passive;

			[NonSerialized]
			public int catFormId;

			public CustomStopSubroutine(P_AO_CatPolymorph _ability)
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

		public class CustomDashLerpSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public P_AO_CatPolymorph passive;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float waitTime;

			[NonSerialized]
			public LayerMask obstacleMask;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public Vector3 originalPos;

			[NonSerialized]
			public Vector3 targetPos;

			public CustomDashLerpSubroutine(P_AO_CatPolymorph _ability, byte _trigger, float _waitTime)
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

		public class CallGenericAbilityTrigger1 : SimulationSubroutine
		{
			[NonSerialized]
			public P_AO_CatPolymorph passive;

			public CallGenericAbilityTrigger1(P_AO_CatPolymorph _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomEquipSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_AO_CatPolymorph passive;

			public CustomEquipSubroutine(P_AO_CatPolymorph _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomRemoveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_AO_CatPolymorph passive;

			public CustomRemoveSubroutine(P_AO_CatPolymorph _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public Ability targetAbility;

		[NonSerialized]
		public float targetAbilityOriginalInputBufferDuration;

		[NonSerialized]
		public Transform catHolderTransform;

		[NonSerialized]
		public PistolModelHolder cat;

		[NonSerialized]
		public int catShootStateHash;

		[NonSerialized]
		public int catWalkStateHash;

		[NonSerialized]
		public string titleStr;

		[NonSerialized]
		public string descStr;

		[NonSerialized]
		public bool inactive;

		[NonSerialized]
		public float dashDistance;

		[NonSerialized]
		public bool jumping;

		public override PassiveConfiguration passiveConfig => null;

		public P_AO_CatPolymorph(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void TryDeactivate()
		{
		}

		public override void ClCustomEvent0()
		{
		}

		public override void ClCustomEvent1()
		{
		}

		public void ClOnShoot()
		{
		}

		public void ClOnEquip()
		{
		}

		public void ClShootCat(PistolModelHolder cat)
		{
		}

		public void ClEquipCat(PistolModelHolder cat)
		{
		}

		public PistolModelHolder ClSpawnCatModel()
		{
			return null;
		}

		public void ClDespawnCatModel(PistolModelHolder harpoon)
		{
		}

		public override void Tick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void ActivatePassive()
		{
		}

		public override void DeactivatePassive()
		{
		}

		public override void ClActivatePassive()
		{
		}

		public override void ClDeactivatePassive()
		{
		}
	}
}
