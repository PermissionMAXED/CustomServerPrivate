using System;
using UnityEngine;

public class ItemIdleAnim : MonoBehaviour
{
	[SerializeField]
	[Header("Bob Settings")]
	public Transform bobTr;

	[SerializeField]
	public float duration;

	[SerializeField]
	public float maxHeight;

	[SerializeField]
	public AnimationCurve heightCurve;

	[Header("Rotation Settings")]
	[SerializeField]
	public Transform rotationTr;

	[SerializeField]
	public float initialYRotation;

	[SerializeField]
	public float randomRotation;

	[NonSerialized]
	public float initialRng;

	public void Awake()
	{
	}

	public void Start()
	{
	}

	public void SetInitialRotation()
	{
	}

	public void Reset()
	{
	}

	public void Update()
	{
	}

	public void Animate()
	{
	}
}
