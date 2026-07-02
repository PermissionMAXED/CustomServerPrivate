using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class HitboxLookAtCharOnTrigger : NetworkBehaviour
	{
		[SerializeField]
		public TransformLookAtTarget transformLookAtTarget;

		[NonSerialized]
		public bool foundTarget;

		[NonSerialized]
		public bool playersOnly;

		[NonSerialized]
		public bool alliesOnly;

		[NonSerialized]
		public int teamId;

		public void OnTriggerEnter(Collider collider)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
