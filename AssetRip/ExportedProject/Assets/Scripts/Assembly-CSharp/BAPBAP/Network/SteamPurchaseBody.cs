using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class SteamPurchaseBody
	{
		[Preserve]
		public string listingId;

		[Preserve]
		public string recipientId;

		[Preserve]
		public int costIndex;

		[Preserve]
		public string steamId;

		[Preserve]
		public string appId;

		[Preserve]
		public string steamLanguage;
	}
}
