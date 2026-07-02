using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_CharAugment_BlindShot_SO : PassiveSO
	{
		[SerializeField]
		public P_CharAugment_BlindShot.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
