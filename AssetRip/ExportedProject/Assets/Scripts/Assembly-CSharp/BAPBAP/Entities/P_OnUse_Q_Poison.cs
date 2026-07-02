using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnUse_Q_Poison : P_OnUse_Poison
	{
		public P_OnUse_Q_Poison(EntityManager entityManager, Config config)
			: base(null, null)
		{
		}

		public override void ActivatePassive()
		{
		}

		public override void DeactivatePassive()
		{
		}

		public override void OnHitboxSpawned(GameObject g, EntityManager cM, int abilityId)
		{
		}

		public new void ModifyHitbox(GameObject g, EntityManager cM)
		{
		}
	}
}
