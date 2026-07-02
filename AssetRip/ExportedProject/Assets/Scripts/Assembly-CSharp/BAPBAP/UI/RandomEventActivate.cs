using System;
using UnityEngine;
using UnityEngine.Events;

namespace BAPBAP.UI
{
	public class RandomEventActivate : MonoBehaviour
	{
		[Serializable]
		public class RendererEvent
		{
			public Renderer renderer;

			public Material material;

			[Min(0f)]
			public int index;
		}

		[Range(0f, 1f)]
		[SerializeField]
		public float normProbability;

		[Space(10f)]
		[SerializeField]
		public UnityEvent onActivatedEvent;

		[SerializeField]
		public RendererEvent[] onActivatedRendererEvent;

		[SerializeField]
		[Space(10f)]
		public UnityEvent onReActivatedEvent;

		[SerializeField]
		public RendererEvent[] onDeactivatedRendererEvent;

		[NonSerialized]
		public bool activated;

		public void Trigger()
		{
		}

		public void TriggerRendererEvent(RendererEvent[] rendererEvent)
		{
		}
	}
}
