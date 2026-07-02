using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ScrollingImage : MonoBehaviour
{
	[SerializeField]
	public RawImage _targetImage;

	[SerializeField]
	public Vector2 _scrollSpeed;

	[NonSerialized]
	public bool _canScroll;

	public void OnEnable()
	{
	}

	public void LateUpdate()
	{
	}
}
