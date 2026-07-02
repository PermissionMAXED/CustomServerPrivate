using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Localisation;
using BAPBAP.UI;
using OccaSoftware.Buto.Runtime;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace BAPBAP.Local
{
	public class LocalSavedData : MonoBehaviour
	{
		public enum QualityPresets
		{
			Auto = 0,
			Low = 1,
			Medium = 2,
			High = 3,
			Ultra = 4,
			Custom = 5
		}

		public enum SupportedRegion
		{
			NA = 0,
			EU = 1
		}

		public enum CursorMode
		{
			Auto = 0,
			Free = 1,
			Confined = 2
		}

		public enum CursorOptions
		{
			Default = 0,
			Square = 1,
			Cross = 2,
			CrossDoted = 3,
			Plus = 4,
			Dot = 5
		}

		public enum CursorColor
		{
			White = 0,
			Orange = 1,
			Red = 2,
			Pink = 3,
			Purple = 4,
			Blue = 5,
			DarkBlue = 6,
			Green = 7
		}

		public enum DisplayMode
		{
			Fullscreen = 0,
			BorderlessFullscreen = 1,
			Windowed = 2
		}

		public enum AntialiasingMode
		{
			None = 0,
			MSAAx2 = 1,
			MSAAx4 = 2,
			MSAAx8 = 3
		}

		public enum FrameRateLimitMode
		{
			Default = 0,
			_30_FPS = 1,
			_60_FPS = 2,
			_120_FPS = 3,
			_144_FPS = 4,
			Unlimited = 5
		}

		public enum VSyncMode
		{
			Disabled = 0,
			Enabled = 1
		}

		public enum RealtimeShadowsMode
		{
			None = 0,
			Low = 1,
			Medium = 2,
			High = 3
		}

		public enum SSAOMode
		{
			None = 0,
			Enabled = 1
		}

		public enum BloomMode
		{
			None = 0,
			Enabled = 1
		}

		public enum DOFMode
		{
			None = 0,
			Enabled = 1
		}

		public enum CharLODMode
		{
			Low = 0,
			Medium = 1,
			High = 2
		}

		public enum CharXRayMode
		{
			None = 0,
			Enabled = 1
		}

		public enum ReflectionsMode
		{
			None = 0,
			Low = 1,
			Medium = 2,
			High = 3
		}

		public enum VolumetricsMode
		{
			None = 0,
			Enabled = 1
		}

		public enum InputDevice
		{
			Auto = 0,
			KeyboardAndMouse = 1,
			Gamepad = 2
		}

		public class Property
		{
			public string playerPrefsKey;

			public bool applyOnStart;

			public virtual void LoadState()
			{
			}

			public virtual void SaveState()
			{
			}

			public virtual void Apply()
			{
			}
		}

		[Serializable]
		public class PropertyFloat : Property
		{
			public float value;

			public float defaultValue;

			public readonly Action<float> applyAction;

			public override void LoadState()
			{
			}

			public override void SaveState()
			{
			}

			public override void Apply()
			{
			}

			public PropertyFloat(string playerPrefsKey, float defaultValue, Action<float> applyAction)
			{
			}
		}

		[Serializable]
		public class PropertyInt : Property
		{
			public delegate int IntDelegate(int v);

			public int value;

			public int defaultValue;

			public readonly Action<int> applyAction;

			public readonly IntDelegate loadValueParseAction;

			public readonly IntDelegate saveValueParseAction;

			public override void LoadState()
			{
			}

			public override void SaveState()
			{
			}

			public override void Apply()
			{
			}

			public PropertyInt(string playerPrefsKey, int defaultValue, Action<int> applyAction, IntDelegate loadValueParseAction = null, IntDelegate saveValueParseAction = null, bool applyOnStart = true)
			{
			}
		}

		[Serializable]
		public class PropertyBool : Property
		{
			public bool value;

			public bool defaultValue;

			public readonly Action<bool> applyAction;

			public override void LoadState()
			{
			}

			public override void SaveState()
			{
			}

			public override void Apply()
			{
			}

			public PropertyBool(string playerPrefsKey, bool defaultValue, Action<bool> applyAction, bool applyOnStart = true)
			{
			}
		}

		[Serializable]
		public class PropertyString : Property
		{
			public string value;

			public string defaultValue;

			public readonly Action<string> applyAction;

			public override void LoadState()
			{
			}

			public override void SaveState()
			{
			}

			public override void Apply()
			{
			}

			public PropertyString(string playerPrefsKey, string defaultValue, Action<string> applyAction)
			{
			}
		}

		[Serializable]
		public class GraphicsProperties
		{
			[Serializable]
			public class GraphicsPropertiesData
			{
				public float renderScale;

				public AntialiasingMode antialiasingMode;

				public RealtimeShadowsMode realtimeShadowsMode;

				public SSAOMode ssaoMode;

				public BloomMode bloomMode;

				public DOFMode dofMode;

				public CharLODMode charLodMode;

				public CharXRayMode charXRayMode;

				public ReflectionsMode reflectionsMode;

				public VolumetricsMode volumetricsMode;
			}

			[NonSerialized]
			public Property[] properties;

			[NonSerialized]
			public PropertyFloat renderScale;

			[NonSerialized]
			public PropertyInt antialiasingMode;

			[NonSerialized]
			public PropertyInt realtimeShadowsMode;

			[NonSerialized]
			public PropertyInt ssaoMode;

			[NonSerialized]
			public PropertyInt bloomMode;

			[NonSerialized]
			public PropertyInt dofMode;

			[NonSerialized]
			public PropertyInt charLODMode;

			[NonSerialized]
			public PropertyInt charXRayMode;

			[NonSerialized]
			public PropertyInt reflectionsMode;

			[NonSerialized]
			public PropertyInt volumetricsMode;

			public void Init()
			{
			}

			public void CopySettings(GraphicsPropertiesData s)
			{
			}

			public void LoadState()
			{
			}

			public void SaveState()
			{
			}

			public void Apply()
			{
			}
		}

		[CompilerGenerated]
		public sealed class _003CSetFullScreenModeNextFrame_003Ed__107 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public FullScreenMode mode;

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
			public _003CSetFullScreenModeNextFrame_003Ed__107(int _003C_003E1__state)
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
		public UIManager uiManager;

		[NonSerialized]
		public AudioManager audioManager;

		[NonSerialized]
		public FMODManager fmodManager;

		[NonSerialized]
		public VoiceManager voiceManager;

		[NonSerialized]
		public InputSystem inputSystem;

		[NonSerialized]
		public int defaultTargetFramerate;

		[NonSerialized]
		public int defaultAntiAliasing;

		[SerializeField]
		[Header("References")]
		public AutoQualityBenchmark autoQualityBenchmark;

		[SerializeField]
		public UniversalRendererData forwardRenderer;

		[SerializeField]
		public FullScreenPassRendererFeature overlayFeature;

		[SerializeField]
		public RenderObjectsMirroredToTextureFeature reflectionFeature;

		[SerializeField]
		public ButoRenderFeature volumetricsFeature;

		[SerializeField]
		public LocalisationConfiguration localisationConfig;

		[SerializeField]
		[Header("Render Pipelines")]
		public RenderPipelineAsset renderPipeline;

		[SerializeField]
		public RenderPipelineAsset renderPipelineShadowsLow;

		[SerializeField]
		public RenderPipelineAsset renderPipelineShadowsMedium;

		[SerializeField]
		public RenderPipelineAsset renderPipelineShadowsHigh;

		[SerializeField]
		public SetGlobalShaderSettings globalShaderSettings;

		[NonSerialized]
		public PropertyInt language;

		[NonSerialized]
		public PropertyInt region;

		[NonSerialized]
		public PropertyInt displayMode;

		[NonSerialized]
		public PropertyInt resolution;

		[NonSerialized]
		public PropertyFloat uiScale;

		[NonSerialized]
		public PropertyInt cursorMode;

		[NonSerialized]
		public PropertyInt cursor;

		[NonSerialized]
		public PropertyInt cursorColor;

		[NonSerialized]
		public PropertyBool displayPing;

		[NonSerialized]
		public PropertyBool displayFps;

		[NonSerialized]
		public PropertyBool displayGameVersion;

		[NonSerialized]
		public PropertyBool hideChatMessages;

		[NonSerialized]
		public PropertyBool anonymousMode;

		[NonSerialized]
		public PropertyBool openFriendRequest;

		[NonSerialized]
		public PropertyBool profanityFilter;

		[NonSerialized]
		public PropertyFloat cameraReach;

		[NonSerialized]
		public PropertyFloat cameraScrollSensitivity;

		[NonSerialized]
		public PropertyBool cameraMouseLock;

		[NonSerialized]
		public PropertyBool musicMuted;

		[NonSerialized]
		public PropertyFloat generalVolume;

		[NonSerialized]
		public PropertyFloat musicVolume;

		[NonSerialized]
		public PropertyFloat gameMusicVolume;

		[NonSerialized]
		public PropertyFloat ambientVolume;

		[NonSerialized]
		public PropertyFloat sfxVolume;

		[NonSerialized]
		public PropertyFloat pingsVolume;

		[NonSerialized]
		public PropertyFloat voicelineVolume;

		[NonSerialized]
		public PropertyFloat uiVolume;

		[NonSerialized]
		public PropertyInt voiceInputDevice;

		[NonSerialized]
		public PropertyFloat voiceInputVolume;

		[NonSerialized]
		public PropertyInt voiceOutputDevice;

		[NonSerialized]
		public PropertyFloat voiceOutputVolume;

		[NonSerialized]
		public PropertyInt quickCastAbilities;

		[NonSerialized]
		public PropertyInt inputDevice;

		[NonSerialized]
		public PropertyInt frameRateLimitMode;

		[NonSerialized]
		public PropertyInt vSyncMode;

		[NonSerialized]
		public PropertyInt qualityPreset;

		[NonSerialized]
		public GraphicsProperties graphicsProperties;

		[Header("Graphics Presets")]
		[SerializeField]
		public GraphicsProperties.GraphicsPropertiesData graphicsSettingsPresetLow;

		[SerializeField]
		public GraphicsProperties.GraphicsPropertiesData graphicsSettingsPresetMedium;

		[SerializeField]
		public GraphicsProperties.GraphicsPropertiesData graphicsSettingsPresetHigh;

		[SerializeField]
		public GraphicsProperties.GraphicsPropertiesData graphicsSettingsPresetUltra;

		[SerializeField]
		[Header("Other")]
		public int defaultTombstoneAssetId;

		[SerializeField]
		public int selectedSkinAssetId;

		[Header("Debugging")]
		[SerializeField]
		public bool forceFirstTimeLaunching;

		[NonSerialized]
		public Property[] properties;

		[NonSerialized]
		public int[] selectedEmoteAssetIds;

		[NonSerialized]
		public int selectedTombstoneAssetId;

		[NonSerialized]
		public bool firstTimeLaunching;

		[NonSerialized]
		public bool firstTimeOpenBetaLaunching;

		[NonSerialized]
		public Vector2Int[] supportedResolutions;

		[NonSerialized]
		public Resolution nativeSystemResolution;

		[NonSerialized]
		public int defaultSysResolutionIndex;

		public const string FirstTimeLaunchOpenBetaKey = "FirstTimeLaunchOpenBeta";

		public const string FirstTimeLaunchingKey = "FirstTimeLaunching";

		[NonSerialized]
		public bool displaySettingsEnabled;

		public void PreAwake()
		{
		}

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnApplicationFocus(bool focusStatus)
		{
		}

		public void InitializeSystemResolutions()
		{
		}

		public QualityPresets GetAutoQualityPreset()
		{
			return default(QualityPresets);
		}

		public void ResetDefaultLocalSavedContent()
		{
		}

		public void SetLanguage(int languageId)
		{
		}

		public void SetRegion(int regionId)
		{
		}

		public void SetDisplayMode(int displayModeId)
		{
		}

		[IteratorStateMachine(typeof(_003CSetFullScreenModeNextFrame_003Ed__107))]
		public IEnumerator SetFullScreenModeNextFrame(FullScreenMode mode)
		{
			return null;
		}

		public int FindSupportedResolutionMatch(Vector2Int targetRes)
		{
			return 0;
		}

		public void SetResolution(int resolutionId)
		{
		}

		public void SetUIScale(float value)
		{
		}

		public void UpdateCursorMode()
		{
		}

		public void SetCursorMode(int value)
		{
		}

		public void SetCursor(int value)
		{
		}

		public void SetCursorColor(int value)
		{
		}

		public void SetDisplayPing(bool isEnabled)
		{
		}

		public void SetDisplayFps(bool isEnabled)
		{
		}

		public void SetDisplayGameVersion(bool isEnabled)
		{
		}

		public void SetHideChatMessages(bool isEnabled)
		{
		}

		public void SetAnonymousMode(bool isEnabled)
		{
		}

		public void SetOpenFriendRequests(bool isEnabled)
		{
		}

		public void SetHiddePlayerNames(bool isEnabled)
		{
		}

		public void SetProfanityFilter(bool isEnabled)
		{
		}

		public void SetCameraReach(float value)
		{
		}

		public void SetCameraScrollSensitivity(float value)
		{
		}

		public void SetMouseLock(bool value)
		{
		}

		public void SetQuickCast(int enabledId)
		{
		}

		public void SetMusicMuted(bool isMuted)
		{
		}

		public void SetGeneralVolume(float normValue)
		{
		}

		public void SetMusicVolume(float normValue)
		{
		}

		public void SetGameMusicVolume(float normValue)
		{
		}

		public void SetAmbientVolume(float normValue)
		{
		}

		public void SetSfxVolume(float normValue)
		{
		}

		public void SetPingsVolume(float normValue)
		{
		}

		public void SetVoicelinesVolume(float normValue)
		{
		}

		public void SetUIVolume(float normValue)
		{
		}

		public void SetVoiceInputDevice(int device)
		{
		}

		public void SetVoiceOutputDevice(int device)
		{
		}

		public void SetVoiceInputVolume(float normValue)
		{
		}

		public void SetVoiceOutputVolume(float normValue)
		{
		}

		public void SetQualityPreset(int qualityPreset)
		{
		}

		public void SetRenderScale(float scaleValue)
		{
		}

		public void SetAntialiasingMode(int selectedModeId)
		{
		}

		public void SetFrameRateLimitMode(int selectedModeId)
		{
		}

		public void SetVSyncMode(int modeId)
		{
		}

		public void SetRealtimeShadowsMode(int selectedModeId)
		{
		}

		public void SetSSAOMode(int selectedModeId)
		{
		}

		public void SetBloomMode(int selectedModeId)
		{
		}

		public void SetDOFMode(int selectedModeId)
		{
		}

		public void SetCharLODMode(int selectedModeId)
		{
		}

		public void SetCharXRayMode(int selectedModeId)
		{
		}

		public void SetReflectionsMode(int selectedModeId)
		{
		}

		public void SetVolumetricsMode(int selectedModeId)
		{
		}

		public void SetInputDevice(int modeId)
		{
		}

		public void SetSelectedEmoteAssetId(int slotId, int emoteAssetId, bool save = true)
		{
		}

		public void SetSelectedTombstoneAssetId(int tombstoneAssetId, bool save = true)
		{
		}

		public MsaaQuality GetMsaaQualityFromAntialiasingMode(AntialiasingMode antialiasingMode)
		{
			return default(MsaaQuality);
		}

		public AntialiasingMode GetAntialiasingModeFromMsaaQuality(MsaaQuality msaaQuality)
		{
			return default(AntialiasingMode);
		}

		public int LocalisationIdFromSysLang(int systemLang)
		{
			return 0;
		}

		public int SysLangIdFromLocalisationId(int supportedLangId)
		{
			return 0;
		}

		public int LocalisationIdFromSystemLang(SystemLanguage systemLanguage)
		{
			return 0;
		}

		public SystemLanguage SystemLangFromLocalisationId(int supportedLangId)
		{
			return default(SystemLanguage);
		}

		public SystemLanguage GetSystemLanguage()
		{
			return default(SystemLanguage);
		}

		public bool IsEmoteAssetIdEquiped(int emoteAssetId)
		{
			return false;
		}

		public bool IsTombstoneAssetIdEquiped(int tombstoneAssetId)
		{
			return false;
		}
	}
}
