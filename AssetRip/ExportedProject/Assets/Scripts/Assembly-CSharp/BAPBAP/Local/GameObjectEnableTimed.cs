using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class GameObjectEnableTimed : MonoBehaviour
	{
		[SerializeField]
		public bool doSetEnabled;

		[SerializeField]
		public float ttl;

		[NonSerialized]
		public float time;

		[NonSerialized]
		public bool done;

		[SerializeField]
		public GameObject[] gameObjects;

		public void SetTtl(float ttl)
		{
		}

		public void Play()
		{
		}

		public void OnEnable()
		{
		}

		public void FixedUpdate()
		{
		}
	}
}
