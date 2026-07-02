using System;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Localisation;
using BAPBAP.Player;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class UpgradeStation : InteractableStation
	{
		[Serializable]
		public class UpgradeSlotMachine
		{
			[Header("References")]
			public Transform uiWindowPivot;

			public Transform speechBubblePivot;

			public Animator animator;

			public AudioSource voiceAudioSource;

			public AudioSource musicAudioSource;

			public Collider collider;

			[Header("Translation Keys")]
			public string completeState;

			public string failState;

			public string progressState;

			public string animHitState;

			[Header("Speech Bubbles Translation Keys")]
			public string[] speechFailTrKey;

			public string[] speechUpgradingTrKey;

			public string[] speechFinishedUpgradeTrKey;

			public string[] speechAttackedTrKey;

			[NonSerialized]
			public string[] speechFailStr;

			[NonSerialized]
			public string[] speechUpgradingStr;

			[NonSerialized]
			public string[] speechFinishedUpgradeStr;

			[NonSerialized]
			public string[] speechAttackedStr;

			[NonSerialized]
			public float hitCdTime;
		}

		[NonSerialized]
		public ItemManager itemManager;

		[NonSerialized]
		public ItemCurrencyManager itemCurrencyManager;

		[Header("View References")]
		[SerializeField]
		public GameObject npcRootGameObject;

		[SerializeField]
		public SimpleTargetDetectionCl targetDetectionCl;

		[SerializeField]
		public LookAtTargetConstraint followLookAtTarget;

		[SerializeField]
		public TextMesh worldTextMesh;

		[SerializeField]
		public GameObject pingColliderObj;

		[SerializeField]
		public UpgradeSlotMachine[] machineSlots;

		[SerializeField]
		[Header("Settings")]
		public float hitCdDuration;

		[SerializeField]
		public float priceReductionPerDeadAlly;

		[SerializeField]
		public float extraPriceReduction;

		[SerializeField]
		[Header("Prefab References")]
		public GameObject despawnVfxPrefab;

		[Header("Translation Keys")]
		[SerializeField]
		public string upgradingTrKey;

		[SerializeField]
		public string upgradeTrKey;

		[SerializeField]
		public string noItemsTrKey;

		[SerializeField]
		public string itemMaxTierTrKey;

		[NonSerialized]
		public string upgradingStr;

		[NonSerialized]
		public string upgradeStr;

		[NonSerialized]
		public string noItemsStr;

		[NonSerialized]
		public string itemMaxTierStr;

		public override void Start()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void Update()
		{
		}

		public override void ClOnEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public int GetModifiedPrice(int price, PlayerManager playerManager)
		{
			return 0;
		}

		public override void ClOnExit(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void UIShowFinishedWindow(InteractableCollider slot)
		{
		}

		public void UIShowMaxTierWindow(InteractableCollider slot, int currentItemId)
		{
		}

		public void UIShowInvalidWindow(InteractableCollider slot, Item currentItem, int upgradePrice)
		{
		}

		public void UIShowValidWindow(InteractableCollider slot, Item currentItem, int upgradePrice)
		{
		}

		public override void OnCastingCompleted(EntityManager entity, int slotId)
		{
		}

		public override void ClOnForceUpdate(EntityManager entity, InteractableCollider slot)
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

		public void SvOnHit(Vector3 hitDir, int dmg, StatusEffectInfo[] statusEffects, int playerId, int teamId, Collider collider)
		{
		}

		[ClientRpc]
		public void RpcOnHit(int machineId)
		{
		}

		[ClientRpc]
		public override void RpcOnUseSuccess(EntityManager entity, int slotId)
		{
		}

		[ClientRpc]
		public override void RpcOnUseFail(EntityManager entity, int slotId)
		{
		}

		[ClientRpc]
		public override void RpcOnUseCastingStart(EntityManager entity, int slotId)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcOnHit__Int32(int machineId)
		{
		}

		public static void InvokeUserCode_RpcOnHit__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public override void UserCode_RpcOnUseSuccess__EntityManager__Int32(EntityManager entity, int slotId)
		{
		}

		public new static void InvokeUserCode_RpcOnUseSuccess__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public override void UserCode_RpcOnUseFail__EntityManager__Int32(EntityManager entity, int slotId)
		{
		}

		public new static void InvokeUserCode_RpcOnUseFail__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public override void UserCode_RpcOnUseCastingStart__EntityManager__Int32(EntityManager entity, int slotId)
		{
		}

		public new static void InvokeUserCode_RpcOnUseCastingStart__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static UpgradeStation()
		{
		}
	}
}
