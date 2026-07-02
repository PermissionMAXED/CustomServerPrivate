using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class NpcArrowMissileAbility : Ability
	{
		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcArrowMissileAbility ability;

			public CustomShootSubroutine(NpcArrowMissileAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomVisibleIndicatorSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcArrowMissileAbility ability;

			[NonSerialized]
			public bool setEnabled;

			public CustomVisibleIndicatorSubroutine(NpcArrowMissileAbility _ability, bool _setEnabled)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
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
		public RotationLockType castRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[Header("Indicator")]
		[SerializeField]
		public GameObject visibleIndicatorPrefab;

		[SerializeField]
		public float indicatorWidth;

		[SerializeField]
		public float indicatorLength;

		[SerializeField]
		public float indicatorRange;

		[Header("Hitbox-related")]
		[SerializeField]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float speed;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public bool destroyOnCharHit;

		[SerializeField]
		public bool destroyOnCollision;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[SerializeField]
		public AnimationCurve speedCurve;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		public float startCooldownTime;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxCastPrefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxCast;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public GameObject currentVisibleIndicator;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void Shoot(Vector3 lookDir, int predTickNum)
		{
		}

		[ClientRpc]
		public void RpcSpawnVisibleIndicator()
		{
		}

		[ClientRpc]
		public void RpcDestroyVisibleIndicator()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcSpawnVisibleIndicator()
		{
		}

		public static void InvokeUserCode_RpcSpawnVisibleIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcDestroyVisibleIndicator()
		{
		}

		public static void InvokeUserCode_RpcDestroyVisibleIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static NpcArrowMissileAbility()
		{
		}
	}
}
