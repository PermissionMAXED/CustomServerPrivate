using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Items;
using BAPBAP.Local;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIFader : MonoBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CFade_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public UIFader _003C_003E4__this;

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
			public _003CFade_003Ed__14(int _003C_003E1__state)
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

		[NonSerialized]
		public ItemManager itemManager;

		[SerializeField]
		public Image icon;

		[SerializeField]
		public Image iconBg;

		[SerializeField]
		public float fadeInTime;

		[SerializeField]
		public float fadeHoldTime;

		[SerializeField]
		public float fadeOutTime;

		[SerializeField]
		public Color clear;

		[SerializeField]
		public Color bgColor;

		[SerializeField]
		public Color bgClear;

		[NonSerialized]
		public Coroutine fade;

		public void Awake()
		{
		}

		public void LoadAbility(Item item)
		{
		}

		public void OnDestroy()
		{
		}

		public void OnDisable()
		{
		}

		[IteratorStateMachine(typeof(_003CFade_003Ed__14))]
		public IEnumerator Fade()
		{
			return null;
		}
	}
}
