using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Entities.View;
using BAPBAP.Items;
using BAPBAP.Local;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class PowerCore : NetworkBehaviour
	{
		[Serializable]
		public class PowerCoreBuff
		{
			public BAPBAP.Items.Stats stat;

			public PassiveSO passive;

			public float value;

			public string buffString;

			public Color buffColor;
		}

		[Serializable]
		public class BreakThresholdInfo
		{
			public float healthPercentThreshold;

			public float spinSeed;

			public BreakThresholdInfo(float healthPercentThreshold, float spinSeed)
			{
			}
		}

		[Serializable]
		public class PowerCorePart
		{
			public GameObject obj;

			public Renderer renderer;

			public ParticleSystem destroyParticle;

			public bool canSpin;

			public bool spinAllAxes;

			public Coroutine activeRoutine;

			public RendererVisibilityEvents visibilityEvents;

			[NonSerialized]
			public bool isDestroying;

			[NonSerialized]
			public bool isDestroyed;

			[NonSerialized]
			public bool isSpinning;

			[NonSerialized]
			public Vector3 initialPosition;

			[NonSerialized]
			public Quaternion initialRotation;

			[NonSerialized]
			public MaterialPropertyBlock propBlock;

			public MaterialPropertyBlock PropBlock => null;

			public bool CanSpin()
			{
				return false;
			}

			public bool CanDestroy()
			{
				return false;
			}

			public void Initialize(Color color)
			{
			}

			public void ResetPosRot()
			{
			}

			public void DestroyPart()
			{
			}
		}

		[CompilerGenerated]
		public sealed class _003CPartDestroyCoroutine_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public PowerCorePart part;

			public PowerCore _003C_003E4__this;

			[NonSerialized]
			public float _003CdestroyTime_003E5__2;

			[NonSerialized]
			public Vector3 _003CstartScale_003E5__3;

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
			public _003CPartDestroyCoroutine_003Ed__36(int _003C_003E1__state)
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
		public sealed class _003CPartSpinCoroutine_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public PowerCorePart part;

			public PowerCore _003C_003E4__this;

			[NonSerialized]
			public Vector3 _003CstartlocalPosition_003E5__2;

			[NonSerialized]
			public Vector3 _003CtargetLocalPos_003E5__3;

			[NonSerialized]
			public Quaternion _003CinitialRotation_003E5__4;

			[NonSerialized]
			public Quaternion _003CtargetRotation_003E5__5;

			[NonSerialized]
			public float _003CspinTime_003E5__6;

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
			public _003CPartSpinCoroutine_003Ed__37(int _003C_003E1__state)
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
		public CharHidden charHidden;

		[NonSerialized]
		public CharMaterial charMaterial;

		[SerializeField]
		[Header("Buff Settings")]
		public PowerCoreBuff[] availableBuffs;

		[SerializeField]
		[Header("References")]
		public string coreName;

		[SerializeField]
		public string coreKillWord;

		[SerializeField]
		public ParticleSystem[] lightningParticleSystems;

		[SerializeField]
		public PowerCorePart[] coreParts;

		[SerializeField]
		public float destroyLength;

		[SerializeField]
		public AnimationCurve destroyCurve;

		[SerializeField]
		public float spinLength;

		[SerializeField]
		public float spinMoveDistance;

		[SerializeField]
		public AnimationCurve spinCurve;

		[SerializeField]
		public RotateTransformX rotator;

		[NonSerialized]
		public readonly WaitForEndOfFrame wait;

		[SyncVar(hook = "OnActiveBuffChanged")]
		[NonSerialized]
		public int activeBuff;

		[SyncVar(hook = "OnCurrentThresholdChanged")]
		[NonSerialized]
		public int currentThreshold;

		[NonSerialized]
		public string buffString;

		[NonSerialized]
		public float healthPercentage;

		[NonSerialized]
		public List<int> spinnableParts;

		[SerializeField]
		public BreakThresholdInfo[] breakInfos;

		[NonSerialized]
		public int teamSize;

		public Action<int, int> _Mirror_SyncVarHookDelegate_activeBuff;

		public Action<int, int> _Mirror_SyncVarHookDelegate_currentThreshold;

		public int NetworkactiveBuff
		{
			get
			{
				return 0;
			}
			[param: In]
			set
			{
			}
		}

		public int NetworkcurrentThreshold
		{
			get
			{
				return 0;
			}
			[param: In]
			set
			{
			}
		}

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public override void OnStartClient()
		{
		}

		public void ApplyBuff(EntityManager applyTo, int aliveMembersOfTeam, bool doText = true)
		{
		}

		public void HitTrigger(Vector3 hitDirection, int dmg, StatusEffectInfo[] statusEffects, int playerId, int teamId, Collider collider)
		{
		}

		public void KillTrigger(EntityManager killer)
		{
		}

		public void OnActiveBuffChanged(int oldValue, int newValue)
		{
		}

		public void OnCurrentThresholdChanged(int oldVal, int newVal)
		{
		}

		[ClientRpc]
		public void RpcOnCoreDestroy()
		{
		}

		[ClientRpc]
		public void RpcOnStartSpin()
		{
		}

		public void ClOnCoreDestroy()
		{
		}

		[IteratorStateMachine(typeof(_003CPartDestroyCoroutine_003Ed__36))]
		public IEnumerator PartDestroyCoroutine(PowerCorePart part)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPartSpinCoroutine_003Ed__37))]
		public IEnumerator PartSpinCoroutine(PowerCorePart part)
		{
			return null;
		}

		public void OnVisibilityChanged(PowerCorePart part, bool visibility)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcOnCoreDestroy()
		{
		}

		public static void InvokeUserCode_RpcOnCoreDestroy(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnStartSpin()
		{
		}

		public static void InvokeUserCode_RpcOnStartSpin(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static PowerCore()
		{
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
