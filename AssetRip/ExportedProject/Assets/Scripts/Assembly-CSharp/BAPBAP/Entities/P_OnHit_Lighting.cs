using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnHit_Lighting : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public CommandId targetAbilityCmdId;

			[Range(0f, 1f)]
			[Tooltip("Chance to apply lighting on ability hit")]
			public float applyChance;

			[Tooltip("Chance to apply lighting on ability critical hit")]
			[Range(0f, 1f)]
			public float critApplyChance;

			[Tooltip("Once lighting has been applied, how much to wait until able to apply again")]
			[Min(0f)]
			public float appliedCooldown;

			[Header("Lighting Config")]
			public GameObject lightingHitboxPrefab;

			[Min(0f)]
			public float hitboxTtl;

			public int lightingDmg;

			public float lightingPercentDmg;

			public float damageScaling;

			[Header("FX Config")]
			public GameObject vfxReadyPrefab;

			public SFXData sfxReadyData;
		}

		public class CustomCdSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnHit_Lighting passive;

			public CustomCdSubroutine(P_OnHit_Lighting _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public bool passiveReady;

		[NonSerialized]
		public byte TRIGGER_COOLDOWN;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnHit_Lighting(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnHitTrigger(EntityManager entity, HitboxBase hitboxBase, int abilityId)
		{
		}

		public void SpawnLighting(EntityManager entity)
		{
		}
	}
}
