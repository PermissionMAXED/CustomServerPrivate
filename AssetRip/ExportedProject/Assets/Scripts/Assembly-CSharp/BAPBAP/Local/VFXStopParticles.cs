using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class VFXStopParticles : MonoBehaviour
	{
		[Header("References")]
		[Tooltip("This particle system will be stopped along with their children, keeping particles already spawned")]
		[SerializeField]
		public ParticleSystem rootParticleSystem;

		[Tooltip("This gameObject will be disabled immediatly when stopped")]
		[SerializeField]
		public GameObject disableImmediate;

		[SerializeField]
		[Header("Config")]
		[Tooltip("When stopping the particle system, setting this to true will wait one frame to stop it")]
		public bool waitOneFrameToStop;

		[NonSerialized]
		public bool playParticles;

		[NonSerialized]
		public bool waitToStopParticles;

		[NonSerialized]
		public bool isPlaying;

		public void PlayParticles(float elapsedTime = 0f)
		{
		}

		public void StopParticles()
		{
		}

		public void TryRefreshPlayingParticles()
		{
		}

		public void OnEnable()
		{
		}

		public void LateUpdate()
		{
		}

		public void PlayParticleSystem(float elapsedTime = 0f)
		{
		}

		public void StopParticleSystem()
		{
		}
	}
}
