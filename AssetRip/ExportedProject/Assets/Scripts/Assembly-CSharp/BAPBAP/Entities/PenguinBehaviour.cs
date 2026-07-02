using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Local;
using BAPBAP.Utilities;
using Mirror;
using UnityEngine;
using UnityEngine.AI;

namespace BAPBAP.Entities
{
	public class PenguinBehaviour : NetworkBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CDoDashDelay_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public PenguinBehaviour _003C_003E4__this;

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
			public _003CDoDashDelay_003Ed__34(int _003C_003E1__state)
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
		public EntityManager entityManager;

		[NonSerialized]
		public NavMeshAgent agent;

		[Header("References")]
		[SerializeField]
		public Animator animator;

		[SerializeField]
		public AudioPlayRandom audioPlayRandom;

		[SerializeField]
		public SimpleTargetDetectionCl targetDetectionCl;

		[SerializeField]
		public LookAtTargetConstraint followLookAtTarget;

		[Header("Wandering Settings")]
		[SerializeField]
		public float wanderingRangeFromOrigin;

		[SerializeField]
		public float stopDistance;

		[SerializeField]
		public RangeFloat wanderingWaitDurationRange;

		[SerializeField]
		[Header("Dash Settings")]
		public float dashStartDelay;

		[SerializeField]
		public float dashImpulse;

		[SerializeField]
		public float dashDecel;

		[SerializeField]
		public float dashDuration;

		[SerializeField]
		public GameObject dashHitboxPrefab;

		[SerializeField]
		public Transform dashFiringPoint;

		[SerializeField]
		public int damage;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("Anim Settings")]
		[SerializeField]
		public string idleState;

		[SerializeField]
		public string dashingState;

		[NonSerialized]
		public bool isIdle;

		[SyncVar(hook = "OnIsWanderingChanged")]
		[NonSerialized]
		public bool isWandering;

		[SyncVar(hook = "OnIsDashingChanged")]
		[NonSerialized]
		public bool isDashing;

		[NonSerialized]
		public float currentWanderingWaitDuration;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public Vector3 startPos;

		[NonSerialized]
		public Vector3 currentTargetPosition;

		[NonSerialized]
		public int isMovingParamHash;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_isWandering;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_isDashing;

		public bool NetworkisWandering
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public bool NetworkisDashing
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public void Awake()
		{
		}

		public void Start()
		{
		}

		[ServerCallback]
		public void FixedUpdate()
		{
		}

		public void WanderingState()
		{
		}

		public void StartIdle()
		{
		}

		public void StartDash()
		{
		}

		public void EndDash()
		{
		}

		[IteratorStateMachine(typeof(_003CDoDashDelay_003Ed__34))]
		public IEnumerator DoDashDelay()
		{
			return null;
		}

		public void SpawnDashHitbox(Vector3 lookDir)
		{
		}

		public void OnCollisionEnter(Collision collider)
		{
		}

		public void OnIsWanderingChanged(bool oldValue, bool newValue)
		{
		}

		public void OnIsDashingChanged(bool oldValue, bool newValue)
		{
		}

		public void ClSetIsInAlert(bool isInAlert)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
