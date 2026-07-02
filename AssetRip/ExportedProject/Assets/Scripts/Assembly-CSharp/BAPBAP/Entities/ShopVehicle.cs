using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Localisation;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class ShopVehicle : InteractableStation
	{
		[CompilerGenerated]
		public sealed class _003CRecoverRoutine_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public ShopVehicle _003C_003E4__this;

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
			public _003CRecoverRoutine_003Ed__19(int _003C_003E1__state)
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

		[Header("Properties")]
		[SerializeField]
		public int price;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public string purchaseForTrKey;

		[Header("References")]
		[SerializeField]
		public Transform windowTransform;

		[SerializeField]
		public Transform vehicleSpawnPos;

		[SerializeField]
		public GameObject[] vehicles;

		[SerializeField]
		public GameObject vehicleSpawnFx;

		[NonSerialized]
		public string purchasingStr;

		[NonSerialized]
		public string purchaseForStr;

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public override void UIShowInvalidWindow(InteractableCollider slot)
		{
		}

		public override void UIShowFinishedWindow(InteractableCollider slot)
		{
		}

		public override void UIShowValidWindow(InteractableCollider slot)
		{
		}

		public override void ClOnForceUpdate(EntityManager entity, InteractableCollider slot)
		{
		}

		public override bool TryUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public void PurchaseVehicle(EntityManager entity)
		{
		}

		public override bool AbleToUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CRecoverRoutine_003Ed__19))]
		public IEnumerator RecoverRoutine()
		{
			return null;
		}

		[ClientRpc]
		public void RpcPlayFX()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcPlayFX()
		{
		}

		public static void InvokeUserCode_RpcPlayFX(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static ShopVehicle()
		{
		}
	}
}
