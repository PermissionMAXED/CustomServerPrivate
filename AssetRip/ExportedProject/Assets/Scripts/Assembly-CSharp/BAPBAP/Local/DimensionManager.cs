using System;
using System.Collections.Generic;
using BAPBAP.Game.Dimensions;
using UnityEngine;

namespace BAPBAP.Local
{
	public class DimensionManager : MonoBehaviour
	{
		[SerializeField]
		[NamedArray(typeof(Dimension.DimensionType), 0)]
		public DimensionBehaviourSO[] dimensions;

		[SerializeField]
		public DimensionRendererFeature dimensionRendererFeature;

		[SerializeField]
		[Tooltip("Converted into a Texture2DArray on Initialization with Repeat wrapping and Bilinear filtering. Access by float3.z / index in shader.")]
		public Texture2D[] dimensionTextures;

		[SerializeField]
		public Texture2D[] dimensionLUTs;

		[NonSerialized]
		public ComputeBuffer _dimensionRenderingDataBuffer;

		[NonSerialized]
		public DimensionBehaviourSO.DimensionRenderingData[] _dimensionRenderingData;

		[NonSerialized]
		public Texture2DArray _dimensionTextureArray;

		[NonSerialized]
		public Texture2DArray _dimensionLUTArray;

		public static readonly int DimensionsRenderingDataID;

		public static readonly int DimensionTexturesID;

		public static readonly int DimensionLUTsID;

		[NonSerialized]
		public List<Dimension> activeDimensions;

		public static DimensionManager Instance;

		public List<Dimension> GetDimensions()
		{
			return null;
		}

		public void PreAwake()
		{
		}

		public void OnDestroy()
		{
		}

		public Texture2DArray DimensionTextureArray()
		{
			return null;
		}

		public Texture2DArray DimensionLUTArray()
		{
			return null;
		}

		public void UpdateRenderingDataBuffers()
		{
		}

		public void DisposeRenderingDataBuffers()
		{
		}

		public void AddDimension(Dimension dimension)
		{
		}

		public void RemoveDimension(Dimension dimension)
		{
		}

		public DimensionBehaviourSO GetDimensionConfig(int dimensionId)
		{
			return null;
		}

		public void SpawnDimension(int dimensionId, Vector3 spawnPos, float radius)
		{
		}
	}
}
