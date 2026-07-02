using System;
using TMPro;
using UnityEngine;

public class UIScrollingText : MonoBehaviour
{
	[SerializeField]
	public RectTransform _scrollArea;

	[SerializeField]
	public TextMeshProUGUI _textToScroll;

	[SerializeField]
	public float _scrollSpeed;

	[SerializeField]
	public int _additionalSpacing;

	[NonSerialized]
	public Vector2 _startingAnchoredPos;

	[NonSerialized]
	public float _loopCyclePos;

	public void Start()
	{
	}

	public void SetupText()
	{
	}

	public void Update()
	{
	}
}
