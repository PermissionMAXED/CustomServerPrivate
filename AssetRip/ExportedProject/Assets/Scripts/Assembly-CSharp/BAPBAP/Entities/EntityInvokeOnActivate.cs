using UnityEngine;
using UnityEngine.Events;

namespace BAPBAP.Entities
{
	public class EntityInvokeOnActivate : EntityActivateBase
	{
		[SerializeField]
		public UnityEvent[] invokeActions;

		public override void Activate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
