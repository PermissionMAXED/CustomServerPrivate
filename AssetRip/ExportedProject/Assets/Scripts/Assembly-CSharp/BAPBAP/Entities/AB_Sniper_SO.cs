using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_Sniper_SO : AbilityBehaviourSO
	{
		[SerializeField]
		public AB_Sniper.Config configuration;

		public override AbilityBehaviour.AbilityBehaviourConfig config => null;

		public override AbilityBehaviour NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
