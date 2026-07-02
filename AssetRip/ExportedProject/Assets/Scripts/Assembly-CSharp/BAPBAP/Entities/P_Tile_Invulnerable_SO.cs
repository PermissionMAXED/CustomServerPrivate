using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Tile_Invulnerable_SO : PassiveSO
	{
		[SerializeField]
		public P_Tile_Invulnerable.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
