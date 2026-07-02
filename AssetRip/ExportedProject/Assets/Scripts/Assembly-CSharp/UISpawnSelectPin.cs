using System;
using BAPBAP.Local;
using BAPBAP.Player;
using BAPBAP.UI;
using UnityEngine;
using UnityEngine.UI;

public class UISpawnSelectPin : MonoBehaviour
{
	[SerializeField]
	public RectTransform _rectTransform;

	[SerializeField]
	public TransformScaleSimpleAnimation _scaleAnim;

	[SerializeField]
	public UIAlphaFade _alphaFade;

	[SerializeField]
	public Image _spawnLeaderIndicator;

	[Header("Character Icon")]
	[SerializeField]
	public Image _iconImage;

	[SerializeField]
	public Image _characterIcon;

	[SerializeField]
	public Image _outline;

	[NonSerialized]
	public UILobbyMatchCharacterSelectPage.Configuration _matchCharConfig;

	[NonSerialized]
	public float _fadeTimer;

	[NonSerialized]
	public bool _waitingToFade;

	public RectTransform RectTransform => null;

	public void Build(UILobbyMatchCharacterSelectPage.Configuration matchCharConfig)
	{
	}

	public void Update()
	{
	}

	public void EnablePin()
	{
	}

	public void SetPlayerColor(Color identityColor)
	{
	}

	public void SetPlayerCharacter(PlayerManager player)
	{
	}

	public void SetSpawnLeaderUI(bool isSpawnLeader)
	{
	}

	public void MoveRectToMapPosition(RectTransform rectTransform, Vector2 screenPos, float moveDuration = 0f)
	{
	}

	public void FadeOutAfterSeconds(float seconds)
	{
	}

	public void PlayScaleAnim()
	{
	}
}
