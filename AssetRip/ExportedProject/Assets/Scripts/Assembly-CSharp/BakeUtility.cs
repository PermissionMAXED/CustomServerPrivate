using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BAPBAP.AssetContainer;
using UnityEngine;

public static class BakeUtility
{
	public static Dictionary<MeshAssetContainer, List<MeshFilter>> bakeProcesses;

	public static event Action<Dictionary<MeshAssetContainer, List<MeshFilter>>> OnRequestBakeProcesses
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	static BakeUtility()
	{
	}

	public static bool BakeMeshFilters(List<MeshFilter> found, MeshAssetContainer container)
	{
		return false;
	}

	public static bool BakeMeshFilter(MeshFilter meshFilter, MeshAssetContainer container)
	{
		return false;
	}

	public static void BakeAllMeshFilters(List<MeshFilter> found, bool isStatic, string savePath, bool permanent, bool removeComputer, bool showProgress = true)
	{
	}

	public static bool BakeMeshFilter(MeshFilter meshFilter, bool isStatic, string savePath, bool permanent, bool removeComputer)
	{
		return false;
	}

	public static void PrepareMeshForSaving(MeshFilter meshFilter, bool makeStatic, bool lightmapUV, out Mesh bakedMesh)
	{
		bakedMesh = null;
	}
}
