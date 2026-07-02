using System;
using BAPBAP.Entities;
using UnityEngine;

public class CatBounceAnimator : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	public ParticleSystem bounceParticlesPrefab;

	[Header("Anim Config")]
	[SerializeField]
	public float heightMultiplier;

	[SerializeField]
	public float heightOffset;

	[SerializeField]
	public float rotationMultiplier;

	[Header("First Bounce Config")]
	[SerializeField]
	public float firstBounceNormDuration;

	[SerializeField]
	public float firstBounceFxNormTrigger;

	[SerializeField]
	public AnimationCurve firstBounceHeightCurve;

	[SerializeField]
	public AnimationCurve firstRotationCurve;

	[SerializeField]
	public AnimationCurve scaleHeightCurve;

	[SerializeField]
	public AnimationCurve scaleWidthCurve;

	[SerializeField]
	[Header("Travel Bounce Config")]
	public float travelBounceFxNormTrigger;

	[SerializeField]
	public AnimationCurve travelBouncesHeightCurve;

	[SerializeField]
	public AnimationCurve travelRotationCurve;

	[SerializeField]
	public AnimationCurve travelScaleHeightCurve;

	[SerializeField]
	public AnimationCurve travelScaleWidthCurve;

	[NonSerialized]
	public float timeElapsed;

	[NonSerialized]
	public float firstBounceDuration;

	[NonSerialized]
	public float travelBouncesDuration;

	[NonSerialized]
	public bool firstBounceFired;

	[NonSerialized]
	public bool travelBounceFired;

	[NonSerialized]
	public int animState;

	[NonSerialized]
	public ParticleSystem bounceParticles;

	[NonSerialized]
	public Hitbox hitbox;

	public void Awake()
	{
	}

	public void Initialize(float fullTtl)
	{
	}

	public void OnDisable()
	{
	}

	public void Update()
	{
	}
}
