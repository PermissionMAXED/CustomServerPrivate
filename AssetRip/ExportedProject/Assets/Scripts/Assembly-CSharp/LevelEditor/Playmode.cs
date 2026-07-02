using UnityEngine;

namespace LevelEditor
{
	public static class Playmode
	{
		public static bool isPlaymodeEnabled;

		public static bool playAndEdit;

		public static bool mouseFollowChar;

		public static bool charCollisionEnabled;

		public static GameObject currentCharObj;

		public static string[] playModeChars;

		public static int selectedPlayModeChar;

		public static CameraFollow camController;

		public static CameraOrbitControls camOrbitControls;

		public static float currentZoomMultiplier;

		public static string[] PlayModeChars => null;

		public static CameraFollow CamFollow => null;

		public static CameraOrbitControls CamOrbitControls => null;

		public static Configuration Config => null;

		public static void ShowSettingsGUI()
		{
		}

		public static void ShowPlaymodeGUI()
		{
		}

		public static void DrawPlayModeCharSelection()
		{
		}

		public static void EnablePlaymode()
		{
		}

		public static void DisablePlaymode()
		{
		}

		public static void SpawnPlayableChar()
		{
		}

		public static void DespawnPlayableChar()
		{
		}

		public static void SetCharCollisionsEnabled(bool enable)
		{
		}

		public static void ProcessPlaymodeHotkeys()
		{
		}

		public static void ResetZoom()
		{
		}

		public static void ZoomOut()
		{
		}

		public static void ZoomIn()
		{
		}
	}
}
