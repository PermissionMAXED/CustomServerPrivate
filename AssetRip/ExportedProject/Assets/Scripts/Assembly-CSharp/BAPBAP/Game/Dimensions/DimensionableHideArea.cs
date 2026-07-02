using System;
using System.Collections.Generic;
using BAPBAP.Entities.HideArea;
using UnityEngine;

namespace BAPBAP.Game.Dimensions
{
	[DefaultExecutionOrder(-100)]
	public class DimensionableHideArea : Dimensionable
	{
		[Serializable]
		public new class DimensionInfo : Dimensionable.DimensionInfo
		{
			[Space(5f)]
			public GameObject[] dimensionHideAreaPrefab;

			public float radius;

			[NonSerialized]
			[NonSerialized]
			public List<MeshRenderer> meshRenderers;

			[NonSerialized]
			[NonSerialized]
			public MaterialPropertyBlock _propertyBlock;

			[NonSerialized]
			[NonSerialized]
			public bool isInitialized;

			public MaterialPropertyBlock propertyBlock => null;

			public void Initialize(HideArea hideArea)
			{
			}

			public void SetMaterialAlpha(float alpha)
			{
			}

			public void ApplyDimensionSwap()
			{
			}

			public void RevertDimensionSwap()
			{
			}

			public void Dispose()
			{
			}
		}

		[SerializeField]
		public HideArea hideArea;

		[SerializeField]
		public BoxCollider dimensionableCollider;

		[SerializeField]
		public DimensionInfo[] dimensionInfo;

		public static readonly int ColorProperty;

		public override void SvOnDimensionEnter(int dimensionId)
		{
		}

		public override void SvOnDimensionExit(int dimensionId)
		{
		}

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

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnDestroy()
		{
		}

		public void SetMaterialAlpha(float alpha)
		{
		}
	}
}
