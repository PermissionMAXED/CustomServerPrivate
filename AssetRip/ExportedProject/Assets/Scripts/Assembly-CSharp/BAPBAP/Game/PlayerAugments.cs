using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Player;
using BAPBAP.UI;
using Mirror;

namespace BAPBAP.Game
{
	public class PlayerAugments : NetworkBehaviour
	{
		[NonSerialized]
		public PlayerManager playerManager;

		[NonSerialized]
		public UIAugments uiAugments;

		[NonSerialized]
		public AugmentManager augmentManager;

		[NonSerialized]
		public List<int> augments;

		[NonSerialized]
		public List<AugmentManager.SelectionData> selectionQueue;

		[NonSerialized]
		public AugmentManager.AugmentSelection currentSelection;

		[NonSerialized]
		public int maxRerolls;

		[NonSerialized]
		public int currentRerolls;

		[NonSerialized]
		public bool initialized;

		public int SelectionsCount => 0;

		public AugmentManager.AugmentSelection CurrentSelection => null;

		public void Awake()
		{
		}

		public void Initialize(PlayerManager _playerManager)
		{
		}

		public void SvEnableAugments()
		{
		}

		public void SvDisableAugments()
		{
		}

		public void NewRandAugmentSelection(AugmentManager.SelectionData.SelectionType type, int tierId)
		{
		}

		public void InitializeNextAugmentSelection()
		{
		}

		public void InitializeAugmentSelection(AugmentManager.SelectionData sq, int[] excludedIds = null)
		{
		}

		public AugmentManager.AugmentSelection CreateAugmentSelection(AugmentManager.SelectionData sq, int[] excludedIds = null)
		{
			return null;
		}

		public void ActivateAugment(int augmentId)
		{
		}

		public void ApplyAugmentsOnRevive()
		{
		}

		public void ClearCurrentSelection()
		{
		}

		[Command]
		public void CmdSelectAugment(int elementIndex)
		{
		}

		[Command]
		public void CmdUseReroll()
		{
		}

		[Command]
		public void CmdFFABuyLives()
		{
		}

		[Command]
		public void CmdFFABuyPassive()
		{
		}

		[Command]
		public void CmdFFABuyConsumable()
		{
		}

		public void ClDisableAugments()
		{
		}

		[TargetRpc]
		public void TargetRpcEnableAugments(NetworkConnection conn)
		{
		}

		[TargetRpc]
		public void TargetRpcDisableAugments(NetworkConnection conn)
		{
		}

		[TargetRpc]
		public void TargetRpcSyncAugmentsCount(NetworkConnection conn, AugmentManager.SelectionData.SelectionType type, int tierId)
		{
		}

		[TargetRpc]
		public void TargetRpcSyncAugmentsSelection(NetworkConnection conn, AugmentManager.SelectionData.SelectionType type, int tierId, int[] selectionIds)
		{
		}

		[TargetRpc]
		public void TargetRpcShowRerollButton(NetworkConnection conn, bool show)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_CmdSelectAugment__Int32(int elementIndex)
		{
		}

		public static void InvokeUserCode_CmdSelectAugment__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdUseReroll()
		{
		}

		public static void InvokeUserCode_CmdUseReroll(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdFFABuyLives()
		{
		}

		public static void InvokeUserCode_CmdFFABuyLives(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdFFABuyPassive()
		{
		}

		public static void InvokeUserCode_CmdFFABuyPassive(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdFFABuyConsumable()
		{
		}

		public static void InvokeUserCode_CmdFFABuyConsumable(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetRpcEnableAugments__NetworkConnection(NetworkConnection conn)
		{
		}

		public static void InvokeUserCode_TargetRpcEnableAugments__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetRpcDisableAugments__NetworkConnection(NetworkConnection conn)
		{
		}

		public static void InvokeUserCode_TargetRpcDisableAugments__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetRpcSyncAugmentsCount__NetworkConnection__SelectionType__Int32(NetworkConnection conn, AugmentManager.SelectionData.SelectionType type, int tierId)
		{
		}

		public static void InvokeUserCode_TargetRpcSyncAugmentsCount__NetworkConnection__SelectionType__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetRpcSyncAugmentsSelection__NetworkConnection__SelectionType__Int32__Int32_005B_005D(NetworkConnection conn, AugmentManager.SelectionData.SelectionType type, int tierId, int[] selectionIds)
		{
		}

		public static void InvokeUserCode_TargetRpcSyncAugmentsSelection__NetworkConnection__SelectionType__Int32__Int32_005B_005D(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetRpcShowRerollButton__NetworkConnection__Boolean(NetworkConnection conn, bool show)
		{
		}

		public static void InvokeUserCode_TargetRpcShowRerollButton__NetworkConnection__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static PlayerAugments()
		{
		}
	}
}
