using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Carried_SO : StatusEffectSO
	{
		[SerializeField]
		public SE_Carried.Config configuration;

		public override StatusEffect.StatusEffectConfiguration config => null;

		public override StatusEffect NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
