using System;
using BAPBAP.Local;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyInfographicPage : UILobbyTabPage
	{
		[Serializable]
		public class InfographicPanel
		{
			public UIAlphaFade alphaFade;

			public UIPosLerpFade posLerpFade;

			public UIAlphaFade areaAlphaFade;

			public UIPosLerpFade areaPosLerpFade;

			public virtual void Build()
			{
			}

			public virtual void TryUpdateKeyBinds(InputBinding input)
			{
			}

			public virtual void Localise(Translator translator)
			{
			}

			public virtual void OpenPanel(bool instant = false, bool directionRight = true)
			{
			}

			public virtual void ClosePanel()
			{
			}
		}

		[Serializable]
		public class InfographicPanelZone : InfographicPanel
		{
			[Serializable]
			public class Configuration
			{
				public string headerTranslationKey;

				public string descriptionTranslationKey;
			}

			[NonSerialized]
			public Configuration config;

			public TMP_Text headerText;

			public TMP_Text descriptionText;

			public override void Localise(Translator translator)
			{
			}
		}

		[Serializable]
		public class InfographicPanelItems : InfographicPanel
		{
			[Serializable]
			public class Configuration
			{
				public string headerTranslationKey;

				public float itemElementOpenStartDelay;

				public float itemElementOpenDelay;

				public string tipTranslationKey;
			}

			[Serializable]
			public class ItemDisplay
			{
				public UIAlphaFadeTimed uiAlphaFadeTimed;

				public Image bgImage;

				public Image[] rarityStarImages;

				public TMP_Text rarityText;
			}

			[NonSerialized]
			public Configuration config;

			public ItemDisplay[] itemDisplays;

			public TMP_Text headerText;

			public TMP_Text tipText;

			public override void Build()
			{
			}

			public override void OpenPanel(bool instant = false, bool directionRight = true)
			{
			}

			public override void Localise(Translator translator)
			{
			}
		}

		[Serializable]
		public class InfographicPanelControls : InfographicPanel
		{
			[Serializable]
			public class Configuration
			{
				public string headerTranslationKey;

				public string tipTranslationKey;

				public string moveTranslationKey;

				public InputTarget moveUpInputTarget;

				public InputTarget moveLeftInputTarget;

				public InputTarget moveDownInputTarget;

				public InputTarget moveRightInputTarget;

				public string attackTranslationKey;

				public InputTarget attackInputTarget;

				public string emoteTranslationKey;

				public InputTarget emoteInputTarget;

				public float controlsOpenStartDelay;

				public float controlsOpenDelay;
			}

			[Serializable]
			public class MultiControlDisplay
			{
				public UIAlphaFadeTimed alphaFadeTimed;

				public TMP_Text nameText;

				public TMP_Text[] keyText;
			}

			[Serializable]
			public class ControlDisplay
			{
				public UIAlphaFadeTimed alphaFadeTimed;

				public TMP_Text nameText;

				public TMP_Text keyText;
			}

			[NonSerialized]
			public Configuration config;

			public MultiControlDisplay moveControlDisplay;

			public ControlDisplay attackControlDisplay;

			public ControlDisplay emoteControlDisplay;

			public TMP_Text headerText;

			public TMP_Text tipText;

			public override void Build()
			{
			}

			public override void TryUpdateKeyBinds(InputBinding binding)
			{
			}

			public override void OpenPanel(bool instant = false, bool directionRight = true)
			{
			}

			public override void Localise(Translator translator)
			{
			}
		}

		[Serializable]
		public class InfographicPanelAbilities : InfographicPanel
		{
			[Serializable]
			public class Configuration
			{
				public string headerTranslationKey;

				public string tipTranslationKey;

				public string specialTranslationKey;

				public InputTarget specialInputTarget;

				public string ultimateTranslationKey;

				public InputTarget ultimateInputTarget;

				public string movementTranslationKey;

				public InputTarget movementInputTarget;

				public float controlsOpenStartDelay;

				public float controlsOpenDelay;
			}

			[NonSerialized]
			public Configuration config;

			public InfographicPanelControls.ControlDisplay specialControlDisplay;

			public InfographicPanelControls.ControlDisplay movementControlDisplay;

			public InfographicPanelControls.ControlDisplay ultimateControlDisplay;

			public TMP_Text headerText;

			public TMP_Text tipText;

			public override void Build()
			{
			}

			public override void TryUpdateKeyBinds(InputBinding binding)
			{
			}

			public override void OpenPanel(bool instant = false, bool directionRight = true)
			{
			}

			public override void Localise(Translator translator)
			{
			}
		}

		[Serializable]
		public class InfographicPanelPotion : InfographicPanel
		{
			[Serializable]
			public class Configuration
			{
				public string headerTranslationKey;

				public string descriptionTranslationKey;

				public string tipTranslationKey;

				public InputTarget potionInputTarget;
			}

			[NonSerialized]
			public Configuration config;

			public TMP_Text headerText;

			public TMP_Text descriptionText;

			public TMP_Text tipText;

			public TMP_Text controlKeyText;

			public override void Build()
			{
			}

			public override void TryUpdateKeyBinds(InputBinding binding)
			{
			}

			public override void Localise(Translator translator)
			{
			}
		}

		[Serializable]
		public class InfographicPanelRespawn : InfographicPanel
		{
			[Serializable]
			public class Configuration
			{
				public string headerTranslationKey;

				public string descriptionTranslationKey;

				public string tipTranslationKey;
			}

			[NonSerialized]
			public Configuration config;

			public TMP_Text headerText;

			public TMP_Text descriptionText;

			public TMP_Text tipText;

			public override void Localise(Translator translator)
			{
			}
		}

		[Serializable]
		public class Configuration
		{
			public SFXData openPageSfxData;

			public InfographicPanelZone.Configuration infoZonePanelConfig;

			public InfographicPanelItems.Configuration infoItemsPanelConfig;

			public InfographicPanelControls.Configuration infoControlsPanelConfig;

			public InfographicPanelAbilities.Configuration infoAbilitiesPanelConfig;

			public InfographicPanelPotion.Configuration infoPotionPanelConfig;

			public InfographicPanelRespawn.Configuration infoRespawnPanelConfig;
		}

		[SerializeField]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public Selectable _canvasGroupSelectable;

		[SerializeField]
		public UIPosLerpFade lerpFade;

		[SerializeField]
		public UIAlphaFade alphaFade;

		[SerializeField]
		public UIAlphaFade _backgroundUIFade;

		[SerializeField]
		public InfographicPanelZone infographicPanelZone;

		[SerializeField]
		public InfographicPanelItems infographicPanelItems;

		[SerializeField]
		public InfographicPanelControls infographicPanelControls;

		[SerializeField]
		public InfographicPanelAbilities infographicPanelAbilities;

		[SerializeField]
		public InfographicPanelPotion infographicPanelPotion;

		[SerializeField]
		public InfographicPanelRespawn infographicPanelRespawn;

		[NonSerialized]
		public InfographicPanel[] infographicPanels;

		[SerializeField]
		public Button prevButton;

		[SerializeField]
		public Button nextButton;

		[SerializeField]
		public Button doneButton;

		[SerializeField]
		public Button fillButtonNext;

		[SerializeField]
		public Button fillButtonDone;

		[SerializeField]
		public Button closeButton;

		[SerializeField]
		public Toggle muteButton;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Translator _translator;

		[NonSerialized]
		public int currentPanelId;

		[NonSerialized]
		public bool allowEscapeToExit;

		public override CanvasGroup CanvasGroup => null;

		public override Selectable CanvasGroupSelectable => null;

		public override UIPosLerpFade UILerpFade => null;

		public override UIAlphaFade UIAlphaFade => null;

		public override UIAlphaFade backgroundUIFade => null;

		public void FixedUpdate()
		{
		}

		public void Update()
		{
		}

		public void Build(Configuration configuration, Translator translator)
		{
		}

		public override void Localise(Translator translator)
		{
		}

		public void OpenPage(bool firstTime)
		{
		}

		public void ClosePage()
		{
		}

		public void OnNextButtonPressed()
		{
		}

		public void OnPrevButtonPressed()
		{
		}

		public void UpdateCycleButtonsState()
		{
		}

		public void TryUpdateKeyBinds(InputBinding input)
		{
		}
	}
}
