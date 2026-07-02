using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Maps;
using UnityEngine;

namespace LevelEditor
{
	public class Main
	{
		public class Process
		{
			public Action action;

			public string processStr;

			public Process(Action action, string processStr = "")
			{
			}
		}

		public class IterationProcess
		{
			public delegate bool DelegateBool(int value);

			public delegate string DelegateString(int value);

			public Action<int> iterationAction;

			public DelegateBool isFinishedAction;

			public DelegateString iterationNameAction;

			public bool isFinished;

			public IterationProcess(Action<int> iterationAction, DelegateBool isFinishedAction, DelegateString iterationNameAction)
			{
			}

			public void ExecuteIteration(int iteration)
			{
			}

			public void GetIsFinished(int iteration)
			{
			}

			public string GetIterationName(int iteration)
			{
				return null;
			}
		}

		[CompilerGenerated]
		public sealed class _003CProcessIterationCoroutine_003Ed__50 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public IterationProcess[] processes;

			public Action onProcessEnd;

			[NonSerialized]
			public int _003CmaxIterations_003E5__2;

			[NonSerialized]
			public int _003CprocessIndex_003E5__3;

			[NonSerialized]
			public IterationProcess _003Cprocess_003E5__4;

			[NonSerialized]
			public int _003Citeration_003E5__5;

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
			public _003CProcessIterationCoroutine_003Ed__50(int _003C_003E1__state)
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

		[CompilerGenerated]
		public sealed class _003CProcessNextFrameCoroutine_003Ed__46 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public Process[] processes;

			[NonSerialized]
			public int _003Ci_003E5__2;

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
			public _003CProcessNextFrameCoroutine_003Ed__46(int _003C_003E1__state)
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

		public static int selectedTab;

		public static bool isEditorActive;

		public static bool showInterfaceGUI;

		public static bool originalAlwaysRefresh;

		public static bool autoPreBakeLevel;

		public static bool camLookHold;

		public static bool rightMouseHold;

		public static bool ctrlKeyHold;

		public static bool shiftKeyHold;

		public static bool mapEditingGUIEnabled;

		public static bool mouseIsOnScene;

		public static bool prevMouseIsOnScene;

		public static string[] settingsTabCaptions;

		public static bool vfxEnabled;

		public static bool processing;

		public static string processingStr;

		public static Color entityWorldPosColor;

		public static Material[] bushMaterialsByBiome;

		public static Dictionary<string, AssetPalette.AutotileAsset> autotileAssetsByName;

		public static Dictionary<string, GameObject> prefabByGUID;

		public static string[] GUIDByPrefabIds;

		public static LayerMask obstacleLayerMask;

		public static Configuration config;

		public static GameObject holderGameObject;

		public static LevelEditorMonoController monoController;

		public static bool initialized;

		public static Vector2Int currentRes;

		public static Vector2 _mousePos;

		public static Func<Vector2Int> GetCurrentRes;

		public static Vector2 mousePos => default(Vector2);

		public static void Load(GameObject _holderGameObject)
		{
		}

		public static void Unload()
		{
		}

		public static void Enable()
		{
		}

		public static void Disable()
		{
		}

		public static void MarkStageAsDirty()
		{
		}

		public static void EnterEditMode()
		{
		}

		public static void ExitEditMode()
		{
		}

		public static void DisableEditorObjectsPicking()
		{
		}

		public static void BuildAssetData()
		{
		}

		public static void GetAllPrefabsByGUID()
		{
		}

		public static GameObject GetPrefabObjFromPrefabGUID(string prefabGUID)
		{
			return null;
		}

		public static string GetPrefabGUIDFromPrefabId(int prefabId)
		{
			return null;
		}

		public static string GetPrefabGUIDFromPrefabObj(GameObject prefab, Dictionary<GameObject, string> GUIDByPrefab)
		{
			return null;
		}

		public static void ProcessNextFrame(Process process)
		{
		}

		public static void ProcessNextFrame(Process[] processes)
		{
		}

		[IteratorStateMachine(typeof(_003CProcessNextFrameCoroutine_003Ed__46))]
		public static IEnumerator ProcessNextFrameCoroutine(Process[] processes)
		{
			return null;
		}

		public static void ProcessIteration(IterationProcess process, Action onProcessEnd = null)
		{
		}

		public static void ProcessIteration(IterationProcess[] processes, Action onProcessEnd = null)
		{
		}

		[IteratorStateMachine(typeof(_003CProcessIterationCoroutine_003Ed__50))]
		public static IEnumerator ProcessIterationCoroutine(IterationProcess[] processes, Action onProcessEnd = null)
		{
			return null;
		}

		public static void SaveLocalSavedSettings()
		{
		}

		public static void LoadLocalSavedSettings()
		{
		}

		public static void Update()
		{
		}

		public static void ProcessEditorHotkeys()
		{
		}

		public static void UndoRedoInput()
		{
		}

		public static void ProcessToolHotkeys()
		{
		}

		public static void InputVisualizerRotation()
		{
		}

		public static void ToolInputEvents()
		{
		}

		public static void ProcessMouseEnterLeaveSceneView()
		{
		}

		public static void OnMouseEnterLeaveSceneView()
		{
		}

		public static void OnGUI()
		{
		}

		public static Vector2Int SetCurrentRes()
		{
			return default(Vector2Int);
		}

		public static void SceneGUI()
		{
		}

		public static void InterfaceGUI()
		{
		}

		public static void PlaySelectSfx(float volumeMultiplier = 1f)
		{
		}

		public static void PlayPlaceSfx(float volumeMultiplier = 1f)
		{
		}

		public static void PlayEraseSfx(float volumeMultiplier = 1f)
		{
		}
	}
}
