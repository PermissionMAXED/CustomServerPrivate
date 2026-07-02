using System;
using BAPBAP.Network;
using BAPBAP.Player;
using BAPBAP.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class View_PreMatch_PlayerDisplay : MonoBehaviour
{
	public GameObject GameObject;

	public RectTransform NameTextRect;

	public TMP_Text PlayerNameText;

	public Image CharImage;

	public UILobbyPlayerContainer PlayerContainer;

	public GameObject PlayerDisplayObj;

	public CanvasGroup CanvasGroup;

	public TMP_Text LockText;

	public Image CharacterPortrait;

	public Image CharacterBorder;

	public Image SpawnIcon;

	public Animator LockInPortraitEffect;

	[HideInInspector]
	public Color IdentityColor;

	[NonSerialized]
	public QueueMatchedData _qmd;

	[NonSerialized]
	public PlayerManager _player;

	[NonSerialized]
	public UILobbyMatchCharacterSelectPage.Configuration _configuration;

	public void Initialize(QueueMatchedData qmd, PlayerManager player, UILobbyMatchCharacterSelectPage.Configuration config)
	{
	}

	public void UpdatePlayerInfo()
	{
	}

	public void SetCharacter(int charId)
	{
	}

	public void UpdateLockedState()
	{
	}
}
