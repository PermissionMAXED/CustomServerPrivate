using System;
using UnityEngine;

public class UIMouseParallax : MonoBehaviour
{
	[SerializeField]
	public float parallaxFactor;

	[SerializeField]
	public bool horizontal;

	[SerializeField]
	public bool vertical;

	[NonSerialized]
	public Vector2 prevMousePos;

	public void Update()
	{
	}
}
