using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Game;
using BAPBAP.Local;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIAugments : MonoBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CAugmentRerollSequence_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public UIAugments _003C_003E4__this;

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
			public _003CAugmentRerollSequence_003Ed__33(int _003C_003E1__state)
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
		public sealed class _003CAugmentSelectSequence_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public UIAugments _003C_003E4__this;

			public int selectedIndex;

			[NonSerialized]
			public PlayerAugments _003CplayerAugments_003E5__2;

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
			public _003CAugmentSelectSequence_003Ed__32(int _003C_003E1__state)
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
		public AugmentManager augmentManager;

		[Header("References")]
		[SerializeField]
		public GameObject augmentSelectHolder;

		[SerializeField]
		[Header("Select")]
		public UIAlphaFade _augmentsAlphaFade;

		[SerializeField]
		public CanvasGroup augmentsCanvasGroup;

		[SerializeField]
		public UIAugmentElement[] augmentElements;

		[SerializeField]
		public UIAugmentToggle augmentToggle;

		[SerializeField]
		[Header("Reroll References")]
		public GameObject _augmentRerollObj;

		[SerializeField]
		public Button _rerollButton;

		[SerializeField]
		public TMP_Text _rerollButtonCostText;

		[SerializeField]
		public UIPosLerpFade _rerollFailAnimation;

		[SerializeField]
		[Header("Skip References")]
		public Button _skipButton;

		[Header("Sfx")]
		[SerializeField]
		public SFXData _augmentOpenSfx;

		[SerializeField]
		public SFXData _augmentCloseSfx;

		[SerializeField]
		public SFXData _rerollFailSfx;

		[Header("Config")]
		[SerializeField]
		[Min(0f)]
		public float augmentSelectWaitDuration;

		[Min(0f)]
		[SerializeField]
		public float augmentRerollWaitDuration;

		[NonSerialized]
		public bool _showingAugments;

		[NonSerialized]
		public bool augmentsEnabled;

		[NonSerialized]
		public bool animatingSelect;

		public void Awake()
		{
		}

		public void Update()
		{
		}

		public void ClGameStart()
		{
		}

		public void ClDisableAugments()
		{
		}

		public void ClSetupAugmentSelection(AugmentManager.AugmentSelection augmentSel)
		{
		}

		public void ClSelectAugment(int augmentElementIndex)
		{
		}

		public void ClRerollAugments()
		{
		}

		public void ClSkipAugments()
		{
		}

		public void ClEnableRerollButton(bool show)
		{
		}

		public void ClSetRerollButtonAvailable(bool isAvailable)
		{
		}

		public void UpdateRemainingSelectionsCounter()
		{
		}

		public void ToggleAugments(bool toggle)
		{
		}

		public void ButtonToggleAugments()
		{
		}

		[IteratorStateMachine(typeof(_003CAugmentSelectSequence_003Ed__32))]
		public IEnumerator AugmentSelectSequence(int selectedIndex)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAugmentRerollSequence_003Ed__33))]
		public IEnumerator AugmentRerollSequence()
		{
			return null;
		}
	}
}
