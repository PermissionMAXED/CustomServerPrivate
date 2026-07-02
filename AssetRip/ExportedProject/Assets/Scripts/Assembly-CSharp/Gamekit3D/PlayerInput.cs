using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gamekit3D
{
	public class PlayerInput : MonoBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CAttackWait_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public PlayerInput _003C_003E4__this;

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
			public _003CAttackWait_003Ed__25(int _003C_003E1__state)
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

		public static PlayerInput s_Instance;

		[HideInInspector]
		public bool playerControllerInputBlocked;

		[NonSerialized]
		public Vector2 m_Movement;

		[NonSerialized]
		public Vector2 m_Camera;

		[NonSerialized]
		public bool m_Jump;

		[NonSerialized]
		public bool m_Attack;

		[NonSerialized]
		public bool m_Pause;

		[NonSerialized]
		public bool m_ExternalInputBlocked;

		[NonSerialized]
		public WaitForSeconds m_AttackInputWait;

		[NonSerialized]
		public Coroutine m_AttackWaitCoroutine;

		public const float k_AttackInputDuration = 0.03f;

		public static PlayerInput Instance => null;

		public Vector2 MoveInput => default(Vector2);

		public Vector2 CameraInput => default(Vector2);

		public bool JumpInput => false;

		public bool Attack => false;

		public bool Pause => false;

		public void Awake()
		{
		}

		public void Update()
		{
		}

		[IteratorStateMachine(typeof(_003CAttackWait_003Ed__25))]
		public IEnumerator AttackWait()
		{
			return null;
		}

		public bool HaveControl()
		{
			return false;
		}

		public void ReleaseControl()
		{
		}

		public void GainControl()
		{
		}
	}
}
