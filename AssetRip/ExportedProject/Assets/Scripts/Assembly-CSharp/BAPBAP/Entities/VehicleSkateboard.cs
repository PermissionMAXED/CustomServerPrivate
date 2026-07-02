using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class VehicleSkateboard : Vehicle
	{
		[SerializeField]
		[Header("Jump Config")]
		public CommandId inputTarget;

		[SerializeField]
		public Transform meshAnimTransform;

		[SerializeField]
		public float jumpDuration;

		[SerializeField]
		public AnimationCurve animRotCurve;

		[SerializeField]
		public AnimationCurve animHeightCurve;

		[SerializeField]
		public AudioClipData[] jumpSfx;

		[SerializeField]
		public AudioClipData[] landSfx;

		[NonSerialized]
		public bool jumping;

		[NonSerialized]
		public bool isGrinding;

		[NonSerialized]
		public float jumpTimer;

		[NonSerialized]
		public GrindRail currGrindRail;

		public override void AssignDriver(EntityManager entity)
		{
		}

		public override void RemoveDriver(EntityManager entity)
		{
		}

		public override void FixedUpdate()
		{
		}

		public void StartJump()
		{
		}

		public void EndJump()
		{
		}

		public void OnGrindRailExit()
		{
		}

		public void Animate(float nt)
		{
		}

		public override void OnCharVehicleChanged(EntityManager oldValue, EntityManager newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
