using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Maps;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntitySerializedHitbox : NetworkBehaviour, IEntityDataProperty
	{
		[CompilerGenerated]
		public sealed class _003CRePosition_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public EntitySerializedHitbox _003C_003E4__this;

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
			public _003CRePosition_003Ed__12(int _003C_003E1__state)
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
		public Hitbox hitbox;

		[Header("Hitbox")]
		[SerializeField]
		public bool doReEnterFix;

		[SerializeField]
		public int dmg;

		[SerializeField]
		public float percentDmg;

		[SerializeField]
		public float radius;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[SerializeField]
		public bool doTtl;

		[Min(0f)]
		[SerializeField]
		public float ttl;

		[SerializeField]
		[Min(0f)]
		public float colEnableTime;

		[ExHeader("\ud83d\udee0 [PROPERTIES] \ud83d\udee0", 0f, 1f, 1f)]
		[SerializeField]
		[Min(0f)]
		public float scale;

		public void Start()
		{
		}

		public void InitializeHitbox()
		{
		}

		[IteratorStateMachine(typeof(_003CRePosition_003Ed__12))]
		public IEnumerator RePosition()
		{
			return null;
		}

		public virtual string PropertyName()
		{
			return null;
		}

		public MapEntityData.Property.Field[] GetPropertyFields()
		{
			return null;
		}

		public void CopyProperties(IEntityDataProperty _source)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
