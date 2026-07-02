using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class LobbySocketResponse
	{
		[Preserve]
		public string socketUrl;
	}
}
