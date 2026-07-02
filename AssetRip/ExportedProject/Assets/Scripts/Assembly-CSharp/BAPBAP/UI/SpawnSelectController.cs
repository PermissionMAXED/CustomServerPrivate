using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.UI
{
	public class SpawnSelectController : ControllerBase
	{
		public SpawnSelectController(ControllerManager controllerManager)
			: base(null)
		{
		}

		public void SelectSpawn(Vector2 spawnLocation)
		{
		}

		public void SendSelectSpawnMessage(Vector2 spawnLocation)
		{
		}

		public void HandleChangeSpawnLocationSuccessMessage(ChangeSpawnLocationSuccessMessage message)
		{
		}

		public void HandleSpawnLocationUpdatedMatchmakingMessage(SpawnLocationUpdatedMatchmakingMessage message)
		{
		}

		public void HandleSpawnLocationSuggestedMessage(SpawnLocationUpdatedMatchmakingMessage message)
		{
		}

		public void HandleSpawnSelectTransitionedMessage(SpawnSelectTransitionedMessage msg)
		{
		}

		public void HandleSpawnSelectFinalizedMessage(SpawnSelectFinalizedMessage msg)
		{
		}
	}
}
