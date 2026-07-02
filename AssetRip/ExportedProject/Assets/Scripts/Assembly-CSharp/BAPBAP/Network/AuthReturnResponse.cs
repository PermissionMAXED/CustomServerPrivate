using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class AuthReturnResponse
	{
		[Preserve]
		public string twitchUsername;
	}
}
