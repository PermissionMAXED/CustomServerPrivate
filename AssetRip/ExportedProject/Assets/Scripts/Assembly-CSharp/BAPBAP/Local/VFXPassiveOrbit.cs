using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class VFXPassiveOrbit : MonoBehaviour
	{
		[SerializeField]
		public ParticleSystem success;

		[SerializeField]
		public ParticleSystem[] orbitParticles;

		[NonSerialized]
		public int orbitAmount;

		public void PlayParticles()
		{
		}

		public void StopParticles()
		{
		}

		public void OnEnable()
		{
		}

		public void PlayParticleSystem()
		{
		}

		public void StopParticleSystem()
		{
		}

		public void SetOrbitAmount(int _orbitAmount, bool complete)
		{
		}
	}
}
