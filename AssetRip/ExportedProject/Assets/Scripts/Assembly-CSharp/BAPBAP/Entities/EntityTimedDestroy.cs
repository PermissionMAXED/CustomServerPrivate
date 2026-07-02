using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityTimedDestroy : NetworkBehaviour
	{
		[SerializeField]
		public float ttl;

		[NonSerialized]
		public float time;

		[ServerCallback]
		public void FixedUpdate()
		{
		}

		public void Destroy()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
