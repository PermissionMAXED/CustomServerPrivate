using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Network.EventData;
using UnityEngine;
using UnityEngine.Audio;

namespace BAPBAP.Local
{
	public class AudioManager : MonoBehaviour
	{
		[Serializable]
		public enum SFX
		{
			[InspectorName("UI/General/Kill")]
			Kill = 0,
			[InspectorName("UI/General/KillSkull")]
			KillSkull = 1,
			[InspectorName("UI/General/CooldownOver")]
			CooldownOver = 2,
			[InspectorName("Game/ItemPickup")]
			ItemPickup = 3,
			[InspectorName("Game/ItemDrop")]
			ItemDrop = 4,
			[InspectorName("UI/General/ZoneNext")]
			ZoneNext = 5,
			[InspectorName("UI/General/SelectUIElement")]
			SelectUIElement = 6,
			[InspectorName("Pings/PingPosition")]
			PingPosition = 7,
			[InspectorName("Pings/PingAlert")]
			PingAlert = 8,
			[InspectorName("Pings/PingEnemy")]
			PingEnemy = 9,
			[InspectorName("Pings/PingHelp")]
			PingHelp = 10,
			[InspectorName("Pings/PingEntity")]
			PingEntity = 11,
			[InspectorName("Pings/PingCancel")]
			PingCancel = 12,
			[InspectorName("UI/General/SelectWheelOpen")]
			SelectWheelOpen = 13,
			[InspectorName("UI/General/SelectWheelHover")]
			SelectWheelHover = 14,
			[InspectorName("UI/General/SelectUIElement2")]
			SelectUIElement2 = 15,
			[InspectorName("General/HitMarker")]
			HitMarker = 16,
			[InspectorName("General/BAPBAP")]
			BAPBAP = 17,
			[InspectorName("UI/Lobby/UIClaimedReward")]
			UIClaimedReward = 18,
			[InspectorName("UI/Lobby/Confirm1")]
			UIMenuConfirm1 = 19,
			[InspectorName("UI/Lobby/Confirm2")]
			UIMenuConfirm2 = 20,
			[InspectorName("UI/Lobby/ReadyButton")]
			UIMenuReadyButton = 21,
			[InspectorName("UI/Lobby/Invite")]
			UIMenuInvite = 22,
			[InspectorName("UI/Lobby/Abilities")]
			UIMenuAbilities = 23,
			[InspectorName("UI/Lobby/CharSelect")]
			UIMenuCharSelect = 24,
			[InspectorName("UI/Lobby/CharShow")]
			UIMenuCharShow = 25,
			[InspectorName("UI/Lobby/CharConfirm")]
			UIMenuCharConfirm = 26,
			[InspectorName("UI/Lobby/LockerEquip")]
			UIMenuLockerEquip = 27,
			[InspectorName("UI/Lobby/LockerEquipConfirm")]
			UIMenuLockerEquipConfirm = 28,
			[InspectorName("UI/Lobby/SettingsOpen")]
			UIMenuSettingsOpen = 29,
			[InspectorName("UI/Lobby/SettingsClose")]
			UIMenuSettingsClose = 30,
			[InspectorName("Game/CoinPickup")]
			CoinPickup = 31,
			[InspectorName("UI/Lobby/Message1")]
			UIMenuMessage1 = 32,
			[InspectorName("UI/Lobby/Message2")]
			UIMenuMessage2 = 33,
			[InspectorName("Game/UIStamp")]
			UIStamp = 34,
			[InspectorName("UI/Lobby/UIUnlockButton")]
			UIUnlockButton = 35,
			[InspectorName("UI/Lobby/UIClaimedCharacter")]
			UIClaimedCharacter = 36,
			[InspectorName("UI/Lobby/UIRankPromoted")]
			UIRankPromoted = 37,
			[InspectorName("UI/Lobby/UIPlayerJoin")]
			UIPlayerJoin = 38,
			[InspectorName("UI/Lobby/UICurrencyFractal")]
			UICurrencyFractal = 39,
			[InspectorName("UI/Lobby/UIAlertSupplyDrop")]
			UIAlertSupplyDrop = 40,
			[InspectorName("UI/General/UIAlertEnd")]
			UIAlertEnd = 41,
			[InspectorName("Game/JuicePickup")]
			JuicePickup = 42,
			[InspectorName("Game/JuiceDrop")]
			JuiceDrop = 43,
			[InspectorName("UI/Lobby/TeamJoined")]
			TeamJoined = 44,
			[InspectorName("UI/Lobby/MatchCountdownTick")]
			MatchCountdownTick = 45,
			[InspectorName("UI/Lobby/MatchCountdownLastTick")]
			MatchCountdownLastTick = 46,
			[InspectorName("Game/JellyCapPickup")]
			JellyCapPickup = 47,
			[InspectorName("Game/JellyCapReady")]
			JellyCapReady = 48,
			[InspectorName("Game/UniqueItemPickup")]
			UniqueItemPickup = 49,
			[InspectorName("UI/Lobby/GameModeOpen")]
			UIGameModeOpen = 50,
			[InspectorName("UI/Lobby/Hover")]
			UIHover = 51,
			[InspectorName("UI/Lobby/InfographicOpen")]
			InfographicOpen = 52,
			[InspectorName("UI/Lobby/InfographicNext")]
			InfographicNext = 53,
			[InspectorName("Game/SnowCapPickup")]
			SnowCapPickup = 54,
			[InspectorName("Game/SnowCapReady")]
			SnowCapReady = 55,
			[InspectorName("Game/MetalBootsPickup")]
			MetalBootsPickup = 56,
			[InspectorName("Game/ExplosionCapPickup")]
			ExplosionCapPickup = 57,
			[InspectorName("UI/Lobby/MatchLost")]
			MatchLost = 58,
			[InspectorName("UI/General/TeammateAttacked")]
			TeammateAttacked = 59,
			[InspectorName("UI/General/TeammateKilled")]
			TeammateKilled = 60,
			[InspectorName("UI/General/ClickClick")]
			ClickClick = 61,
			[InspectorName("UI/Lobby/SummaryStatsOpen")]
			SummaryStatsOpen = 62,
			[InspectorName("UI/Lobby/SummaryCHBOpen")]
			SummaryCHBOpen = 63,
			[InspectorName("UI/Lobby/SummaryCHBObtain")]
			SummaryCHBObtain = 64,
			[InspectorName("UI/Lobby/ShopCardFadeIn")]
			ShopCardFadeIn = 65,
			[InspectorName("UI/Lobby/ShopCardHover")]
			ShopCardHover = 66,
			[InspectorName("UI/Lobby/ShopCardFlipGeneric")]
			ShopCardFlipGeneric = 67,
			[InspectorName("Game/UIMasteryBadge")]
			UIMasteryBadge = 68,
			[InspectorName("UI/Lobby/SummaryCHBComplete")]
			SummaryCHBComplete = 69,
			[InspectorName("UI/Lobby/SummaryCHBStart")]
			SummaryCHBStart = 70,
			[InspectorName("UI/Lobby/ShopCardFlipBanner")]
			ShopCardFlipBanner = 71,
			[InspectorName("UI/Lobby/ShopCardFlipCurrency")]
			ShopCardFlipCurrency = 72,
			[InspectorName("UI/Lobby/ShopCardFlipSticker")]
			ShopCardFlipSticker = 73,
			[InspectorName("UI/Lobby/ShopCardOpenUnflipped")]
			ShopCardOpenUnflipped = 74,
			[InspectorName("UI/Lobby/SummaryCHBSwoosh")]
			SummaryCHBSwoosh = 75,
			[InspectorName("UI/Lobby/LoginButton")]
			LoginButton = 76,
			[InspectorName("Game/GoldRockSpawnGold")]
			GoldRockSpawnGold = 77,
			[InspectorName("Game/Downed")]
			Downed = 78,
			[InspectorName("Game/SquadWipe")]
			SquadWipe = 79,
			[InspectorName("UI/Lobby/FriendsOpen")]
			FriendsOpen = 80,
			[InspectorName("UI/Lobby/FriendsClose")]
			FriendsClose = 81,
			[InspectorName("UI/Lobby/FriendsClosedParty")]
			FriendsClosedParty = 82,
			[InspectorName("UI/Lobby/FriendsCodeCopy")]
			FriendsCodeCopy = 83,
			[InspectorName("UI/Lobby/FriendsSendRequest")]
			FriendsSendRequest = 84,
			[InspectorName("UI/Lobby/NotificationMsg")]
			NotificationMsg = 85,
			[InspectorName("Game/ConsumablePickup")]
			ConsumablePickup = 86,
			[InspectorName("Game/ConsumableDrop")]
			ConsumableDrop = 87,
			[InspectorName("Pings/PingStickTogether")]
			PingStickTogether = 88,
			[InspectorName("Pings/PingWait")]
			PingWait = 89,
			[InspectorName("UI/Lobby/ChallengeOpen")]
			ChallengeOpen = 90,
			[InspectorName("UI/Lobby/ChallengeSwoosh")]
			ChallengeSwoosh = 91,
			[InspectorName("UI/Lobby/ChallengePrizeCountUp")]
			ChallengePrizeCountUp = 92,
			[InspectorName("UI/Lobby/ChallengePrizeFinished")]
			ChallengePrizeFinished = 93,
			[InspectorName("UI/Lobby/FriendInvitePopUp")]
			FriendInvitePopUp = 94,
			[InspectorName("UI/Lobby/ChallengePostGameWin")]
			ChallengePostGameWin = 95,
			[InspectorName("UI/Augments/AugmentHover")]
			AugmentHover = 96,
			[InspectorName("UI/Augments/AugmentClose")]
			AugmentClose = 97,
			[InspectorName("UI/Augments/AugmentOpen")]
			AugmentOpen = 98,
			[InspectorName("UI/Augments/AugmentReadyEnd")]
			AugmentReadyEnd = 99,
			[InspectorName("UI/Augments/AugmentSelect")]
			AugmentSelect = 100,
			[InspectorName("UI/Augments/AugmentReroll")]
			AugmentReroll = 101,
			[InspectorName("UI/PreMatch/MatchFound")]
			MatchFound = 102,
			[InspectorName("UI/PreMatch/CharacterPick")]
			CharacterPick = 103,
			[InspectorName("UI/PreMatch/LockCharacter")]
			LockCharacter = 104,
			[InspectorName("UI/PreMatch/SpawnStart")]
			SpawnStart = 105,
			[InspectorName("UI/PreMatch/SpawnSelect")]
			SpawnSelect = 106,
			[InspectorName("UI/PreMatch/SpawnSuggest")]
			SpawnSuggest = 107,
			[InspectorName("UI/PreMatch/SpawnLocked")]
			SpawnLocked = 108,
			[InspectorName("UI/PreMatch/Tick1")]
			Tick1 = 109,
			[InspectorName("UI/PreMatch/Tick2")]
			Tick2 = 110,
			[InspectorName("Game/LootableDropFailed")]
			LootableDropFailed = 111,
			[InspectorName("Game/Passive/Adrenaline")]
			Adrenaline = 112,
			[InspectorName("Game/Error")]
			Error = 113
		}

