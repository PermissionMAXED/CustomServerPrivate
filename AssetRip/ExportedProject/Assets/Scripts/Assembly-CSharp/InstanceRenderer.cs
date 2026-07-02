using System;
using System.Collections.Generic;
using UnityEngine;

public class InstanceRenderer : MonoBehaviour
{
	public struct PrefabData
	{
		public Material material;

		public Mesh mesh;

		public Bounds bounds;

		public ComputeBuffer transformsBuffer;

		public ComputeBuffer argsBuffer;

		public Matrix4x4[] transforms;

		public Dictionary<int, int> gridIndexToBufferIndex;

		public Dictionary<int, int> bufferIndexToGridIndex;

		public uint[] args;

		public int instanceCount;
	}

	[Header("Common")]
	[SerializeField]
	public Material material;

	[Header("Instanced")]
	[SerializeField]
	public bool instancingEnabled;

	[NonSerialized]
	public Dictionary<int, PrefabData> prefabDatas;

	[NonSerialized]
	public List<int> prefabIds;

	[NonSerialized]
	public HashSet<int> changedPrefabIds;

	[NonSerialized]
	public int width;

	[NonSerialized]
	public int height;

	[NonSerialized]
	public int size;

	public static InstanceRenderer _instance;

	public static InstanceRenderer Instance => null;

	public void Awake()
	{
	}

	public void Update()
	{
	}

	public void OnDisable()
	{
	}

	public void Init(int _width, int _height)
	{
	}

	public void SetBuffers()
	{
	}

	public void AddTile(GameObject prefabObj, int prefabId, int xGrid, int yGrid, float xWorld, float zWorld, float rotation)
	{
	}

	public void RemoveTile(int prefabId, int xGrid, int yGrid)
	{
	}

	public void CreateNewPrefabData(GameObject prefabObj, int prefabId)
	{
	}
}
