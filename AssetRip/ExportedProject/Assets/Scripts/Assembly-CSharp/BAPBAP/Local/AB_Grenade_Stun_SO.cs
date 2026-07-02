using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_Grenade_Stun_SO : AbilityBehaviourSO
	{
		[SerializeField]
		public AB_Grenade_Stun.Config configuration;

		public override AbilityBehaviour.AbilityBehaviourConfig config => null;

		public override AbilityBehaviour NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
