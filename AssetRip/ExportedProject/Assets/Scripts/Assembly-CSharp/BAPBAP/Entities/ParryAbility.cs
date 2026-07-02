using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class ParryAbility : Ability
	{
		public class CustomParryStartSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public ParryAbility ability;

			public CustomParryStartSubroutine(ParryAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomParrySubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public ParryAbility ability;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public byte triggerSilenced;

			[NonSerialized]
			public CastFlags interruptCastFlags;

			public CustomParrySubroutine(ParryAbility _ability, byte _trigger, byte _triggerSilenced)
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

		public class CustomEndParrySubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public ParryAbility ability;

			public CustomEndParrySubroutine(ParryAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomDestroyLoopVfxSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public LoopVfxSubroutine loopVfx;

			public CustomDestroyLoopVfxSubroutine(LoopVfxSubroutine _loopVfx)
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
		public AnimationCurve scaleCurve;

		[Header("Hitbox")]
		[SerializeField]
		public GameObject spellReflectHitbox;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[SerializeField]
		public float meleeDamagePercent;

		[SerializeField]
		public float rangedDamagePercent;

		[SerializeField]
		[Header("State-related")]
		public float castingTime;

		[SerializeField]
		public float parryTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxCastPrefab;

		[SerializeField]
		public GameObject vfxParryLoopPrefab;

		[SerializeField]
		public GameObject vfxParrySuccessPrefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxStart;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public bool isParrying;

		[NonSerialized]
		public LoopVfxSubroutine loopVfxSubroutine;

		[NonSerialized]
		public Hitbox currentParryHitbox;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void Shoot()
		{
		}

		public void StartParry()
		{
		}

		public void EndParry()
		{
		}

		[Server]
		public override void OnOtherHitboxHit(Hitbox otherHitbox, HitboxBase hitboxBase)
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

		[ClientRpc]
		public void RpcPlayParryVfx()
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

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcPlayParryVfx()
		{
		}

		public static void InvokeUserCode_RpcPlayParryVfx(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static ParryAbility()
		{
		}
	}
}
