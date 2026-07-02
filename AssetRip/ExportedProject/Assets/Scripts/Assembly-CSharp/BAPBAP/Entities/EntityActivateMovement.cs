using System;
using BAPBAP.Maps;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateMovement : EntityActivateBase
	{
		[Header("Settings")]
		[SerializeField]
		public float distanceForward;

		[SerializeField]
		public float timeToTransit;

		[SerializeField]
		public float transitCooldown;

		[SerializeField]
		public AnimationCurve transitCurve;

		[NonSerialized]
		[NonSerialized]
		public Vector3 targetPosition;

		[NonSerialized]
		[NonSerialized]
		public Vector3 originPosition;

		[NonSerialized]
		[NonSerialized]
		public Vector3 currentStartingPosition;

		[NonSerialized]
		[NonSerialized]
		public Vector3 currentTargetPosition;

		[NonSerialized]
		public bool coolingDown;

		[NonSerialized]
		[NonSerialized]
		public bool inTransit;

		[NonSerialized]
		[NonSerialized]
		public bool inReverse;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public bool activated;

		public override void Awake()
		{
		}

		public float GetTotalCDTime()
		{
			return 0f;
		}

		public override void Activate()
		{
		}

		public void FixedUpdate()
		{
		}

		public MapEntityData.Property.FloatField[] GetPropertyFloatFields()
		{
			return null;
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
