using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace BAPBAP.Local
{
	public class VFXStopDecals : MonoBehaviour
	{
		[SerializeField]
		[Header("References")]
		public DecalProjector _decalProjector;

		[Header("Config")]
		[SerializeField]
		public bool doTtl;

		[ConditionalHide("doTtl", true)]
		[SerializeField]
		[Min(0f)]
		public float Duration;

		[SerializeField]
		[ConditionalHide("doTtl", true)]
		public AnimationCurve _sizeOverLifetimeX;

		[ConditionalHide("doTtl", true)]
		[SerializeField]
		public AnimationCurve _sizeOverLifetimeY;

		[SerializeField]
		[ConditionalHide("doTtl", true)]
		public AnimationCurve _sizeOverLifetimeZ;

		[ConditionalHide("doTtl", true)]
		[SerializeField]
		public AnimationCurve _fadeOverLifetime;

		[NonSerialized]
		public Vector3 _originalSize;

		[NonSerialized]
		public float _timer;

		public void Awake()
		{
		}

		public void OnEnable()
		{
		}

		public void LateUpdate()
		{
		}

		public void Animate(float nt)
		{
		}

		public void EnableDecal(float elapsedTime = 0f, float duration = 0f)
		{
		}

		public void DisableDecal()
		{
		}
	}
}
