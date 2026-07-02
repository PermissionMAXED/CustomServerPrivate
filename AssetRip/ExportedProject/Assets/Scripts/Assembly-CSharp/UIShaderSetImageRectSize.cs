using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[ExecuteInEditMode]
public class UIShaderSetImageRectSize : UIBehaviour
{
	[SerializeField]
	public string propertyName;

	[SerializeField]
	public Image image;

	[NonSerialized]
	public RectTransform parent;

	[NonSerialized]
	public RectTransform rect;

	public override void Start()
	{
	}

	public void UpdateLayout()
	{
	}
}
