using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Entities;
using BAPBAP.Game;
using BAPBAP.Local;
using BAPBAP.Player;
using BAPBAP.Systems;
using BAPBAP.UI;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

namespace BAPBAP.Debugging
{
	public class DebugGameplayManager : MonoBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CUpdatePing_003Ed__232 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public DebugGameplayManager _003C_003E4__this;

			public float seconds;

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
			public _003CUpdatePing_003Ed__232(int _003C_003E1__state)
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
		public DebugManager debugManager;

		[NonSerialized]
		public GameManager gameManager;

		[NonSerialized]
		public SystemManager systemManager;

		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public Camera cam;

		[NonSerialized]
		public CameraController cameraController;

		[SerializeField]
		[Header("References")]
		public Material debugMaterial;

		[SerializeField]
		public Material navMeshDebugMaterial;

		[SerializeField]
		public Material hitboxMaterial;

		[SerializeField]
		public Material hitboxMaterialDisabled;

		[SerializeField]
		public Material hitboxObstacleMaterial;

		[SerializeField]
		public Material hitboxObstacleMaterialDisabled;

		[SerializeField]
		public Material hurtboxMaterial;

		[SerializeField]
		public Material skySphereMat;

		[SerializeField]
		public Material skySphereChromaMat;

		[SerializeField]
		public Mesh cubeMesh;

		[SerializeField]
		public Mesh sphereMesh;

		[SerializeField]
		public Mesh cylinderMesh;

		[SerializeField]
		public GameObject canvasBlackBG;

		[SerializeField]
		public GameObject skySpherePrefab;

		[SerializeField]
		public GameObject debugGridPrefab;

		[SerializeField]
		public bool loadMapDynamic;

		[SerializeField]
		public bool hpBarsEnabled;

		[SerializeField]
		public bool hpBarNamesEnabled;

		[SerializeField]
		public bool pointsUIEnabled;

		[SerializeField]
		public bool interactWorldUIEnabled;

		[SerializeField]
		public bool stickerUIEnabled;

		[SerializeField]
		public bool playerUIEnabled;

		[SerializeField]
		public bool minimapUIEnabled;

		[SerializeField]
		public GameObject thirdPersonCursor;

		[SerializeField]
		public GameObject thirdPersonGroundTarget;

		[Header("Battle Royale")]
		[SerializeField]
		public GameObject[] cmdSupplyDropList;

		[Header("Other")]
		[SerializeField]
		public Text charStatsText;

		[SerializeField]
		public Text rigDebugText;

		[SerializeField]
		public Text pingAllText;

		[SerializeField]
		public Material textureMapDebugMaterial;

		[SerializeField]
		public UniversalRendererData universalRendererData;

		[SerializeField]
		public GameObject[] squadOpEntitySpawnCmds;

		[SerializeField]
		public GameObject uiCursorControllerPrefab;

		[Header("Debug Settings")]
		[SerializeField]
		public bool displayVfx;

		[SerializeField]
		public bool displayHitbox;

		[SerializeField]
		public bool displayChar;

		[SerializeField]
		public bool displayCharHurtbox;

		[SerializeField]
		public bool displayCharMesh;

		[SerializeField]
		public bool displayCharBaseIndicator;

		[SerializeField]
		public bool displayCharAnimator;

		[SerializeField]
		public bool serverEntityViewEnabled;

		[SerializeField]
		public bool graphicRaycastersEnabled;

		[SerializeField]
		public bool uiAllEnabled;

		[SerializeField]
		public bool enableFoW;

		[SerializeField]
		public bool enableFoWRendering;

		[SerializeField]
		public bool seeHiddenEntities;

		[SerializeField]
		public bool brZoneTimeEnabled;

		[SerializeField]
		public bool displayNavmesh;

		[SerializeField]
		public bool cinematicModeEnabled;

		[SerializeField]
		public bool mapLoadingLogsEnabled;

		[SerializeField]
		public bool mapLoadingMeshesLogEnabled;

		[SerializeField]
		public bool environmentMeshesEnabled;

		[SerializeField]
		public bool environmentChunkLinesEnabled;

		[SerializeField]
		public bool updatePingAllEnabled;

		[SerializeField]
		public bool cursorToggleEnabled;

		[SerializeField]
		public bool mapRotated;

		[SerializeField]
		public float speedHackSpeed;

		[SerializeField]
		public bool trainingeNpcRespawn;

		[SerializeField]
		public bool silhouetteShaderEnabled;

		[SerializeField]
		public bool envAlphaOcclusionEnabled;

		[SerializeField]
		public bool itemsVisibility;

