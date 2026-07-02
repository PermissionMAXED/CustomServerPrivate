using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gamekit3D
{
	[RequireComponent(typeof(CharacterController))]
	[RequireComponent(typeof(Animator))]
	public class PlayerController : MonoBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CRespawnRoutine_003Ed__89 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public PlayerController _003C_003E4__this;

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
			public _003CRespawnRoutine_003Ed__89(int _003C_003E1__state)
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

		public static PlayerController s_Instance;

		public float maxForwardSpeed;

		public float gravity;

		public float jumpSpeed;

		public float minTurnSpeed;

		public float maxTurnSpeed;

		public float idleTimeout;

		public bool canAttack;

		public Camera cam;

		public MeleeWeapon meleeWeapon;

		[NonSerialized]
		public AnimatorStateInfo m_CurrentStateInfo;

		[NonSerialized]
		public AnimatorStateInfo m_NextStateInfo;

		[NonSerialized]
		public bool m_IsAnimatorTransitioning;

		[NonSerialized]
		public AnimatorStateInfo m_PreviousCurrentStateInfo;

		[NonSerialized]
		public AnimatorStateInfo m_PreviousNextStateInfo;

		[NonSerialized]
		public bool m_PreviousIsAnimatorTransitioning;

		[NonSerialized]
		public bool m_IsGrounded;

		[NonSerialized]
		public bool m_PreviouslyGrounded;

		[NonSerialized]
		public bool m_ReadyToJump;

		[NonSerialized]
		public float m_DesiredForwardSpeed;

		[NonSerialized]
		public float m_ForwardSpeed;

		[NonSerialized]
		public float m_VerticalSpeed;

		[NonSerialized]
		public PlayerInput m_Input;

		[NonSerialized]
		public CharacterController m_CharCtrl;

		[NonSerialized]
		public Animator m_Animator;

		[NonSerialized]
		public Material m_CurrentWalkingSurface;

		[NonSerialized]
		public Quaternion m_TargetRotation;

		[NonSerialized]
		public float m_AngleDiff;

		[NonSerialized]
		public Collider[] m_OverlapResult;

		[NonSerialized]
		public bool m_InAttack;

		[NonSerialized]
		public bool m_InCombo;

		[NonSerialized]
		public Renderer[] m_Renderers;

		[NonSerialized]
		public bool m_Respawning;

		[NonSerialized]
		public float m_IdleTimer;

		public const float k_AirborneTurnSpeedProportion = 5.4f;

		public const float k_GroundedRayDistance = 1f;

		public const float k_JumpAbortSpeed = 10f;

		public const float k_MinEnemyDotCoeff = 0.2f;

		public const float k_InverseOneEighty = 1f / 180f;

		public const float k_StickingGravityProportion = 0.5f;

		public const float k_GroundAcceleration = 20f;

		public const float k_GroundDeceleration = 25f;

		[NonSerialized]
		public readonly int m_HashAirborneVerticalSpeed;

		[NonSerialized]
		public readonly int m_HashForwardSpeed;

		[NonSerialized]
		public readonly int m_HashAngleDeltaRad;

		[NonSerialized]
		public readonly int m_HashTimeoutToIdle;

		[NonSerialized]
		public readonly int m_HashGrounded;

		[NonSerialized]
		public readonly int m_HashInputDetected;

		[NonSerialized]
		public readonly int m_HashMeleeAttack;

		[NonSerialized]
		public readonly int m_HashHurt;

		[NonSerialized]
		public readonly int m_HashDeath;

		[NonSerialized]
		public readonly int m_HashRespawn;

		[NonSerialized]
		public readonly int m_HashHurtFromX;

		[NonSerialized]
		public readonly int m_HashHurtFromY;

		[NonSerialized]
		public readonly int m_HashStateTime;

		[NonSerialized]
		public readonly int m_HashFootFall;

		[NonSerialized]
		public readonly int m_HashLocomotion;

		[NonSerialized]
		public readonly int m_HashAirborne;

		[NonSerialized]
		public readonly int m_HashLanding;

		[NonSerialized]
		public readonly int m_HashEllenCombo1;

		[NonSerialized]
		public readonly int m_HashEllenCombo2;

		[NonSerialized]
		public readonly int m_HashEllenCombo3;

		[NonSerialized]
		public readonly int m_HashEllenCombo4;

		[NonSerialized]
		public readonly int m_HashEllenDeath;

		[NonSerialized]
		public readonly int m_HashBlockInput;

		public static PlayerController instance => null;

		public bool IsMoveInput => false;

		public void SetCanAttack(bool canAttack)
		{
		}

		public void Reset()
		{
		}

		public void Awake()
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void FixedUpdate()
		{
		}

		public void CacheAnimatorState()
		{
		}

		public void UpdateInputBlocking()
		{
		}

		public bool IsWeaponEquiped()
		{
			return false;
		}

		public void EquipMeleeWeapon(bool equip)
		{
		}

		public void CalculateForwardMovement()
		{
		}

		public void CalculateVerticalMovement()
		{
		}

		public void SetTargetRotation()
		{
		}

		public bool IsOrientationUpdated()
		{
			return false;
		}

		public void UpdateOrientation()
		{
		}

		public void TimeoutToIdle()
		{
		}

		public void OnAnimatorMove()
		{
		}

		public void MeleeAttackStart(int throwing = 0)
		{
		}

		public void MeleeAttackEnd()
		{
		}

		public void Respawn()
		{
		}

		[IteratorStateMachine(typeof(_003CRespawnRoutine_003Ed__89))]
		public IEnumerator RespawnRoutine()
		{
			return null;
		}
	}
}
