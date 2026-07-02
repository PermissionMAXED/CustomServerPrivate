using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Items
{
	public class ItemObjectDestroyDelay : NetworkBehaviour
	{
		[NonSerialized]
		public ItemObject itemObject;

		[SerializeField]
		public float duration;

		[NonSerialized]
		public float timer;

		public void Awake()
		{
		}

		public void Reset()
		{
		}

		public void StartDestroy()
		{
		}

		public void StartDestroy(float duration)
		{
		}

		public void OnDisable()
		{
		}

		[ServerCallback]
		public void Update()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
