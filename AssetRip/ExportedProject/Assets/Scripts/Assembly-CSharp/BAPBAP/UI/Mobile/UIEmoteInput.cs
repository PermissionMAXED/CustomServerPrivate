using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using BAPBAP.Local;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI.Mobile
{
	public class UIEmoteInput : MonoBehaviour
	{
		[Serializable]
		public class EmoteButton
		{
			public Image icon;

			public Button button;
		}

		[SerializeField]
		public Button button;

		[SerializeField]
		public CanvasGroup emoteCanvasGroup;

		[SerializeField]
		public float autoCloseDuration;

		[SerializeField]
		public List<EmoteButton> emoteButtons;

		[NonSerialized]
		public EmoteManager emoteManager;

		[NonSerialized]
		public bool active;

		[NonSerialized]
		public float activatedAt;

		public void OnEnable()
		{
		}

		public void Update()
		{
		}

		public void ToggleEmotes()
		{
		}

		public void DoEmote(int id)
		{
		}

		public bool TryGetCharEmotes(out CharEmotes charEmotes)
		{
			charEmotes = null;
			return false;
		}
	}
}
