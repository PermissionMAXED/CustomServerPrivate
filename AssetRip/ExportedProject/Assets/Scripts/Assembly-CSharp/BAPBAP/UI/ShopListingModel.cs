using System;

namespace BAPBAP.UI
{
	[Serializable]
	public class ShopListingModel : Model
	{
		public string listingId;

		public int globalStock;

		public int accountStock;

		public AssetModel[] costs;

		public AssetModel[] rewards;

		public int expiresAt;

		public int purchases;
	}
}