		public enum Music
		{
			Lobby = 0,
			VictoryStart = 1,
			VictoryLoop = 2,
			MatchStart = 3,
			LobbyNight = 4,
			ChallengeStart = 5,
			ChallengeLoop = 6,
			ChallengeStartRev = 7,
			ChallengeLoopRev = 8
		}

		[CompilerGenerated]
		public sealed class _003CCrossFadeAudioSourcesCoroutine_003Ed__86 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public AudioSource currentAudioSource;

			public AudioSource nextAudioSource;

			public float crossFadeDuration;

			public float currentAudioSourceVolume;

			public float newAudioSourceVolume;

			public Action onFinishedAction;

			[NonSerialized]
			public float _003Ctime_003E5__2;

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
			public _003CCrossFadeAudioSourcesCoroutine_003Ed__86(int _003C_003E1__state)
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
		public sealed class _003CFadeAudioSourceIn_003Ed__82 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public AudioSource audioSource;

			public AudioClip newClip;

			public float fadeDuration;

			[NonSerialized]
			public float _003Ctime_003E5__2;

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
			public _003CFadeAudioSourceIn_003Ed__82(int _003C_003E1__state)
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
		public sealed class _003CFadeAudioSourceOutCoroutine_003Ed__84 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public AudioSource audioSource;

