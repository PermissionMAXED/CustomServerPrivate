using UnityEngine;

namespace PathCreation.Examples
{
	[RequireComponent(typeof(PathCreator))]
	public class GeneratePathExample : MonoBehaviour
	{
		public bool closedLoop;

		public Transform[] waypoints;

		public void Start()
		{
		}
	}
}
