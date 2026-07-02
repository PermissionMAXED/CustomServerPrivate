using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnHit_Lmb_LowerCd : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float cdReductionAmount;

			public float cdReductionCritAmount;

			public GameObject vfxFollowPrefab;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int vfxFollowId;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnHit_Lmb_LowerCd(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnHitTrigger(EntityManager hittedEntity, HitboxBase hitboxBase, int abilityId)
		{
		}

		public void ReduceCD(Ability ability, float amount, bool secondaryHitbox)
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
