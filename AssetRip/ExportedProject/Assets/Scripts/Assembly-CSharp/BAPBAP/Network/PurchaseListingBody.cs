using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class PurchaseListingBody
	{
		[Preserve]
		public string listingId;

		[Preserve]
		public string recipientId;

		[Preserve]
		public int costIndex;
	}
}
