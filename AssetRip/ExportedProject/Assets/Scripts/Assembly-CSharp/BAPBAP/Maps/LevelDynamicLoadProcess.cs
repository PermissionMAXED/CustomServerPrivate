using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace BAPBAP.Maps
{
	public class LevelDynamicLoadProcess : MonoBehaviour
	{
		public struct DynamicLoadTriggerLevel
		{
			public DynamicLoadTrigger[][] chunks;
		}

		public class DynamicLoadTrigger
		{
			public bool loaded;

			public GameObject loadedChunkInstance;

			public int chunkLevel;

			public Vector2Int chunkGridPos;

			public List<int> hideAreaIds;

			public void TryLoad(LevelDynamicLoadProcess levelLoad, bool loadImmediate = false)
			{
			}

			public void TryUnload(LevelDynamicLoadProcess levelLoad)
			{
			}
		}

		public class ChunkJob
		{
			public int chunkLevel { get; }

			public Vector2Int chunkPos { get; }

			public ChunkJob(int chunkLevel, Vector2Int chunkPos)
			{
			}
		}

		[CompilerGenerated]
		public sealed class _003CChunkProcessor_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public LevelDynamicLoadProcess _003C_003E4__this;

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
			public _003CChunkProcessor_003Ed__14(int _003C_003E1__state)
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

		[NonSerialized]
		public LevelRuntimeManager levelRuntime;

		[NonSerialized]
		public int chunkLevelCount;

		[NonSerialized]
		public DynamicLoadTriggerLevel[] chunkGridLevels;

		[NonSerialized]
		public Dictionary<int, GameObject> loadedHideAreasByIds;

		[NonSerialized]
		public Queue<ChunkJob> chunkJobs;

		[NonSerialized]
		public bool initialized;

		public void Initialize()
		{
		}

		public void OnDestroy()
		{
		}

		public void StartProcessor()
		{
		}

		public void CreateAllDynamicChunkTriggers()
		{
		}

		public void CreateAllDynamicHideAreaTriggers()
		{
		}

		[IteratorStateMachine(typeof(_003CChunkProcessor_003Ed__14))]
		public IEnumerator ChunkProcessor()
		{
			return null;
		}

		public void LoadDynamicChunk(int chunkLevel, Vector2Int chunkPos)
		{
		}

		public void LoadDynamicChunkImmediate(int chunkLevel, Vector2Int chunkPos)
		{
		}

		public void UnloadDynamicChunk(int chunkLevel, Vector2Int chunkPos, GameObject loadedChunkInstance)
		{
		}

		public void LoadDynamicHideArea(int hideAreaId)
		{
		}

		public void UnloadDynamicHideArea(int hideAreaId)
		{
		}

		public void TryLoadChunk(int level, int x, int y, bool loadImmediate = false)
		{
		}

		public void TriggerDinamicMapFullLoad()
		{
		}
	}
}
