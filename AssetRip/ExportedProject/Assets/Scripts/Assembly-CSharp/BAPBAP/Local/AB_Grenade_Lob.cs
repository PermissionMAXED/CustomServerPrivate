using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Entities;
using BAPBAP.Network;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_Grenade_Lob : AbilityBehaviour
	{
		[Serializable]
		public class Config : AbilityBehaviourConfig
		{
			public MotionLockType motionLockType;

			public RotationLockType rotationLockType;

			public float minCastingTime;

			public float maxCastingTime;

			[Tooltip("Interrupts the casting if entity just got damaged")]
			public bool interuptCastOnDamage;

			[Header("Custom Config")]
			public GameObject travelSpellPrefab;

			public GameObject dmgSpellPrefab;

			[Header("Indicator")]
			public GameObject indicatorPrefab;

			public Vector2 indicatorMouseHalfScale;

			public Vector2 indicatorBaseHalfScale;

			public Vector2 indicatorOffset;

			public float indicatorChargeFactorMultiplier;

			public bool indicatorRotateWithDirection;

			[Header("Hitbox-related")]
			public float radius;

			public int damage;

			public float ttl;

			public float dmgTTL;

			public float hitboxScaleTime;

			public List<StatusEffectInfo> statusEffects;

			[Header("Misc")]
			public float interpDuration;

			public float height;

			public AnimationCurve heightCurve;

			public float zoomOutMultiplier;

			[Header("VFX/SFX")]
			public GameObject castLoopVfx;

			public AudioClipData sfxCast;

			public GameObject vfxShootPrefab;

			public AudioClipData sfxShoot;
		}

		public class CustomChargeSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_Grenade_Lob behaviour;

			[NonSerialized]
			public byte finishTrigger;

			[NonSerialized]
			public bool inputUp;

			[NonSerialized]
			public Vector3 maxMouseIndicatorScale;

			[NonSerialized]
			public Vector2 lerpSize;

			[NonSerialized]
			public float timeElapsed;

			public CustomChargeSubroutine(AB_Grenade_Lob ability, byte finishTrigger)
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

		public class CustomThrowGrenadeSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_Grenade_Lob behaviour;

			public CustomThrowGrenadeSubroutine(AB_Grenade_Lob behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public Vector3 targetPos;

		[NonSerialized]
		public float chargeFactor;

		[NonSerialized]
		public MouseIndicatorSubroutine mouseIndicatorSubroutine;

		[NonSerialized]
		public IndicatorMouse mouseIndicator;

		public AB_Grenade_Lob(Config _config)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}

		public void Shoot(EntityManager cM, Vector3 landingPoint)
		{
		}
	}
}
