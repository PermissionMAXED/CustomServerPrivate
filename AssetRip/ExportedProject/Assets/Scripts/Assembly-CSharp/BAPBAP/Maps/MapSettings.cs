using System;
using BAPBAP.Game;
using UnityEngine;

namespace BAPBAP.Maps
{
	[Serializable]
	public class MapSettings
	{
		[Serializable]
		public struct MapNamedModule
		{
			public string moduleName;

			public Vector2 moduleCenterPos;

			public Vector2 size;

			public ushort colorId;

			public override string ToString()
			{
				return null;
			}
		}

		public const int AmbienceMapUnitSize = 2;

		[ReadOnly]
		public Vector2Int size;

		[Header("Shared Config")]
		public bool includeInBuild;

		[HideInInspector]
		public int mapType;

		public string displayName;

		public bool excludeNavMeshFloor;

		public bool exclueWaterPerimeter;

		public int[,] biomeMap;

		public byte[,] ambienceMap;

		public Color[,] splatMap;

		[HideInInspector]
		public int[] serializedBiomeMap;

		[HideInInspector]
		public byte[] serializedAmbienceMap;

		[HideInInspector]
		public byte[] serializedSplatMap;

		[ReadOnly]
		[Header("BR Maps Config")]
		public MapNamedModule[] namedModules;

		[Space(5f)]
		[Tooltip("Override the default br zone rounds with the given array of rounds")]
		public bool customZoneRounds;

		public GameModeBattleRoyale.SerializedMapZones zoneRounds;

		[Header("Module Config")]
		public ushort colorId;

		public ushort biomeId;

		public bool isSelected;

		public bool rotationAllowed;

		[NonSerialized]
		public Texture2D biomeMapTex;

		[NonSerialized]
		public Texture2D tempSplatMapTex;

		public MapSettings(Vector2Int size)
		{
		}

		public MapSettings(MapSettings source)
		{
		}

		public void Serialize()
		{
		}

		public void Deserialize()
		{
		}
	}
}
