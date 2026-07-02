using System;
using UnityEngine;

namespace BAPBAP.Local.Rendering
{
	public class VFXLightShafts : MonoBehaviour
	{
		[SerializeField]
		public ParticleSystem particleSystem;

		[NonSerialized]
		public Light _light;

		[NonSerialized]
		public ParticleSystem.Particle[] particles;

		public void Start()
		{
		}

		public void LateUpdate()
		{
		}

		public void AlignWithLight()
		{
		}
	}
}
