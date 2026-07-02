using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Unity.Services.Vivox;
using UnityEngine;

namespace BAPBAP.Local
{
	public class VoiceManager : MonoBehaviour
	{
		public delegate void MuteStateChanged(string accountId, bool state);

		public delegate void SpeechDetected(string accountId, bool detected);

		public delegate void AudioEnergyChanged(string accountId, float energy, bool local);

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		public struct _003CDisable_003Ed__29 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public VoiceManager _003C_003E4__this;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		public struct _003CEnable_003Ed__28 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public VoiceManager _003C_003E4__this;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		public struct _003CInitialise_003Ed__31 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public VoiceManager _003C_003E4__this;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		public struct _003CSetAutoActivityDetection_003Ed__49 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public bool enabled;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		public struct _003CSetCachedInputDevice_003Ed__60 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public VoiceManager _003C_003E4__this;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		public struct _003CSetCachedOutputDevice_003Ed__61 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public VoiceManager _003C_003E4__this;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		public struct _003CSetChannel_003Ed__30 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public VoiceManager _003C_003E4__this;

			public string channel;

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

		[NonSerialized]
		public string _accountId;

		[NonSerialized]
		public bool _initialised;

		[NonSerialized]
		public string _channel;

		public bool Enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Muted
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string InputDeviceId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string OutputDeviceId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public event MuteStateChanged OnMuteStateChanged
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

		public event SpeechDetected OnSpeechDetected
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

		public event AudioEnergyChanged OnAudioEnergyChanged
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

		public void SetAccount(string accountId)
		{
		}

		[AsyncStateMachine(typeof(_003CEnable_003Ed__28))]
		public Task Enable()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CDisable_003Ed__29))]
		public Task Disable()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSetChannel_003Ed__30))]
		public Task SetChannel(string channel)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CInitialise_003Ed__31))]
		public Task Initialise()
		{
			return null;
		}

		public static string AlphaNumericString(string input)
		{
			return null;
		}

		public static string ClampStringLength(string input, int maxLength)
		{
			return null;
		}

		public void MuteSelf()
		{
		}

		public void UnmuteSelf()
		{
		}

		public void MutePlayer(string accountId)
		{
		}

		public void UnmutePlayer(string accountId)
		{
		}

		public void SetInputDevice(int device)
		{
		}

		public void SetOutputDevice(int device)
		{
		}

		public void SetOutputVolume(float volume)
		{
		}

		public void SetInputVolume(float volume)
		{
		}

		public void SetChannelVolume(float volume)
		{
		}

		public void SetPlayerVolume(string accountId, float volume)
		{
		}

		public void ResetPlayerVolume(string accountId)
		{
		}

		public float GetPlayerVolume(string accountId)
		{
			return 0f;
		}

		public bool IsPlayerMuted(string accountId)
		{
			return false;
		}

		public bool IsSelfMuted()
		{
			return false;
		}

		public void SetEchoCancellation(bool enabled)
		{
		}

		[AsyncStateMachine(typeof(_003CSetAutoActivityDetection_003Ed__49))]
		public void SetAutoActivityDetection(bool enabled)
		{
		}

		public void CachePlayerVolume(string accountId, float volume)
		{
		}

		public void ClearCachedPlayerVolume(string accountId)
		{
		}

		public bool TryGetCachedPlayerVolume(string accountId, out float volume)
		{
			volume = default(float);
			return false;
		}

		public string GetVolumeCacheKey(string accountId)
		{
			return null;
		}

		public void CachePlayerMute(string accountId, bool mute)
		{
		}

		public bool GetCachedPlayerMute(string accountId)
		{
			return false;
		}

		public string GetMuteCacheKey(string accountId)
		{
			return null;
		}

		public void OnConnectionFailedToRecover()
		{
		}

		public void OnParticipantAddedToChannel(VivoxParticipant participant)
		{
		}

		public void OnParticipantRemovedFromChannel(VivoxParticipant participant)
		{
		}

		[AsyncStateMachine(typeof(_003CSetCachedInputDevice_003Ed__60))]
		public Task SetCachedInputDevice()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSetCachedOutputDevice_003Ed__61))]
		public Task SetCachedOutputDevice()
		{
			return null;
		}

		public void OnAvailableInputDevicesChanged()
		{
		}

		public void OnAvailableOutputDevicesChanged()
		{
		}

		public void ParticipantMuteStateChanged(VivoxParticipant participant)
		{
		}

		public void ParticipantSpeedDetected(VivoxParticipant participant)
		{
		}

		public void ParticipantAudioEnergyChanged(VivoxParticipant participant)
		{
		}

		public bool TryGetParticipant(string accountId, out VivoxParticipant participant)
		{
			participant = null;
			return false;
		}

		public int FloatToVolume(float volume)
		{
			return 0;
		}

		public float VolumeToFloat(int volume)
		{
			return 0f;
		}
	}
}
