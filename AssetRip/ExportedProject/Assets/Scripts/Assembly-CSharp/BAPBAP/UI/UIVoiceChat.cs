using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Local;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIVoiceChat : MonoBehaviour
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		public struct _003CToggleVoiceAsync_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public UIVoiceChat _003C_003E4__this;

			public bool value;

			[NonSerialized]
			public TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[SerializeField]
		public GameObject root;

		[SerializeField]
		public RectTransform lobbyHolder;

		[SerializeField]
		public RectTransform gameHolder;

		[SerializeField]
		public CanvasGroup panelCanvasGroup;

		[SerializeField]
		public UIAlphaFade panelAlphaFade;

		[SerializeField]
		public Toggle voiceToggle;

		[SerializeField]
		public Toggle inputToggle;

		[SerializeField]
		public Button settingsButton;

		[SerializeField]
		public UITabController voiceSettingsTab;

		[SerializeField]
		public Image inputFill;

		[NonSerialized]
		public VoiceManager _voiceManager;

		public void Awake()
		{
		}

		public void Init(VoiceManager voiceManager)
		{
		}

		public void Show(bool fadeIn = false)
		{
		}

		public void Hide()
		{
		}

		public void OnVoiceToggle(bool value)
		{
		}

		[AsyncStateMachine(typeof(_003CToggleVoiceAsync_003Ed__16))]
		public void ToggleVoiceAsync(bool value)
		{
		}

		public void OnInputToggle(bool value)
		{
		}

		public void OnSettingsButton()
		{
		}

		public void SpeechDetected(string accountId, bool detected)
		{
		}

		public void EnergyChanged(string accountId, float energy, bool local)
		{
		}
	}
}
