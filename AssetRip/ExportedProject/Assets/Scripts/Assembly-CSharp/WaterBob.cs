using System;
using UnityEngine;

public class WaterBob : MonoBehaviour
{
	public float bobbingHeight;

	public float bobbingSpeed;

	public float rotationAmount;

	public bool randomOffset;

	public Vector2 randomRange;

	[NonSerialized]
	public Vector3 startPos;

	[NonSerialized]
	public Quaternion startRotation;

	public void Start()
	{
	}

	public void Update()
	{
	}
}
