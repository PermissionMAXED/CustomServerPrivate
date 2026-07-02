using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class DestroyAfterDelay : NetworkBehaviour
	{
		[SerializeField]
		public float destroyDelay;

		[NonSerialized]
		public float time;

		[ClientCallback]
		public void FixedUpdate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
