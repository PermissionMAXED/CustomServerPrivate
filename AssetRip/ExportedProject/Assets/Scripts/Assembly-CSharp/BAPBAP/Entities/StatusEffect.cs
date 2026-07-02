using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class StatusEffect : IComparable
	{
		[Serializable]
		public class StatusEffectConfiguration
		{
			[Tooltip("Only allows for one instance of this status effect to be active. Any extra status effects added will just reinitialize the existing one.")]
			[Header("Configs")]
			public bool onlyOneInstance;

			[Tooltip("Only allows for one instance of this status effect of the same properties. Any extra identical status effect added will just reinitialize the existing one.")]
			public bool mergeIdentical;

			[Header("Properties")]
			[Tooltip("The status effect will not be deleted when the duration is 0.")]
			public bool ignoreDuration;

			[Tooltip("Is this status effect allowed to be cleansed and removed?")]
			public bool isCleanseable;

			[Tooltip("Is this status effect non-immune? If true, it will be applied even on immune entities")]
			public bool isNonImmune;

			[Tooltip("Is this status effect applying a movement debuff")]
			public bool isMovementDebuff;

			[Header("UI Config")]
			public string nameTranslationKey;

			public string nameAppliedTranslationKey;

			public string spriteId;

			public Color color;

			[Header("FX Config")]
			public GameObject vfxLoopPrefab;

			public GameObject vfxEndPrefab;

			public bool applyCharColor;

			[ConditionalHide("applyCharColor", true)]
			public Color charColor;

			[NonSerialized]
			public string localizedName;

			[NonSerialized]
			public string localizedAppliedName;
		}

		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharStatusEffects charStatusEffects;

		[NonSerialized]
		public CharMaterial charMaterial;

		[NonSerialized]
		public CharFX charFx;

		[NonSerialized]
		public CharHurtbox charHurtbox;

		[NonSerialized]
		public EntityMovement charMove;

		[NonSerialized]
		public CharAbilities charAbilities;

		[NonSerialized]
		public CharTriggerbox charTriggerbox;

		[NonSerialized]
		public CharAim charAim;

		public int id;

		public bool active;

		public float duration;

		public float multiplier;

		[NonSerialized]
		public int otherPlayerId;

		[NonSerialized]
		public Vector3 direction;

		public virtual StatusEffectConfiguration statusEffectConfig => null;

		public StatusEffect(EntityManager em)
		{
		}

		public virtual void OnTick(float fixedDt)
		{
		}

		public virtual void ClOnTick(float fixedDt)
		{
		}

		public virtual void OnUpdate()
		{
		}

		public virtual void Activate(float _duration, float _multiplier, int _otherPlayerId, Vector3 _direction)
		{
		}

		public virtual void Deactivate()
		{
		}

		public virtual void Reactivate(float _duration, float _multiplier, int _otherPlayerId, Vector3 _direction)
		{
		}

		public virtual void ClActivate(float _duration, float _multiplier)
		{
		}

		public virtual void ClDeactivate()
		{
		}

		public virtual void ClReactivate(float _duration, float _multiplier)
		{
		}

		public virtual float GetMultiplier()
		{
			return 0f;
		}

		public virtual Vector3 ApplyInputDirModification(Vector3 inputDir)
		{
			return default(Vector3);
		}

		public int CompareTo(object obj)
		{
			return 0;
		}

		public int CompareTo(StatusEffect other)
		{
			return 0;
		}
	}
}
