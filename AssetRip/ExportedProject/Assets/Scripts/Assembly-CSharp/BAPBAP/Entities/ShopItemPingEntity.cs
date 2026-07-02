using System;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class ShopItemPingEntity : NetworkBehaviour
	{
		[NonSerialized]
		[SyncVar]
		public ShopStation shopStation;

		public Collider pingCol;

		[NonSerialized]
		public NetworkBehaviourSyncVar ___shopStationNetId;

		public ShopStation NetworkshopStation
		{
			get
			{
				return null;
			}
			[param: In]
			set
			{
			}
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
