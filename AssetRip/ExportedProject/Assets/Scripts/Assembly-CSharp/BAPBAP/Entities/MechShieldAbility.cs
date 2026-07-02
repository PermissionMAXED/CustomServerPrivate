using System;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class MechShieldAbility : Ability
	{
		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public MechShieldAbility ability;

			public CustomShootSubroutine(MechShieldAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[SerializeField]
		[Header("General")]
		public GameObject shieldPrefab;

		[SerializeField]
		public Transform firingPoint;

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
		public float maxDistance;

		[Header("Hitbox-related")]
		[SerializeField]
		public float ttl;

		[SerializeField]
		public float activateDuration;

		[SerializeField]
		[Header("State-related")]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

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
		[Header("Misc")]
		public float interpDuration;

		[SerializeField]
		public float height;

		[SerializeField]
		public AnimationCurve heightCurve;

		[SerializeField]
		public float navRadiusCheck;

		[SerializeField]
		[Header("Effects")]
		public float camKickPower;

		[SerializeField]
		[Header("SFX")]
		public GameObject vfxCastPrefab;

		[SerializeField]
		public AudioClipData sfxCast;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void Shoot(Vector3 targetPos)
		{
		}

		[ClientRpc]
		public void RpcOnShieldStart(GameObject shieldObj)
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

		public void UserCode_RpcOnShieldStart__GameObject(GameObject shieldObj)
		{
		}

		public static void InvokeUserCode_RpcOnShieldStart__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static MechShieldAbility()
		{
		}
	}
}
