using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class VehicleDrone : Vehicle
	{
		[Header("Top down control Parameters")]
		[SerializeField]
		public float topDownAccel;

		[SerializeField]
		public float topDownDecel;

		[SerializeField]
		public float topDownTurnSpeed;

		[SerializeField]
		public float directionChangeMultiplier;

		[NonSerialized]
		public Vector3 topDownDirection;

		public override void Update()
		{
		}

		public override void CarVelPhysics(float fixedDt)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
