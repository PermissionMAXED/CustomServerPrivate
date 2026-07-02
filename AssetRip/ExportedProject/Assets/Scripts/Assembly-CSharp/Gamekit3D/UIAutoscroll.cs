using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Gamekit3D
{
	public class UIAutoscroll : MonoBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CScroller_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public UIAutoscroll _003C_003E4__this;

			[NonSerialized]
			public float _003Ct_003E5__2;

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
			public _003CScroller_003Ed__5(int _003C_003E1__state)
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

		public ScrollRect scrollRect;

		public Scrollbar scrollbar;

		public float scrollValue;

		public float duration;

		public void OnEnable()
		{
		}

		[IteratorStateMachine(typeof(_003CScroller_003Ed__5))]
		public IEnumerator Scroller()
		{
			return null;
		}
	}
}
