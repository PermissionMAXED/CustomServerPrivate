using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class AddFriendBody
	{
		[Preserve]
		public string username;

		[Preserve]
		public int discriminator;
	}
}
