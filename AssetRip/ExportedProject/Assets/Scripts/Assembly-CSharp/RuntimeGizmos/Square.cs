using UnityEngine;

namespace RuntimeGizmos
{
	public struct Square
	{
		public Vector3 bottomLeft;

		public Vector3 bottomRight;

		public Vector3 topLeft;

		public Vector3 topRight;

		public Vector3 this[int index] => default(Vector3);
	}
}
