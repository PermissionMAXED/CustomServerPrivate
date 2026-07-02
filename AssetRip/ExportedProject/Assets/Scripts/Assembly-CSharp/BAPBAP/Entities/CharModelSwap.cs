using System;
using System.Text;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class CharModelSwap : NetworkBehaviour, INetworkPredicted
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharAbilities charAbilities;

		[NonSerialized]
		public CharMaterial charMaterial;

		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public ItemManager itemManager;

		[Header("References")]
		[SerializeField]
		public GameObject modelSwapHolder;

		[SerializeField]
		public Transform modelSwapContainer;

		[SerializeField]
		public ItemObjectVisualizer itemObjectVisualizer;

		[SerializeField]
		public Transform vfxHolder;

		[Header("Configs")]
		[SerializeField]
		public float slowAmount;

		[Header("Prefabs")]
		[SerializeField]
		public GameObject transformFxPrefab;

		[NonSerialized]
		public GameObject itemThemeVfx;

		[NonSerialized]
		public GameObject currentModel;

		[NonSerialized]
		public TransformScaleAnimation modelStartAnim;

		[NonSerialized]
		public Animator modelAnimator;

		[NonSerialized]
		public int isMovingParamHash;

		[NonSerialized]
		public float modelSwappedVisibleTimer;

		[NonSerialized]
		public float visibleRotationDeltaThreshold;

		[NonSerialized]
		public float modelSwappedVisibleDuration;

		[NonSerialized]
		public float modelSwappedInitialVisibleDuration;

		[NonSerialized]
		public Animator currentAnimator;

		[NonSerialized]
		public short currentModelSwapId;

		public bool ModelSwapped => false;

		public void PreAwake(EntityManager e)
		{
		}

		public override void OnStartClient()
		{
		}

		public override void OnStopClient()
		{
		}

		public void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void Update()
		{
		}

		[ServerCallback]
		public void ActivateSwap(int modelSwapId)
		{
		}

		[ServerCallback]
		public void DeactivateSwap()
		{
		}

		[ClientRpc]
		public void RpcOnModelSwap()
		{
		}

		public void ClSetModelSwapState(bool isSwapped)
		{
		}

		public void ClApplySwapModel(int modelSwapId)
		{
		}

		public void ClPlayTransformFx()
		{
		}

		public void OnModelSwappedChanged()
		{
		}

		public void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public bool OnNetDebugCompare(NetworkReader netReader)
		{
			return false;
		}

		public void OnNetDebugLog(StringBuilder sb)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcOnModelSwap()
		{
		}

		public static void InvokeUserCode_RpcOnModelSwap(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static CharModelSwap()
		{
		}
	}
}
