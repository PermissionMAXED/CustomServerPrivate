using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Local
{
	[CreateAssetMenu(menuName = "BAPBAP/Selectable/SelectableResponseForce")]
	public class SelectableResponseForce : SelectableResponse
	{
		[Min(0f)]
		public float multiplier;

		[Min(0f)]
		public float upwardsModifier;

		[Min(0f)]
		public float radius;

		[Min(0f)]
		public float torqueMultiplier;

		public Vector3 torqueRange;

		[Min(0f)]
		public float hoverAlignmentSpeed;

		[Min(0f)]
		public float resetRange;

		[NonSerialized]
		[NonSerialized]
		public Dictionary<GameObject, Vector3> initialForwards;

		[NonSerialized]
		[NonSerialized]
		public Dictionary<GameObject, Vector3> initialPositions;

		[NonSerialized]
		[NonSerialized]
		public Dictionary<GameObject, float> lastClick;

		[NonSerialized]
		[NonSerialized]
		public Dictionary<GameObject, Rigidbody> rigidbodies;

		public override void Initialize(ISelectable selectable)
		{
		}

		public override void OnSelect(ISelectable selectable)
		{
		}

		public override void OnHoverUpdate(ISelectable selectable, float deltaTime)
		{
		}

		public override void GeneralUpdate(ISelectable selectable, float deltaTime)
		{
		}
	}
}