		[SerializeField]
		public bool allyVisionEnabled;

		[SerializeField]
		public bool inGmeProgressionMusicEnabled;

		[SerializeField]
		public bool expGroundFxEnabled;

		[NonSerialized]
		public UICursorController uiCursorController;

		[NonSerialized]
		public GameObject spawnedSkySphereObj;

		[NonSerialized]
		public float originalCameraFarClipPlane;

		[NonSerialized]
		public bool charStatsEnabled;

		[NonSerialized]
		public float charStatsUpdateTimer;

		[NonSerialized]
		public bool debugRigEnabled;

		[NonSerialized]
		public float debugRigUpdateTimer;

		[NonSerialized]
		public Transform[] localCharRig;

		[NonSerialized]
		public GameObject debugNavHolder;

		[NonSerialized]
		public bool debugLastPressedKey;

		[NonSerialized]
		public bool addedCmds;

		public EntityVisibility[] allyVisionSpawnedEntityVis;

		[SerializeField]
		public KeyCode sprintHackKey;

		[InspectorButton("OnSaveSprintKey")]
		[SerializeField]
		public bool SaveSprintKeyButton;

		[NonSerialized]
		public bool listeningForNewSprintKey;

		[SerializeField]
		public KeyCode repeatLastCommandKey;

		[SerializeField]
		public float repeatLastCommandHoldDelay;

		[SerializeField]
		public float repeatLastCommandHoldRate;

		[NonSerialized]
		public float repeatLastCommandHoldTimer;

		[NonSerialized]
		public List<Tuple<KeyCode, string>> keyBindings;

		[NonSerialized]
		public PlayerManager[] players;

		[NonSerialized]
		public Coroutine currentUpdatePingCoroutine;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnSaveSprintKey()
		{
		}

		public void SaveSprintKey(KeyCode keyCode)
		{
		}

		public void UpdateBinds()
		{
		}

		public bool TryConvertStringToKeyCode(string keyString, out KeyCode keyCode)
		{
			keyCode = default(KeyCode);
			return false;
		}

		public void ManagedUpdate()
		{
		}

		public bool HasOpAccess(DebugManager.OperatorLevel level = DebugManager.OperatorLevel.Admin)
		{
			return false;
		}

		public void Bind(string keyCodeToParse, string cmdMsg)
		{
		}

		public void RemoveBind(string keyCodeToParse)
		{
		}

		public void ResetBinds()
		{
		}

		public void TryEndMatch()
		{
		}

		public void LobbyForceStartMatch()
		{
		}

		public void UIMainCanvasToggle()
		{
		}

		public void UIToggleAllGraphicRaycasters()
		{
		}

		public void UIAllToggle()
		{
		}

		public void UIAllToggle(bool isEnabled)
		{
		}

		public void SetUIAll(bool isEnabled)
		{
		}

		public void UIToggleStats(bool isEnabled)
		{
		}

		public void UIToggleMinimap()
		{
		}

		public void UIToggleRecordingMode()
		{
		}

		public void UIHpBarsToggle()
		{
		}

		public void UIHpBarsNameToggle()
		{
		}

		public void UIPlayerUIToggle()
		{
		}

		public void UIInteractableInfoUIToggle()
		{
		}

		public void UITeammateUIToggle()
		{
		}

		public void UIPointsToggle()
		{
		}

		public void UIWorldInteractToggle()
		{
		}

		public void UIKillfeedToggle()
		{
		}

		public void UIMessagesToggle()
		{
		}

		public void UIScreenEffectsToggle()
		{
		}

		public void UIChatToggle()
		{
		}

		public void UIClearChat()
		{
		}

		public void ClearPlayerPrefs()
		{
		}

		public void ClearEditorPrefs()
		{
		}

		public void UIToggleUtilities()
		{
		}

		public void UIToggleSpectator()
		{
		}

		public void UITogglePings()
		{
		}

		public void UIToggleStickers()
		{
		}

		public void UICursorSetVisibility(bool isVisible)
		{
		}

		public void UICursorToggle()
		{
		}

		public void UICursorDebugBothToggle()
		{
		}

		public void ToggleNavmeshVisibility()
		{
		}

		public void SetNavmeshVisibility(bool doDisplay)
		{
		}

		public void HitboxDebug()
		{
		}

		public void ToggleHitboxDebug(GameObject hitbox)
		{
		}

		public void HitboxVFXDebug()
		{
		}

		public void CharacterHurtboxDebug()
		{
		}

		public void ToggleCharDebugHurtbox(CharMaterial charMaterial)
		{
		}

		public void CharacterAnimatorDebug()
		{
		}

