using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomLobbyConfig", menuName = "BAPBAP/Configuration/CustomLobbyConfig")]
public class CustomLobbyConfig : ScriptableObject
{
	public SerializedDictionary<int, string> BattleRoyaleMaps;

	public string ForceStartTranslationKey;

	public string AreYouSureForceStartTranslationKey;

	public string CloseTranslationKey;
}
