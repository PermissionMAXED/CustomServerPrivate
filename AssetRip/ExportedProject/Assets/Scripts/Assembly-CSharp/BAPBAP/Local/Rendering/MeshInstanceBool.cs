using System;
using UnityEngine;

namespace BAPBAP.Local.Rendering
{
	[Serializable]
	public struct MeshInstanceBool
	{
		public Vector3 position;

		[Min(0.1f)]
		public float radius;

		public MeshInstanceBool(Vector3 position, float radius)
		{
			this.position = default(Vector3);
			this.radius = 0f;
		}
	}
}
