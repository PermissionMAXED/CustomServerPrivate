using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Local;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateSfx : EntityActivateBase
	{
		[CompilerGenerated]
		public sealed class _003CDelaySfx_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public EntityActivateSfx _003C_003E4__this;

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
			public _003CDelaySfx_003Ed__10(int _003C_003E1__state)
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

		[Header("Settings")]
		[SerializeField]
		public AudioSource aS;

		[SerializeField]
		public AudioClipData chargeAudio;

		[SerializeField]
		public bool parented;

		[SerializeField]
		public bool loop;

		[SerializeField]
		public float pitch;

		[SerializeField]
		public float delay;

		[NonSerialized]
		public Transform spawnedAudioSource;

		public override void Activate()
		{
		}

		[ClientRpc]
		public void RpcSpawnSfx()
		{
		}

		public void Update()
		{
		}

		[IteratorStateMachine(typeof(_003CDelaySfx_003Ed__10))]
		public IEnumerator DelaySfx()
		{
			return null;
		}

		public void ClPlaySfx()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcSpawnSfx()
		{
		}

		public static void InvokeUserCode_RpcSpawnSfx(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static EntityActivateSfx()
		{
		}
	}
}
