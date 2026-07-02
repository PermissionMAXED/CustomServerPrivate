using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class MeshAnimation : MonoBehaviour
	{
		public Mesh[] meshFrames;

		public float[] framerateMultiplier;

		public float frameRateSpeed;

		public MeshFilter meshFilter;

		[NonSerialized]
		public float currentFrame;

		[NonSerialized]
		public int totalFrames;

		[NonSerialized]
		public int prevFrame;

		public void Start()
		{
		}

		public void Update()
		{
		}
	}
}
