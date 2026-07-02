using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class BeeSwarmReset : NetworkBehaviour
	{
		[NonSerialized]
		public ProjectileMove projMove;

		[NonSerialized]
		public Transform source;

		[NonSerialized]
		public float timeUntilReturn;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public float timerOut;

		public void Start()
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