			public float fadeDuration;

			[NonSerialized]
			public float _003CstartingVolume_003E5__2;

			[NonSerialized]
			public float _003Ctime_003E5__3;

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
			public _003CFadeAudioSourceOutCoroutine_003Ed__84(int _003C_003E1__state)
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
		public sealed class _003CPlayChallengeLobbyMusicCoroutine_003Ed__67 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public AudioManager _003C_003E4__this;

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
			public _003CPlayChallengeLobbyMusicCoroutine_003Ed__67(int _003C_003E1__state)
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
		public sealed class _003CPlayMatchStartMusicCoroutine_003Ed__74 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public AudioManager _003C_003E4__this;

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
			public _003CPlayMatchStartMusicCoroutine_003Ed__74(int _003C_003E1__state)
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
		public sealed class _003CPlayVictoryMusicCoroutine_003Ed__72 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public AudioManager _003C_003E4__this;

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
			public _003CPlayVictoryMusicCoroutine_003Ed__72(int _003C_003E1__state)
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

		[NamedArray(typeof(SFX), 0)]
		[SerializeField]
		public AudioClip[] sfxClips;

		[NamedArray(typeof(Music), 0)]
		[SerializeField]
		public AudioClip[] musicClips;

		[SerializeField]
		public AudioClip[] gameProgressMusicClips;

