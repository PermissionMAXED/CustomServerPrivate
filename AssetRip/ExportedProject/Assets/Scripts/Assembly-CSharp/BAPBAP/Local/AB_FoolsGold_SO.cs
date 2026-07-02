using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_FoolsGold_SO : AbilityBehaviourSO
	{
		[SerializeField]
		public AB_FoolsGold.Config configuration;

		public override AbilityBehaviour.AbilityBehaviourConfig config => null;

		public override AbilityBehaviour NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
