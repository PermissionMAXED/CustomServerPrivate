using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Game;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Localisation;
using Mirror;
using UnityEngine;
using UnityEngine.AI;

namespace BAPBAP.Entities
{
	public class PayGate : InteractableStation
	{
		[CompilerGenerated]
		public sealed class _003CDoDurationAndCooldown_003Ed__49 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public PayGate _003C_003E4__this;

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
			public _003CDoDurationAndCooldown_003Ed__49(int _003C_003E1__state)
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

		[Header("References")]
		[SerializeField]
		public Transform windowTransform;

		[SerializeField]
		public int price;

		[SerializeField]
		public Item keyItem;

		[SerializeField]
		public FogOfWarOcclusionMeshBuilder fowBuilder;

		[SerializeField]
		public bool animationBased;

		[SerializeField]
		public GameObject gate;

		[SerializeField]
		public float openGateYAmount;

		[SerializeField]
		public Animator gateAnimator;

		[SerializeField]
		public string openGateString;

		[SerializeField]
		public string closeGateString;

		[SerializeField]
		public string isOpenString;

		[SerializeField]
		public string isClosedString;

		[SerializeField]
		public float crossFadeDuration;

		[SerializeField]
		public Collider[] gateColliders;

		[SerializeField]
		public float duration;

		[SerializeField]
		public float cooldown;

		[Header("Configs")]
		[SerializeField]
		public string purchaseString;

		[SerializeField]
		public string purchaseForString;

		[SerializeField]
		public string keyCostString;

		[SerializeField]
		public string keyUnlockString;

		[NonSerialized]
		public string purchasingStr;

		[NonSerialized]
		public string purchaseForStr;

		[NonSerialized]
		public string keyCostStr;

		[NonSerialized]
		public string keyUnlockStr;

		[SyncVar(hook = "UsedChanged")]
		[NonSerialized]
		public bool used;

		[SyncVar(hook = "OpenChanged")]
		[NonSerialized]
		public bool open;

		[SyncVar(hook = "DurationTimeChanged")]
		[NonSerialized]
		public float durationTime;

		[SyncVar(hook = "CooldownTimeChanged")]
		[NonSerialized]
		public float cooldownTime;

		[NonSerialized]
		public int openGateHash;

		[NonSerialized]
		public int closeGateHash;

		[NonSerialized]
		public int isOpenHash;

		[NonSerialized]
		public int isCloseHash;

		[NonSerialized]
		public NavMeshObstacle navMeshObstacle;

		[NonSerialized]
		public ColliderExpand colliderExpand;

		[NonSerialized]
		public Vector3 gateOpenPosition;

		[NonSerialized]
		public Vector3 gateClosePosition;

		[NonSerialized]
		public GameManager gameManager;

		[NonSerialized]
		public GameObject fowObj;

		[NonSerialized]
		public bool playAnim;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_used;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_open;

		public Action<float, float> _Mirror_SyncVarHookDelegate_durationTime;

		public Action<float, float> _Mirror_SyncVarHookDelegate_cooldownTime;

		public bool Networkused
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public bool Networkopen
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public float NetworkdurationTime
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		public float NetworkcooldownTime
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		public override void OnStartClient()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public override void ClOnEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void UIShowFinishedWindow(InteractableCollider slot)
		{
		}

		public override void UIShowInvalidWindow(InteractableCollider slot)
		{
		}

		public override void UIShowValidWindow(InteractableCollider slot)
		{
		}

		public override bool TryUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public override bool AbleToUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CDoDurationAndCooldown_003Ed__49))]
		public IEnumerator DoDurationAndCooldown()
		{
			return null;
		}

		[ClientRpc]
		public override void RpcOnUseSuccess(EntityManager entity, int slotId)
		{
		}

		[ClientRpc]
		public void RpcRefreshUI()
		{
		}

		public void UsedChanged(bool oldValue, bool newValue)
		{
		}

		public void OpenChanged(bool oldValue, bool newValue)
		{
		}

		public void DurationTimeChanged(float oldValue, float newValue)
		{
		}

		public void CooldownTimeChanged(float oldValue, float newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public override void UserCode_RpcOnUseSuccess__EntityManager__Int32(EntityManager entity, int slotId)
		{
		}

		public new static void InvokeUserCode_RpcOnUseSuccess__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcRefreshUI()
		{
		}

		public static void InvokeUserCode_RpcRefreshUI(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static PayGate()
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
