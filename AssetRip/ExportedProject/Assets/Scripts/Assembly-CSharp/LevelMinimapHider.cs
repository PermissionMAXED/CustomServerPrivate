using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelMinimapHider : MonoBehaviour
{
	public bool setToMaskMaterial;

	[NonSerialized]
	public Material defaultMaterial;

	public bool allChildren;

	[NonSerialized]
	public Dictionary<Transform, Material[]> originalMaterials;

	public void PopulateOriginalMaterials()
	{
	}

	public void Hide(Material maskMaterial = null)
	{
	}

	public void Show()
	{
	}
}
