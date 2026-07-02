using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_Jetpack_SO : AbilityBehaviourSO
	{
		[SerializeField]
		public AB_Jetpack.Config configuration;

		public override AbilityBehaviour.AbilityBehaviourConfig config => null;

		public override AbilityBehaviour NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
