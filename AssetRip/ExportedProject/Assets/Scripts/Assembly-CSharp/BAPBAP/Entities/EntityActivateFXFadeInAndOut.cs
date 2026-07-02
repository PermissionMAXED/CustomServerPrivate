using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateFXFadeInAndOut : EntityActivateBase
	{
		[CompilerGenerated]
		public sealed class _003CRpcFadeInAndOut_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public EntityActivateFXFadeInAndOut _003C_003E4__this;

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
			public _003CRpcFadeInAndOut_003Ed__6(int _003C_003E1__state)
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
		public float time;

		[SerializeField]
		public float waitTime;

		public override void Awake()
		{
		}

		public void Start()
		{
		}

		public override void Activate()
		{
		}

		[ClientRpc]
		public void RpcStartAnim()
		{
		}

		[IteratorStateMachine(typeof(_003CRpcFadeInAndOut_003Ed__6))]
		public IEnumerator RpcFadeInAndOut()
		{
			return null;
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcStartAnim()
		{
		}

		public static void InvokeUserCode_RpcStartAnim(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static EntityActivateFXFadeInAndOut()
		{
		}
	}
}
