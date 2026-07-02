using System;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class FireMeteoriteAbility : Ability
	{
		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FireMeteoriteAbility ability;

			public CustomShootSubroutine(FireMeteoriteAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[SerializeField]
		[Header("General")]
		public GameObject spellPrefab;

		[SerializeField]
		public Transform firingPoint;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		public float abilityRadius;

		[SerializeField]
		[Header("Hitbox-related")]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float hitboxRadius;

		[SerializeField]
		public float ttl;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		public float startCooldownTime;

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
		public float meteorInterpDuration;

		[Header("Effects")]
		[SerializeField]
		public float camKickPower;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxCast;

		[SerializeField]
		public AudioClipData targetHitAudioClipData;

		[SerializeField]
		public CharVoicelineConfig voicelineCast;

		[SerializeField]
		public CharVoicelineConfig voicelineKill;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public bool resetSfx;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void Shoot(Vector3 landingPoint, int predTickNum)
		{
		}

		[Server]
		public override void OnTargetHit(EntityManager otherEntityManager, HitboxBase hitboxBase)
		{
		}

		[Server]
		public override void OnTargetKill(EntityManager otherEntityManager)
		{
		}

		[ClientRpc]
		public void RpcOnTargetHit(Vector3 hitPosition)
		{
		}

		[ClientRpc]
		public void RcpOnTargetKill(int charId)
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

		public void UserCode_RpcOnTargetHit__Vector3(Vector3 hitPosition)
		{
		}

		public static void InvokeUserCode_RpcOnTargetHit__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RcpOnTargetKill__Int32(int charId)
		{
		}

		public static void InvokeUserCode_RcpOnTargetKill__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static FireMeteoriteAbility()
		{
		}
	}
}
