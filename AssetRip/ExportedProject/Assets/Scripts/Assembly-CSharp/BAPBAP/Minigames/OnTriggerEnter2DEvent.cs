using System;
using UnityEngine;

namespace BAPBAP.Minigames
{
	public class OnTriggerEnter2DEvent : MonoBehaviour
	{
		[NonSerialized]
		public Action<Collider2D> onTriggerEnterAction;

		public void Initialize(Action<Collider2D> onTriggerEnterAction)
		{
		}

		public void OnTriggerEnter2D(Collider2D other)
		{
		}
	}
}
