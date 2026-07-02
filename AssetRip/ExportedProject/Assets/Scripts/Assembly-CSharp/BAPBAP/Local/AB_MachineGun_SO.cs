using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_MachineGun_SO : AbilityBehaviourSO
	{
		[SerializeField]
		public AB_MachineGun.Config configuration;

		public override AbilityBehaviour.AbilityBehaviourConfig config => null;

		public override AbilityBehaviour NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
