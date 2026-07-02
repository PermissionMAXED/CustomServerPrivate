using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class SteamPurchaseFinaliseBody
	{
		[Preserve]
		public ulong orderId;
	}
}
