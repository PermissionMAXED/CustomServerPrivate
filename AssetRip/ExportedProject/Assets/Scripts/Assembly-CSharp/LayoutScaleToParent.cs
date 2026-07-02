using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class LayoutScaleToParent : UIBehaviour
{
	[NonSerialized]
	public RectTransform rect;

	[NonSerialized]
	public RectTransform parent;

	public override void Start()
	{
	}

	public override void OnRectTransformDimensionsChange()
	{
	}

	public void UpdateLayout()
	{
	}
}
