using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class ScaleTimer : MonoBehaviour
	{
		[SerializeField]
		public float duration;

		[SerializeField]
		public float startingScale;

		[SerializeField]
		public bool isTimeScaled;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public float targetScale;

		public void Start()
		{
		}

		public void DoReset()
		{
		}

		public void LateUpdate()
		{
		}
	}
}
