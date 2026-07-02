using System;
using UnityEngine;

namespace BAPBAP.Local.Rendering
{
	[Serializable]
	public struct MeshInstanceArea
	{
		public Vector3 position;

		[Range(32f, 16384f)]
		public int instanceCount;

		[Range(0f, 3f)]
		public int shapeType;

		[Range(0f, 2f)]
		public int mergeType;

		public float rotation;

		[Min(0.1f)]
		public float scale;

		[Min(0.1f)]
		public float falloffStrength;

		[ReadOnly]
		[Range(-1f, 3f)]
		public int splatChannelMask;

		[ReadOnly]
		[Range(0.1f, 1f)]
		public float splatChannelMaskThreshold;

		public MeshInstanceArea(Vector3 position, int instanceCount, int shapeType, float scale, float falloffStrength, int splatChannelMask, float splatChannelMaskThreshold)
		{
			this.position = default(Vector3);
			this.instanceCount = 0;
			this.shapeType = 0;
			mergeType = 0;
			rotation = 0f;
			this.scale = 0f;
			this.falloffStrength = 0f;
			this.splatChannelMask = 0;
			this.splatChannelMaskThreshold = 0f;
		}
	}
}
