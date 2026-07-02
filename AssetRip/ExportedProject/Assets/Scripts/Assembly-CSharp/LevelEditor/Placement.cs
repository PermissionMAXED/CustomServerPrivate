using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Maps;
using UnityEngine;

namespace LevelEditor
{
	public static class Placement
	{
		[CompilerGenerated]
		public sealed class _003CPlaceAllAssetsCoroutine_003Ed__57 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			[NonSerialized]
			public GameObject[] _003CallObjects_003E5__2;

			[NonSerialized]
			public int _003CspacingCells_003E5__3;

			[NonSerialized]
			public int _003Csize_003E5__4;

			[NonSerialized]
			public int _003Coffset_003E5__5;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CPlaceAllAssetsCoroutine_003Ed__57(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public static GameObject objectToPlace;

		public static AssetPalette.AutotileAsset autotileAssetToPlace;

		public static bool autotileEnabled;

		public static AssetPalette.VariationAsset currentVariationAsset;

		public static GUIContent[] currentVariationAssetGUIContent;

		public static bool variationAssetEnabled;

		public static bool modulePlacingEnabled;

		public static bool rotationEnabled;

		public static bool rotation45DegreeEnabled;

		public static bool eraserEnabled;

		public static bool blockEraserMod;

		public static bool replaceEnabled;

		public static bool blockReplaceMod;

		public static bool blockOffGridAssets;

		public static bool blockRandomizerMod;

		public static bool offGridAssetsEnabled;

		public static bool checkCollisionOnPlaceEnabled;

		public static bool allowOverlappingMapObject;

		public static bool showPlacementSettings;

		public static bool brushSizeEnabled;

		public static int currentBrushSizeId;

		public static int currentBrushSize;

		public static int[] brushSizes;

		public static float checkColliderSizeMultiplier;

		public static Configuration Config => null;

		public static void SetModuleToPlace(string moduleName, string path)
		{
		}

		public static void SetAutotileToPlace(AssetPalette.AutotileAsset autotileAsset)
		{
		}

		public static void SetVariationAssetToPlace(AssetPalette.VariationAsset variationAsset)
		{
		}

		public static void SetObjectToPlace(GameObject obj)
		{
		}

		public static void ResetSettings()
		{
		}

		public static void BlockEraser(bool isBlocked)
		{
		}

		public static void BlockOffGridAssets(bool isBlocked)
		{
		}

		public static void SetOffGridAssetsEnabled(bool isEnabled)
		{
		}

		public static void BlockReplaceMod(bool isBlocked)
		{
		}

		public static void CycleVariationAsset()
		{
		}

		public static void IncreaseBrushSize()
		{
		}

		public static void ReduceBrushSize()
		{
		}

		public static void SetBrushSizeId(int id)
		{
		}

		public static void SetBrushSizeEnabled(bool isEnabled)
		{
		}

		public static void OnEditSfx(float volumeMultiplier = 1f)
		{
		}

		public static bool TryEditSceneObject()
		{
			return false;
		}

		public static void EditBrush(Vector3 worldPos, Action<Vector3> editAction)
		{
		}

		public static bool OnTryErasePrefabOnWorldPos(Vector3 worldPos, MapLayer mapLayer)
		{
			return false;
		}

		public static bool TryEraseTileOnScene(GameObject prefabToErase, Vector2 worldPos)
		{
			return false;
		}

		public static bool TryPlacePrefabOnScene(GameObject newObjectToPlace, Vector3 worldPos, bool replace = false)
		{
			return false;
		}

		public static void OnEditSuccess(float sfxVolMult = 1f)
		{
		}

		public static void PlaceWorldTile(GameObject prefabToPlace, Vector2 worldPos, int rotationId)
		{
		}

		public static void PlaceTile(int rotTileId, Vector2Int tilemapPos, MapLayer mapLayer)
		{
		}

		public static void RemoveWorldTile(Vector2 worldPos, MapLayer mapLayer)
		{
		}

		public static void RemoveTile(Vector2Int tilemapPos, MapLayer mapLayer)
		{
		}

		public static void PlaceWorldMapObject(GameObject prefab, Vector3 worldPos, Vector3 angle, Vector3 scale)
		{
		}

		public static void PlaceWorldMapObject(int prefabId, Vector3 worldPos, Vector3 angle, Vector3 scale, MapLayer mapLayer)
		{
		}

		public static void RemoveWorldMapObject(GameObject obj)
		{
		}

		public static bool IsCollidingWithObstacle(GameObject newObjectToPlace, Vector2 worldCoord, Quaternion visRotation)
		{
			return false;
		}

		public static void PlaceAssetRadially(int count, float radius)
		{
		}

		public static void PlaceAllAssets()
		{
		}

		[IteratorStateMachine(typeof(_003CPlaceAllAssetsCoroutine_003Ed__57))]
		public static IEnumerator PlaceAllAssetsCoroutine()
		{
			return null;
		}

		public static void DrawPlacementSettingsGUI(bool onDock = false)
		{
		}
	}
}
