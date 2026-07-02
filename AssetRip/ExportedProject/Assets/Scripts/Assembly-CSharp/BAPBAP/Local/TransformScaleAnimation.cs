using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class TransformScaleAnimation : MonoBehaviour
	{
		[SerializeField]
		public AnimationCurve heightCurve;

		[SerializeField]
		public AnimationCurve widthCurve;

		[SerializeField]
		public float duration;

		[SerializeField]
		public bool doLoop;

		[SerializeField]
		public bool resetOnDisable;

		[SerializeField]
		public bool serializeOriginalScale;

		[ConditionalHide("serializeOriginalScale", true)]
		[SerializeField]
		public Vector3 originalScale;

		[NonSerialized]
		public float time;

		[NonSerialized]
		public bool isEnabled;

		public void Awake()
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void Play()
		{
		}

		public void Update()
		{
		}

		public void Animate(float nt)
		{
		}
	}
}