		public void CharacterMeshToggle()
		{
		}

		public void CharBaseIndicatorToggle()
		{
		}

		public void CharactersVisibilityToggle()
		{
		}

		public void LocalCharacterVisibilityToggle()
		{
		}

		public void ToggleCharVisibility(CharMaterial charMaterial, bool display)
		{
		}

		public void ServerEntityViewToggle()
		{
		}

		public void CharStatsToggle()
		{
		}

		public void CharKillCurrent()
		{
		}

		public void CharKillAll()
		{
		}

		public void RespawnAltarResetActiveAll()
		{
		}

		public void IndicatorDisplayToggle()
		{
		}

		public void SetFoWToggle()
		{
		}

		public void SetFoWEnabled(bool isEnabled)
		{
		}

		public void FoWRenderingToggle()
		{
		}

		public void SetFoWRenderingEnabled(bool isEnabled)
		{
		}

		public void FoWRenderingAllClientsToggle()
		{
		}

		public void FoWRenderingTexQuality(int texQuality)
		{
		}

		public void FoWRenderingAAQuality(int aaQuality)
		{
		}

		public void FoWBlurToggle()
		{
		}

		public void ShadowmapToggle()
		{
		}

		public void GetTickRates()
		{
		}

		public void Unpause()
		{
		}

		public void SlowMotionToggle()
		{
		}

		public void ZoneEnabledToggle()
		{
		}

		public void ZoneSetEnabled(bool isEnabled)
		{
		}

		public void ZoneNext()
		{
		}

		public void ZoneRestart()
		{
		}

		public void AddAugmentSelectionRound()
		{
		}

		public void AddAugmentSelection()
		{
		}

		public void AddAugmentSelection(int tierId)
		{
		}

		public void ResetAllEntities()
		{
		}

		public void SetNoCooldownMode(bool isEnabled)
		{
		}

		public void SetInvincibilityMode(bool isEnabled)
		{
		}

		public void SetNoCooldownModeAll(bool isEnabled)
		{
		}

		public void SetInvincibilityModeAll(bool isEnabled)
		{
		}

		public void SetNoAggro(bool isEnabled)
		{
		}

		public void SetNoAggroAll(bool isEnabled)
		{
		}

		public void SetCharSelectorAll(bool isEnabled)
		{
		}

		public void HealMaxHpAll()
		{
		}

		public void SpawnBrEvent(int id)
		{
		}

		public void RespawnCharacter()
		{
		}

		public void RespawnDeadCharacterAll()
		{
		}

		public void ResurrectDownedCharacter()
		{
		}

		public void ResurrectDownedCharacterAll()
		{
		}

		public void ClearWorldItems()
		{
		}

		public void ClearWorldTombstones()
		{
		}

		public void SetAllItemVisibility(bool isEnabled)
		{
		}

		public void SetAllyVisionEnabledAll(bool isEnabled)
		{
		}

		public void SetAllyVisionEnabled(bool isEnabled)
		{
		}

		public void AddSharedVisionToChar(EntityManager entityManager)
		{
		}

		public void RemoveSharedVisionFromChar(EntityManager entityManager)
		{
		}

		public void SetNoClip(bool isEnabled)
		{
		}

		public void CmdSetGlobalThirdPersonMode(bool isEnabled)
		{
		}

		public void SetThirdPersonMode(bool isEnabled)
		{
		}

		public void SetPlayerName(string playerName)
		{
		}

		public void TestNavMesh(int numTests, float distance, float boundsMax)
		{
		}

		public void ToggleRigVisibility(bool enable)
		{
		}

		public void CinematicModeToggle()
		{
		}

		public void CinematicModeEnable()
		{
		}

		public void CinematicModeDisable()
		{
		}

		public void CinematicModeSkyChromaToggle()
		{
		}

		public void DisposeNetworkPrefabPools()
		{
		}

		public void MapLoadingLogsToggle()
		{
		}

		public void MapLoadingMeshesLogToggle()
		{
		}

		public void SetLoadMapDynamic(bool isEnabled)
		{
		}

		public void SetFogEnabled(bool enabled)
		{
		}

		public void ChangeSkinWeight(int boneWeight)
		{
		}

		public void ToggleCompleteLogin()
		{
		}

		public void ToggleFullscreenButton()
		{
		}

		public void MapSetRotatedAllEnabled(bool isEnabled)
		{
		}

		public void MapToggleRotatedEnabled()
		{
		}

		public void MapSetRotatedEnabled(bool isEnabled)
		{
		}

		public void TrainingToggleNpcRespawn()
		{
		}