		[SerializeField]
		public AudioClip[] predictedSfxClips;

		[SerializeField]
		[Header("References")]
		public AudioSource masterAudioSource;

		[SerializeField]
		public AudioSource sfxAudioSource;

		[SerializeField]
		public AudioSource pingsAudioSource;

		[SerializeField]
		public AudioSource uiAudioSource;

		[SerializeField]
		public AudioSource uiBarProgressAudioSource;

		[SerializeField]
		public AudioSource lobbyMusicAudioSource;

		[SerializeField]
		public AudioSource inGameMusicAudioSource;

		[SerializeField]
		public AudioSource gameEndMusicAudioSource;

		[SerializeField]
		public AudioSource matchStartMusicAudioSource;

		[SerializeField]
		public AudioSource ambientAudioSource;

		[SerializeField]
		public AudioSource ambientAudioSourceNight;

		[SerializeField]
		[Header("BR Zone SFX")]
		public float zoneEnterSfxVolume;

		[SerializeField]
		public AudioSource zoneEnterAudioSource;

		[SerializeField]
		public AudioFade zoneEnterAudioFade;

		[SerializeField]
		public float zoneLoopSfxVolume;

		[SerializeField]
		public float zoneLoopFadeDuration;

		[SerializeField]
		public AudioSource zoneLoopAudioSource;

		[SerializeField]
		public AudioFade zoneLoopAudioFade;

		[SerializeField]
		[Header("Crit SFX")]
		public AudioClipData critSfxRangedData;

		[SerializeField]
		public AudioClipData critSfxMeleeData;

		[SerializeField]
		public AudioClipData critSfxMagicData;

		[Header("Mixer")]
		[SerializeField]
		public AudioMixer masterMixer;

