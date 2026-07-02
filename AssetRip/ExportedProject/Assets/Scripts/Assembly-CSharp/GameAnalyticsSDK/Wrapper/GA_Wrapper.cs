using System.Collections.Generic;
using GameAnalyticsSDK.Net;

namespace GameAnalyticsSDK.Wrapper
{
	public class GA_Wrapper
	{
		public class UnityRemoteConfigsListener : IRemoteConfigsListener
		{
			public void OnRemoteConfigsUpdated()
			{
			}
		}

		public static readonly UnityRemoteConfigsListener unityRemoteConfigsListener;

		public static void configureAvailableCustomDimensions01(string list)
		{
		}

		public static void configureAvailableCustomDimensions02(string list)
		{
		}

		public static void configureAvailableCustomDimensions03(string list)
		{
		}

		public static void configureAvailableResourceCurrencies(string list)
		{
		}

		public static void configureAvailableResourceItemTypes(string list)
		{
		}

		public static void configureSdkGameEngineVersion(string unitySdkVersion)
		{
		}

		public static void configureGameEngineVersion(string unityEngineVersion)
		{
		}

		public static void configureBuild(string build)
		{
		}

		public static void configureUserId(string userId)
		{
		}

		public static void initialize(string gamekey, string gamesecret)
		{
		}

		public static void setCustomDimension01(string customDimension)
		{
		}

		public static void setCustomDimension02(string customDimension)
		{
		}

		public static void setCustomDimension03(string customDimension)
		{
		}

		public static void setGlobalCustomEventFields(string customFields)
		{
		}

		public static void addBusinessEvent(string currency, int amount, string itemType, string itemId, string cartType, string fields, bool mergeFields)
		{
		}

		public static void addResourceEvent(int flowType, string currency, float amount, string itemType, string itemId, string fields, bool mergeFields)
		{
		}

		public static void addProgressionEvent(int progressionStatus, string progression01, string progression02, string progression03, string fields, bool mergeFields)
		{
		}

		public static void addProgressionEventWithScore(int progressionStatus, string progression01, string progression02, string progression03, int score, string fields, bool mergeFields)
		{
		}

		public static void addDesignEvent(string eventId, string fields, bool mergeFields)
		{
		}

		public static void addDesignEventWithValue(string eventId, float value, string fields, bool mergeFields)
		{
		}

		public static void addErrorEvent(int severity, string message, string fields, bool mergeFields)
		{
		}

		public static void setEnabledInfoLog(bool enabled)
		{
		}

		public static void setEnabledVerboseLog(bool enabled)
		{
		}

		public static void setManualSessionHandling(bool enabled)
		{
		}

		public static void setEventSubmission(bool enabled)
		{
		}

		public static void gameAnalyticsStartSession()
		{
		}

		public static void gameAnalyticsEndSession()
		{
		}

		public static string getRemoteConfigsValueAsString(string key, string defaultValue)
		{
			return null;
		}

		public static bool isRemoteConfigsReady()
		{
			return false;
		}

		public static string getRemoteConfigsContentAsString()
		{
			return null;
		}

		public static string getABTestingId()
		{
			return null;
		}

		public static string getABTestingVariantId()
		{
			return null;
		}

		public static void configureAutoDetectAppVersion(bool flag)
		{
		}

		public static void SetAvailableCustomDimensions01(string list)
		{
		}

		public static void SetAvailableCustomDimensions02(string list)
		{
		}

		public static void SetAvailableCustomDimensions03(string list)
		{
		}

		public static void SetAvailableResourceCurrencies(string list)
		{
		}

		public static void SetAvailableResourceItemTypes(string list)
		{
		}

		public static void SetUnitySdkVersion(string unitySdkVersion)
		{
		}

		public static void SetUnityEngineVersion(string unityEngineVersion)
		{
		}

		public static void SetBuild(string build)
		{
		}

		public static void SetCustomUserId(string userId)
		{
		}

		public static void SetEnabledManualSessionHandling(bool enabled)
		{
		}

		public static void SetEnabledEventSubmission(bool enabled)
		{
		}

		public static void SetAutoDetectAppVersion(bool flag)
		{
		}

		public static void StartSession()
		{
		}

		public static void EndSession()
		{
		}

		public static void Initialize(string gamekey, string gamesecret)
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

		public static void AddBusinessEvent(string currency, int amount, string itemType, string itemId, string cartType, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void AddResourceEvent(GAResourceFlowType flowType, string currency, float amount, string itemType, string itemId, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void AddProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void AddProgressionEventWithScore(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03, int score, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void AddDesignEvent(string eventID, float eventValue, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void AddDesignEvent(string eventID, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void AddErrorEvent(GAErrorSeverity severity, string message, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void AddAdEventWithDuration(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, long duration, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void AddAdEventWithReason(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, GAAdError noAdReason, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void AddAdEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, IDictionary<string, object> fields, bool mergeFields)
		{
		}

		public static void SetInfoLog(bool enabled)
		{
		}

		public static void SetVerboseLog(bool enabled)
		{
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

		public static string DictionaryToJsonString(IDictionary<string, object> dict)
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
	}
}
