using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Entities.View;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityCooldownBumper : EntityCooldownView
	{
		[CompilerGenerated]
		public sealed class _003CSpin_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public EntityCooldownBumper _003C_003E4__this;

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
			public _003CSpin_003Ed__27(int _003C_003E1__state)
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
		public Transform top;

		[SerializeField]
		public Transform bumperPivot;

		[SerializeField]
		public Transform[] bumpers;

		[SerializeField]
		public SpriteRenderer[] progressRings;

		[SerializeField]
		public ParticleSystem readyVfx;

		[SerializeField]
		public AudioSource readyLoopAudioSource;

		[SerializeField]
		public AudioSource activateAudioSource;

		[SerializeField]
		public AnimationCurve bumpCurve;

		[SerializeField]
		public AnimationCurve topCurve;

		[SerializeField]
		public float bumpMaxDistance;

		[SerializeField]
		public float bumperMaxScale;

		[SerializeField]
		public float topMaxScale;

		[SerializeField]
		public float topMaxDistance;

		[SerializeField]
		public float rotationSpeed;

		[NonSerialized]
		public readonly WaitForEndOfFrame wait;

		[NonSerialized]
		public Vector3[] startBumperLocalPositions;

		[NonSerialized]
		public Vector3 startBumperTopPosition;

		public override void OnSubscribed()
		{
		}

		public override void OnEntityDestroyed()
		{
		}

		public override void OnActivate()
		{
		}

		public override void OnIsActivated(bool activated)
		{
		}

		public override void PreFullActivateTick(float normValue)
		{
		}

		public void Bump(float cursor)
		{
		}

		public void ExtendBumper(float cursor, int i, float distance)
		{
		}

		public override void OnReset()
		{
		}

		public override void SetCooldown(float cd)
		{
		}

		public void SetRestockProgressRing(float normValue)
		{
		}

		[IteratorStateMachine(typeof(_003CSpin_003Ed__27))]
		public IEnumerator Spin()
		{
			return null;
		}

		public override void OnRendererVisibilityChanged(bool visible)
		{
		}

		public void OnDisable()
		{
		}

		public void OnEnable()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
