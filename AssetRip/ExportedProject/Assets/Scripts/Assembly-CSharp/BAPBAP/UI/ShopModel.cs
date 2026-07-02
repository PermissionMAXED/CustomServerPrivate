using System.Collections.Generic;

namespace BAPBAP.UI
{
	public class ShopModel : Model
	{
		public string timestamp;

		public ShopListingModel[] freebie;

		public ShopListingModel[] rotation;

		public int dropId;

		public string dropEndDate;

		public ShopListingModel refreshListing;

		public int currentRefreshes;

		public int maxRefreshes;

		public readonly HashSet<string> purchasedListings;

		public readonly HashSet<string> flippedCardListings;
	}
}
