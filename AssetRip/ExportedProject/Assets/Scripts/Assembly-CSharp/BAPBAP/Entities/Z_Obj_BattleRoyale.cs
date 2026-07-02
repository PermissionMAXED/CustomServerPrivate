using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class Z_Obj_BattleRoyale : Z_Obj
	{
		[Serializable]
		public class Config : Z_ObjConfiguration
		{
			[Header("Custom Config")]
			public GameObject zone;

			public int startZoneRadius;

			public ZoneRound[] zoneRounds;

			[Header("Custom Loot Config")]
			public GameObject box;

			public int boxAmount;

			public GameObject npc;

			public int npcAmount;

			public int cellSize;
		}

		[CompilerGenerated]
		public sealed class _003CWaitToCloseZone_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public Z_Obj_BattleRoyale _003C_003E4__this;

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
			public _003CWaitToCloseZone_003Ed__21(int _003C_003E1__state)
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

		[CompilerGenerated]
		public sealed class _003CWaitToStartNotification_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public Z_Obj_BattleRoyale _003C_003E4__this;

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
			public _003CWaitToStartNotification_003Ed__19(int _003C_003E1__state)
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
		public float waitToStart;

		[NonSerialized]
		public float objectiveSeconds;

		[NonSerialized]
		public BattleRoyaleZone zone;

		[NonSerialized]
		public List<GameObject> objects;

		[NonSerialized]
		public List<Vector3> spawnPoints;

		[NonSerialized]
		public float cellSizeSqrd;

		[NonSerialized]
		public Vector3 closePoint;

		[NonSerialized]
		public int currentIndex;

		public override Z_ObjConfiguration dObjConfig => null;

		public Z_Obj_BattleRoyale(Config config)
		{
		}

		public void SpawnObjects()
		{
		}

		public void TrySpawnObject(GameObject g)
		{
		}

		public Vector3 RandomPositionWithinRadius()
		{
			return default(Vector3);
		}

		public bool IsPositionValid(Vector3 position)
		{
			return false;
		}

		public override void RoundStart()
		{
		}

		public void SpawnZone()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitToStartNotification_003Ed__19))]
		public IEnumerator WaitToStartNotification()
		{
			return null;
		}

		public void SpawnBRZone()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitToCloseZone_003Ed__21))]
		public IEnumerator WaitToCloseZone()
		{
			return null;
		}

		public override void SvTick(float fixedDt)
		{
		}
	}
}
