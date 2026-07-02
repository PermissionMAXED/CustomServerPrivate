using BAPBAP.Network;

namespace BAPBAP.UI
{
	public class RankingsController : ControllerBase
	{
		public RankingsController(ControllerManager controllerManager)
			: base(null)
		{
		}

		public override void OnLoginComplete(LoadResponse response)
		{
		}

		public void SendLeaderboardPreviewRequest()
		{
		}

		public void SendLeaderboardAllRequestRank(int mode, int rankHigh)
		{
		}

		public void SendLeaderboardAllRequestPage(int mode, int page)
		{
		}

		public void SendLeaderboardSelfRequest(int mode)
		{
		}

		public void SendLeaderboardFriendsRequestPage(int mode, int page)
		{
		}

		public void HandleLeaderboardPreviewResponse(LeaderboardPreviewResponse response)
		{
		}

		public void HandleLeaderboardAllResponse(LeaderboardAllResponse response)
		{
		}

		public void HandleLeaderboardSelfResponse(LeaderboardSelfResponse response)
		{
		}

		public void HandleLeaderboardFriendsResponse(LeaderboardAllResponse response)
		{
		}

		public void UpdateRankingsTabAllData(LeaderboardAllResponse response)
		{
		}

		public void UpdateRankingsTabSelfData(LeaderboardSelfResponse response)
		{
		}

		public void UpdateRankingsTabFriendsData(LeaderboardAllResponse response)
		{
		}
	}
}
