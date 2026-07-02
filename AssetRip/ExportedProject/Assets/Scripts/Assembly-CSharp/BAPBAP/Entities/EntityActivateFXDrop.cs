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
	public class EntityActivateFXDrop : NetworkBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CClDropCoroutine_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public EntityActivateFXDrop _003C_003E4__this;

			[NonSerialized]
			public Vector3 _003CstartingPos_003E5__2;

			[NonSerialized]
			public Vector3 _003CendingPos_003E5__3;

			[NonSerialized]
			public float _003Ct_003E5__4;

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
			public _003CClDropCoroutine_003Ed__23(int _003C_003E1__state)
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
		public sealed class _003CSvDropCoroutine_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public EntityActivateFXDrop _003C_003E4__this;

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
			public _003CSvDropCoroutine_003Ed__20(int _003C_003E1__state)
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
		public EntityBehaviour entityBehaviour;

		[NonSerialized]
		public CharTriggerbox charTriggerbox;

		[NonSerialized]
		public NetworkTransform networkTransform;

		[Min(0f)]
		[SerializeField]
		[Header("Settings")]
		public float dropDuration;

		[Tooltip("If enabled, apply consumable coloring to the drop vfx capsule.")]
		[SerializeField]
		public bool isConsumable;

		[Tooltip("If enabled, the entity will apply triggerlocks at the start of the drop animation, and reset them when finished.")]
		[SerializeField]
		public bool triggerLockedWhileDropping;

		[Header("Anim Configs")]
		[SerializeField]
		public bool useAnimation;

		[SerializeField]
		[ConditionalHide("useAnimation", true)]
		public Animation dropAnimation;

		[ConditionalInverseHide("useAnimation", true)]
		[SerializeField]
		public Transform animTransform;

		[SerializeField]
		[ConditionalInverseHide("useAnimation", true)]
		public float animHeight;

		[ConditionalInverseHide("useAnimation", true)]
		[SerializeField]
		public AnimationCurve dropCurve;

		[Header("FX References")]
		[SerializeField]
		public AudioClipData dropAudioData;

		[Tooltip("Any custom drop vfx to provide on the object. If null, will default to instantiating the DropVfxPrefab object.")]
		[SerializeField]
		public ParticleSystem customDropVfx;

		[SerializeField]
		[Header("Prefabs")]
		public GameObject dropVfxPrefab;

		[NonSerialized]
		public MaterialPropertyBlock propBlock;

		public MaterialPropertyBlock PropBlock => null;

		public void Awake()
		{
		}

		public void InitializeDrop(float duration = 0f, int tierColorId = -1)
		{
		}

		public void SetBehaviourEnabled(bool isEnabled)
		{
		}

		[IteratorStateMachine(typeof(_003CSvDropCoroutine_003Ed__20))]
		public IEnumerator SvDropCoroutine()
		{
			return null;
		}

		[ClientRpc]
		public void RpcOnDropStart(int tierColorId)
		{
		}

		public void ClActivateDrop(int tierColorId)
		{
		}

		[IteratorStateMachine(typeof(_003CClDropCoroutine_003Ed__23))]
		public IEnumerator ClDropCoroutine()
		{
			return null;
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcOnDropStart__Int32(int tierColorId)
		{
		}

		public static void InvokeUserCode_RpcOnDropStart__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static EntityActivateFXDrop()
		{
		}
	}
}
