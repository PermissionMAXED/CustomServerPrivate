using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class InviteLobbyResponse
	{
		[Serializable]
		public class Payload
		{
			[Preserve]
			public string receiverAccountId;

			[Preserve]
			public string senderAccountId;

			[Preserve]
			public string lobbyId;
		}

		[Preserve]
		public Payload payload;
	}
}
