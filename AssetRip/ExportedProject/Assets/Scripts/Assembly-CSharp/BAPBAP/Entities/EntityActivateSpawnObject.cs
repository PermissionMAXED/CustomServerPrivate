using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateSpawnObject : EntityActivateBase
	{
		[SerializeField]
		public GameObject objToSpawn;

		[SerializeField]
		public bool doDestroyDelay;

		[ConditionalHide("doDestroyDelay", true)]
		[SerializeField]
		public float ttl;

		public override void Activate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
