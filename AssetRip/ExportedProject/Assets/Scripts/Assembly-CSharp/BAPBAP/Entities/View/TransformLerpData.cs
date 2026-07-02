using UnityEngine;

namespace BAPBAP.Entities.View
{
	public struct TransformLerpData
	{
		public int tickNum;

		public Vector3 position;

		public Quaternion rotation;

		public Vector3 scale;

		public TransformLerpData(int tickNum, Vector3 position, Quaternion rotation, Vector3 scale)
		{
			this.tickNum = 0;
			this.position = default(Vector3);
			this.rotation = default(Quaternion);
			this.scale = default(Vector3);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
