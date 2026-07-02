using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using BAPBAP.Game.Dimensions;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_SinCity_RespawnTracker : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public int maxLives;

			[Header("Respawn Config")]
			public float killedWaitDuration;

			public float respawnWaitDuration;

			public GameObject killedRespawnStartVfxPrefab;

			public GameObject respawnVfxPrefab;

			public GameObject respawnEndVfxPrefab;

			[Header("References")]
			public P_D_SinCity_SO sinCity;
		}

		[CompilerGenerated]
		public sealed class _003CRespawnCoroutine_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public P_SinCity_RespawnTracker _003C_003E4__this;

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
			public _003CRespawnCoroutine_003Ed__13(int _003C_003E1__state)
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
		public Config config;

		[NonSerialized]
		public int currentLives;

		[NonSerialized]
		public byte respawningState;

		[NonSerialized]
		public DimensionZone dimensionZone;

		[NonSerialized]
		public SinCityLivesTracker sinLivesTracker;

		public override PassiveConfiguration passiveConfig => null;

		public P_SinCity_RespawnTracker(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void Reactivate()
		{
		}

		public override void ClDeactivatePassive()
		{
		}

		public override void OnKilledTrigger(EntityManager killerManager)
		{
		}

		public void StartRespawn()
		{
		}

		[IteratorStateMachine(typeof(_003CRespawnCoroutine_003Ed__13))]
		public IEnumerator RespawnCoroutine()
		{
			return null;
		}

		public Vector3 RandomPositionWithinRadius()
		{
			return default(Vector3);
		}

		public bool IsPointWithinZone(Vector2 point, Vector2 zonePosition, float zoneRadius)
		{
			return false;
		}

		public void ClOnKilledRespawnStart()
		{
		}

		public void ClOnRespawn()
		{
		}

		public void ClOnRespawnFinished()
		{
		}

		public void OnCurrentLivesChanged()
		{
		}

		public void OnRespawningStateChanged(byte oldValue, byte newValue)
		{
		}

		public override void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public override void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public override bool OnNetDebugCompare(NetworkReader netReader)
		{
			return false;
		}

		public override void OnNetDebugLog(StringBuilder sb)
		{
		}
	}
}
