using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Untargetable_SO : StatusEffectSO
	{
		[SerializeField]
		public SE_Untargetable.Config configuration;

		public static int Id;

		public override StatusEffect.StatusEffectConfiguration config => null;

		public override StatusEffect NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
