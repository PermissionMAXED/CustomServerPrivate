using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIMessageElement : MonoBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CStartCoroutine_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public UIMessageElement _003C_003E4__this;

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
			public _003CStartCoroutine_003Ed__9(int _003C_003E1__state)
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

		public TMP_Text text;

		public RectTransform backdrop;

		public Image backdropImage;

		public Image colorImage;

		public CanvasGroup canvasGroup;

		public UIMessages UIMessages;

		[HideInInspector]
		public float timer;

		[NonSerialized]
		public bool initialized;

		public void Initialize(string textString, float timer_, Color color)
		{
		}

		[IteratorStateMachine(typeof(_003CStartCoroutine_003Ed__9))]
		public IEnumerator StartCoroutine()
		{
			return null;
		}

		public void SetUpWidth()
		{
		}

		public void DoMessageAnimation()
		{
		}

		public void LateUpdate()
		{
		}
	}
}
