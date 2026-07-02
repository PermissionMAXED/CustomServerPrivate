using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Network;

namespace BAPBAP.UI
{
	public class DebugController : ControllerBase
	{
		[CompilerGenerated]
		public sealed class _003CUpdate_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

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
			public _003CUpdate_003Ed__13(int _003C_003E1__state)
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

		public DebugController(ControllerManager controllerManager)
			: base(null)
		{
		}

		public void HandleDeveloperLobbyButton()
		{
		}

		public void DebugAddAsset(int assetId)
		{
		}

		public void DebugResetMetagame()
		{
		}

		public void DebugRedeemGold(int goldAmount)
		{
		}

		public void DebugRedeemXp(int charId, int xpAmount)
		{
		}

		public void HandleTwitchLink()
		{
		}

		public void SendGiveXpRequest(int charId, int amount)
		{
		}

		public void SendGiveGoldRequest(int amount)
		{
		}

		public void SendResetMetagameRequest()
		{
		}

		public void HandleGiveXpResponse(GiveXpResponse response)
		{
		}

		public void HandleGiveGoldResponse(GiveGoldResponse response, int amount)
		{
		}

		public void HandleResetMetagameResponse(ResetMetagameResponse response)
		{
		}

		[IteratorStateMachine(typeof(_003CUpdate_003Ed__13))]
		public IEnumerator Update()
		{
			return null;
		}
	}
}
