using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_Grenade_Stun : AbilityBehaviour
	{
		[Serializable]
		public class Config : AbilityBehaviourConfig
		{
			public MotionLockType motionLockType;

			public RotationLockType rotationLockType;

			public float castTime;

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

			public float indicatorMaxDistance;

			public bool indicatorRotateWithDirection;

			public GameObject visibleIndicatorPrefab;

			[Header("Hitbox-related")]
			public float abilityRange;

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

		public class CustomSetPositionSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_Grenade_Stun behaviour;

			public CustomSetPositionSubroutine(AB_Grenade_Stun behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomVisibleIndicatorSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_Grenade_Stun behaviour;

			[NonSerialized]
			public bool spawn;

			public CustomVisibleIndicatorSubroutine(AB_Grenade_Stun _behaviour, bool _spawn)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomThrowGrenadeSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_Grenade_Stun behaviour;

			public CustomThrowGrenadeSubroutine(AB_Grenade_Stun behaviour)
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
		public GameObject currentIndicator;

		public AB_Grenade_Stun(Config _config)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}

		public void Shoot(EntityManager cM, Vector3 landingPoint)
		{
		}

		[ClientRpc]
		public void RpcSpawnVisibleIndicator(Vector3 position)
		{
		}

		[ClientRpc]
		public void RpcDestroyVisibleIndicator()
		{
		}
	}
}
