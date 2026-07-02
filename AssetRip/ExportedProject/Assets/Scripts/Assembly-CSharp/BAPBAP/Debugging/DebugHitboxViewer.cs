using System;
using UnityEngine;

namespace BAPBAP.Debugging
{
	public class DebugHitboxViewer : MonoBehaviour
	{
		[NonSerialized]
		public GameObject holderObj;

		[NonSerialized]
		public MeshRenderer[] meshRenderers;

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void UpdateState()
		{
		}

		public void ProcessCollider(Collider col, int index)
		{
		}

		public void OnHitboxDestroyObj()
		{
		}
	}
}
