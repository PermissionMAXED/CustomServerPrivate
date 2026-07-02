using BAPBAP.Network;

namespace BAPBAP.UI
{
	public class CommunityChallengeController : ControllerBase
	{
		public CommunityChallengeController(ControllerManager controllerManager)
			: base(null)
		{
		}

		public override void OnLoginComplete(LoadResponse response)
		{
		}

		public void HandleUIChallengeSignUpAction(string referralCode)
		{
		}

		public void HandleUIChallengeClaimReferralLiveAction(string listingId)
		{
		}

		public void HandleUIChallengeClaimGamesLiveAction(string listingId)
		{
		}

		public void HandleUIChallengeClaimDropsLiveAction(string listingId, string entitlementId)
		{
		}

		public void HandleChallengePreview()
		{
		}

		public void HandleChallengeRequest()
		{
		}

		public void HandleCopyChallengeReferralCode()
		{
		}

		public void HandleChallengePreviewResponse(ChallengePreviewResponse response)
		{
		}

		public void HandleChallengeResponse(ChallengeResponse response)
		{
		}

		public void HandleChallengeClaimReferralLiveResponse(ChallengeClaimReferralLiveResponse response)
		{
		}

		public void HandleChallengeClaimGamesLiveResponse(ChallengeClaimGamesLiveResponse response)
		{
		}

		public void HandleChallengeClaimDropsLiveResponse(ChallengeClaimDropsLiveResponse response)
		{
		}

		public void HandleChallengeSignUpRequest(ChallengeSignUpResponse response)
		{
		}

		public void HandleChallengeSignUpError(ErrorResponse error)
		{
		}

		public void HandleChallengeUpdatedMessage(ChallengeUpdatedMessage message)
		{
		}

		public void HandleChallengeLiveFeedUpdatedMessage(ChallengeLiveFeedUpdatedMessage message)
		{
		}
	}
}
