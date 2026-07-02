using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class AcceptFriendBody
	{
		[Preserve]
		public string accountId;
	}
}
