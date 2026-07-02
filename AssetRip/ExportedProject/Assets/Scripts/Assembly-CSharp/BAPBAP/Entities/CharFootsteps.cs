using System;
using BAPBAP.Local;
using BAPBAP.Systems;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class CharFootsteps : MonoBehaviour
	{
		public enum Foot
		{
			Left = 0,
			Right = 1
		}

		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public EntityMovement charMove;

		[NonSerialized]
		public CharHidden charHidden;

		[NonSerialized]
		public SystemManager systemManager;

		[NonSerialized]
		public Animator animator;

		[SerializeField]
		[Header("References")]
		public FootstepData footstepData;

		[SerializeField]
		public GameObject footstepVfxPrefab;

		[SerializeField]
		public GameObject slipperyVfxPrefab;

		[Header("Footstep Audio")]
		[SerializeField]
		public float stepsVolumeMultiplier;

		[SerializeField]
		public float stepsPitchSpread;

		[SerializeField]
		public AudioSource audioSource;

		[Header("Settings")]
		[SerializeField]
		public Foot startingFoot;

		[SerializeField]
		public bool flipFootBackwards;

		[Header("Footstep VFX")]
		[SerializeField]
		public Transform leftFoot;

		[SerializeField]
		public Transform rightFoot;

		[NonSerialized]
		public ParticleSystem footstepVfx;

		[NonSerialized]
		public ParticleSystem slipperyVfxLeft;

		[NonSerialized]
		public ParticleSystem slipperyVfxRight;

		[NonSerialized]
		public AudioLoopSpeed slipperySfx;

		[NonSerialized]
		public bool isActive;

		[NonSerialized]
		public int footstepCurveValue;

		[NonSerialized]
		public float minStepTime;

		[NonSerialized]
		public float timeSinceLastStep;

		[NonSerialized]
		public bool currentFoot;

		[NonSerialized]
		public int prevSurfaceId;

		[NonSerialized]
		public float initialPitch;

		[NonSerialized]
		public bool slipperyActive;

		[NonSerialized]
		public bool cementActive;

		[NonSerialized]
		public bool metallicActive;

		[NonSerialized]
		public bool bloodyActive;

		[NonSerialized]
		public int animForwardParamId;

		[NonSerialized]
		public int animFootstepCurveParamId;

		public void PreAwake(EntityManager e)
		{
		}

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnDestroy()
		{
		}

		public void ManagedUpdate()
		{
		}

		public void TriggerFootstep(int legId)
		{
		}

		public void CreateFootstep()
		{
		}

		public void SetSlipperyFx(bool isEnabled)
		{
		}

		public void SetCementFootstep(bool isEnabled)
		{
		}

		public void SetMetallicFootstep(bool isEnabled)
		{
		}

		public void SetBloodyFootstep(bool isEnabled)
		{
		}

		public void OnDisable()
		{
		}
	}
}
