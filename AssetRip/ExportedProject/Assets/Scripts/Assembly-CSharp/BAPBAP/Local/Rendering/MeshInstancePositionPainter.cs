using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Local.Rendering
{
	public class MeshInstancePositionPainter : MonoBehaviour
	{
		public bool painterEnabled;

		[Header("References")]
		public MeshInstanceDefinition instanceDefinition;

		public MeshInstanceRenderer instanceRenderer;

		public ComputeShader shader;

		[Header("Erasing")]
		public bool erase;

		[Range(0.1f, 5f)]
		public float erasePower;

		[Header("Brush")]
		public Texture2D brush;

		[Range(2f, 12f)]
		public int brushResolution;

		[Range(0f, 1f)]
		public float brushScale;

		[Header("Cleanup Minimum Radius")]
		[Range(0f, 0.4f)]
		public float minimumRadius;

		[Header("Plane / Layer")]
		public bool useLayer;

		public LayerMask paintObjLayer;

		public float yOffset;

		[Header("Debug")]
		public bool visualizePositions;

		[Header("Saving")]
		public MeshInstanceData meshInstanceData;

		[HideInInspector]
		public List<Vector3> currentPositions;

		[HideInInspector]
		public Texture2D resizedBrush;

		[NonSerialized]
		public ComputeBuffer removeBuffer;

		[NonSerialized]
		public ComputeBuffer positionBuffer;

		[NonSerialized]
		public ComputeBuffer resultBuffer;

		[NonSerialized]
		public ComputeBuffer countBuffer;

		public void ResizeBrush(float brushSize)
		{
		}

		public void OnDrawGizmos()
		{
		}

		public void OnMouseUp()
		{
		}

		public void Paint(Ray ray)
		{
		}

		public void ProcessPositions(float radius)
		{
		}

		public void ErasePositions(Vector3 erasePosition, float eraseRadius)
		{
		}

		public void ClearPositions()
		{
		}
	}
}
