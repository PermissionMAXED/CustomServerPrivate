using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class StopTrail : MonoBehaviour
	{
		[NonSerialized]
		public TrailRenderer trailRenderer;

		public float duration;

		[NonSerialized]
		public float timer;

		public void Awake()
		{
		}

		public void Update()
		{
		}
	}
}
