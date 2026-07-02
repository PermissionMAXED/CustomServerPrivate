using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityDestroyOnActivate : EntityActivateBase
	{
		[SerializeField]
		public int countToDestroy;

		[Min(0f)]
		[SerializeField]
		public float delay;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public int count;

		[NonSerialized]
		public bool isEnabled;

		public override void Activate()
		{
		}

		public void Update()
		{
		}

		public void DoDestroy()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
