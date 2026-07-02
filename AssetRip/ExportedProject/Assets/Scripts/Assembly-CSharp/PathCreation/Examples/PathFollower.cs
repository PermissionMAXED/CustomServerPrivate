using System;
using UnityEngine;

namespace PathCreation.Examples
{
	public class PathFollower : MonoBehaviour
	{
		public PathCreator pathCreator;

		public EndOfPathInstruction endOfPathInstruction;

		public float speed;

		[NonSerialized]
		public float distanceTravelled;

		public void Start()
		{
		}

		public void Update()
		{
		}

		public void OnPathChanged()
		{
		}
	}
}
