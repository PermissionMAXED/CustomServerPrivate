using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GameAnalyticsSDK.Events;
using GameAnalyticsSDK.Setup;
using UnityEngine;

namespace GameAnalyticsSDK
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(GA_SpecialEvents))]
	public class GameAnalytics : MonoBehaviour
	{
		public static Settings _settings;

		public static GameAnalytics _instance;

		public static bool _hasInitializeBeenCalled;

		public static Settings SettingsGA
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static event Action OnRemoteConfigsUpdatedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void Awake()
		{
		}

		public void OnDestroy()
		{
		}

		public void OnApplicationQuit()
		{
		}

		public static void InitAPI()
		{
		}

		public static void InternalInitialize()
		{
		}

		public static void Initialize()
		{
		}

		public static void NewBusinessEvent(string currency, int amount, string itemType, string itemId, string cartType)
		{
		}

		public static void NewBusinessEvent(string currency, int amount, string itemType, string itemId, string cartType, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewDesignEvent(string eventName)
		{
		}

		public static void NewDesignEvent(string eventName, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewDesignEvent(string eventName, float eventValue)
		{
		}

		public static void NewDesignEvent(string eventName, float eventValue, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, int score)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, int score, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, int score)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, int score, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03, int score)
		{
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03, int score, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewResourceEvent(GAResourceFlowType flowType, string currency, float amount, string itemType, string itemId)
		{
		}

		public static void NewResourceEvent(GAResourceFlowType flowType, string currency, float amount, string itemType, string itemId, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewErrorEvent(GAErrorSeverity severity, string message)
		{
		}

		public static void NewErrorEvent(GAErrorSeverity severity, string message, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewAdEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, long duration)
		{
		}

		public static void NewAdEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, long duration, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewAdEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, GAAdError noAdReason)
		{
		}

		public static void NewAdEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, GAAdError noAdReason, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void NewAdEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement)
		{
		}

		public static void NewAdEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, IDictionary<string, object> customFields, bool mergeFields = false)
		{
		}

		public static void SetCustomId(string userId)
		{
		}

		public static void SetEnabledManualSessionHandling(bool enabled)
		{
		}

		public static void SetEnabledEventSubmission(bool enabled)
		{
		}

		public static void StartSession()
		{
		}

		public static void EndSession()
		{
		}

		public static void SetCustomDimension01(string customDimension)
		{
		}

		public static void SetCustomDimension02(string customDimension)
		{
		}

		public static void SetCustomDimension03(string customDimension)
		{
		}

		public static void SetGlobalCustomEventFields(IDictionary<string, object> customFields)
		{
		}

		public void OnRemoteConfigsUpdated()
		{
		}

		public static void RemoteConfigsUpdated()
		{
		}

		public static string GetRemoteConfigsValueAsString(string key)
		{
			return null;
		}

		public static string GetRemoteConfigsValueAsString(string key, string defaultValue)
		{
			return null;
		}

		public static bool IsRemoteConfigsReady()
		{
			return false;
		}

		public static string GetRemoteConfigsContentAsString()
		{
			return null;
		}

		public static string GetABTestingId()
		{
			return null;
		}

		public static string GetABTestingVariantId()
		{
			return null;
		}

		public static void StartTimer(string key)
		{
		}

		public static void PauseTimer(string key)
		{
		}

		public static void ResumeTimer(string key)
		{
		}

		public static long StopTimer(string key)
		{
			return 0L;
		}

		public static void RequestTrackingAuthorization(IGameAnalyticsATTListener listener)
		{
		}

		public static string GetUnityVersion()
		{
			return null;
		}

		public static int GetPlatformIndex()
		{
			return 0;
		}

		public static void SetBuildAllPlatforms(string build)
		{
		}
	}
}
