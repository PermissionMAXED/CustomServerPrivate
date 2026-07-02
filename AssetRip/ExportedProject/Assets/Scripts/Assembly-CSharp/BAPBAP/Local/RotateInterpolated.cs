using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Local
{
	public class RotateInterpolated : NetworkBehaviour
	{
		[SerializeField]
		public float duration;

		[SerializeField]
		public float startRotation;

		[SerializeField]
		public float endRotation;

		[NonSerialized]
		public float timer;

		public Vector3 rotationDirection;

		[NonSerialized]
		public float rotationAmount;

		[NonSerialized]
		public bool initalEnabled;

		public void Awake()
		{
		}

		public override void OnStartServer()
		{
		}

		public void LateUpdate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
