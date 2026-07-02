using System;
using System.Collections.Generic;
using BAPBAP.AssetContainer;
using Dreamteck.Splines;
using UnityEngine;

[RequireComponent(typeof(MeshGenerator))]
[RequireComponent(typeof(SplineComputer))]
[RequireComponent(typeof(MeshFilter))]
[ExecuteInEditMode]
public class LevelSpline : MonoBehaviour, IGeneratedLevelAsset
{
	[SerializeField]
	public MeshFilter meshFilter;

	[SerializeField]
	public SplineComputer splineComputer;

	[SerializeField]
	public MeshGenerator meshGenerator;

	[SerializeField]
	public bool bakeable;

	[NonSerialized]
	public bool isBaked;

	[SerializeField]
	public MeshAssetContainer container;

	public MeshAssetContainer Container => null;

	public bool IsBaked => false;

	public void OnEnable()
	{
	}

	public void OnRequestBakeProcesses(Dictionary<MeshAssetContainer, List<MeshFilter>> bakeProcesses)
	{
	}

	public void OnDisable()
	{
	}
}
