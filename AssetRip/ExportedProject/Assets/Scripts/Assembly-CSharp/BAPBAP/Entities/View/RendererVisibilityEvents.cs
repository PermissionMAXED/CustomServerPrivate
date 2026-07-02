using System;
using UnityEngine;

namespace BAPBAP.Entities.View
{
	public class RendererVisibilityEvents : MonoBehaviour
	{
		public Action<bool> OnVisibilityChanged;

		public void OnBecameInvisible()
		{
		}

		public void OnBecameVisible()
		{
		}
	}
}
