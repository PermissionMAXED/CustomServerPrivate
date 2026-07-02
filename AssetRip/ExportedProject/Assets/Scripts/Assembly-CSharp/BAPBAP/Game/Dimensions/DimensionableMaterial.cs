using System;
using UnityEngine;

namespace BAPBAP.Game.Dimensions
{
	public class DimensionableMaterial : Dimensionable
	{
		[Serializable]
		public new class DimensionInfo : Dimensionable.DimensionInfo
		{
			[Space(5f)]
			public Renderer targetRenderer;

			public Material material;

			public bool createMaterialInstance;

			[NonSerialized]
			public Material originalMaterial;
		}

		[SerializeField]
		public DimensionInfo[] dimensionInfo;

		public override void ClOnDimensionEnter(int dimensionId)
		{
		}

		public override void ClOnDimensionExit(int dimensionId)
		{
		}

		public void ApplyDimensionSwap(DimensionInfo info)
		{
		}

		public void RevertDimensionSwap(DimensionInfo info)
		{
		}

		public override void SvOnDimensionEnter(int dimensionId)
		{
		}

		public override void SvOnDimensionExit(int dimensionId)
		{
		}
	}
}
