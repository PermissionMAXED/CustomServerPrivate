using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class MaterialAlphaCurve : MonoBehaviour
	{
		public Renderer rend;

		public AnimationCurve animCurve;

		public bool doLoop;

		public float loopDuration;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public bool isEnabled;

		public void Start()
		{
		}

		public void OnEnable()
		{
		}

		public void Update()
		{
		}
	}
}
