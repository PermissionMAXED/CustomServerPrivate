using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

[BurstCompile]
public struct ProjectOntoMeshFilterVertexColorsJob : IJobParallelFor
{
	public NativeArray<Vector3>.ReadOnly EvaluatedPositions;

	public float Radius;

	public bool Invert;

	public Color VertexColor;

	public NativeArray<Vector3>.ReadOnly Vertices;

	public NativeArray<Color> VertexColors;

	public void Execute(int index)
	{
	}
}
