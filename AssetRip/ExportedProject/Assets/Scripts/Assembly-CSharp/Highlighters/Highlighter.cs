using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Highlighters
{
	public class Highlighter : MonoBehaviour
	{
		public enum FindRenderers
		{
			FindRenderersInChildren = 0,
			OnlyComponents = 1
		}

		public delegate void HighlighterChange(int ID);

		public delegate void HighlightersReset();

		[SerializeField]
		public HighlighterSettings highlighterSettings;

		[SerializeField]
		public FindRenderers findRenderers;

		[SerializeField]
		public List<HighlighterRenderer> renderers;

		[InspectorButton("GetRenderers")]
		public bool getRenderers;

		[HideInInspector]
		[SerializeField]
		public int id;

		[Tooltip("Draws helper gizmos of adjusted bounds of each renderer.")]
		[SerializeField]
		public bool showRenderBounds;

		[Tooltip("Draws helper gizmos of rendering bounds in screen space.")]
		[SerializeField]
		public bool showScreenAdjustedRenderBounds;

		public HighlighterSettings Settings => null;

		public List<HighlighterRenderer> Renderers
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int ID => 0;

		public static event HighlighterChange OnHighlighterValidate
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

		public static event HighlightersReset OnHighlighterReset
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

		public static void HighlighterValidate(int ID)
		{
		}

		public static void HighlightersNeedReset()
		{
		}

		public void HighlighterValidate()
		{
		}

		public void OnDrawGizmos()
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void OnDestroy()
		{
		}

		public void Setup()
		{
		}

		public void GetRenderers()
		{
		}

		public void GetRenderersInChildren()
		{
		}

		public void GetRenderersInComponents()
		{
		}
	}
}
