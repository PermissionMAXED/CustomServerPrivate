using System;
using UnityEngine;

namespace Gamekit3D
{
	public class ParticleDeactivator : MonoBehaviour
	{
		public float duration;

		[NonSerialized]
		public float m_SinceActivation;

		[NonSerialized]
		public ParticleSystem m_ParticleSystem;

		public void OnEnable()
		{
		}

		public void Update()
		{
		}
	}
}
