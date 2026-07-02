using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Buff_ApplyStatusEffectToHitboxes_SO : PassiveSO
	{
		[SerializeField]
		public P_Buff_ApplyStatusEffectToHitboxes.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
