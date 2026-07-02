using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_AO_CatPolymorph_SO : PassiveSO
	{
		[SerializeField]
		public P_AO_CatPolymorph.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
