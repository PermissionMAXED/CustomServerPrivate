using UnityEngine;

namespace BAPBAP.Entities
{
	[CreateAssetMenu(fileName = "P_OnUse_AtkSpeed", menuName = "BAPBAP/Passives/P_OnUse_AtkSpeed")]
	public class P_OnUse_AtkSpeed_SO : PassiveSO
	{
		[SerializeField]
		public P_OnUse_AtkSpeed.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
