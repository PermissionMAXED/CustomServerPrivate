using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class Ability : NetworkBehaviour
	{
		[SerializeField]
		[Header("General")]
		[Tooltip("Which command will this ability be casted with? (LMB = Ability1, Q = Ability2, Space = Ability3, E = Ability4)")]
		public CommandId cmdId;

		[SerializeField]
		public bool useCustomUIData;

		[ConditionalHide("useCustomUIData", true)]
		[SerializeField]
		public UICharactersConfiguration.CharacterConfiguration.AbilityData customUIData;

		[ConditionalHide("useCustomUIData", true)]
		[SerializeField]
		public Color customUIIconColor;

		[ConditionalHide("useCustomUIData", true)]
		[SerializeField]
		public Color customUITitleColor;

		[Tooltip("This ability will be able to auto-cancel other abilities (equivalent to canceling the current casting one and casting this new one)")]
		[SerializeField]
		[Header("Mechanics")]
		public bool autoCancel;

		[Tooltip("Prioritization used in input buffering. When 2 or more abilities are queued to be casted, the higher priority is always casted first (Low = 1, High = 4)")]
		[SerializeField]
		public int priority;

		[Tooltip("After releasing the input, inputs will be held in a buffer for this amount of time (default 250ms)")]
		[SerializeField]
		public float inputBufferDuration;

		[SerializeField]
		[Tooltip("When cancelling an ability, the player needs to wait this amount of time before recasting")]
		public float canceledTime;

		[Tooltip("If the character is silenced, this ability will be interrupted")]
		[SerializeField]
		public bool silenceable;

		[Tooltip("This ability may be cancelable by pressing the Cancel button or casting a canceler")]
		[SerializeField]
		public bool cancelable;

		[SerializeField]
		[Tooltip("Is this ability able to be casted while being downed?")]
		public bool usableOnDowned;

		[SerializeField]
		[Tooltip("Is this ability able to perform critical damage?")]
		public bool enableCritDmg;

		[SerializeField]
		[Tooltip("How much can the server dilate the casting time? (default 200ms)")]
		public float maxTimeDilation;

		[NonSerialized]
		public byte useLocks;

		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharSimulation charSim;

		[NonSerialized]
		public CharAbilities charAbilities;

		[NonSerialized]
		public CharPassives charPassives;

		[NonSerialized]
		public EntityMovement charMove;

		[NonSerialized]
		public CharAim charAim;

		[NonSerialized]
		public CharAnimator charAnim;

		[NonSerialized]
		public CharHurtbox charHurtbox;

		[NonSerialized]
		public CharTriggerbox charTriggerbox;

		[NonSerialized]
		public CharEvents charEvents;

		[NonSerialized]
		public CharFX charFx;

		[NonSerialized]
		public CharItems charItems;

		[NonSerialized]
		public CharHidden charHidden;

		[NonSerialized]
		public CharMaterial charMaterial;

		[NonSerialized]
		public CharStatusEffects charStatusEffects;

		[NonSerialized]
		public CharVoicelines CharVoicelines;

		[NonSerialized]
		public CharDowned charDowned;

		[NonSerialized]
		public VfxManager vfxM;

		[NonSerialized]
		public AudioManager audioM;

		[NonSerialized]
		public StatusEffectManager statusEffectM;

		[NonSerialized]
		public SimulationFsm fsm;

		[NonSerialized]
		public byte stateId;

		[NonSerialized]
		public byte triggerId;

		[NonSerialized]
		public byte TRIGGER_NONE;

		[NonSerialized]
		public byte TRIGGER_FORCEINTERRUPT_EXT;

		[NonSerialized]
		public byte npcCastExternalTrigger;

		[NonSerialized]
		public byte npcInterruptExternalTrigger;

		[NonSerialized]
		public AbilityStates state;

		[NonSerialized]
		public float dilatedTime;

		[NonSerialized]
		public bool isInputBuffered;

		[NonSerialized]
		public float inputBufferTimeLeft;

		[NonSerialized]
		public CooldownSubroutine cooldownSubroutine;

		[NonSerialized]
		public CooldownSubroutine startCdSubroutine;

		[NonSerialized]
		public CastSubroutine castSubroutine;

		public virtual void PreAwake(EntityManager _entityManager)
		{
		}

		public virtual void Start()
		{
		}

		public virtual void Tick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public virtual void ClStartAuth()
		{
		}

		public virtual void ClStopAuth()
		{
		}

		public virtual void LoadAbilityUI()
		{
		}

		public virtual void UpdateAbilityBehaviourChanged(int consumableSlot)
		{
		}

		public virtual void ResetInputBuffer()
		{
		}

		public bool IsCriticalDamage(int predTickNum, int nonce = 0)
		{
			return false;
		}

		public virtual float GetAbilityCooldownTimeElapsed()
		{
			return 0f;
		}

		public virtual float GetAbilityCooldownTime()
		{
			return 0f;
		}

		public bool IsOnCooldown()
		{
			return false;
		}

		public void InitializeElapsedStartCooldown(float baseCooldown)
		{
		}

		public virtual void ResetCooldown()
		{
		}

		public virtual void LowerCooldownByPercent(float percent)
		{
		}

		public virtual void ChangeCastTime(float ct)
		{
		}

		[Server]
		public virtual void OnTargetHit(EntityManager otherEntityManager, HitboxBase hitboxBase)
		{
		}

		[Server]
		public virtual void OnTargetKill(EntityManager otherEntityManager)
		{
		}

		[Server]
		public virtual void OnWallHit(GameObject hboxObj)
		{
		}

		[Server]
		public virtual void OnOtherHitboxHit(Hitbox otherHitbox, HitboxBase hitboxBase)
		{
		}

		[Server]
		public virtual void OnHitboxDestroy(HitboxBase hitboxBase)
		{
		}

		[Server]
		public virtual void OnHitboxEnd(List<EntityManager> entityHits)
		{
		}

		public virtual void GenericAbilityTrigger1()
		{
		}

		public virtual bool OnStopItemRemoved()
		{
			return false;
		}

		public virtual string GetTooltipDescription()
		{
			return null;
		}

		public virtual string GetTooltipExpandedDescription()
		{
			return null;
		}

		public string BuildTooltipDescription(string[] statStrings)
		{
			return null;
		}

		public string GetTooltipScaledDamage(int baseDamage, float damageScaling)
		{
			return null;
		}

		public string GetTooltipScaledDamagePerSecond(int baseDamage, float damageScaling, float damageRate)
		{
			return null;
		}

		public string GetTooltipScaledCooldownStat(float baseCooldown)
		{
			return null;
		}

		public string GetTooltipBaseCooldownStat(float baseCooldown)
		{
			return null;
		}

		public string GetTooltipStat(float statValue, BAPBAP.Items.Stats stat)
		{
			return null;
		}

		public string GetTooltipStatPercent(float statNormValue, BAPBAP.Items.Stats stat, bool includeSign = true)
		{
			return null;
		}

		public string GetTooltipStatusEffect(StatusEffectSO statusEffect)
		{
			return null;
		}

		public static string GetTooltipStatusEffect(int statusEffectId)
		{
			return null;
		}

		public void SetState(AbilityStates _state)
		{
		}

		public void FireExternalCast()
		{
		}

		public void FireExternalInterrupt()
		{
		}

		public virtual void ForceInterrupt()
		{
		}

		public void OnStateChanged()
		{
		}

		public virtual void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public virtual void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public virtual bool OnNetDebugCompare(NetworkReader netReader)
		{
			return false;
		}

		public virtual void OnNetDebugLog(StringBuilder sb)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
