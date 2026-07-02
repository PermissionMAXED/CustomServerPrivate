using System;
using UnityEngine;

public class TrailGravityModifier : MonoBehaviour
{
	[SerializeField]
	public float gravity;

	[NonSerialized]
	public TrailRenderer trailRenderer;

	public void Start()
	{
	}

	public void Update()
	{
	}
}
