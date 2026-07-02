using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class ConsumableDropShadow : MonoBehaviour
	{
		[SerializeField]
		public float targetHeight;

		[SerializeField]
		public float timeToDisable;

		[NonSerialized]
		public float time;

		public void LateUpdate()
		{
		}
	}
}
