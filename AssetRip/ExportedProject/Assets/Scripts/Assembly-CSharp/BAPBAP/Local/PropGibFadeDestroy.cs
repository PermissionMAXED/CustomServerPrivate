using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class PropGibFadeDestroy : MonoBehaviour
	{
		[SerializeField]
		[Min(0f)]
		public float ttl;

		[Min(0f)]
		[SerializeField]
		public float randomTtlSpread;

		[Min(0f)]
		[SerializeField]
		public float fadeStart;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public float ttlFadeStart;

		[NonSerialized]
		public Material mat;

		public void Start()
		{
		}

		public void Update()
		{
		}

		public void SetFadeProgress(float nt)
		{
		}
	}
}
