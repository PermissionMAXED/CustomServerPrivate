using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class Z_Obj_Territory : Z_Obj
	{
		[Serializable]
		public class Config : Z_ObjConfiguration
		{
			[Header("Custom Config")]
			public GameObject territory;

			public float territoryRatio;

			public float spawnWaitTime;

			public float objectiveSeconds;

			[Header("Custom Loot Config")]
			public GameObject box;

			public int boxAmount;

			public GameObject npc;

			public int npcAmount;

			public int cellSize;
		}

		[CompilerGenerated]
		public sealed class _003CWaitToEndNotification_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public Z_Obj_Territory _003C_003E4__this;

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
			public _003CWaitToEndNotification_003Ed__19(int _003C_003E1__state)
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
		public sealed class _003CWaitToSpawn_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public Z_Obj_Territory _003C_003E4__this;

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
			public _003CWaitToSpawn_003Ed__15(int _003C_003E1__state)
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
		public sealed class _003CWaitToStartNotification_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public Z_Obj_Territory _003C_003E4__this;

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
			public _003CWaitToStartNotification_003Ed__18(int _003C_003E1__state)
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
		public List<TerritoryZone> territories;

		[NonSerialized]
		public List<GameObject> objects;

		[NonSerialized]
		public List<Vector3> spawnPoints;

		[NonSerialized]
		public List<Vector3> objectivePositions;

		[NonSerialized]
		public float cellSizeSqrd;

		public override Z_ObjConfiguration dObjConfig => null;

		public Z_Obj_Territory(Config config)
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

		[IteratorStateMachine(typeof(_003CWaitToSpawn_003Ed__15))]
		public IEnumerator WaitToSpawn()
		{
			return null;
		}

		public void SpawnTerritories()
		{
		}

		public void AddObjective(int index)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitToStartNotification_003Ed__18))]
		public IEnumerator WaitToStartNotification()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWaitToEndNotification_003Ed__19))]
		public IEnumerator WaitToEndNotification()
		{
			return null;
		}

		public override void SvTick(float fixedDt)
		{
		}

		public override void EndObjective()
		{
		}
	}
}
