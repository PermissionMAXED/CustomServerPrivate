using System;
using UnityEngine;

namespace BAPBAP.Debugging
{
	public class DebugHurtboxViewer : MonoBehaviour
	{
		[NonSerialized]
		public GameObject currentHurtbox;

		[NonSerialized]
		public MeshRenderer currentMeshRenderer;

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void UpdateState()
		{
		}
	}
}