		[SerializeField]
		public AudioMixerSnapshot masterSnapshot;

		[SerializeField]
		public AudioMixerSnapshot zoneSnapshot;

		[SerializeField]
		public AudioLowPassFilter zoneLowPassFilter;

		[Header("Prefabs")]
		[SerializeField]
		public GameObject sfxPrefab;

		[SerializeField]
		[Header("Night Time Configs")]
		[Range(0f, 24f)]
		public int nightTimeStartHour;

		[SerializeField]
		[Range(0f, 24f)]
		public int nightTimeEndHour;

		[NonSerialized]
		public Dictionary<AudioClip, int> predictedSfxPrefabToId;

		[NonSerialized]
		public Dictionary<int, List<ActiveSfxData>> activeSfxDataByNetId;

		[NonSerialized]
		public Dictionary<int, List<ActiveSfxData>> activeGlobalSfxDataByNetId;

		[NonSerialized]
		public List<AudioBufferData> bufferClips;

		[NonSerialized]
		public float victoryMusicStartLength;

		[NonSerialized]
		public float generalVolume;

		[NonSerialized]
		public float originalSfxPrefabMinDistance;

		[NonSerialized]
		public float originalSfxPrefabMaxDistance;

		[NonSerialized]
		public AudioSource[] ambientAudioSourceExtra;

		public AudioSource AmbientAudioSource => null;

		public static AudioManager Instance => null;

		public void Awake()
		{
		}

		public void LateUpdate()
		{
		}

		public int GetPredSfxId(AudioClip audioClip)
		{
			return 0;
		}

		public int SpawnSfx(SfxEventData eventData, uint netId)
		{
			return 0;
		}

		public void DestroyOldestSfx(SfxEventData eventData, uint netId)
		{
		}

		public bool DestroySfx(SfxEventData eventData, uint netId)
		{
			return false;
		}

		public void SpawnGlobalSfxAtPosition(SfxEventData sfxEventData, uint netId, float distMultiplier, float minDist, SfxTeamTarget teamTarget = SfxTeamTarget.All, int teamId = -1)
		{
		}

		public void DestroyGlobalSfxAtPosition(int sfxId, uint netId)
		{
		}

		public void ClearGlobalSfxIds()
		{
		}

		public GameObject SpawnSfxInstance(AudioClipData audioClipData, Vector3 worldPos, float sizeMultiplier = 1f, Transform parent = null, bool destroyByClipTtl = true, bool doLoop = false, float minAudioDistance = 0f, bool buffer = false, float delay = 0f)
		{
			return null;
		}

		public GameObject SpawnSfxInstance(AudioClip clip, Vector3 worldPos, float pitchSpread = 0f, float volume = 1f, float sizeMultiplier = 1f, Transform parent = null, bool destroyByClipTtl = true, bool doLoop = false, float minAudioDistance = 0f, bool buffer = false, float delay = 0f)
		{
			return null;
		}

		public void DespawnSfxInstance(GameObject sfxInstance, float delay = 0f)
		{
		}

		public void SpawnSfxAtPosition(SfxEventData sfxEventData, float distMultiplier, float minDist)
		{
		}

		public void Play2DSFX(SFXData sfxData, Mixer mixer = Mixer.Master)
		{
		}

		public void Play2DSFX(SFX sfx, float volume = 1f, float pitchSpread = 0f, Mixer mixer = Mixer.Master)
		{
		}

		public void Play2DSFX(AudioClipData clipData, Mixer mixer = Mixer.Master)
		{
		}

		public void Play2DSFX(AudioClip clip, float volume = 1f, float pitchSpread = 0f, Mixer mixer = Mixer.Master)
		{
		}

		public bool IsNightTime()
		{
			return false;
		}

		public void PlayLobbyMusic(float fadeDuration = 1f)
		{
		}

		public void StopLobbyMusic(float fadeDuration = 1f)
		{
		}

