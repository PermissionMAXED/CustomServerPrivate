using System;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Local
{
	public class BehaviourTimedEnableSync : NetworkBehaviour
	{
		[SerializeField]
		public MonoBehaviour[] behaviours;

		[SerializeField]
		public bool doSetEnabled;

		[SerializeField]
		[SyncVar]
		public float ttl;

		[NonSerialized]
		public float time;

		[NonSerialized]
		public bool isEnabled;

		public float Networkttl
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		public void OnEnable()
		{
		}

		public void FixedUpdate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
