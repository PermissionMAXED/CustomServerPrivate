using System;
using System.Collections.Generic;
using BAPBAP.Localisation;
using BAPBAP.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI;

public class View_PreMatch_CharSelect : View
{
	[SerializeField]
	public UIAlphaFade _uiAlphaFade;

	[SerializeField]
	public UIAlphaFade _backgroundAlphaFade;

	[SerializeField]
	public Image _characterSplashImage;

	[SerializeField]
	public Image _characterShineImage;

	[SerializeField]
	public TextMeshProUGUI _characterNameText;

	[SerializeField]
	public TextMeshProUGUI _characterSubtitleText;

	[SerializeField]
	public Transform _characterButtonParent;

	[SerializeField]
	public Button _lockInButton;

	[SerializeField]
	public UIAlphaFade _lockInAlphaFade;

	[SerializeField]
	public Animator _animator;

	[SerializeField]
	public AnimationClip _charSelectAnim;

	[SerializeField]
	public AnimationClip _charLockAnim;

	[SerializeField]
	public ParticleSystem _lockInVFX;

	[SerializeField]
	[Header("Minimap")]
	public TMP_Text _mapPreviewNameText;

	[SerializeField]
	public Image _mapPreviewImage;

	[SerializeField]
	[Header("Abilities")]
	public RectTransform _abilityIconsContentParent;

	[SerializeField]
	public TMP_Text _titleText;

	[SerializeField]
	public TMP_Text _keyText;

	[SerializeField]
	public TMP_Text _descriptionText;

	[SerializeField]
	public UIAlphaFade _abilityPanelFade;

	[SerializeField]
	public UIAlphaFade _abilityInfoAlphaFade;

	[SerializeField]
	public UIPosLerpFade _abilityInfoPosLerpFade;

	public const int NUM_ABILITIES = 4;

	[NonSerialized]
	public UILobbyMatchCharacterSelectPage.Configuration _configuration;

	[NonSerialized]
	public UILobbyCharacterSelectIcon.Factory _charSelectIconFactory;

	[NonSerialized]
	public UILobbyCharacterSelectIcon[] _charSelectButtons;

	[NonSerialized]
	public UILobbyCharacterSelectAbility.Factory _charSelectAbilityFactory;

	[NonSerialized]
	public List<UILobbyCharacterSelectAbility> _charAbilityEntries;

	[NonSerialized]
	public UILobbyCharacterSelectAbility _selectedAbilityIcon;

	public UIManager UIManager => null;

	public Translator Translator => null;

	public void Initialize(UILobbyMatchCharacterSelectPage.Configuration configuration)
	{
	}

	public void InitMap()
	{
	}

	public void Open(bool instant = false)
	{
	}

	public void Close(bool instant = false)
	{
	}

	public void PopulateCharacterButtons()
	{
	}

	public void PopulateAbilityButtons()
	{
	}

	public void SetDisplayedCharacter(UICharactersConfiguration.CharacterConfiguration character, bool animate = false)
	{
	}

	public void SetDisplayedAbility(int abilityIndex)
	{
	}

	public void UpdateCharButtons()
	{
	}

	public void UpdateCharacterAbilities(int charId)
	{
	}

	public void PlayCharacterLockEffect(PlayerManager player)
	{
	}

	public int GetCharIndexByID(int charID)
	{
		return 0;
	}
}
