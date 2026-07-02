using System;
using UnityEngine;

namespace Gamekit3D
{
	[ExecuteInEditMode]
	public class SunSkybox : MonoBehaviour
	{
		public Material skyboxMaterial;

		[NonSerialized]
		public int sunDirId;

		[NonSerialized]
		public int sunColorId;

		[NonSerialized]
		public Light sun;

		public void Awake()
		{
		}

		public void Update()
		{
		}
	}
}
