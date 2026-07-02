using UnityEngine;

namespace BAPBAP.Entities
{
	[CreateAssetMenu(fileName = "P_OnHpLossFreeze", menuName = "BAPBAP/Passives/P_OnHpLossFreeze")]
	public class P_OnHpLossFreeze_SO : PassiveSO
	{
		[SerializeField]
		public P_OnHpLossFreeze.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
