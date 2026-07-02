using System;
using UnityEngine;

public class PlayTrailEmitter : MonoBehaviour
{
	[SerializeField]
	[Header("References")]
	public TrailRenderer trailRenderer;

	[Header("Settings")]
	[SerializeField]
	public float emissionDuration;

	[Tooltip("Should this trail only emmit under a the given threshold? If enabled, the trail will only emit if the elapsed distance between frames is under this threshold")]
	[SerializeField]
	public bool emitUnderThreshold;

	[SerializeField]
	[ConditionalHide("emitUnderThreshold", true)]
	public float emitThreshold;

	[NonSerialized]
	public bool isEmitting;

	[NonSerialized]
	public float emissionTimer;

	[NonSerialized]
	public Vector3 prevPos;

	[NonSerialized]
	public float emitThresholdSqr;

	public void OnValidate()
	{
	}

	public void Awake()
	{
	}

	public void LateUpdate()
	{
	}

	public void Play()
	{
	}

	public void Stop()
	{
	}
}
