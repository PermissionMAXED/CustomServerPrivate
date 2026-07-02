using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class VFXSpawn : MonoBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CSpawnDelayed_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public float delay;

			public VFXSpawn _003C_003E4__this;

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
			public _003CSpawnDelayed_003Ed__19(int _003C_003E1__state)
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
		public HitboxBase hitbox;

		[Header("Settings")]
		[SerializeField]
		public float vfxScale;

		[SerializeField]
		public float startDelay;

		[Tooltip("Spawns on hitbox start")]
		[Header("Cast Vfx")]
		[SerializeField]
		public GameObject VFXCastPrefab;

		[SerializeField]
		public float VFXCastDestroyDelay;

		[Header("Follow Vfx")]
		[Tooltip("Spawns on hitbox start and follows the hitbox as a child.")]
		[SerializeField]
		public GameObject VFXFollowPrefab;

		[SerializeField]
		public float VFXFollowDestroyDelay;

		[Tooltip("Use a different parent for follow vfx. Default parent is root")]
		[SerializeField]
		public Transform customFollowParent;

		[Header("Destroy Vfx")]
		[Tooltip("Spawns on hitbox destroy")]
		[SerializeField]
		public GameObject VFXDestroyPrefab;

		[SerializeField]
		public float VFXDestroyDelayDestroy;

		[Header("Impact Vfx")]
		[Tooltip("Spawns when impacting an enemy or collision")]
		[SerializeField]
		public GameObject VFXImpactPrefab;

		[SerializeField]
		public float VFXImpactDestroyDelay;

		[NonSerialized]
		public bool playOnStart;

		[NonSerialized]
		public GameObject vfxFollowObject;

		[NonSerialized]
		public Transform followParent;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void DoStart()
		{
		}

		public void Spawn()
		{
		}

		[IteratorStateMachine(typeof(_003CSpawnDelayed_003Ed__19))]
		public IEnumerator SpawnDelayed(float delay)
		{
			return null;
		}

		public void DoDestroy(bool doDestroyVFX, Vector3 destroyPos)
		{
		}

		public void SpawnImpactVFX(Vector3 impactPosition)
		{
		}

		public void SpawnVFX(GameObject vfxPrefab, Vector3 pos, float delayDestroy = 1f, bool setParent = false)
		{
		}

		public void SpawnVFXFollow(GameObject vfxPrefab)
		{
		}

		public void TrySpawnVFXFollow()
		{
		}

		public void DestroyVFXFollow()
		{
		}
	}
}
