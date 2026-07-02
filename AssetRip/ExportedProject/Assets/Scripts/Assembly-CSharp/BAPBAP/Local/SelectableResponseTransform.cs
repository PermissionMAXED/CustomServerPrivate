using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Local
{
	[CreateAssetMenu(menuName = "BAPBAP/Selectable/SelectableResponseTransform")]
	public class SelectableResponseTransform : SelectableResponse
	{
		public class SelectableTransformInfo
		{
			public Transform transform;

			public Vector3 originalPosition;

			public Vector3 originalScale;

			public Quaternion originalRotation;

			public float time;

			public float duration;

			public float returnPoint;

			public float returnSpeedMultiplier;

			public bool isReturning;

			public void Update(float deltaTime, AnimationCurve curve, SelectableTransformResponse response)
			{
			}
		}

		[Serializable]
		public class SelectableTransformResponse
		{
			[Serializable]
			public class ResponseSettings
			{
				public bool enabled;

				public Vector3 direction;

				public AnimationCurve curve;
			}

			public bool onSelect;

			[Min(1f)]
			public float returnSpeedMultiplier;

			public ResponseSettings position;

			public ResponseSettings scale;

			public ResponseSettings rotation;
		}

		[SerializeField]
		public SelectableTransformResponse transformResponse;

		[NonSerialized]
		public Dictionary<ISelectable, SelectableTransformInfo> activeTransforms;

		[NonSerialized]
		public Dictionary<ISelectable, bool> returnHistory;

		public override void OnSelect(ISelectable selectable)
		{
		}

		public override void OnDeselect(ISelectable selectable)
		{
		}

		public override void OnSelectUpdate(ISelectable selectable, float deltaTime)
		{
		}

		public void AddActiveTransform(ISelectable selectable)
		{
		}
	}
}
