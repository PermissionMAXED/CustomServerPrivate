using System;
using Mirror;

namespace BAPBAP.Entities
{
	public class EntityActivateBase : NetworkBehaviour
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public EntityBehaviour entityBehav;

		[NonSerialized]
		public EntityTriggerAreaBehaviour entityTriggerAreaBehav;

		public virtual void Awake()
		{
		}

		[ServerCallback]
		public virtual void Activate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
