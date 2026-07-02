using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateOnSpawnerObject : EntityActivateBase
	{
		[SerializeField]
		public EntitySpawner spawner;

		public override void Activate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
