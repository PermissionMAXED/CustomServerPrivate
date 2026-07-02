using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_D_SinCity : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public PassiveSO extraDamageOnKillPassive;

			public GameObject bloodExplosion;

			public float bloodExplosionTtl;

			[Header("FX Config")]
			public GameObject bleedVfxPrefab;

			public AudioClip lowHpAudioClip;

			public float lowHpVolume;

			[Header("Bleed Config")]
			public float maxHpToActivate;

			public float bloodSpawnDistance;

			public float bleedHitTime;

			public GameObject bloodHuntPuddle;

			public GameObject bloodDirectionalImpact;

			public float directionalImpactOffset;

			public bool puddleDoTtl;

			public float puddleTtl;

			public List<StatusEffectInfo> statusEffects;

			[Header("Respawn Config")]
			public P_SinCity_RespawnTracker_SO respawnTracker;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_D_SinCity passive;

			[NonSerialized]
			public byte trigger;

			public CustomPassiveSubroutine(P_D_SinCity _passive, byte _trigger)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomBleedSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_D_SinCity passive;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public Vector3 lastTrailPosition;

			[NonSerialized]
			public float trailSpawnDistanceSqr;

			public CustomBleedSubroutine(P_D_SinCity _passive, byte _trigger)
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

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public float lastHitTimer;

		[NonSerialized]
		public AudioSource bleedAudioSource;

		[NonSerialized]
		public bool _isBleeding;

		[NonSerialized]
		public float _meter;

		public override PassiveConfiguration passiveConfig => null;

		public bool IsLowHpThreshold => false;

		public bool IsBleeding => false;

		public P_D_SinCity(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void Tick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void ClTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void SpawnTrailArea(Vector3? overrideDirection = null)
		{
		}

		public override float GetFloat1()
		{
			return 0f;
		}

		public override void OnKilledTrigger(EntityManager killerManager)
		{
		}

		public override void OnTakeDamageTrigger(int damage, Vector3 hitDir)
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

		public void OnIsBleedingChanged()
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
