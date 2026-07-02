using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PathCreation.Examples
{
	[ExecuteInEditMode]
	public abstract class PathSceneTool : MonoBehaviour
	{
		public PathCreator pathCreator;

		public bool autoUpdate;

		public VertexPath path => null;

		public event Action onDestroyed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void TriggerUpdate()
		{
		}

		public virtual void OnDestroy()
		{
		}

		public abstract void PathUpdated();

		public PathSceneTool()
		{
		}
	}
}
