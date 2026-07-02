using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Buff_HP : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public int healthAmount;

			public int bonusHealthPerAmount;

			public float tickRate;

			public GameObject vfxFollowPrefab;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public float timeElapsed;

		[NonSerialized]
		public bool buffApplied;

		[NonSerialized]
		public int maxHpAmount;

		[NonSerialized]
		public int buffAmount;

		[NonSerialized]
		public int vfxLoopId;

		public override PassiveConfiguration passiveConfig => null;

		public P_Buff_HP(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void Tick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void TryApplyBuff()
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
