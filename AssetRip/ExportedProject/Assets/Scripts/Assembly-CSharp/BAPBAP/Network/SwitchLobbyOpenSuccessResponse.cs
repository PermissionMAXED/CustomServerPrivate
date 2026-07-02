using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class SwitchLobbyOpenSuccessResponse
	{
		[Serializable]
		public class Payload
		{
			[Preserve]
			public bool lobbyOpen;
		}

		[Preserve]
		public Payload payload;
	}
}
