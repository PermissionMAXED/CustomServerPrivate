using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Silenced_SO : StatusEffectSO
	{
		[SerializeField]
		public SE_Silenced.Config configuration;

		public override StatusEffect.StatusEffectConfiguration config => null;

		public override StatusEffect NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
