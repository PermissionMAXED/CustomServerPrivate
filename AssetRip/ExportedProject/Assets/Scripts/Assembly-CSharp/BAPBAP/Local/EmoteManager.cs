using System;
using BAPBAP.Content;
using BAPBAP.UI;
using UnityEngine;

namespace BAPBAP.Local
{
	public class EmoteManager : MonoBehaviour
	{
		[NonSerialized]
		public LocalSavedData localSavedData;

		[NonSerialized]
		public UISelectionWheelEmotes emoteSelectionWheel;

		[SerializeField]
		[Header("References")]
		public EmoteData emoteData;

		[SerializeField]
		public AudioSource charEmoteSfxPrefab;

		[SerializeField]
		public GameObject defaultEmotePrefab;

		[Tooltip("Including wheel options and center option")]
		[Header("Settings")]
		public int selectableEmoteCount;

		public int[] defaultSelectedEmotes;

		public float stickerEmoteDuration;

		[Header("Cooldown")]
		public float stickerEmoteCooldown;

		public float masteryBadgeEmoteCooldown;

		[Header("Spam cooldown")]
		public float spamToStartCooldown;

		public float spamCooldownDuration;

		[Header("SFX")]
		public float emoteCreateVolume;

		public float masteryBadgeCreateVolume;

		public AudioManager.SFX spamSfxId;

		public float spamSfxVolume;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void LoadEmoteWheelOptions()
		{
		}

		public UISelectionWheel.OptionData[] GetEmoteWheelOptions()
		{
			return null;
		}

		public UISelectionWheel.OptionData GetOptionDataFromEmote(Emote emote)
		{
			return null;
		}

		public void LoadEmoteWheelOptions(UISelectionWheel.OptionData[] optionsData)
		{
		}

		public void LoadEmoteWheelOption(int optionId, UISelectionWheel.OptionData optionData)
		{
		}

		public Emote GetEmoteByAssetId(int emoteAssetId)
		{
			return null;
		}

		public Sprite GetEmoteIcon(Emote emote)
		{
			return null;
		}
	}
}
