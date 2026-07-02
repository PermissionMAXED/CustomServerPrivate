using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.AssetContainer
{
	public class MeshAssetContainer : AssetContainer<Mesh>
	{
		public override Mesh OptimizeAsset(Mesh asset)
		{
			return null;
		}

		public override string GetUniqueAssetName(List<Mesh> assets, string name)
		{
			return null;
		}

		public override bool ValidateAsset(Mesh asset)
		{
			return false;
		}

		[ContextMenu("Remove All Meshes")]
		public void RemoveAllMeshes()
		{
		}
	}
}
