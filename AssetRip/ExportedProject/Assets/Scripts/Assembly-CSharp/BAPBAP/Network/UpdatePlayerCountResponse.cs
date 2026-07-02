using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class UpdatePlayerCountResponse
	{
		[Serializable]
		public class Payload
		{
			[Preserve]
			public string accountId;

			[Preserve]
			public int playerCount;

			[Preserve]
			public int maxPlayers;
		}

		[Preserve]
		public Payload payload;
	}
}
