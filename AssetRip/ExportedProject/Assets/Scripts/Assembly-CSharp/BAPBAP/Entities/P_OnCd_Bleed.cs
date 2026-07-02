using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnCd_Bleed : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public GameObject vfxLoopPrefab;

			public PassiveSO additionalPassiveToActivate;

			public PassiveSO bleedPassive;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnCd_Bleed passive;

			public CustomPassiveSubroutine(P_OnCd_Bleed _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnCd_Bleed(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnDealtDamageTrigger(EntityManager otherCharManager, int damage, bool isCrit, Vector3 hitDir)
		{
		}

		public override void ActivatePassive()
		{
		}

		public override void DeactivatePassive()
		{
		}
	}
}
