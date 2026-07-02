using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace BAPBAP.Pooling
{
	public class LocalPrefabPool
	{
		[Serializable]
		public class Config
		{
			public GameObject prefab;

			public int initialSize;

			public ResizeStrategy resizeStrategy;
		}

		public enum ResizeStrategy
		{
			Increment = 0,
			InitialSize = 1,
			DoubleCount = 2
		}

		[CompilerGenerated]
		public sealed class _003CDespawnAfterRoutine_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public GameObject instance;

			public float seconds;

			[NonSerialized]
			public float _003Ct_003E5__2;

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
			public _003CDespawnAfterRoutine_003Ed__13(int _003C_003E1__state)
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

		public static Dictionary<GameObject, LocalPrefabPool> poolLookup;

		public static List<LocalPrefabPool> poolList;

		public static Dictionary<GameObject, GameObject> instanceLookup;

		public static Dictionary<GameObject, IPoolSpawnListener[]> spawnListeners;

		public static Dictionary<GameObject, IPoolDespawnListener[]> despawnListeners;

		[NonSerialized]
		public Config _config;

		[NonSerialized]
		public Stack<GameObject> _stack;

		[NonSerialized]
		public int _count;

		[NonSerialized]
		public Vector3 _initialPosition;

		[NonSerialized]
		public Quaternion _initialRotation;

		[NonSerialized]
		public Vector3 _initialScale;

		static LocalPrefabPool()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		public static void Reset()
		{
		}

		public static void Create(Config config)
		{
		}

		public static GameObject Spawn(GameObject prefab, Transform parent, bool enabled = true)
		{
			return null;
		}

		public static GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, bool enabled = true)
		{
			return null;
		}

		public static void Despawn(GameObject instance)
		{
		}

		public static void DespawnAfter(GameObject instance, float seconds)
		{
		}

		public static bool IsPooled(GameObject prefab)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CDespawnAfterRoutine_003Ed__13))]
		public static IEnumerator DespawnAfterRoutine(GameObject instance, float seconds)
		{
			return null;
		}

		public LocalPrefabPool(Config config)
		{
		}

		public void Create(int count)
		{
		}

		public GameObject Pop(Transform parent, bool enabled)
		{
			return null;
		}

		public GameObject Pop(Vector3 position, Quaternion rotation, bool enabled)
		{
			return null;
		}

		public void Push(GameObject obj)
		{
		}
	}
}
