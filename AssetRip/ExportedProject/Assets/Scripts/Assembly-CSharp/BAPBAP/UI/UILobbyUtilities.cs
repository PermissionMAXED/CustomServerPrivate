using System.Collections.Generic;
using BAPBAP.Content;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public static class UILobbyUtilities
	{
		public const string notifSeparator = ";";

		public static void OpenEquipContentPage(BAPBAP.Content.Content content)
		{
		}

		public static List<int> GetOwnedGroupContentAssetIds(BAPBAP.Content.Content content)
		{
			return null;
		}

		public static void FillContentData(ContentConfiguration contentConfig, Translator translator, BAPBAP.Content.Content content, TMP_Text collectionText, TMP_Text titleText, TMP_Text descText, TMP_Text tierRarityText, UIContentRarityStars rarityStars, int balance = 1)
		{
		}

		public static string GetContentTitle(Translator translator, BAPBAP.Content.Content content, int balance = 1)
		{
			return null;
		}

		public static void VisualizeContentInPanel(BAPBAP.Content.Content content, Image panelDisplay, float initializeDelay = 0f, bool allowSpawn3DVis = true)
		{
		}

		public static void SpawnImageContentVisualizer(BAPBAP.Content.Content content, RectTransform panel)
		{
		}

		public static void DestroySpawnedVisualizers(Transform panel)
		{
		}

		public static void Set3DVisualizerContent(BAPBAP.Content.Content content, Transform panelDisplay, float initializeDelay = 0f)
		{
		}

		public static void SerializeAndSaveAllNotifications(string prefKey, int[] ids)
		{
		}

		public static int[] UnserializeAllSavedNotifications(string prefKey)
		{
			return null;
		}

		public static void AddSaveSerializeNotification(string prefKey, int id)
		{
		}

		public static void DeleteSavedSerializeNotification(string prefKey, int id)
		{
		}
	}
}
