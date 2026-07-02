using System;
using UnityEngine;

namespace Highlighters
{
	[RequireComponent(typeof(HighlighterTrigger))]
	[RequireComponent(typeof(Highlighter))]
	public abstract class TriggerWrapper : MonoBehaviour
	{
		[NonSerialized]
		public HighlighterTrigger highlighterTrigger;

		[NonSerialized]
		public Highlighter highlighter;

		public void GetRequiredComponents()
		{
		}

		public virtual void OnEnable()
		{
		}

		public virtual void OnDisable()
		{
		}

		public virtual void TriggeringStarted()
		{
		}

		public virtual void TriggeringEnded()
		{
		}

		public virtual void HitTrigger()
		{
		}

		public TriggerWrapper()
		{
		}
	}
}
