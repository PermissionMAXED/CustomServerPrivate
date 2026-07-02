using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class CustomSetTeamResponse
	{
		[Serializable]
		public class Payload
		{
			[Preserve]
			public PlayerData player;

			[Preserve]
			public string warningMessage;
		}

		[Preserve]
		public Payload payload;
	}
}
