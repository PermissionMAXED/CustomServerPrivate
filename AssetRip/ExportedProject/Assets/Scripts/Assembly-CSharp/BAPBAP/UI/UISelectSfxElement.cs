using System;
using BAPBAP.Local;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UISelectSfxElement : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, ISelectHandler
	{
		[NonSerialized]
		public AudioManager audioManager;

		[NonSerialized]
		public Button uiButton;

		[Header("Hover SFX")]
		[SerializeField]
		public bool playHover;

		[ConditionalHide("playHover", true)]
		[SerializeField]
		public AudioManager.SFX hoverSfxId;

		[ConditionalHide("playHover", true)]
		[SerializeField]
		public float hoverSfxVolume;

		[Header("Click SFX")]
		[SerializeField]
		public bool playClick;

		[ConditionalHide("playClick", true)]
		[SerializeField]
		public AudioManager.SFX clickSfxId;

		[ConditionalHide("playClick", true)]
		[SerializeField]
		public float clickSfxVolume;

		public void Awake()
		{
		}

		public void OnBeginHover()
		{
		}

		public void OnClick(float volumeMultiplier = 1f)
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}
	}
}
