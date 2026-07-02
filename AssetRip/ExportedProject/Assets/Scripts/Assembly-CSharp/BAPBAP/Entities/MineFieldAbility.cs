using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class MineFieldAbility : Ability
	{
		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public MineFieldAbility ability;

			public CustomShootSubroutine(MineFieldAbility _ability)
			{
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[Header("General")]
		[SerializeField]
		public GameObject mineSpellPrefab;

		[SerializeField]
		public GameObject explosionSpellPrefab;

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
		[Header("Indicator")]
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
		public float abilityRange;

		[SerializeField]
		public float mineLandingAreaRadius;

		[SerializeField]
		public float explosionRadius;

		[SerializeField]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public int mineNumber;

		[SerializeField]
		public float mineTtl;

		[SerializeField]
		public float explosionTtl;

		[SerializeField]
		public int mineHp;

		[SerializeField]
		public float mineColEnableTimeMultiplier;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("Misc")]
		[SerializeField]
		public float interpDuration;

		[SerializeField]
		public float height;

		[SerializeField]
		public AnimationCurve heightCurve;

		[SerializeField]
		public float mineRandomPosMultiplier;

		[SerializeField]
		public float mineRandomTtlVariation;

		[SerializeField]
		public float zoomOutMultiplier;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		public float startCooldownTime;

		[Header("Effects")]
		[SerializeField]
		public float camShakeTrauma;

		[SerializeField]
		[Header("VFX")]
		public GameObject vfxShootPrefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxCast;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		[Server]
		public void Shoot(Vector3 landingPoint, int predTickNum)
		{
		}

		[Server]
		public void SpawnMine(Vector3 landingPoint, int predTickNum, int critNonce = 0)
		{
		}

		[ClientRpc]
		public void RpcOnMineStart(GameObject mineObj, float duration)
		{
		}

		[Server]
		public void DeactivateCurrentMines()
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

		public void UserCode_RpcOnMineStart__GameObject__Single(GameObject mineObj, float duration)
		{
		}

		public static void InvokeUserCode_RpcOnMineStart__GameObject__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static MineFieldAbility()
		{
		}
	}
}
