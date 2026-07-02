using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class UpdateFriendRequestsResponse
	{
		[Serializable]
		public class Payload
		{
			[Preserve]
			public string accountId;

			[Preserve]
			public string username;

			[Preserve]
			public int discriminator;

			[Preserve]
			public int avatarId;
		}

		[Preserve]
		public Payload payload;
	}
}
