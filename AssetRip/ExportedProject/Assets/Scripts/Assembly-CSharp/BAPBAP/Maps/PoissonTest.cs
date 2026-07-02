using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Maps
{
	public class PoissonTest : MonoBehaviour
	{
		public float radius;

		[Range(0.1f, 20f)]
		public float minRadius;

		[Range(0.1f, 20f)]
		public float maxRadius;

		public Vector2 regionSize;

		public int rejectionSamples;

		public float displayRadius;

		public List<Vector2> points;

		public Vector2 densityIncrease;

		public void OnValidate()
		{
		}

		public void OnDrawGizmos()
		{
		}
	}
}
