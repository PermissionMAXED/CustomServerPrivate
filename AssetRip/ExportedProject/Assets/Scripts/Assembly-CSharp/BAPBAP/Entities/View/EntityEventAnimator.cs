using System;
using BAPBAP.Utilities;
using UnityEngine;

namespace BAPBAP.Entities.View
{
	public class EntityEventAnimator : MonoBehaviour
	{
		public abstract class EntityAnimator
		{
			[SerializeField]
			[Tooltip("Specify a animation transform for this animator. If null, will default to the mesh transform")]
			public Transform animationTr;

			[NonSerialized]
			public EntityEventAnimator anim;

			[NonSerialized]
			public bool animating;

			public virtual void Initialize(EntityEventAnimator anim)
			{
			}

			public abstract void Animate();

			public abstract void Play();

			public virtual void OnDisable()
			{
			}

			public EntityAnimator()
			{
			}
		}

		[Serializable]
		public class WobbleAnimator : EntityAnimator
		{
			[SerializeField]
			public AnimationCurve animationCurve;

			[SerializeField]
			public float sizeMultiplier;

			[SerializeField]
			public float rotationMultiplier;

			[SerializeField]
			public float hitAnimDuration;

			[SerializeField]
			[Space(5f)]
			public bool doForceIntensityRange;

			[SerializeField]
			public int damageNormRange;

			[SerializeField]
			public RangeFloat forceIntensityRange;

			[NonSerialized]
			public float timer;

			[NonSerialized]
			public float intensityMult;

			[NonSerialized]
			public Vector3 worldDirection;

			[NonSerialized]
			public Vector3 originalScale;

			public override void Initialize(EntityEventAnimator anim)
			{
			}

			public override void Animate()
			{
			}

			public override void Play()
			{
			}

			public void SetIntensityMult(float normIntensity)
			{
			}
		}

		[Serializable]
		public class PushAnimator : EntityAnimator
		{
			[SerializeField]
			public AnimationCurve animationCurve;

			[SerializeField]
			public float rotationMultiplier;

			[NonSerialized]
			public float timer;

			[NonSerialized]
			public float duration;

			[NonSerialized]
			public float intensityMult;

			[NonSerialized]
			public Vector3 worldDirection;

			public override void Animate()
			{
			}

			public override void Play()
			{
			}
		}

		[Serializable]
		public class ShakeAnimator : EntityAnimator
		{
			[SerializeField]
			public AnimationCurve animationCurve;

			[SerializeField]
			public float intensityMultiplier;

			[SerializeField]
			public float duration;

			[NonSerialized]
			public float timer;

			public override void Animate()
			{
			}

			public override void Play()
			{
			}
		}

		[Serializable]
		public class SpinAnimator : EntityAnimator
		{
			[SerializeField]
			public AnimationCurve animationCurve;

			[NonSerialized]
			public float duration;

			[NonSerialized]
			public float timer;

			public override void Animate()
			{
			}

			public override void Play()
			{
			}

			public override void OnDisable()
			{
			}
		}

		[Serializable]
		public class JumpAnimator : EntityAnimator
		{
			[SerializeField]
			public float intensityMultiplier;

			[SerializeField]
			public AnimationCurve heightCurve;

			[NonSerialized]
			public float duration;

			[NonSerialized]
			public float timer;

			public override void Animate()
			{
			}

			public override void Play()
			{
			}

			public override void OnDisable()
			{
			}
		}

		[NonSerialized]
		public CharMaterial charMaterial;

		[SerializeField]
		[Header("References")]
		public Transform meshTransform;

		[Header("Animator Config")]
		[SerializeField]
		public bool wobbleEnabled;

		[ConditionalHide("wobbleEnabled", true)]
		[SerializeField]
		public WobbleAnimator wobbleAnimator;

		[Space(10f)]
		[SerializeField]
		public bool pushEnabled;

		[ConditionalHide("pushEnabled", true)]
		[SerializeField]
		public PushAnimator pushAnimator;

		[Space(10f)]
		[SerializeField]
		public bool shakeEnabled;

		[ConditionalHide("shakeEnabled", true)]
		[SerializeField]
		public ShakeAnimator shakeAnimator;

		[Space(10f)]
		[SerializeField]
		public bool spinEnabled;

		[ConditionalHide("spinEnabled", true)]
		[SerializeField]
		public SpinAnimator spinAnimator;

		[SerializeField]
		[Space(10f)]
		public bool jumpEnabled;

		[SerializeField]
		[ConditionalHide("jumpEnabled", true)]
		public JumpAnimator jumpAnimator;

		[NonSerialized]
		public EntityAnimator[] animators;

		public bool PushAnimating => false;

		public void Awake()
		{
		}

		public void Update()
		{
		}

		public void OnDisable()
		{
		}

		public void OnAnimFinished()
		{
		}

		public void DoWobble(Vector3 hitNormal = default(Vector3), int damage = 0)
		{
		}

		public void DoWobble(Vector3 hitNormal = default(Vector3), float normIntensity = 1f)
		{
		}

		public void DoPush(Vector3 hitNormal = default(Vector3), float duration = 0.5f, float intensityMult = 1f)
		{
		}

		public void DoShake()
		{
		}

		public void DoSpin(float duration = 0.5f, float time = 0f)
		{
		}

		public void StopSpin()
		{
		}

		public void DoJump(float _duration, float _intensity, float _time)
		{
		}

		public void StopJump()
		{
		}
	}
}
