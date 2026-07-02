using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Pooling
{
	public class NetworkPrefabPool
	{
		[Serializable]
		public class Config
		{
			public GameObject prefab;

			public int initialSizeServer;

			public int initialSizeClient;

			public ResizeStrategy resizeStrategy;
		}

		public enum ResizeStrategy
		{
			Increment = 0,
			InitialSize = 1,
			DoubleCount = 2
		}

		[CompilerGenerated]
		public sealed class _003CDespawnAfterRoutine_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public float seconds;

			public GameObject instance;

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
			public _003CDespawnAfterRoutine_003Ed__16(int _003C_003E1__state)
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

		public static Dictionary<GameObject, uint> netIdLookup;

		public static Dictionary<uint, NetworkPrefabPool> poolLookup;

		public static List<NetworkPrefabPool> poolList;

		public static Dictionary<GameObject, IPoolSpawnListener[]> spawnListeners;

		public static Dictionary<GameObject, IPoolDespawnListener[]> despawnListeners;

		[NonSerialized]
		public Config _config;

		[NonSerialized]
		public uint _netId;

		[NonSerialized]
		public bool _isServer;

		[NonSerialized]
		public Stack<GameObject> _inactive;

		[NonSerialized]
		public GameObject[] _activeBuffer;

		[NonSerialized]
		public Dictionary<GameObject, int> _activeLookup;

		[NonSerialized]
		public HashSet<GameObject> _activeHash;

		[NonSerialized]
		public int _count;

		static NetworkPrefabPool()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		public static void Reset()
		{
		}

		public static void Create(Config config, bool isServer)
		{
		}

		public static void ServerCreate(Config config)
		{
		}

		public static void ClientCreate(Config config)
		{
		}

		public static GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
		{
			return null;
		}

		public static void Despawn(GameObject instance)
		{
		}

		public static void DespawnAfter(GameObject instance, float seconds)
		{
		}

		public static bool IsPooled(GameObject instance)
		{
			return false;
		}

		public static void DisposeAll()
		{
		}

		public static void DisposePool(GameObject obj)
		{
		}

		[IteratorStateMachine(typeof(_003CDespawnAfterRoutine_003Ed__16))]
		public static IEnumerator DespawnAfterRoutine(GameObject instance, float seconds)
		{
			return null;
		}

		public NetworkPrefabPool(Config config, uint netId, bool isServer)
		{
		}

		public void Create(int count)
		{
		}

		public GameObject Pop(Vector3 position, Quaternion rotation, Vector3 scale)
		{
			return null;
		}

		public void Push(GameObject instance)
		{
		}

		public void Dispose()
		{
		}

		public GameObject SpawnHandler(SpawnMessage msg)
		{
			return null;
		}

		public void DespawnHandler(GameObject instance)
		{
		}
	}
}
