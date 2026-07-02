using UnityEngine;

namespace BAPBAP.Local
{
	public class NetworkCache : MonoBehaviour
	{
		[HideInInspector]
		public int teamId;

		[HideInInspector]
		public int playerId;

		[HideInInspector]
		public int[] teammatePlayerIds;
	}
}
