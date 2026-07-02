using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit3D
{
	public class Respawner : MonoBehaviour
	{
		[Serializable]
		public class SaveState
		{
			public Vector3 position;

			public Quaternion rotation;
		}

		public GameObject player;

		public float savePeriod;

		public List<SaveState> savedStates;

		[NonSerialized]
		public float lastCheck;

		[NonSerialized]
		public bool paused;

		public void Start()
		{
		}

		public void Pause()
		{
		}

		public void Resume()
		{
		}

		public void RestoreLast()
		{
		}

		public void Update()
		{
		}
	}
}
