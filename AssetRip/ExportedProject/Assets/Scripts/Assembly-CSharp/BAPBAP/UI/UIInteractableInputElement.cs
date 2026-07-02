using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Pooling;
using TMPro;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIInteractableInputElement : MonoBehaviour
	{
		[Serializable]
		public class Configuration
		{
			public UIInteractableInputElement Prefab;

			public int PoolSize;

			public LocalPrefabPool.ResizeStrategy ResizeStrategy;
		}

		public class Pool
		{
			[NonSerialized]
			public Queue<UIInteractableInputElement> _activeQueue;

			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public Queue<UIInteractableInputElement> _inactiveQueue;

			[NonSerialized]
			public Transform _parentTransform;

			public Pool(Configuration configuration, Transform parentTransform)
			{
			}

			public UIInteractableInputElement Spawn(InputBinding input, bool isGamepad, string str)
			{
				return null;
			}

			public void Despawn(UIInteractableInputElement instance)
			{
			}

			public void Dispose()
			{
			}
		}

		[SerializeField]
		public UIInputIcon inputIcon;

		[SerializeField]
		public TMP_Text text;

		public void Initialise(InputBinding input, bool isGamepad, string str)
		{
		}
	}
}
