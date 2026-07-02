using System;
using BAPBAP.UI;
using UnityEngine;

public class LabelElement : MonoBehaviour
{
	[NonSerialized]
	public string labelStr;

	[NonSerialized]
	public UIWorldLabelElement labelUI;

	public void OnDisable()
	{
	}

	public void SetLabelStr(string labelStr)
	{
	}

	public void SetUILabel(UIWorldLabelElement labelUI, bool fadeIn = true)
	{
	}

	public UIWorldLabelElement GetUILabel()
	{
		return null;
	}
}
