using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateDamageSelf : EntityActivateBase
	{
		[SerializeField]
		public CharHurtbox charHurtbox;

		[SerializeField]
		public int dmg;

		public override void Activate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
