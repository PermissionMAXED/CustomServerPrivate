using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class StopParticlesDestroyTimed : MonoBehaviour
	{
		public ParticleSystem rootParticleSystem;

		public float duration;

		[NonSerialized]
		public float timer;

		public float destroyDelayAfterStop;

		public void Awake()
		{
		}

		public void Update()
		{
		}
	}
}
