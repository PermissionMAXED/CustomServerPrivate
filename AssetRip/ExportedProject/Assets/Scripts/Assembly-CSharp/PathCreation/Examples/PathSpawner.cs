using UnityEngine;

namespace PathCreation.Examples
{
	public class PathSpawner : MonoBehaviour
	{
		public PathCreator pathPrefab;

		public PathFollower followerPrefab;

		public Transform[] spawnPoints;

		public void Start()
		{
		}
	}
}
