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
	public class EntityActivateFXShrinkAndGrow : EntityActivateBase
	{
		[CompilerGenerated]
		public sealed class _003CShrinkAndThenGrowCactus_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public EntityActivateFXShrinkAndGrow _003C_003E4__this;

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
			public _003CShrinkAndThenGrowCactus_003Ed__8(int _003C_003E1__state)
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
		public AudioManager audioManager;

		[SerializeField]
		[Header("Settings")]
		public AnimationCurve shrinkCurve;

		[SerializeField]
		public AnimationCurve growCurve;

		[SerializeField]
		public AudioClipData growAudioData;

		[SerializeField]
		public ParticleSystem growParticleSystem;

		public override void Awake()
		{
		}

		public override void Activate()
		{
		}

		[ClientRpc]
		public void RpcShrinkAndThenGrowCactus()
		{
		}

		[IteratorStateMachine(typeof(_003CShrinkAndThenGrowCactus_003Ed__8))]
		public IEnumerator ShrinkAndThenGrowCactus()
		{
			return null;
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcShrinkAndThenGrowCactus()
		{
		}

		public static void InvokeUserCode_RpcShrinkAndThenGrowCactus(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static EntityActivateFXShrinkAndGrow()
		{
		}
	}
}
