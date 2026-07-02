using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIZoneTitle : MonoBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CFadeInCanvasCoroutine_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public UIZoneTitle _003C_003E4__this;

			[NonSerialized]
			public float _003Ctime_003E5__2;

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
			public _003CFadeInCanvasCoroutine_003Ed__9(int _003C_003E1__state)
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

		[CompilerGenerated]
		public sealed class _003CFadeOutCanvasCoroutine_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public UIZoneTitle _003C_003E4__this;

			public string text;

			[NonSerialized]
			public float _003Ctime_003E5__2;

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
			public _003CFadeOutCanvasCoroutine_003Ed__10(int _003C_003E1__state)
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

		[SerializeField]
		[Header("References")]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public TMP_Text textMesh;

		[SerializeField]
		[Header("Settings")]
		public float fadeIn;

		[SerializeField]
		public float holdTime;

		[SerializeField]
		public float fadeOut;

		[NonSerialized]
		public Coroutine inCoroutine;

		[NonSerialized]
		public Coroutine outCoroutine;

		[NonSerialized]
		public bool inProgress;

		public void StartFade(string text)
		{
		}

		[IteratorStateMachine(typeof(_003CFadeInCanvasCoroutine_003Ed__9))]
		public IEnumerator FadeInCanvasCoroutine()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CFadeOutCanvasCoroutine_003Ed__10))]
		public IEnumerator FadeOutCanvasCoroutine(string text = "")
		{
			return null;
		}
	}
}
