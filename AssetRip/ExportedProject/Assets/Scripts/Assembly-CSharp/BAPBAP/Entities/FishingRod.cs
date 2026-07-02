using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Localisation;
using BAPBAP.Network;
using BAPBAP.UI;
using BAPBAP.Utilities;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class FishingRod : InteractableStation
	{
		[Serializable]
		public class ReelInSettings
		{
			[Tooltip("The valid area to align and pull the fish")]
			[Range(1f, 360f)]
			public float validAreaPullRadius;

			[Min(0f)]
			[Tooltip("How much force to pull the fish when aligned on the valid area direction")]
			public float pullImpulseForce;

			[Tooltip("How much force does the full pull back continuously")]
			[Min(0f)]
			public float fishEscapeForce;

			[Min(0f)]
			[Header("Lerp Settings")]
			[Space(-10f)]
			public float fishDistLerpSpeed;

			[Min(0f)]
			public float fishDirLerpSpeed;

			[Space(-10f)]
			[Min(0f)]
			[Header("Fish Move Settings")]
			[Tooltip("How frequent random changes in direction are. The lower the value, the more frequent changes will be")]
			public float randomDirectionChangeFrequency;

			[Tooltip("The speed for the fish to move towards the current random direction")]
			[Min(0f)]
			public float randomDirectionChangeSpeed;

			[Min(0f)]
			[Tooltip("Once entering the catch minigame state, at which world unit distance should the fish start at")]
			[Header("Distance Settings")]
			[Space(-10f)]
			public float reelInInitialFishDistance;
		}

		public class CustomStateEnterSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FishingRod fishingRod;

			public CustomStateEnterSubroutine(FishingRod _fishingRod)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomFishingWaitSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FishingRod fishingRod;

			[NonSerialized]
			public byte triggerFinished;

			[NonSerialized]
			public float elapsedTime;

			[NonSerialized]
			public float currentDuration;

			public CustomFishingWaitSubroutine(FishingRod _fishingRod, byte _triggerFinished)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomFishingCatchSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FishingRod fishingRod;

			[NonSerialized]
			public byte triggerLost;

			[NonSerialized]
			public float elapsedTime;

			[NonSerialized]
			public float currentCatchTime;

			[NonSerialized]
			public GameObject uiAttentionInd;

			public CustomFishingCatchSubroutine(FishingRod _fishingRod, byte _triggerLost)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomReelInSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public FishingRod fishingRod;

			[NonSerialized]
			public byte triggerCaught;

			[NonSerialized]
			public byte triggerCaughtDone;

			[NonSerialized]
			public byte triggerLost;

			[NonSerialized]
			public float elapsedTime;

			public float pullCdTime;

			public float halfAreaRadius;

			[NonSerialized]
			public float fishFrequencyTime;

			public float fishDistance;

			public float currentFishDirChange;

			public float pullAreaAngle;

			public float fishAngle;

			public float lerpedFishDistance;

			public CustomReelInSubroutine(FishingRod _fishingRod, byte _triggerCaught, byte _triggerCaughtDone, byte _triggerLost)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}

			public bool OnInputReelIn()
			{
				return false;
			}

			public bool IsInValidPullArea()
			{
				return false;
			}

			public float GetPullAreaAngle(float dt)
			{
				return 0f;
			}
		}

		public class CustomCatchLootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FishingRod fishingRod;

			[NonSerialized]
			public byte triggerFinished;

			[NonSerialized]
			public float elapsedTime;

			public CustomCatchLootSubroutine(FishingRod _fishingRod, byte _triggerFinished)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomCatchDoneLootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FishingRod fishingRod;

			[NonSerialized]
			public byte triggerInactive;

			[NonSerialized]
			public float elapsedTime;

			public CustomCatchDoneLootSubroutine(FishingRod _fishingRod, byte _triggerInactive)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomFrenzyCaughtLootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FishingRod fishingRod;

			[NonSerialized]
			public byte triggerFinished;

			[NonSerialized]
			public byte triggerEnd;

			[NonSerialized]
			public float elapsedTime;

			public CustomFrenzyCaughtLootSubroutine(FishingRod _fishingRod, byte _triggerFinished, byte _triggerEnd)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomFrenzyCatchSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FishingRod fishingRod;

			[NonSerialized]
			public byte triggerLost;

			[NonSerialized]
			public float elapsedTime;

			[NonSerialized]
			public float currentIdleTime;

			public CustomFrenzyCatchSubroutine(FishingRod _fishingRod, byte _triggerLost)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomRecoverySubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FishingRod fishingRod;

			[NonSerialized]
			public float elapsedTime;

			public CustomRecoverySubroutine(FishingRod _fishingRod)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomInactiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FishingRod fishingRod;

			public CustomInactiveSubroutine(FishingRod _fishingRod)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomAnimSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FishingRod fishingRod;

			[NonSerialized]
			public string stateId;

			public CustomAnimSubroutine(FishingRod _fishingRod, string _stateId)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomSfxSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FishingRod fishingRod;

			[NonSerialized]
			public AudioClipData sfx;

			public CustomSfxSubroutine(FishingRod _fishingRod, AudioClipData _sfx)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[CompilerGenerated]
		public sealed class _003CAnimationPlayEndFrame_003Ed__192 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public FishingRod _003C_003E4__this;

			public string animState;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CAnimationPlayEndFrame_003Ed__192(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		public sealed class _003CDeliveryAnimSubroutine_003Ed__187 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public FishingRod _003C_003E4__this;

			public GameObject spawnedLootInstance;

			[NonSerialized]
			public float _003Ctime_003E5__2;

			[NonSerialized]
			public Vector3 _003CtargetPos_003E5__3;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDeliveryAnimSubroutine_003Ed__187(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		public sealed class _003CWaitToSpawnLvlUpReward_003Ed__184 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public FishingRod _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWaitToSpawnLvlUpReward_003Ed__184(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[NonSerialized]
		public AudioManager audioManager;

		[NonSerialized]
		public ItemManager itemManager;

		[SerializeField]
		[Header("References")]
		public ItemDrops haxRandomDrops;

		[SerializeField]
		public Animator animator;

		[SerializeField]
		public Transform fishingRodRoot;

		[SerializeField]
		public Transform fishingRodBaitPoint;

		[SerializeField]
		public Transform[] fishingRodLineBones;

		[SerializeField]
		public Transform fishingRodLineHook;

		[SerializeField]
		public ParticleSystem fishingVfxStart;

		[SerializeField]
		public ParticleSystem caughtVfxLoop;

		[SerializeField]
		public ParticleSystem caughtVfxPull;

		[SerializeField]
		public SkinnedMeshRenderer fishingRodRenderer;

		[SerializeField]
		public Material fishingFrenzyMaterial;

		[Header("External References")]
		[SerializeField]
		public PassiveSO expertFishingPassive;

		[SerializeField]
		public UIFishingMinigame uiFishingMinigamePrefab;

		[SerializeField]
		public GameObject uiAttentionIndPrefab;

		[Header("Properties")]
		[SerializeField]
		public RangeFloat idleTimeRange;

		[SerializeField]
		public RangeFloat fishingTimeRange;

		[SerializeField]
		public float interactCdDuration;

		[SerializeField]
		public float lootDeliveryDuration;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public IntRange lootRange;

		[SerializeField]
		[Range(0f, 1f)]
		public float fishingFrenzyChance;

		[SerializeField]
		public IntRange frenzyLootRange;

		[Header("Reel In Minigame Settings")]
		[Tooltip("The whole area radius for the minigame")]
		[SerializeField]
		[Range(1f, 360f)]
		public float areaRadius;

		[SerializeField]
		[Min(0f)]
		public float reelInAreaDirLerpSpeed;

		[SerializeField]
		public ReelInSettings reelInSettingsMed;

		[SerializeField]
		public ReelInSettings reelInSettingsLarge;

		[Min(0f)]
		[SerializeField]
		[Tooltip("If the current fish distance is under this world unit length, finish succesfully")]
		public float minDistanceToCatch;

		[SerializeField]
		[Min(0f)]
		[Tooltip("If the current fish distance surpassed this world unit length, finish unsuccesfully")]
		public float maxDistanceToLose;

		[Tooltip("If the reel minigame has been going for longer than this duration, finish unsuccesfully")]
		[SerializeField]
		[Min(0f)]
		public float reelInMaxDuration;

		[SerializeField]
		[Min(0f)]
		public float reelInInputCdDuration;

		[Space(-10f)]
		[Header("View Settings")]
		[SerializeField]
		public RangeFloat camZoomMultiplierRange;

		[SerializeField]
		public float syncInterpFactor;

		[SerializeField]
		[Header("Loot Settings")]
		public float smallLootChance;

		[SerializeField]
		public float mediumLootChance;

		[SerializeField]
		public float largeLootChance;

		[SerializeField]
		public Item fishingHat;

		[SerializeField]
		public GameObject npcSpawnVfx;

		[SerializeField]
		[Space(-10f)]
		[Header("Small Loot")]
		public bool firstPullNoTrash;

		[SerializeField]
		public float trashChance;

		[SerializeField]
		public float grayChance;

		[SerializeField]
		public float greenChance;

		[SerializeField]
		public Item[] trashItems;

		[SerializeField]
		public float npcChanceSmall;

		[SerializeField]
		public GameObject[] npcPrefabsSmall;

		[Space(-10f)]
		[Header("Medium Loot")]
		[SerializeField]
		public float blueChance;

		[SerializeField]
		public float lootableChance;

		[SerializeField]
		public float npcChanceMed;

		[SerializeField]
		public float fishingHatChanceMed;

		[SerializeField]
		public GameObject[] npcPrefabsMed;

		[SerializeField]
		[Header("Large Loot")]
		[Space(-10f)]
		public float purpleChance;

		[SerializeField]
		public float legendaryChance;

		[SerializeField]
		public float fishingHatChanceLarge;

		[SerializeField]
		public float npcChanceLarge;

		[SerializeField]
		public GameObject[] npcPrefabsLarge;

		[Header("Sfx")]
		[SerializeField]
		public AudioClipData sfxLostPull;

		[SerializeField]
		public AudioClipData sfxCaught;

		[SerializeField]
		public AudioClipData sfxPullCaught;

		[SerializeField]
		public AudioClipData sfxDeactive;

		[SerializeField]
		public float sfxDeactivePlayDelay;

		[SerializeField]
		public AudioSource audioSourceStartFishing;

		[SerializeField]
		public float sfxStartFishingPlayDelay;

		[SerializeField]
		public AudioClip interactReelInAudioClip;

		[SerializeField]
		public AudioSource audioSourceCaughtLoop;

		[SerializeField]
		public AudioClipData frenzyStartPullSfx;

		[SerializeField]
		public AudioClipData frenzyLootSfx;

		[SerializeField]
		public AudioSource goldenLoop;

		[SerializeField]
		public AudioFade goldenLoopFade;

		[SerializeField]
		public CharVoicelineConfig legendaryPullVoiceline;

		[Header("Delivery Anim")]
		[SerializeField]
		public Transform lootSpawnStartPoint;

		[SerializeField]
		public Transform lootSpawnTargetPoint;

		[Tooltip("Randomizes the target landing position for the loop by this multiplier amount")]
		[SerializeField]
		[Min(0f)]
		public float lootSpawnTargetRandomMult;

		[SerializeField]
		public float deliveryAnimDuration;

		[SerializeField]
		public float heightMultiplier;

		[SerializeField]
		public AnimationCurve deliveryLerpCurve;

		[SerializeField]
		public AnimationCurve deliveryHeightCurve;

		[Header("XP")]
		[SerializeField]
		public int xpPerCatch;

		[SerializeField]
		public int xpNeededForLevel;

		[SerializeField]
		public int levelUpGoldAmount;

		[SerializeField]
		public GameObject xpLevelUpVfxPrefab;

		[SerializeField]
		public AudioClipData xpLevelUpSfx;

		[SerializeField]
		public GameObject xpLevelUpUIWindow;

		[SerializeField]
		public float windowDuration;

		[Header("Animation")]
		[SerializeField]
		public string animIdleState;

		[SerializeField]
		public string animStartFishingState;

		[SerializeField]
		public string animFishingState;

		[SerializeField]
		public string animCaughtState;

		[SerializeField]
		public string animPullCatchState;

		[SerializeField]
		public string animReelInState;

		[SerializeField]
		public string animReelInPullState;

		[SerializeField]
		public string animLostState;

		[SerializeField]
		public string animInactiveState;

		[SerializeField]
		public string animInactiveLoopState;

		[Header("Translation Keys")]
		[SerializeField]
		public string startFishingTranslationKey;

		[SerializeField]
		public string catchTranslationKey;

		[SerializeField]
		public string pullTranslationKey;

		[SerializeField]
		public string inactiveTranslationKey;

		[SerializeField]
		public string pullingTranslationKey;

		[SerializeField]
		public string caughtFishTranslationKey;

		[SerializeField]
		public string levelXTranslationKey;

		[SerializeField]
		public string youReachedLevelXTranslationKey;

		[NonSerialized]
		public SimulationFsm fsm;

		[NonSerialized]
		public byte stateIdleId;

		[NonSerialized]
		public byte stateFishingCatchId;

		[NonSerialized]
		public byte stateFishingWaitId;

		[NonSerialized]
		public byte stateReelInId;

		[NonSerialized]
		public byte stateFrenzyWaitId;

		[NonSerialized]
		public byte stateRecoveringId;

		[NonSerialized]
		public byte stateInactiveId;

		[NonSerialized]
		public byte EXT_TRIGGER_START_FISHING;

		[NonSerialized]
		public byte EXT_TRIGGER_UNSUCESSFUL;

		[NonSerialized]
		public byte EXT_TRIGGER_FISHCATCH;

		[NonSerialized]
		public byte EXT_TRIGGER_FRENZYCAUGHT;

		[NonSerialized]
		public float fishingTimer;

		[NonSerialized]
		public int lootGiven;

		[NonSerialized]
		public int currentMaxLoot;

		[NonSerialized]
		public int frenzyLootCount;

		[NonSerialized]
		public int latestUsingPlayerId;

		[NonSerialized]
		public float interactCdTimer;

		[NonSerialized]
		public bool isAnimatingStartInactive;

		[NonSerialized]
		public bool _isClient;

		[NonSerialized]
		public bool _isServer;

		[NonSerialized]
		public Material originalMaterial;

		[NonSerialized]
		public AudioClip interactOriginalAudioClip;

		[NonSerialized]
		public Vector3 lootSpawnTargetNavPos;

		[NonSerialized]
		public CustomReelInSubroutine reelInSubroutine;

		[NonSerialized]
		public UIFishingMinigame uiFishingMinigame;

		[NonSerialized]
		public int expertFishingPassiveId;

		[NonSerialized]
		public float[] lootChances;

		[NonSerialized]
		public ReelInSettings reelInSettings;

		[NonSerialized]
		public string startFishingStr;

		[NonSerialized]
		public string catchStr;

		[NonSerialized]
		public string catchFishStr;

		[NonSerialized]
		public string pullStr;

		[NonSerialized]
		public string popUpLevelXStr;

		[NonSerialized]
		public string youReachedLevelXStr;

		[SyncVar(hook = "OnSyncFsmStateIdChanged")]
		[NonSerialized]
		public byte syncFsmStateId;

		[SyncVar]
		[NonSerialized]
		public byte fishLootType;

		[SyncVar]
		[NonSerialized]
		public float pullAreaAngle;

		[SyncVar]
		[NonSerialized]
		public float fishAngle;

		[SyncVar]
		[NonSerialized]
		public float lerpedFishDistance;

		[SyncVar(hook = "OnIsFrenzyChanged")]
		[NonSerialized]
		public bool isFrenzy;

		[SyncVar(hook = "OnCharUsingChanged")]
		[NonSerialized]
		public EntityManager usingChar;

		[NonSerialized]
		public NetworkBehaviourSyncVar ___usingCharNetId;

		public Action<byte, byte> _Mirror_SyncVarHookDelegate_syncFsmStateId;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_isFrenzy;

		public Action<EntityManager, EntityManager> _Mirror_SyncVarHookDelegate_usingChar;

		public byte NetworksyncFsmStateId
		{
			get
			{
				return 0;
			}
			[param: In]
			set
			{
			}
		}

		public byte NetworkfishLootType
		{
			get
			{
				return 0;
			}
			[param: In]
			set
			{
			}
		}

		public float NetworkpullAreaAngle
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		public float NetworkfishAngle
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		public float NetworklerpedFishDistance
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		public bool NetworkisFrenzy
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public EntityManager NetworkusingChar
		{
			get
			{
				return null;
			}
			[param: In]
			set
			{
			}
		}

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public override void OnDestroy()
		{
		}

		public void FixedUpdate()
		{
		}

		public void LateUpdate()
		{
		}

		public void UpdateFishingMinigame()
		{
		}

		public override void ClOnEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public void UIShowStartFishingWindow()
		{
		}

		public void UIShowWaitCatchWindow()
		{
		}

		public void UIShowCatchWindow()
		{
		}

		public void UIShowPullWindow()
		{
		}

		public void UIShowFrenzyWindow()
		{
		}

		public override void OnSlotExit(EntityManager entity, InteractableCollider slot)
		{
		}

		public override bool TryUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public override bool AbleToUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public override void OnLocalAuthPlayerChanged(EntityManager entity, InteractableCollider slot)
		{
		}

		public void OnStartFishing()
		{
		}

		public void OnPullSuccesful(EntityManager entity)
		{
		}

		public bool OnReelInPull()
		{
			return false;
		}

		public void OnFrenzyFishCaught(EntityManager entity)
		{
		}

		public void OnPullUnsuccesful()
		{
		}

		public void SetCharUsing(EntityManager entity)
		{
		}

		public void RemoveCharUsing()
		{
		}

		public void TryApplyFishingBonus(EntityManager entity)
		{
		}

		public void SetLootType()
		{
		}

		public void SpawnLoot()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitToSpawnLvlUpReward_003Ed__184))]
		public IEnumerator WaitToSpawnLvlUpReward()
		{
			return null;
		}

		public void SwitchMaterialTo(Material m)
		{
		}

		public void StartDeliveryAnim(GameObject instance)
		{
		}

		[IteratorStateMachine(typeof(_003CDeliveryAnimSubroutine_003Ed__187))]
		public IEnumerator DeliveryAnimSubroutine(GameObject spawnedLootInstance)
		{
			return null;
		}

		[ClientRpc]
		public override void RpcOnUseCastingStart(EntityManager entity, int slotId)
		{
		}

		[ClientRpc]
		public override void RpcOnUseSuccess(EntityManager entity, int slotId)
		{
		}

		[ClientRpc]
		public override void RpcOnUseFail(EntityManager entity, int slotId)
		{
		}

		[ClientRpc]
		public void RpcOnStartFishing()
		{
		}

		[IteratorStateMachine(typeof(_003CAnimationPlayEndFrame_003Ed__192))]
		public IEnumerator AnimationPlayEndFrame(string animState)
		{
			return null;
		}

		[ClientRpc]
		public void RpcOnPullSuccesfull()
		{
		}

		[ClientRpc]
		public void RpcOnPullStartFrenzy()
		{
		}

		[ClientRpc]
		public void RpcOnReelIn()
		{
		}

		[ClientRpc]
		public void RpcOnLootSpawned(GameObject lootInstance, int usingPlayerId)
		{
		}

		[ClientRpc]
		public void RpcSpawnNpcVfx()
		{
		}

		[ClientRpc]
		public void RpcGetXp(int playerId, int xp)
		{
		}

		[ClientRpc]
		public void RpcXpLevelUp(int playerId, int level)
		{
		}

		public override void OnActiveChanged(bool oldValue, bool newValue)
		{
		}

		public void OnSyncFsmStateIdChanged(byte oldValue, byte newValue)
		{
		}

		public void OnIsFrenzyChanged(bool oldValue, bool newValue)
		{
		}

		public void OnCharUsingChanged(EntityManager oldValue, EntityManager newValue)
		{
		}

		public void ClOnLockedChanged()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public override void UserCode_RpcOnUseCastingStart__EntityManager__Int32(EntityManager entity, int slotId)
		{
		}

		public new static void InvokeUserCode_RpcOnUseCastingStart__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public override void UserCode_RpcOnUseSuccess__EntityManager__Int32(EntityManager entity, int slotId)
		{
		}

		public new static void InvokeUserCode_RpcOnUseSuccess__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public override void UserCode_RpcOnUseFail__EntityManager__Int32(EntityManager entity, int slotId)
		{
		}

		public new static void InvokeUserCode_RpcOnUseFail__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnStartFishing()
		{
		}

		public static void InvokeUserCode_RpcOnStartFishing(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnPullSuccesfull()
		{
		}

		public static void InvokeUserCode_RpcOnPullSuccesfull(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnPullStartFrenzy()
		{
		}

		public static void InvokeUserCode_RpcOnPullStartFrenzy(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnReelIn()
		{
		}

		public static void InvokeUserCode_RpcOnReelIn(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnLootSpawned__GameObject__Int32(GameObject lootInstance, int usingPlayerId)
		{
		}

		public static void InvokeUserCode_RpcOnLootSpawned__GameObject__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSpawnNpcVfx()
		{
		}

		public static void InvokeUserCode_RpcSpawnNpcVfx(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcGetXp__Int32__Int32(int playerId, int xp)
		{
		}

		public static void InvokeUserCode_RpcGetXp__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcXpLevelUp__Int32__Int32(int playerId, int level)
		{
		}

		public static void InvokeUserCode_RpcXpLevelUp__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static FishingRod()
		{
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
