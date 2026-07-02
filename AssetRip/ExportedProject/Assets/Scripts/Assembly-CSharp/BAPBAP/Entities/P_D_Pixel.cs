using System;
using System.Collections.Generic;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_D_Pixel : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public GameObject trailHitbox;

			public float trailTtl;

			public float trailSpawnDistance;

			public List<StatusEffectInfo> statusEffects;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public Vector3 lastTrailPos;

		[NonSerialized]
		public Vector3 lastMoveDir;

		public override PassiveConfiguration passiveConfig => null;

		public P_D_Pixel(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void Tick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void ClTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void SpawnTrailArea(Vector3 overrideDirection)
		{
		}

		public override Vector3 ApplyInputDirModification(Vector3 inputDir)
		{
			return default(Vector3);
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
	}
}
