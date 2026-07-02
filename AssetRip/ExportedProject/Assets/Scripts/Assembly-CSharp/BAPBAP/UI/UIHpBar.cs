using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using BAPBAP.Local;
using BAPBAP.Pooling;
using BAPBAP.Systems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIHpBar : MonoBehaviour
	{
		[Serializable]
		public class Configuration
		{
			public UIHpBar Prefab;

			public int PoolSize;

			public LocalPrefabPool.ResizeStrategy ResizeStrategy;
		}

		public class Pool
		{
			[NonSerialized]
			public Queue<UIHpBar> _activeQueue;

			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public Queue<UIHpBar> _inactiveQueue;

			[NonSerialized]
			public Transform _parentTransform;

			[NonSerialized]
			public HpBarSystem _system;

			public Pool(Configuration configuration, Transform parentTransform)
			{
			}

			public UIHpBar Spawn(Transform followTransform, float worldHeight, bool isAlly, bool isLocalPlayer, string name)
			{
				return null;
			}

			public void Despawn(UIHpBar instance)
			{
			}

			public void Dispose()
			{
			}
		}

		[SerializeField]
		[Header("Components")]
		public UIHpBarHp uiHpBarHp;

		[SerializeField]
		public UIHpBarStatusEffects uiHpBarStatusEffects;

		[SerializeField]
		public UIHpBarCasting uiHpBarCasting;

		[SerializeField]
		public UIHpBarHit uiHpBarHit;

		[SerializeField]
		public UIHpBarShader uiHpBarsShader;

		[SerializeField]
		public UIHpBarCulling uiHpBarCulling;

		[SerializeField]
		public UIHpBarFollow uiHpBarFollow;

		[SerializeField]
		[Header("References")]
		public GameObject rootObj;

		[SerializeField]
		public GameObject barVisibilityRoot;

		[SerializeField]
		public GameObject healthContainerRoot;

		[SerializeField]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public LayoutElement layoutElement;

		[Header("Component References")]
		[SerializeField]
		public TMP_Text nameText;

		[SerializeField]
		public Image hpBar;

		[SerializeField]
		public UIEffectIconStack uiEffectIconStack;

		[SerializeField]
		public Image uieffectStackProgressFill;

		[SerializeField]
		public GameObject uieffectStackProgressRoot;

		[SerializeField]
		public Color originalStackProgressColor;

		[SerializeField]
		public Color fullStackProgressColor;

		[SerializeField]
		public UIFader lootableAbilityFader;

		[Header("Downed Component References")]
		[SerializeField]
		public GameObject downBarHolder;

		[SerializeField]
		public Image uidownedProgressFill;

		[SerializeField]
		[Header("Detect Mark")]
		public Image detectMarkImage;

		[SerializeField]
		public CanvasGroup detectMarkGroup;

		[SerializeField]
		public TransformScaleAnimation detectMarkAnim;

		[SerializeField]
		public UIAlphaFadeTimed detectMarkFade;

		[SerializeField]
		public Color originalMarkColor;

		[SerializeField]
		public Color nearestMarkColor;

		[Header("Aggro Mark")]
		[SerializeField]
		public Image aggroMark;

		[SerializeField]
		public TransformScaleAnimation aggroMarkFadeIn;

		[SerializeField]
		public UIAlphaFadeTimed aggroMarkFadeOut;

		[SerializeField]
		[Header("Ammo UI")]
		public GameObject ammoHolder;

		[SerializeField]
		public Transform ammoIconContainer;

		[SerializeField]
		public GameObject ammoIcon;

		[SerializeField]
		public TextMeshProUGUI reloadingText;

		[SerializeField]
		public Color usedBulletColor;

		[Header("Configs")]
		[SerializeField]
		public bool nameTextHidden;

		[SerializeField]
		public int dividerCellSize;

		[SerializeField]
		public float stackProgressFullSize;

		[NonSerialized]
		public int _maxHpCache;

		[NonSerialized]
		public int _shieldCache;

		[NonSerialized]
		public bool _ammoIsEnabled;

		[NonSerialized]
		public List<Image> _spawnedBulletIcons;

		[NonSerialized]
		public Configuration _config;

		[NonSerialized]
		public Pool _pool;

		public CanvasGroup CanvasGroup => null;

		public void Build(Pool pool, Configuration config)
		{
		}

		public void Start()
		{
		}

		public void ManagedLateUpdate()
		{
		}

		public void Initialise(Transform followTransform, float worldHeight, bool isAlly, bool isLocalPlayer, string name)
		{
		}

		public void UpdateName(string playerName)
		{
		}

		public void UpdatePlayerType(bool isAlly, bool isLocalPlayer)
		{
		}

		public void UpdateNameHidden()
		{
		}

		public void SetNameHidden(bool isHidden)
		{
		}

		public void InitialiseHp(int maxHp)
		{
		}

		public void UpdateHpShield(int hp, int maxHp, int shield)
		{
		}

		public void DoHitEffect(int oldLife, int newLife, int oldTotalLife, int newTotalLife, bool isCrit)
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

		public void SetEffectStack(int stack, bool isMaxStack = false)
		{
		}

		public void DisableEffectStack()
		{
		}

		public void SetEffectStackProgress(float normProgress)
		{
		}

		public void DisableEffectStackProgress()
		{
		}

		public void EnableEffectStackProgress()
		{
		}

		public void UpdateCastingTime(int predTickNum, float time, float totalTime, bool isUlt)
		{
		}

		public void UpdateChannelingTime(int predTickNum, float time, float totalTime, bool isUlt)
		{
		}

		public void ToggleCastingTime(bool shown)
		{
		}

		public void TriggerCastingSuccess()
		{
		}

		public void TriggerCastingFail()
		{
		}

		public void SetDownedTimer(float currentTime, float downedTime)
		{
		}

		public void ToggleDowned(bool isDowned)
		{
		}

		public void ToggleHpBarSemiVisibility(bool isEnabled)
		{
		}

		public void ToggleHidden(bool isHidden)
		{
		}

		public void ToggleDetectMarkEnabled(bool isEnabled)
		{
		}

		public void ToggleDetectMarkClosest(bool isClosest)
		{
		}

		public void ShowEmotionStateMark(UIManager.EmotionState state)
		{
		}

		public void ToggleAmmoHolder(bool isEnabled)
		{
		}

		public void SetMaxAmmoCount(int maxAmmo)
		{
		}

		public void SetAmmoCount(int currentAmmo)
		{
		}

		public void SetGunReloadingState(bool isReloading)
		{
		}

		public void Dispose()
		{
		}
	}
}
