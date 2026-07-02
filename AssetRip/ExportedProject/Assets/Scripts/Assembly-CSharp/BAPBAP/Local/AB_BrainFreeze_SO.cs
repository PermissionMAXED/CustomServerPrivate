using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_BrainFreeze_SO : AbilityBehaviourSO
	{
		[SerializeField]
		public AB_BrainFreeze.Config configuration;

		public override AbilityBehaviour.AbilityBehaviourConfig config => null;

		public override AbilityBehaviour NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
