using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Buff_AtkSpeed_To_Crit : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float atkSpeedPercent;

			public float critChance;

			public float critDmg;

			public float tickRate;

			[Header("FX Config")]
			public GameObject vfxLoopPrefab;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public bool buffApplied;

		[NonSerialized]
		public float atkSpeedAmount;

		[NonSerialized]
		public float critChanceAmount;

		[NonSerialized]
		public float critDmgAmount;

		[NonSerialized]
		public float timeElapsed;

		[NonSerialized]
		public int vfxLoopId;

		public override PassiveConfiguration passiveConfig => null;

		public P_Buff_AtkSpeed_To_Crit(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void Tick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void DeactivatePassive()
		{
		}

		public void ApplyBuff()
		{
		}

		public void RevertBuff()
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
