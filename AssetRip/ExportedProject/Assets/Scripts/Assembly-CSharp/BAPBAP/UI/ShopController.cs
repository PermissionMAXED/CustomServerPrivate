using BAPBAP.Network;

namespace BAPBAP.UI
{
	public class ShopController : ControllerBase
	{
		public ShopController(ControllerManager controllerManager)
			: base(null)
		{
		}

		public override void OnLoginComplete(LoadResponse response)
		{
		}

		public void RefreshShop()
		{
		}

		public void UpdatePlayTabCurrency(int assetId, int balance, int change)
		{
		}

		public void HandleUIPurchaseFreebieListingAction(string listingId)
		{
		}

		public void HandleUIPurchaseRotationListingAction(string listingId, int costIndex)
		{
		}

		public void HandleCharacterUnlockAction(int charListingIndex, int costIndex)
		{
		}

		public void HandleUIPurchaseCharMasteryRewardAction(int charId, int levelId)
		{
		}

		public void HandlePurchaseCharMasteryPassListingResponse(PurchaseListingResponse response)
		{
		}

		public void SendCharMasteryPassRequest(int charId)
		{
		}

		public void HandleCharMasteryPassResponse(PassResponse response, int charId)
		{
		}

		public void SendDailyRewardRequest()
		{
		}

		public void HandleDailyRewardResponse(DailyResponse response)
		{
		}

		public void SendPurchaseCharacterListingRequest(string listingId, int costIndex)
		{
		}

		public void HandlePurchaseCharacterListingResponse(PurchaseListingResponse response)
		{
		}

		public void SendPurchaseCharMasteryPassListingRequest(string listingId, int costIndex)
		{
		}

		public void SendPurchaseRotationRefreshRequest(string listingId, int costIndex)
		{
		}

		public void HandleShopResponse(ShopResponse response)
		{
		}

		public void SendPurchaseShopFreebieListingRequest(string listingId, int costIndex)
		{
		}

		public void SendPurchaseShopRotationListingRequest(string listingId, int costIndex)
		{
		}

		public void HandlePurchaseShopFreebieListingResponse(PurchaseListingResponse response, string listingId, int costIndex)
		{
		}

		public void HandlePurchaseShopRotationListingResponse(PurchaseListingResponse response)
		{
		}

		public void HandlePurchaseRotationRefreshResponseSuccess(ShopRotationRefreshResponse response)
		{
		}

		public void HandlePurchaseRotationRefreshResponseFailure(ErrorResponse error)
		{
		}

		public void UpdateShopTabData(ShopResponse response)
		{
		}

		public ShopListingModel ParseShopListingFromResponse(ShopResponse.Listing responseListing)
		{
			return null;
		}

		public void UpdateShopRotationData(ShopRotationRefreshResponse response)
		{
		}

		public void AddAssetView(int assetId, int amount, int balance)
		{
		}

		public void TriggerObtainAssetView(int assetId, int amount, int balance)
		{
		}
	}
}
