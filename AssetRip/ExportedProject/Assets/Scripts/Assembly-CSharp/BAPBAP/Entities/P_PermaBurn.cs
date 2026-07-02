using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_PermaBurn : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public int burnDamage;

			public float burnDamagePercentHp;

			public float tickDuration;

			public GameObject vfxLoopPrefab;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public float hitTimer;

		[NonSerialized]
		public int vfxLoopId;

		public override PassiveConfiguration passiveConfig => null;

		public P_PermaBurn(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void Tick(float fixedDt, Command cmd, bool isResim)
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
