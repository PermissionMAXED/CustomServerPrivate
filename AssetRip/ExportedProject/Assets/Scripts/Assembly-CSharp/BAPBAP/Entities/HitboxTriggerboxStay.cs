using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class HitboxTriggerboxStay : HitboxTriggerbox
	{
		[ServerCallback]
		public void OnTriggerStay(Collider collider)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
