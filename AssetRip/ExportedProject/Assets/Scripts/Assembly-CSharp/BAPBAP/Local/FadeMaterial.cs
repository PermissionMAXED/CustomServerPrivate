using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class FadeMaterial : MonoBehaviour
	{
		public Renderer rend;

		public float ttl;

		[NonSerialized]
		public float timer;

		public static readonly int Intensity_ShaderProperty;

		public void Update()
		{
		}
	}
}
