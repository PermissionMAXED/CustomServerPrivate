using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_AO_Pistol : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public bool applyAtkSpeedMultiplier;

			public bool applyCooldownMultiplier;

			public InputType inputType;

			public MotionLockType motionLockType;

			public int maxAmmo;

			public int dualWieldMaxAmmoMult;

			public float castTime;

			public float recoveryTime;

			public float cooldownTime;

			public float autoReloadTime;

			public float reloadTime;

			public float removeTime;

			public float spread;

			public float inputBufferDuration;

			public CommandId targetAbility;

			public P_D_SinCity_SO P_D_SinCity_SO;

			public bool doGenericAbilityTrigger;

			[Header("Anim/FX Config")]
			public GameObject pistolViewPrefab;

			public AudioClipData reloadStartSfx;

			public AudioClipData reloadEndSfx;

			public float reloadEndSfxDelay;

			public float dualWieldingPosOffset;

			public string gunShootState;

			public string gunReloadStartState;

			[Header("UI Config")]
			public string titleTranslationKey;

			public string descTranslationKey;

			public Color iconColor;

			public Color titleColor;

			[Header("Hitbox Config")]
			public GameObject rockPrefab;

			public float firingPointOffset;

			public int damage;

			public float damageScaling;

			public bool doCrits;

			public float speed;

			public float ttl;

			public List<StatusEffectInfo> statusEffects;
		}

		public class IdleReloadSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_AO_Pistol passive;

			[NonSerialized]
			public byte reloadTrigger;

			[NonSerialized]
			public float autoReloadTime;

			[NonSerialized]
			public float time;

			public IdleReloadSubroutine(P_AO_Pistol _ability, float _autoReloadTime, byte _reloadTrigger)
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

		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_AO_Pistol passive;

			public CustomShootSubroutine(P_AO_Pistol _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CallGenericAbilityTrigger1 : SimulationSubroutine
		{
			[NonSerialized]
			public P_AO_Pistol passive;

			public CallGenericAbilityTrigger1(P_AO_Pistol _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomCheckAmmoSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_AO_Pistol passive;

			[NonSerialized]
			public byte triggerIdle;

			[NonSerialized]
			public byte triggerReload;

			[NonSerialized]
			public byte triggerRemove;

			public CustomCheckAmmoSubroutine(P_AO_Pistol _ability, byte _triggerIdle, byte _triggerReload, byte _triggerRemove)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomIdleReloadAmmoSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_AO_Pistol passive;

			[NonSerialized]
			public byte finishedTrigger;

			[NonSerialized]
			public float reloadTime;

			[NonSerialized]
			public float time;

			public CustomIdleReloadAmmoSubroutine(P_AO_Pistol _ability, float _reloadTime, byte _finishedTrigger)
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
		}

		public class CustomReloadAmmoSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_AO_Pistol passive;

			public CustomReloadAmmoSubroutine(P_AO_Pistol _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomRemovePistolSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_AO_Pistol passive;

			public CustomRemovePistolSubroutine(P_AO_Pistol _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int ammo;

		[NonSerialized]
		public bool isReloading;

		[NonSerialized]
		public bool isDualWielding;

		[NonSerialized]
		public byte TRIGGER_FORCERELOAD;

		[NonSerialized]
		public Ability targetAbility;

		[NonSerialized]
		public float targetAbilityOriginalInputBufferDuration;

		[NonSerialized]
		public Transform pistolHolderTransform;

		[NonSerialized]
		public PistolModelHolder mainPistol;

		[NonSerialized]
		public PistolModelHolder dualPistol;

		[NonSerialized]
		public int gunShootStateHash;

		[NonSerialized]
		public int gunReloadStartStateHash;

		[NonSerialized]
		public string titleStr;

		[NonSerialized]
		public string descStr;

		[NonSerialized]
		public bool inactive;

		[NonSerialized]
		public CooldownSubroutine cooldownSubroutine;

		public override PassiveConfiguration passiveConfig => null;

		public P_AO_Pistol(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public void Shoot(EntityManager cM, int predTickNum)
		{
		}

		public void ReloadAmmo()
		{
		}

		public bool IsInDimension()
		{
			return false;
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

		public void ClOnReload()
		{
		}

		public void ClShootPistol(PistolModelHolder pistol)
		{
		}

		public void ClReloadPistol(PistolModelHolder pistol)
		{
		}

		public PistolModelHolder ClSpawnGunModel()
		{
			return null;
		}

		public void ClDespawnGunModel(PistolModelHolder pistol)
		{
		}

		public override void Tick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void Reactivate()
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

		public override void ClStartAuth()
		{
		}

		public override void ClStopAuth()
		{
		}

		[ClientRpc]
		public void RpcYo()
		{
		}

		public void OnAmmoChanged()
		{
		}

		public void OnIsReloadingChanged()
		{
		}

		public void OnIsDualWieldingChanged()
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
}
