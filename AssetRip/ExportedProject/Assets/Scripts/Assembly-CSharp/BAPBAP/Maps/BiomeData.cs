using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Maps
{
	[CreateAssetMenu(fileName = "BiomeData", menuName = "BAPBAP/Maps/BiomeData", order = 1)]
	public class BiomeData : ScriptableObject
	{
		[Serializable]
		public class BiomeConfig
		{
			public string name;

			[Tooltip("The base surface id for this biome ground")]
			public SurfaceId groundSurfaceId;

			[Tooltip("The bush surface id for these biome bushes")]
			public SurfaceId bushSurfaceId;

			[Tooltip("The ambience id to default for this biome")]
			public AmbienceId ambienceId;

			[Tooltip("Default ground asset to place. Copy-paste the desired ground asset into here")]
			[Header("Ground Assets")]
			public AssetPalette.AutotileAsset defaultGroundAsset;

			[Tooltip("Default ground path asset to place")]
			public AssetPalette.AutotileAsset pathGroundAsset;

			[Header("Obstacle Assets")]
			[Tooltip("Default obstacle asset to place")]
			public AssetPalette.AutotileAsset obstacleAsset;

			[Tooltip("Variation asset to be placed on obstacle edges")]
			public AssetPalette.VariationAsset edgeObstacleAsset;

			[Tooltip("Variation asset to be placed on obstacle inner tiles")]
			public AssetPalette.VariationAsset innerObstacleDecoAsset;

			[Header("Water Edges Asset")]
			public AssetPalette.AutotileAsset waterAutotileAsset;

			[Header("Module Settings")]
			public ProceduralLevelGeneration.BiomeSettings biomeSettings;

			[Header("Ground Map")]
			public ColorMapValues colorMapValues;

			[Header("Biome Colors")]
			public Color bushColor;

			public Color minimapObstacleColor;
		}

		[Serializable]
		public class ProcgenAssets
		{
			public AssetPalette.AutotileAsset defaultWaterAutotileAsset;

			public GameObject procgenFloorTransitionTile;

			public GameObject playerSpawnProxyPrefab;
		}

		[Serializable]
		public class ProcgenConfig
		{
			[Serializable]
			public class IslandGenSettings
			{
				[Tooltip("How many cellular automata iterations should the generated island map have.")]
				[Min(0f)]
				public int cellularAutomataIterations;
			}

			[Serializable]
			public class BiomeGenSettings
			{
				[Min(0f)]
				public float flowMapAmplitude;

				[Min(0f)]
				public float flowMapFrequency;
			}

			[Serializable]
			public class PathGenSettings
			{
				public Texture2D flowMapTex;

				[Min(0f)]
				public float flowMapAmplitude;

				[Min(0f)]
				public float flowMapFrequency;

				[Min(0f)]
				[Tooltip("The thickness of the path carving to generate. This will carve out obstacles in the obstacle gen.")]
				public int colliderThickness;

				[Min(0f)]
				[Tooltip("The thickness of the path tiles to generate.")]
				public int meshThickness;

				[Tooltip("When drawing paths, the distance/spacing at wich to draw the paths.")]
				[Min(0.5f)]
				public float drawMinDistance;

				[Tooltip("When drawing paths carving, the distance/spacing at wich to draw the paths.")]
				[Min(0.5f)]
				public float carveDrawMinDistance;

				[Range(0f, 1f)]
				[Tooltip("Out of all the non-spanning tree paths, what percentage of all of them should add to the map paths.")]
				public float randomPathsAddPercentage;

				[Min(0f)]
				[Tooltip("Iterations of cellular automata to smooth out path tiles.")]
				public int cellularAutomataIterations;

				[Tooltip("In order to avoid paths tiles in biome transitions, how much padding on biome transition to carve into paths.")]
				[Min(0f)]
				public int carveBiomePadding;
			}

			[Serializable]
			public class ObstacleGenSettings
			{
				public Texture2D flowMapTex;

				[Min(0f)]
				public float flowMapAmplitude;

				[Min(0f)]
				public float flowMapFrequency;

				[Tooltip("How much padding from the modules should the obstacle tiles have.")]
				[Min(0f)]
				public int modulePadding;

				[Min(0f)]
				[Tooltip("How many cellular automata iterations should the generated obstacle tiles have.")]
				public int cellularAutomataIterations;
			}

			public IslandGenSettings islandGenSettings;

			public BiomeGenSettings biomeGenSettings;

			public PathGenSettings pathGenSettings;

			public ObstacleGenSettings obstacleGenSettings;
		}

		[Serializable]
		public struct ColorMapValues
		{
			public Color groundColor;

			public Texture2D groundTexture;

			public Texture2D groundTextureSplatR;

			public SurfaceId groundPaintRSurfaceId;

			[Range(0f, 1f)]
			public float groundPaintRSurfaceThreshold;

			[Range(0f, 1f)]
			public float groundTexAlpha;

			public float groundTextureScale;

			public float splatTextureScale;

			public float heightBlendFactor;

			public float heightBlendFalloff;

			public float heightEdgeFalloff;
		}

		[Header("Procgen Biomes")]
		public BiomeConfig[] biomesConfig;

		[Header("Procgen")]
		public ProcgenAssets procgenAssets;

		public ProcgenConfig procgenConfig;

		[Header("Named Modules Data")]
		public Color[] namedModuleColors;

		[Header("Color Map Values")]
		public ColorMapValues[] miscColorMapValues;

		public Color GetBiomeColor(int biomeId)
		{
			return default(Color);
		}

		public int GetBiomeId(Color color)
		{
			return 0;
		}

		public float ColorDistance(Color c1, Color c2)
		{
			return 0f;
		}
	}
}
