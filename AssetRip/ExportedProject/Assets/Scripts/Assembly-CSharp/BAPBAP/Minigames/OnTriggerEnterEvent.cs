using System;
using UnityEngine;

namespace BAPBAP.Minigames
{
	public class OnTriggerEnterEvent : MonoBehaviour
	{
		[NonSerialized]
		public Action<Collider> onTriggerEnterAction;

		public void Initialize(Action<Collider> onTriggerEnterAction)
		{
		}

		public void OnTriggerEnter(Collider other)
		{
		}
	}
}
