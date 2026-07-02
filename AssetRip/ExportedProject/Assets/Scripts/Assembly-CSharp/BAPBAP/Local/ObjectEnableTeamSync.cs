using System;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Local
{
	public class ObjectEnableTeamSync : NetworkBehaviour
	{
		[SerializeField]
		public bool doSetEnabled;

		[SerializeField]
		public GameObject[] gameObjects;

		[NonSerialized]
		[SyncVar]
		public int teamId;

		public int NetworkteamId
		{
			get
			{
				return 0;
			}
			[param: In]
			set
			{
			}
		}

		public void Start()
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
