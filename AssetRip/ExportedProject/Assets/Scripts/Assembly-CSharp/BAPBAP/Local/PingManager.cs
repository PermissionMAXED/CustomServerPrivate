using System;
using BAPBAP.Localisation;
using BAPBAP.Player;
using BAPBAP.UI;
using UnityEngine;

namespace BAPBAP.Local
{
	public class PingManager : MonoBehaviour
	{
		[Serializable]
		public class PingPositionConfig
		{
			public GameObject worldPrefab;

			public GameObject uiPrefab;

			public GameObject minimapPrefab;

			public string msgTranslationKey;

			public AudioManager.SFX sfxId;

			public Sprite icon;

			public Color iconColor;

			public string optionTranslationKey;
		}

		[Serializable]
		public class PingCharConfig
		{
			public GameObject worldPrefab;

			public GameObject uiPrefab;

			public GameObject minimapPrefab;

			public string translationKey;

			public Color color;

			public AudioManager.SFX sfxId;
		}

		[SerializeField]
		[Header("Ping Pos Configs")]
		public GameObject defaultPingPosWorldPrefab;

		[SerializeField]
		public GameObject defaultPingPosUiPrefab;

		[SerializeField]
		public GameObject defaultPingPosMinimapPrefab;

		[NamedArray(typeof(PlayerPing.PositionType), 0)]
		[SerializeField]
		public PingPositionConfig[] pingPosConfig;

		[SerializeField]
		[Header("Ping Entity Configs")]
		public GameObject defaultPingWorldPrefab;

		[SerializeField]
		public GameObject defaultPingUiPrefab;

		[SerializeField]
		public GameObject defaultPingMinimapPrefab;

		[Header("Ping Char Configs")]
		[SerializeField]
		public GameObject defaultPingCharWorldPrefab;

		[SerializeField]
		public GameObject defaultPingCharUiPrefab;

		[SerializeField]
		public GameObject defaultPingCharMinimapPrefab;

		[SerializeField]
		[NamedArray(typeof(PlayerPing.CharType), 0)]
		public PingCharConfig[] pingCharConfig;

		[Header("Other Ping Configs")]
		[SerializeField]
		public GameObject pingWorldItemPrefab;

		[SerializeField]
		public GameObject pingUIItemPrefab;

		[SerializeField]
		public GameObject pingMinimapItemPrefab;

		[SerializeField]
		public GameObject pingUIShopItemPrefab;

		[SerializeField]
		public GameObject pingMinimapShopItemPrefab;

		[SerializeField]
		[Header("Settings")]
		public float entityRayRadius;

		[SerializeField]
		public float pingPositionTtl;

		[SerializeField]
		public float pingItemTtl;

		[SerializeField]
		public float pingEntityTtl;

		[Header("Ping Max Amount Settings")]
		[SerializeField]
		[Min(1f)]
		public int maxCharacterPings;

		[SerializeField]
		[Min(1f)]
		public int maxInteractablePings;

		[SerializeField]
		[Min(1f)]
		public int maxItemPings;

		[SerializeField]
		[Min(1f)]
		public int maxPositionPings;

		[SerializeField]
		[Header("Spam/Cooldown Settings")]
		public float cooldownDuration;

		[SerializeField]
		public float pingSpamToStartCooldown;

		[Header("SFX")]
		[SerializeField]
		public float pingCreateVolume;

		[SerializeField]
		public float pingCancelVolume;

		[Header("Translation Keys")]
		[SerializeField]
		public string pingCooldownTranslationKey;

		[SerializeField]
		public string pingingTranslationKey;

		[SerializeField]
		public string pingingTypeItemTranslationKey;

		[SerializeField]
		public string abilityXHasYSecondsRemainingTranslationKey;

		[SerializeField]
		public string abilityXIsReadyTranslationKey;

		[NonSerialized]
		public string pingingStr;

		[NonSerialized]
		public string pingingTypeItemStr;

		[NonSerialized]
		public string stopSpammingStr;

		[NonSerialized]
		public string[] worldPingMsgStr;

		[NonSerialized]
		public string[] charTypeStr;

		[NonSerialized]
		public string abilityXHasYSecondsRemainingStr;

		[NonSerialized]
		public string abilityXIsReadyStr;

		[NonSerialized]
		public UISelectionWheel.OptionData[] pingWheelOptions;

		public void Awake()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public GameObject GetPingPosWorldPrefab(int pingPosTypeId)
		{
			return null;
		}

		public GameObject GetPingPosUIPrefab(int pingPosTypeId)
		{
			return null;
		}

		public GameObject GetPingPosMinimapPrefab(int pingPosTypeId)
		{
			return null;
		}

		public GameObject GetPingCharWorldPrefab(int pingCharTypeId)
		{
			return null;
		}

		public GameObject GetPingCharUIPrefab(int pingCharTypeId)
		{
			return null;
		}

		public GameObject GetPingCharMinimapPrefab(int pingCharTypeId)
		{
			return null;
		}
	}
}
