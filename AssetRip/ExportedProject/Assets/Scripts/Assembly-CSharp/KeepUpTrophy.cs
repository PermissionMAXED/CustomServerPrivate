using System;
using FMODUnity;
using TMPro;
using UnityEngine;

public class KeepUpTrophy : MonoBehaviour
{
	public string playerPrefName;

	public int keepUpCount;

	public int levelUpSoundInterval;

	public TextMeshPro text;

	[NonSerialized]
	public Color initialColor;

	public StudioEventEmitter levelUpSound;

	public GameObject trophy;

	public int unlockAt;

	[NonSerialized]
	public Color[] levelColors;

	public int HighScore => 0;

	public void Awake()
	{
	}

	public void OnEnable()
	{
	}

	public void StartGame()
	{
	}

	public void KeepUp()
	{
	}

	public void ResetKeepUp()
	{
	}

	public void NewHighscore()
	{
	}
}