		public void PrintAllEntities()
		{
		}

		public void PrintAllSystemListeners()
		{
		}

		public void PrintSceneCounts()
		{
		}

		public void ToggleRendering()
		{
		}

		public void ToggleCheckCameraObscurance()
		{
		}

		public void MapMeshesToggle()
		{
		}

		public void MapToggleChunkLines()
		{
		}

		public void MapToggleDynamicChunkDebug()
		{
		}

		public void EnvDebugSurfaceMap()
		{
		}

		public void EnvDebugAmbienceMap()
		{
		}

		public Texture2D GridIntIntoTextureMap(byte[][] grid, float alpha, Color[] colorsByIndex = null)
		{
			return null;
		}

		public void SeeHiddenEntitiesToggle()
		{
		}

		public void TrainingAutoRespawnToggle()
		{
		}

		public void PlayFMODEvent(string path)
		{
		}

		public void EnableVoicelines(string pass)
		{
		}

		public void DisableVoicelines()
		{
		}

		public void PingShowAllToggle()
		{
		}

		[IteratorStateMachine(typeof(_003CUpdatePing_003Ed__232))]
		public IEnumerator UpdatePing(float seconds)
		{
			return null;
		}

		public void UpdatePing()
		{
		}

		public void RealtimeShadowsPrintSettings()
		{
		}

		public void SpawnShadowsTest()
		{
		}

		public void ApplyStatusEffect(int statusEffectId, float duration)
		{
		}

		public void ModifyTriggerLocks(bool apply)
		{
		}

		public void AddPassive(int passiveId)
		{
		}

		public void RemovePassive(int passiveId)
		{
		}

		public void AddGameModifier(int gameModifierId)
		{
		}

		public void RemoveGameModifier(int gameModifierId)
		{
		}

		public void SpawnBot()
		{
		}

		public void SpawnBot1(int charId)
		{
		}

		public void SpawnBot2(int charId = -1, bool enableAI = true)
		{
		}

		public void SpawnBot3(int charId = -1, bool enableAI = true, bool isAlly = false)
		{
		}

		public void SpawnBot4(int charId = -1, bool enableAI = true, bool isAlly = false, bool isInvincible = false)
		{
		}

		public void SpawnBotChar(int charId = -1, bool enableAI = true, bool isAlly = false, bool isInvincible = false, BotDifficulty difficulty = BotDifficulty.Easy)
		{
		}

		public void SvSpawnBot(int charId, Vector3 spawnPos = default(Vector3), bool enableAI = true, int teamId = -1, bool isInvincible = false, BotDifficulty difficulty = BotDifficulty.Medium)
		{
		}

		public void SpawnEntity(int entityPrefabId, DebugManager.OperatorLevel opLevel = DebugManager.OperatorLevel.Admin)
		{
		}

		public void AddPassiveToChar(int passiveId = 0)
		{
		}

		public void RemovePassiveOnChar(int passiveId = 0)
		{
		}

		public void ResetMetagame()
		{
		}

		public void AddXp(int xpAmount)
		{
		}

		public void AddXpChar(int charId, int xpAmount)
		{
		}

		public void RedeemGold(int goldAmount)
		{
		}

		public void AddAsset(int assetId)
		{
		}

		public void AddCharacterAssets()
		{
		}

		public void AddEmoteAssets()
		{
		}

		public void AddTombstoneAssets()
		{
		}

		public void AddPlayerBannerAssets()
		{
		}

		public void AddMasteryBadgeAssets()
		{
		}

		public void AddSkinAssets()
		{
		}

		public void SetCharSkinSelected(int skinId)
		{
		}

		public void EnableIaps(bool enable)
		{
		}

		public void SetCreatorCode(string code)
		{
		}

		public void JoinLobby(string lobbyId)
		{
		}

		public void ToggleDevLobbyButton()
		{
		}

		public void SetAutoQualityPreset()
		{
		}

		public string FormatAllSystemListeners()
		{
			return null;
		}

		public string FormatSceneCounts()
		{
			return null;
		}

		public void EnableShaderKeyword(string shaderFeature)
		{
		}

		public void DisableShaderKeyword(string shaderFeature)
		{
		}

		public void SetSilhouetteShaderAll(bool isEnabled)
		{
		}

		public void SetSilhouetteShaderEnabled(bool isEnabled)
		{
		}

		public void SetEnvAlphaOcclusion(bool isEnabled)
		{
		}

		public void SetEnvAlphaOcclusionEnabled(bool isEnabled)
		{
		}

		public void URPFeatureToggle(string featureName)
		{
		}
	}
}
