using System;
using Mirror;

namespace BAPBAP.Entities
{
	public class SvTimedInvoke : NetworkBehaviour
	{
		public float ttl;

		public Action InvokeAction;

		[NonSerialized]
		public float time;

		public override void OnStopServer()
		{
		}

		[ServerCallback]
		public void FixedUpdate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
