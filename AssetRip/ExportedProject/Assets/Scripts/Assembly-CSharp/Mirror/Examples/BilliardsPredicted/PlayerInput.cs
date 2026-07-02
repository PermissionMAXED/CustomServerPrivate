using UnityEngine;

namespace Mirror.Examples.BilliardsPredicted
{
	public struct PlayerInput
	{
		public double timestamp;

		public Vector3 force;

		public PlayerInput(double timestamp, Vector3 force)
		{
			this.timestamp = 0.0;
			this.force = default(Vector3);
		}
	}
}
