using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Content;
using BAPBAP.Utilities;
using UnityEngine;

namespace BAPBAP.Entities
{
	[RequireComponent(typeof(CharEmotes))]
	public class NpcEmoteEvent : MonoBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CWaitToEmote_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public RangeFloat waitRange;

			public NpcEmoteEvent _003C_003E4__this;

			public EmoteSO[] emotes;

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
			public _003CWaitToEmote_003Ed__20(int _003C_003E1__state)
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
		public CharEmotes charEmotes;

		[SerializeField]
		[Header("Random")]
		public bool doRandomEmote;

		[SerializeField]
		public RangeFloat randomEmoteWaitTime;

		[SerializeField]
		[Range(0f, 1f)]
		public float randomEmoteChance;

		[SerializeField]
		public EmoteSO[] randomEmotes;

		[SerializeField]
		[Header("On Entity Kill")]
		public bool doOnKillEmote;

		[SerializeField]
		public RangeFloat onKillEmoteWaitTime;

		[Range(0f, 1f)]
		[SerializeField]
		public float onKilledEmoteChance;

		[SerializeField]
		public EmoteSO[] onKillEmotes;

		[Header("On Damaged")]
		[SerializeField]
		public bool doOnDamagedEmote;

		[SerializeField]
		public RangeFloat onDamagedEmoteWaitTime;

		[Range(0f, 1f)]
		[SerializeField]
		public float onDamagedEmoteChance;

		[SerializeField]
		public EmoteSO[] onDamagedEmotes;

		[NonSerialized]
		public float currentRandomEmoteDuration;

		[NonSerialized]
		public float randomEmoteTimer;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void FixedUpdate()
		{
		}

		public void OnKillEmote(EntityManager killerManager)
		{
		}

		public void OnHitEmote(Vector3 hitDir, int dmg, StatusEffectInfo[] statusEffects, int playerId, int teamId, Collider collider)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitToEmote_003Ed__20))]
		public IEnumerator WaitToEmote(RangeFloat waitRange, EmoteSO[] emotes)
		{
			return null;
		}

		public void DoEmote(EmoteSO[] emotes)
		{
		}
	}
}
