using System;
using System.Collections.Generic;
using BAPBAP.Game.Dimensions;
using UnityEngine;

namespace BAPBAP.Local.Rendering
{
	[ExecuteAlways]
	public class MeshInstanceRenderer : MonoBehaviour
	{
		[Serializable]
		public class DefinitionPositions
		{
			public class InstanceLine
			{
				public List<Vector3> linePoints;

				public List<Vector3> generatedPositions;

				public Vector3 GetMidPoint()
				{
					return default(Vector3);
				}
			}

			public MeshInstanceDefinition meshDefinition;

			public List<Vector3> positions;

			[NonSerialized]
			public List<Vector3> cachedAllPositions;

			public List<InstanceLine> lines;

			public List<Vector3> CachedAllPositions => null;

			public List<Vector3> Positions
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public void ClearCachedPositions()
			{
			}
		}

		public class MeshDefinitionRenderer
		{
			public DefinitionPositions Positions;

			public OctreeFrustumCulling culling;

			public ComputeBuffer argsBuffer;

			public Material cachedMaterial;

			public DimensionRendererFeature dimensionRendererFeature;

			public Dimension.DimensionType overrideDimensionType;

			public Material Material => null;

			public bool IsValid()
			{
				return false;
			}

			public void OnDisable()
			{
			}

			public void OnEnable()
			{
			}

			public void Render(Vector3 rootPosition, Vector3 rootScale, Camera camera, int drawDistance)
			{
			}

			public void RenderInstance(Camera camera, Mesh mesh, uint[] args)
			{
			}
		}

		[Header("Settings")]
		public bool forceRenderDimensionableInstances;

		public DimensionRendererFeature dimensionRendererFeature;

		public MeshInstanceData existingData;

		[Min(10f)]
		public int drawDistance;

		[NonSerialized]
		[NonSerialized]
		public List<MeshDefinitionRenderer> allRenderers;

		[NonSerialized]
		public List<MeshDefinitionRenderer> validRenderers;

		public void LateUpdate()
		{
		}

		public void Render(Camera camera)
		{
		}

		public void OnDisable()
		{
		}

		public void OnEnable()
		{
		}

		public void OnDrawGizmos()
		{
		}

		public void SetValidInstanceBuffers()
		{
		}

		public void SetDefinitionPositions(MeshInstanceDefinition definition, List<Vector3> positions)
		{
		}

		public void SetOverrideDimensionType(Dimension.DimensionType dimensionType)
		{
		}

		public void RemoveDefinition(MeshInstanceDefinition definition)
		{
		}

		public void RemoveAllDefinitions()
		{
		}

		public void SetInstanceData(MeshInstanceData data)
		{
		}

		public List<DefinitionPositions> GetValidDefinitionData()
		{
			return null;
		}

		public void ClearCachedMaterials()
		{
		}
	}
}
