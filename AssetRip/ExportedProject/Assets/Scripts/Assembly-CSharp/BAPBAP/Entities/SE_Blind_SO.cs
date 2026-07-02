using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Blind_SO : StatusEffectSO
	{
		[SerializeField]
		public SE_Blind.Config configuration;

		public static int Id;

		public override StatusEffect.StatusEffectConfiguration config => null;

		public override StatusEffect NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
