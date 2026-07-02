using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityCooldownHourglass : NetworkBehaviour
	{
		[SerializeField]
		public SpriteRenderer[] progressRings;

		[SerializeField]
		public Renderer renderer;

		[SerializeField]
		public int sandMatIndex;

		[SerializeField]
		[Min(0.1f)]
		public float rotationDuration;

		[SerializeField]
		public Transform rotatorTransform;

		[SerializeField]
		public AnimationCurve rotatorAnimCurve;

		[SerializeField]
		public ParticleSystem readyVfx;

		[SerializeField]
		public AudioSource readyLoopAudioSource;

		[SerializeField]
		public AudioSource activateAudioSource;

		[NonSerialized]
		public Quaternion targetRotation;

		[NonSerialized]
		public Quaternion prevRotation;

		[NonSerialized]
		public bool flipRotation;

		[NonSerialized]
		public float cooldownDuration;

		[NonSerialized]
		public bool animateRotatorReset;

		[NonSerialized]
		public float rotatorTimer;

		[NonSerialized]
		public EntityBehaviour entityBehaviour;

		[NonSerialized]
		public CharMaterial charMaterial;

		[NonSerialized]
		public MaterialPropertyBlock propBlock;

		public MaterialPropertyBlock PropBlock => null;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void Update()
		{
		}

		public bool isQuaternionZero(Quaternion q)
		{
			return false;
		}

		public void OnDestroy()
		{
		}

		public void OnActivate()
		{
		}

		public void OnIsActivated(bool activated)
		{
		}

		public void OnReset()
		{
		}

		public void GetMaterialProps()
		{
		}

		public void SetCooldown(float cd)
		{
		}

		public void SetRestockProgressRing(float normValue)
		{
		}

		public void SetAmountProgress(float normValue, float cd)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
