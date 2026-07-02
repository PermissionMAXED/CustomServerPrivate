using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Local;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIRebindKeyController : UIPropertyController
	{
		[CompilerGenerated]
		public sealed class _003CWaitToEnableButton_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public UIRebindKeyController _003C_003E4__this;

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
			public _003CWaitToEnableButton_003Ed__24(int _003C_003E1__state)
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
		public sealed class _003CWaitToStartKeyBind_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public UIRebindKeyController _003C_003E4__this;

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
			public _003CWaitToStartKeyBind_003Ed__23(int _003C_003E1__state)
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

		[Header("References")]
		[SerializeField]
		public Button button;

		[SerializeField]
		public Button resetButton;

		[SerializeField]
		public TMP_Text keyText;

		[SerializeField]
		public UISelectSfxElement rebindSfxElement;

		[SerializeField]
		public UIOnClickYPosLerp clickYPosLerp;

		[SerializeField]
		public GameObject ResetControllerButtonVis;

		[SerializeField]
		[Header("Sfx")]
		public SFXData rebindSuccessSfx;

		[NonSerialized]
		public InputBinding _inputBinding;

		[NonSerialized]
		public string _pressKeyStr;

		[NonSerialized]
		public bool _isHovered;

		public InputBinding InputBinding => null;

		public void FixedUpdate()
		{
		}

		public void Awake()
		{
		}

		public void Initialize(string propertyTrKey, string descTrKey, Action<UIPropertyController> onSelectedAction, InputTarget action)
		{
		}

		public void OnEnable()
		{
		}

		public override void Localise(Translator translator)
		{
		}

		public void SetKeyName(KeyCode key)
		{
		}

		public void BindSetListenText()
		{
		}

		public void OnBindReset()
		{
		}

		public void OnStartBind()
		{
		}

		public void OnBindCompleted(KeyCode newKey, bool playSfx = true)
		{
		}

		public void SetResetButtonEnabled()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitToStartKeyBind_003Ed__23))]
		public IEnumerator WaitToStartKeyBind()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWaitToEnableButton_003Ed__24))]
		public IEnumerator WaitToEnableButton()
		{
			return null;
		}

		public override void OnSelect()
		{
		}

		public override void OnDeselect()
		{
		}

		public override void OnSubmit()
		{
		}
	}
}
