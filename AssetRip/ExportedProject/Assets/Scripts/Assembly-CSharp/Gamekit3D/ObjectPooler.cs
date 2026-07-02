using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit3D
{
	public class ObjectPooler<T> where T : MonoBehaviour, IPooled<T>
	{
		public T[] instances;

		[NonSerialized]
		public Stack<int> m_FreeIdx;

		public void Initialize(int count, T prefab)
		{
		}

		public T GetNew()
		{
			return null;
		}

		public void Free(T obj)
		{
		}
	}
}
