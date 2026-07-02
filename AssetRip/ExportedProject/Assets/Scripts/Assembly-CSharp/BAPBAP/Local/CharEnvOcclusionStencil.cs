using System;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class CharEnvOcclusionStencil : MonoBehaviour
	{
		[NonSerialized]
		public CharHidden charHidden;

		public GameObject stencilWritePrefab;

		[NonSerialized]
		public GameObject currentStencilWriteObj;

		public void Start()
		{
		}

		public void LateUpdate()
		{
		}
	}
}
