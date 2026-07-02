using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Local.Rendering
{
	public class MeshInstanceAreaGroup : MonoBehaviour
	{
		public class Visualizer
		{
			public GameObject visualizerObj;

			public MeshRenderer visualizerRenderer;

			public Material visualizerMaterial;

			public RenderTexture visualizerTexture;

			public RenderTexture positionsTexture;

			public Vector4 boundsVector;

			public int visualizerDimensions;

			public RenderTexture CreateSDFRT(int width, int height)
			{
				return null;
			}

			public RenderTexture CreatePositionsRT(int width, int height)
			{
				return null;
			}

			public void UpdateVisualizer(bool positions)
			{
			}

			public void CreateVisualizer()
			{
			}

			public RenderTexture GetSDFRT()
			{
				return null;
			}

			public RenderTexture GetPositionsRT()
			{
				return null;
			}
		}

		public MeshInstanceDefinition instanceDefinition;

		public MeshInstanceRenderer instanceRenderer;

		public ComputeShader positionComputer;

		public Texture2D blueNoise;

		public float noiseScale;

		public float noiseScale2;

		[Range(-2f, 2f)]
		public float yOffset;

		[Range(0.001f, 1f)]
		public float positionsThreshold;

		[Range(-1f, 3f)]
		public int splatChannelMask;

		[Range(0.1f, 1f)]
		public float splatChannelMaskThreshold;

		[Range(-0.5f, 0.5f)]
		public float sdfStep;

		[Range(-0.5f, 0.5f)]
		public float sdfStepOffset;

		public bool visualizePositions;

		public MeshInstanceArea[] areas;

		public MeshInstanceBool[] bools;

		public List<Vector3> cachedPositions;

		[InspectorButton("ComputeAllPositions")]
		[SerializeField]
		public bool computeAllPositions;

		[NonSerialized]
		public float minX;

		[NonSerialized]
		public float minZ;

		[NonSerialized]
		public float maxX;

		[NonSerialized]
		public float maxZ;

		[NonSerialized]
		public float width;

		[NonSerialized]
		public float height;

		[NonSerialized]
		public float maxSize;

		[NonSerialized]
		public ComputeBuffer allPositionsBuffer;

		[NonSerialized]
		public ComputeBuffer areasBuffer;

		[NonSerialized]
		public ComputeBuffer boolsBuffer;

		[NonSerialized]
		public ComputeBuffer countBuffer;

		[NonSerialized]
		public Visualizer visualizer;

		public int ThreadGroupsX => 0;

		public int ThreadGroupsY => 0;

		public Vector4 BoundsVector => default(Vector4);

		public void ComputeAllPositions()
		{
		}

		public void InitBuffers()
		{
		}

		public int Area2SDf2PosKernel()
		{
			return 0;
		}

		public void InitSizes()
		{
		}

		public void SetupComputer()
		{
		}

		public void DispatchComputer()
		{
		}

		public void ReleaseBuffers()
		{
		}

		public void RemoveFromRenderer()
		{
		}
	}
}
