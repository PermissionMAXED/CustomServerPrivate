using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class VFXLightMuzzlePooled : MonoBehaviour
	{
		[SerializeField]
		public bool doSetEnabled;

		[SerializeField]
		public float ttl;

		[NonSerialized]
		public float time;

		[NonSerialized]
		public bool done;

		[SerializeField]
		public Light[] lights;

		public void SetTtl(float ttl)
		{
		}

		public void OnEnable()
		{
		}

		public void FixedUpdate()
		{
		}
	}
}
