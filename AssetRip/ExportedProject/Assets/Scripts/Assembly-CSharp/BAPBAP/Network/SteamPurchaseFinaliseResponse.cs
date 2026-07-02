using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class SteamPurchaseFinaliseResponse
	{
		[Serializable]
		public class Asset
		{
			[Preserve]
			public int assetId;

			[Preserve]
			public int amount;

			[Preserve]
			public int balance;
		}

		[Preserve]
		public Asset[] rewards;
	}
}
