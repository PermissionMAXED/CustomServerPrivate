using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIHpBarStatusEffects : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		public TMP_Text statusText;

		[SerializeField]
		public Image statusTimerImg;

		[SerializeField]
		public TMP_Text playerNameText;

		[SerializeField]
		[Header("Config")]
		public bool hidePlayerName;

		[NonSerialized]
		public bool _isShown;

		[NonSerialized]
		public List<StatusEffectData> _statusEffects;

		public void Awake()
		{
		}

		public void Reset()
		{
		}

		public void ModifyOrAddStatusEffect(StatusEffectData data)
		{
		}

		public void RemoveAllStatusEffect(StatusEffectData data)
		{
		}

		public void RemoveOldestStatusEffect(StatusEffectData data)
		{
		}

		public void ManagedLateUpdate()
		{
		}

		public void UpdateStatusEffects()
		{
		}
	}
}
