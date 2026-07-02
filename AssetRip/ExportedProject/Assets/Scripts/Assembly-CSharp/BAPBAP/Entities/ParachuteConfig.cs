using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class ParachuteConfig : MonoBehaviour
	{
		[NonSerialized]
		public EntityManager entityManager;

		[SerializeField]
		[Tooltip("Activates the parachute config on this object start")]
		[Header("Settings")]
		public bool applyOnStart;

		[SerializeField]
		[Tooltip("When finished landing, sends a supply drop icon landed update")]
		public bool setSupplyDropLanded;

		[SerializeField]
		[Tooltip("Overrides the default config in SE_Parachute")]
		[Header("Override Config")]
		public bool overrideDuration;

		[Min(0f)]
		[SerializeField]
		public float duration;

		[SerializeField]
		[Tooltip("Overrides the default config in SE_Parachute")]
		[Header("Land Hitbox Settings")]
		public bool overrideSpawnHitboxOnLand;

		[Tooltip("When finished landing, spawns a hitbox")]
		[SerializeField]
		public bool spawnHitboxOnLand;

		[SerializeField]
		public GameObject landingHitboxPrefab;

		[SerializeField]
		public int damage;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public float hitboxRadius;

		[SerializeField]
		public StatusEffectInfo statusEffect;

		[Header("References")]
		[Tooltip("Overrides the default config in SE_Parachute")]
		[SerializeField]
		public Transform customParachutePivot;

		[SerializeField]
		[Tooltip("Overrides the default config in SE_Parachute")]
		public GameObject customParachuteObj;

		[SerializeField]
		[Tooltip("Overrides the default config in SE_Parachute")]
		[Header("SFX")]
		public bool overridePreLandSfx;

		[SerializeField]
		public bool spawnPreLandSfx;

		[SerializeField]
		public float preLandSfxTimeBeforeLand;

		[SerializeField]
		public AudioClipData[] preLandSfxData;

		public Action SvOnParachuteBegin;

		public Action SvOnParachuteLanded;

		public Action<bool> ClOnParachuteUpdateLandedState;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnParachuteLanded()
		{
		}
	}
}
