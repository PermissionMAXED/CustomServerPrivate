using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class FriendRemovedResponse
	{
		[Serializable]
		public class Payload
		{
			[Preserve]
			public string accountId;
		}

		[Preserve]
		public Payload payload;
	}
}
