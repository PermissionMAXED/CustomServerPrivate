using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UITeammateElement : MonoBehaviour
	{
		[NonSerialized]
		public UITeammates uiTeammates;

		[NonSerialized]
		public ItemManager itemManager;

		[SerializeField]
		[Header("Hp Bar Settings")]
		public int dividerCellSize;

		[SerializeField]
		public float damageOverlaySpeed;

		[Header("Settings")]
		[SerializeField]
		public Color itemMaxCountColor;

		[SerializeField]
		public Color portraitKilledColor;

		[SerializeField]
		public Material grayscaleMat;

		[SerializeField]
		public Color downedColor;

		[SerializeField]
		public Sprite downedIcon;

		[SerializeField]
		public Color executingColor;

		[SerializeField]
		public Sprite executingIcon;

		[SerializeField]
		public Color revivingColor;

		[SerializeField]
		public Sprite revivingIcon;

		[SerializeField]
		[Header("UI References")]
		public UIHpBarShader uiHpBarShader;

		[SerializeField]
		public Image charAccentColor;

		[SerializeField]
		public Image charPortrait;

		[SerializeField]
		public TMP_Text playerName;

		[SerializeField]
		public CanvasGroup charDamageOverlay;

		[SerializeField]
		public CanvasGroup hpBarDamageOverlay;

		[SerializeField]
		public Toggle muteToggle;

		[SerializeField]
		public UIAlphaFade killedAnim;

		[SerializeField]
		public UISelectSfxElement muteToggleSfx;

		[SerializeField]
		public UIItemSlotElement[] itemSlots;

		[SerializeField]
		public UIItemSlotElement[] consumableSlot;

		[SerializeField]
		public UIItemSlotElement abilitySlot;

		[SerializeField]
		public UIItemSlotElement goldUI;

		[SerializeField]
		public Transform passiveContainer;

		[SerializeField]
		public UIPassiveElement uiPassiveElement;

		[SerializeField]
		public GameObject downedNotifObj;

		[SerializeField]
		public Image downedIconImage;

		[SerializeField]
		public TransformScaleSimpleAnimation downedIconAnim;

		[SerializeField]
		public Image downedProgress;

		[NonSerialized]
		public List<UIPassiveElement> _spawnedPassiveElements;

		[NonSerialized]
		public float damageTimer;

		[NonSerialized]
		public int maxHpCache;

		[NonSerialized]
		public int shieldCache;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void Update()
		{
		}

		public void OnMutePressed()
		{
		}

		public void TriggerDamageOverlayHit()
		{
		}

		public void SetTeammateName(string name)
		{
		}

		public void TriggerTeammateKilledAnim()
		{
		}

		public void SetTeammateHp(int hp, int maxHp, int shield)
		{
		}

		public void SetTeammateHpBarColor(Color color)
		{
		}

		public void SetTeammateCharPortrait(Sprite portrait)
		{
		}

		public void SetTeammatePortraitAccentColor(Color color)
		{
		}

		public void SetTeammatePortraitDowned(bool isDowned)
		{
		}

		public void SetTeammatePortraitDead()
		{
		}

		public void SetTeammatePortraitColor(Color color)
		{
		}

		public void SetTeammateDownedState(PlayerManager.DownedState downedState)
		{
		}

		public void SetTeammateDownedTime(float normTime)
		{
		}

		public void RemoveAllItemsAndConsumables()
		{
		}

		public void SetTeammateItem(int slotId, int itemId)
		{
		}

		public void RemoveTeammateItem(int slotId)
		{
		}

		public void SetTeammateConsumable(int slotId, int itemId)
		{
		}

		public void SetTeammateConsumableCount(int slotId, int count, int maxCount)
		{
		}

		public void SetTeammateConsumableCountMax(UIItemSlotElement uIItemSlotElement, bool isEnabled)
		{
		}

		public void RemoveTeammateConsumable(int slotId)
		{
		}

		public void SetTeammateAbility(int itemId)
		{
		}

		public void RemoveTeammateAbility()
		{
		}

		public void SetAugmentAbility(int augmentId)
		{
		}

		public void SetTeammateGold(int amount)
		{
		}
	}
}