		[IteratorStateMachine(typeof(_003CPlayChallengeLobbyMusicCoroutine_003Ed__67))]
		public IEnumerator PlayChallengeLobbyMusicCoroutine()
		{
			return null;
		}

		public void SetLobbyMusicNoFilter()
		{
		}

		public void SetLobbyMusicFilter()
		{
		}

		public void PlayVictoryMusic()
		{
		}

		public void StopVictoryMusic(float fadeOutDuration = 1f)
		{
		}

		[IteratorStateMachine(typeof(_003CPlayVictoryMusicCoroutine_003Ed__72))]
		public IEnumerator PlayVictoryMusicCoroutine()
		{
			return null;
		}

		public void PlayMatchStartMusic(float waitTimeDuration = 20f)
		{
		}

		[IteratorStateMachine(typeof(_003CPlayMatchStartMusicCoroutine_003Ed__74))]
		public IEnumerator PlayMatchStartMusicCoroutine(float waitTimeDuration)
		{
			return null;
		}

		public void StopAmbient(float fadeDuration = 1f)
		{
		}

		public void PlayNightTimeAmbience()
		{
		}

		public void StopNightTimeAmbience()
		{
		}

		public void PlayInGameMusic(Music music, float fadeDuration = 1f)
		{
		}

		public void StopInGameMusic(float fadeDuration = 1f)
		{
		}

		public void PlayMatchProgressionMusic(float normMatchProgress)
		{
		}

		public void StopMatchProgressionMusic(float fadeOutDuration = 1f)
		{
		}

		[IteratorStateMachine(typeof(_003CFadeAudioSourceIn_003Ed__82))]
		public IEnumerator FadeAudioSourceIn(AudioSource audioSource, AudioClip newClip, float fadeDuration = 1f)
		{
			return null;
		}

		public Coroutine FadeAudioSourceOut(AudioSource audioSource, float fadeDuration = 1f)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CFadeAudioSourceOutCoroutine_003Ed__84))]
		public IEnumerator FadeAudioSourceOutCoroutine(AudioSource audioSource, float fadeDuration = 1f)
		{
			return null;
		}

		public void CrossFadeAudioSources(AudioSource currentAudioSource, AudioSource nextAudioSource, out Coroutine coroutine, float crossFadeDuration = 1f, Action onFinishedAction = null, float currentAudioSourceVolume = 1f, float newAudioSourceVolume = 1f)
		{
			coroutine = null;
		}

		[IteratorStateMachine(typeof(_003CCrossFadeAudioSourcesCoroutine_003Ed__86))]
		public IEnumerator CrossFadeAudioSourcesCoroutine(AudioSource currentAudioSource, AudioSource nextAudioSource, float crossFadeDuration = 1f, Action onFinishedAction = null, float currentAudioSourceVolume = 1f, float newAudioSourceVolume = 1f)
		{
			return null;
		}

		public void SetZoneOverlayToggle(bool isEnabled)
		{
		}

		public void PlayUIBarProgress()
		{
		}

		public void StopUIBarProgress()
		{
		}

		public void SetMixerMasterSnapshot(float transitionDuration = 0.25f)
		{
		}

		public void SetMixerZoneSnapshot(float transitionDuration = 0.25f)
		{
		}

		public void SetGeneralVolume(float value)
		{
		}

		public void MuteGeneralVolume(bool mute)
		{
		}

		public void SetMixerMusicVolume(float value)
		{
		}

		public void SetMixerGameMusicVolume(float value)
		{
		}

		public void SetMixerAmbientVolume(float value)
		{
		}

		public void SetMixerSfxVolume(float value)
		{
		}

		public void SetMixerPingsVolume(float value)
		{
		}

		public void SetMixerUIVolume(float value)
		{
		}

		public void SetMixerLowPass(bool isEnabled)
		{
		}

		public void SetMixerChannelVolume(string paramName, float value)
		{
		}
	}
}
