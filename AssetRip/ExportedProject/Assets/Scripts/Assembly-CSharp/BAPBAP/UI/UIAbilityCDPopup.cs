using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIAbilityCDPopup : MonoBehaviour
	{
		[SerializeField]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public TMP_Text cdText;

		[SerializeField]
		public Image abilityIcon;

		[NonSerialized]
		public float cdTimer;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public float yPos;

		public void SetAbility(Sprite icon)
		{
		}

		public void OnEnable()
		{
		}

		public void SetCD(float s)
		{
		}

		public void LateUpdate()
		{
		}
	}
}
