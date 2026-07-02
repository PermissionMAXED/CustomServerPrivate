using System;
using AYellowpaper.SerializedCollections;
using BAPBAP.Game.Dimensions;
using UnityEngine;

namespace BAPBAP.Local.Rendering
{
	[Serializable]
	[CreateAssetMenu(fileName = "MeshInstanceDefinition", menuName = "Rendering/InstancingSystem/Mesh Instance Definition", order = 1)]
	public class MeshInstanceDefinition : ScriptableObject
	{
		public SerializedDictionary<Dimension.DimensionType, Mesh> dimensionMeshes;

		[SerializeField]
		public Mesh instanceMesh;

		[SerializeField]
		public Material instanceMaterial;

		[Min(0f)]
		public int submeshIndex;

		public bool gpuCullMultiMesh;

		public bool castShadows;

		public Mesh GetDefaultMesh()
		{
			return null;
		}

		public Mesh GetMesh()
		{
			return null;
		}

		public Mesh GetMesh(Dimension.DimensionType dimensionType)
		{
			return null;
		}

		public Material GetMaterial()
		{
			return null;
		}

		public int GetSubMeshIndex()
		{
			return 0;
		}
	}
}
