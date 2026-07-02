using System;
using UnityEngine;

public class ObjectPlaceAnimation : MonoBehaviour
{
	public AnimationCurve heightCurve;

	public AnimationCurve widthCurve;

	[SerializeField]
	public bool destroyOnEnd;

	[NonSerialized]
	public float duration;

	[NonSerialized]
	public float time;

	public void Play()
	{
	}

	public void Update()
	{
	}
}
