using System;
using BAPBAP.Content;
using BAPBAP.Local;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class CharEmotes : NetworkBehaviour
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public AudioManager audioManager;

		[NonSerialized]
		public LocalSavedData localSavedData;

		[NonSerialized]
		public EmoteManager emoteManager;

		[NonSerialized]
		public UISelectionWheel emoteSelectionWheel;

		[NonSerialized]
		public UIGameMode uiGameMode;

		[NonSerialized]
		public UIChat uiChat;

		[SerializeField]
		public float stickerWorldHeight;

		[NonSerialized]
		public float spamTimer;

		[NonSerialized]
		public bool isSpamCooldown;

		[NonSerialized]
		public float cooldownTimer;

		[NonSerialized]
		public Emote currentPlayingEmote;

		[NonSerialized]
		public UIEmoteStickerElement spawnedStickerEmote;

		[NonSerialized]
		public float spawnedEmoteTimer;

		[NonSerialized]
		public bool isPlayingAnim;

		[NonSerialized]
		public GameObject currentAnimFxObj;

		[NonSerialized]
		public GameObject currentVoicelineSfxObj;

		[NonSerialized]
		public AudioSource charAudioSource;

		[NonSerialized]
		public bool _isOwned;

		public void PreAwake(EntityManager e)
		{
		}

		public void Start()
		{
		}

		public void Update()
		{
		}

		public void DoWheelEmote(int optionId)
		{
		}

		public void TryCreateEmote(int emoteAssetId)
		{
		}

		public void ClCreateEmote(uint attachedNetId, int emoteAssetId)
		{
		}

		public void CreateLocalPlayerEmote(uint attachedNetId, int emoteAssetId)
		{
		}

		[Command]
		public void CmdCreateEmote(uint attachedNetId, int emoteAssetId)
		{
		}

		[ClientRpc(includeOwner = false)]
		public void RpcCreateEmote(uint attachedNetId, int emoteAssetId)
		{
		}

		public void SvExternalCreateEmote(int emoteAssetId)
		{
		}

		public bool TryGetTargetAttachedObj(uint attachedNetId, out Transform attachedTransform)
		{
			attachedTransform = null;
			return false;
		}

		public float GetEmoteTypeDuration(int emoteAssetId)
		{
			return 0f;
		}

		public bool GetIsPlayerOnCooldown()
		{
			return false;
		}

		public void OnEmoteAddCooldown(float cooldown)
		{
		}

		public void OnSpamEmoteAdded()
		{
		}

		public void OnDestroy()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_CmdCreateEmote__UInt32__Int32(uint attachedNetId, int emoteAssetId)
		{
		}

		public static void InvokeUserCode_CmdCreateEmote__UInt32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcCreateEmote__UInt32__Int32(uint attachedNetId, int emoteAssetId)
		{
		}

		public static void InvokeUserCode_RpcCreateEmote__UInt32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static CharEmotes()
		{
		}
	}
}
