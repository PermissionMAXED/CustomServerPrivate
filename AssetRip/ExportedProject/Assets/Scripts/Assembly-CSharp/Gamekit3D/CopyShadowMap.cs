using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Gamekit3D
{
	[ExecuteInEditMode]
	public class CopyShadowMap : MonoBehaviour
	{
		[NonSerialized]
		public CommandBuffer cb;

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}
	}
}
