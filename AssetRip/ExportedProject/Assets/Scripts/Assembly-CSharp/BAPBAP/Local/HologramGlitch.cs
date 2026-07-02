using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class HologramGlitch : MonoBehaviour
	{
		[NonSerialized]
		public float t;

		[NonSerialized]
		public float tMax;

		public float glitchStrength;

		public float glitchRate;

		[NonSerialized]
		public bool stopGlitch;

		[NonSerialized]
		public Material hologramMaterial;

		public static readonly int GlitchIntensity_ShaderProperty;

		public void Start()
		{
		}

		public void Update()
		{
		}
	}
}
