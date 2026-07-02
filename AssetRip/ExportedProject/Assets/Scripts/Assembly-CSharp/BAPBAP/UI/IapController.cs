using System;
using BAPBAP.Localisation;
using BAPBAP.Network;

namespace BAPBAP.UI
{
	public class IapController : ControllerBase
	{
		[NonSerialized]
		public string _loginRequiredStr;

		public IapController(ControllerManager controllerManager)
			: base(null)
		{
		}

		public override void OnLocalise(Translator translator)
		{
		}

		public override void OnLoginComplete(LoadResponse response)
		{
		}

		public void HandleUIPurchaseFractalsAction(string listingId)
		{
		}

		public void SetCreatorCode(string code)
		{
		}

		public void SendXsollaTokenRequest(string listingId, string recipientAccount = "")
		{
		}

		public void SendSteamPurchaseRequest(string listingId, string recipientAccount = "")
		{
		}

		public void SendIapListingRequest()
		{
		}

		public void HandleSteamIapAuthorized(object sender, ulong orderId)
		{
		}

		public void HandleIapListingResponse(IapListingResponse response)
		{
		}

		public void HandleXsollaPurchaseResponse(XsollaPurchaseResponse response)
		{
		}

		public void HandleXsollaPurchaseError(ErrorResponse error)
		{
		}

		public void HandleAsyncPurchaseResultMessage(AsyncPurchaseMessage message)
		{
		}

		public void HandleSteamPurchaseResponse(SteamPurchaseResponse response)
		{
		}

		public void HandleSteamPurchaseError(ErrorResponse error)
		{
		}

		public void HandleSteamPurchaseFinaliseResponse(SteamPurchaseFinaliseResponse response)
		{
		}

		public void HandleSteamPurchaseFinaliseError(ErrorResponse error)
		{
		}
	}
}
