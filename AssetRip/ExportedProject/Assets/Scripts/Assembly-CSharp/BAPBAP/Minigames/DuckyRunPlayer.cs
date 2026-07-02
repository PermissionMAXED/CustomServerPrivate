using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.Minigames
{
	public class DuckyRunPlayer : MonoBehaviour
	{
		public Image image;

		[NonSerialized]
		public Action onTriggerEnterAction;

		public void Initialize(Action onTriggerEnterAction)
		{
		}

		public void OnTriggerEnter(Collider other)
		{
		}
	}
}
