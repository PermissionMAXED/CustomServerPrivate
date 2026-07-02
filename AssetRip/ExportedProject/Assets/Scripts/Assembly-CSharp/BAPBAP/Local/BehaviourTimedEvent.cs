using System;
using Mirror;
using UnityEngine;
using UnityEngine.Events;

namespace BAPBAP.Local
{
	public class BehaviourTimedEvent : NetworkBehaviour
	{
		public float ttl;

		[SerializeField]
		public UnityEvent[] clientEvents;

		[SerializeField]
		public UnityEvent[] serverEvents;

		[SerializeField]
		public UnityEvent<bool>[] svEnableActions;

		[SerializeField]
		public UnityEvent<bool>[] clEnableActions;

		[SerializeField]
		public bool doSetEnabled;

		[SerializeField]
		public bool setAtStart;

		[NonSerialized]
		public float time;

		public override void OnStartServer()
		{
		}

		public override void OnStartClient()
		{
		}

		public void FixedUpdate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
