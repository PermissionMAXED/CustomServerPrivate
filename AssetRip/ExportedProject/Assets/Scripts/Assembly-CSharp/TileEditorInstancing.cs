using System;
using UnityEngine;

public class TileEditorInstancing : MonoBehaviour
{
	public enum TileLayers
	{
		Ground = 0,
		Obstacles = 1,
		Decoration = 2
	}

	[Serializable]
	public struct TileTemplate
	{
		public GameObject prefabObj;

		public TileLayers layer;
	}

	public struct Tile
	{
		public bool exists;

		public int prefabId;

		public int rotationId;
	}

	[SerializeField]
	public int width;

	[SerializeField]
	public int height;

	[SerializeField]
	public TileTemplate[] tiles;

	[SerializeField]
	public LayerMask baseLayer;

	[SerializeField]
	[Header("Misc")]
	public int multiplier;

	[SerializeField]
	public float layerFillRate;

	[SerializeField]
	public GameObject refPrefab;

	[SerializeField]
	public Material mat;

	[NonSerialized]
	public int tileIdSelected;

	[NonSerialized]
	public Camera mainCamera;

	[NonSerialized]
	public RaycastHit mouseHit;

	[NonSerialized]
	public Ray mouseRay;

	[NonSerialized]
	public InstanceRenderer tileEditorRenderer;

	[NonSerialized]
	public Tile[,] mapGround;

	[NonSerialized]
	public Tile[,] mapObstacles;

	[NonSerialized]
	public Tile[,] mapDecoration;

	public void Awake()
	{
	}

	public void Start()
	{
	}

	public void Update()
	{
	}

	public Vector2Int GetMouseGridPosition()
	{
		return default(Vector2Int);
	}

	public Vector2Int ToGridPosition(float worldX, float worldZ)
	{
		return default(Vector2Int);
	}

	public void DrawTileSelector(Vector2Int mouseWorldPos)
	{
	}

	public void SetupTileMaps()
	{
	}

	public void ModifyTile(TileTemplate tileTemplate, int tileTemplateId, int x, int z)
	{
	}

	public void AddTile(Tile[,] map, TileTemplate tileTemplate, int tileTemplateId, int x, int z)
	{
	}

	public void DeleteTile(Tile[,] map, int x, int z)
	{
	}
}
