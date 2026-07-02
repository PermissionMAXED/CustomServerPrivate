using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AimAssistIndicator : MonoBehaviour
	{
		[SerializeField]
		public TransformScaleSimpleAnimation pulseAnimation;

		[SerializeField]
		public TransformScaleSimpleAnimation inAnimation;

		[SerializeField]
		public TransformScaleSimpleAnimation outAnimation;

		[NonSerialized]
		public InputSystem inputSystem;

		[NonSerialized]
		public AimAssistDetection.Target target;

		public void Awake()
		{
		}

		public void LateUpdate()
		{
		}

		public void Show()
		{
		}

		public void Hide()
		{
		}
	}
}
