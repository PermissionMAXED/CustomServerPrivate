using System;
using Mirror;

namespace BAPBAP.Systems
{
	public struct StateSyncMessage : NetworkMessage
	{
		public ArraySegment<byte> svState;

		public ArraySegment<byte> svEvents;
	}
}
