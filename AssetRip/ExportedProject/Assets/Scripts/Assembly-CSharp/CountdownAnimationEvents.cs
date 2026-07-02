using System;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;

public class CountdownAnimationEvents : MonoBehaviour
{
	[SerializeField]
	public TMP_Text countdownText;

	[SerializeField]
	public TMP_Text countdownTextGhost;

	[SerializeField]
	public AudioSource audioSource;

	[SerializeField]
	public string goTranslationKey;

	[NonSerialized]
	public string goStr;

	public void Localise(Translator translator)
	{
	}

	public void SetText3()
	{
	}

	public void SetText2()
	{
	}

	public void SetText1()
	{
	}

	public void SetTextGO()
	{
	}

	public void Disable()
	{
	}

	public void SetText(string s)
	{
	}
}
