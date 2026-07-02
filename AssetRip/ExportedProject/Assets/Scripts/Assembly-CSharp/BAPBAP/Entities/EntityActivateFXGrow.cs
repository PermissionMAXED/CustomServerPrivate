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
	public class EntityActivateFXGrow : EntityActivateBase
	{
		[CompilerGenerated]
		public sealed class _003CPlayGrowCoroutine_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public EntityActivateFXGrow _003C_003E4__this;

			[NonSerialized]
			public float _003Ct_003E5__2;

			[NonSerialized]
			public float _003CanimTime_003E5__3;

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
			public _003CPlayGrowCoroutine_003Ed__9(int _003C_003E1__state)
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
		[Header("Config")]
		public bool playOnStart;

		[Header("Settings")]
		[SerializeField]
		public AnimationCurve growCurve;

		[SerializeField]
		public float growTime;

		[SerializeField]
		public float waitTime;

		[SerializeField]
		public AudioClipData growAudioData;

		[SerializeField]
		public ParticleSystem growParticleSystem;

		public void Start()
		{
		}

		public override void Activate()
		{
		}

		[ClientRpc]
		public void RpcPlay()
		{
		}

		[IteratorStateMachine(typeof(_003CPlayGrowCoroutine_003Ed__9))]
		public IEnumerator PlayGrowCoroutine()
		{
			return null;
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcPlay()
		{
		}

		public static void InvokeUserCode_RpcPlay(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static EntityActivateFXGrow()
		{
		}
	}
}
