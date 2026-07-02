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
	[RequireComponent(typeof(Vehicle))]
	public class VehicleDestroy : NetworkBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CBeginDestroy_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public VehicleDestroy _003C_003E4__this;

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
			public _003CBeginDestroy_003Ed__20(int _003C_003E1__state)
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
		public CharHurtbox charHurtbox;

		[NonSerialized]
		public CharHpBar charHpBar;

		[NonSerialized]
		public Vehicle vehicle;

		[SerializeField]
		[Tooltip("How much time to wait for the car to get destroyed when no hp left.")]
		[Header("Settings")]
		public float hpDestroyWaitDuration;

		[SerializeField]
		[Range(0f, 1f)]
		public float lowHpThresholdNorm;

		[SerializeField]
		[Min(0f)]
		public float damageMult;

		[Tooltip("The damage curve to apply to the vehicle on collision, where time is the factor from current velocity to max speed.")]
		[SerializeField]
		public AnimationCurve damageByCollisionSpeed;

		[Header("References")]
		[SerializeField]
		public ParticleSystem lowHpVfx;

		[SerializeField]
		public AudioPlayRandom hitAudioPlay;

		[Header("Prefabs")]
		[SerializeField]
		public GameObject vfxDestroyPrefab;

		[Header("Destroy Explosion Hitbox")]
		[SerializeField]
		public GameObject explosionHitboxPrefab;

		[SerializeField]
		public float explosionTtl;

		[SerializeField]
		public float explosionRadius;

		[SerializeField]
		public int explosionHitboxDamage;

		[SerializeField]
		public List<StatusEffectInfo> explosionStatusEffects;

		[NonSerialized]
		public bool isBeingDestroyed;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnHurtboxHit(Vector3 hitDir, int dmg, StatusEffectInfo[] statusEffects, int playerId, int teamId, Collider collider)
		{
		}

		[IteratorStateMachine(typeof(_003CBeginDestroy_003Ed__20))]
		public IEnumerator BeginDestroy()
		{
			return null;
		}

		public void OnVehicleCollision(Collision collision, Vector3 impulseForce)
		{
		}

		public void SpawnDestroyExplosion()
		{
		}

		[ClientRpc]
		public void RpcOnHurtboxHit()
		{
		}

		[ClientRpc]
		public void RpcOnBeginDestroy()
		{
		}

		public void OnHpChangedHook()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcOnHurtboxHit()
		{
		}

		public static void InvokeUserCode_RpcOnHurtboxHit(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnBeginDestroy()
		{
		}

		public static void InvokeUserCode_RpcOnBeginDestroy(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static VehicleDestroy()
		{
		}
	}
}
