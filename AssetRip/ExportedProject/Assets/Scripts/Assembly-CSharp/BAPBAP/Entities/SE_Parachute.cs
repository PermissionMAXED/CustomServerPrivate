using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Parachute : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
			[Header("Custom Config")]
			[Min(0.01f)]
			[Tooltip("How much time is it gonna take to land to the ground")]
			public float defaultDuration;

			[Header("Land Hitbox Settings")]
			public bool spawnHitboxOnLand;

			public GameObject landingHitboxPrefab;

			public int damage;

			public float ttl;

			public float hitboxRadius;

			public StatusEffectInfo statusEffect;

			[Header("Anim Config")]
			public float droppingHeight;

			public AnimationCurve dropCurve;

			public AnimationClip swayAnimClip;

			public GameObject parachutePrefab;

			[Header("SFX")]
			public bool spawnPreLandSfx;

			public float preLandSfxTimeBeforeLand;

			public AudioClipData[] preLandSfxData;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public ParachuteConfig parachuteConfig;

		[NonSerialized]
		public float totalDuration;

		[NonSerialized]
		public bool spawnedPreLandSfx;

		[NonSerialized]
		public Animation swayAnimation;

		[NonSerialized]
		public Transform parachutePivot;

		[NonSerialized]
		public GameObject customParachuteObj;

		[NonSerialized]
		public bool spawnPreLandSfx;

		[NonSerialized]
		public float preLandSfxTimeBeforeLand;

		[NonSerialized]
		public AudioClipData[] preLandSfxData;

		public bool spawnHitboxOnLand;

		public GameObject landingHitboxPrefab;

		public int damage;

		public float ttl;

		public float hitboxRadius;

		public StatusEffectInfo statusEffect;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_Parachute(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public void TryInitializeParachuteConfig()
		{
		}

		public override void Activate(float _duration, float _multiplier, int _otherPlayerId, Vector3 _direction)
		{
		}

		public override void Deactivate()
		{
		}

		public override void ClActivate(float _duration, float _multiplier)
		{
		}

		public override void ClDeactivate()
		{
		}

		public override void OnUpdate()
		{
		}

		public void SpawnLandingHitbox()
		{
		}

		public void ClUpdateDroppingHeight(float landingTime)
		{
		}

		public void ClUpdateState(bool isEnabled)
		{
		}
	}
}
