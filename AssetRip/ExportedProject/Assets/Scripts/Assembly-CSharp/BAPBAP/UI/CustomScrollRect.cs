using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class CustomScrollRect : ScrollRect, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[CompilerGenerated]
		public sealed class _003CWaitForMoveToContentElement_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public CustomScrollRect _003C_003E4__this;

			public float normValue;

			public bool keepCentered;

			public bool fadePos;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWaitForMoveToContentElement_003Ed__17(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public static string mouseScrollWheelAxis;

		[NonSerialized]
		public bool isMouseOver;

		public float smoothScrollTime;

		[NonSerialized]
		public bool isHoldingVerticalScrollbar;

		public Vector2 targetNormPos;

		public override void OnBeginDrag(PointerEventData eventData)
		{
		}

		public override void OnDrag(PointerEventData eventData)
		{
		}

		public override void OnEndDrag(PointerEventData eventData)
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		public new void Awake()
		{
		}

		public void Update()
		{
		}

		public void SetTargetNormalizedVPos(float value)
		{
		}

		public void SetTargetNormalizedHPos(float value)
		{
		}

		public override void OnScroll(PointerEventData data)
		{
		}

		public void MoveToContentElement(RectTransform element, bool fadePos = false, bool keepCentered = true)
		{
		}

		public void MoveToContentElement(float normValue, bool fadePos = false, bool keepCentered = true)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForMoveToContentElement_003Ed__17))]
		public IEnumerator WaitForMoveToContentElement(float normValue, bool fadePos = false, bool keepCentered = true)
		{
			return null;
		}

		public static bool IsMouseWheelRolling()
		{
			return false;
		}
	}
}
