using UnityEngine;
using UnityEngine.UI;

public class CanvasMesh : Image
{
	public Mesh mesh;

	public static readonly Vector4 s_DefaultTangent;

	public static readonly Vector3 s_DefaultNormal;

	public override void OnPopulateMesh(VertexHelper vh)
	{
	}

	public Vector3 TransformVertex(Vector3 vertex)
	{
		return default(Vector3);
	}

	public Vector3 InverseTransformVertex(Vector3 vertex)
	{
		return default(Vector3);
	}
}
