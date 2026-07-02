using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class LookTowardsMoveDirection : MonoBehaviour
	{
		[SerializeField]
		public bool noYPos;

		[NonSerialized]
		public Vector3 _prevPos;

		public void Start()
		{
		}

		public void LateUpdate()
		{
		}
	}
}
