using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class FriendInviteBody
	{
		[Preserve]
		public string accountId;

		[Preserve]
		public string lobbyId;
	}
}
