using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class RockyRuptureAbility : Ability
	{
		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public RockyRuptureAbility ability;

			public CustomShootSubroutine(RockyRuptureAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[Header("General")]
		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public RotationLockType castRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		public float abilityRadius;

		[Header("Indicator")]
		[SerializeField]
		public GameObject indicatorPrefab;

		[SerializeField]
		public Vector2 indicatorMouseHalfScale;

		[SerializeField]
		public Vector2 indicatorBaseHalfScale;

		[SerializeField]
		public Vector2 indicatorOffset;

		[SerializeField]
		public float indicatorMaxDistance;

		[SerializeField]
		public bool indicatorRotateWithDirection;

		[SerializeField]
		public GameObject visibleIndicatorPrefab;

		[Header("Hitbox-related")]
		[SerializeField]
		public GameObject spellHitPrefab;

		[SerializeField]
		public GameObject spellKnockPrefab;

		[SerializeField]
		public GameObject spellWallPrefab;

		[SerializeField]
		public float impactTime;

		[SerializeField]
		public int initialDamage;

		[SerializeField]
		public float initialDamageScaling;

		[SerializeField]
		public float initialTtl;

		[SerializeField]
		public List<StatusEffectInfo> initialStatusEffects;

		[SerializeField]
		public List<StatusEffectInfo> knockStatusEffects;

		[SerializeField]
		public float wallTtl;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		public float startCooldownTime;

		[SerializeField]
		[Header("Effects")]
		public float camShakeTrauma;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxCastPrefab;

		[SerializeField]
		public GameObject vfxMuzzlePrefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxCast;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		public override void PreAwake(EntityManager _charManager)
		{
		}

		public void Shoot(Vector3 landingPoint, int predTickNum)
		{
		}

		[ClientRpc]
		public void RpcSpawnVisibleIndicator(Vector3 position, Vector3 forward)
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

		public void UserCode_RpcSpawnVisibleIndicator__Vector3__Vector3(Vector3 position, Vector3 forward)
		{
		}

		public static void InvokeUserCode_RpcSpawnVisibleIndicator__Vector3__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static RockyRuptureAbility()
		{
		}
	}
}
