namespace BapCustomServerMelon;

// Pure (Unity-free) map-carrier logic from CustomServerMod (F170). The KnownLevelNames table
// maps level indices to real engine map names so the level-load coroutine doesn't NullReference
// before the custom-map hook runs. Custom slots (5..40) all load the "Arena_Map2" carrier.
// Array size 41 is load-bearing: mapIds above 40 index out of bounds (see bug B25).
internal static class MelonMapHelpers
{
    public const int LevelNameCount = 41;

    public static string[] BuildKnownLevelNames()
    {
        var names = new string[LevelNameCount];
        names[0] = "Map2_BazaarCity 3";
        names[1] = "Map2_BazaarCity 3";
        names[2] = "Map3_Lyceum";
        names[3] = "Arena_Map2";
        names[4] = "OpenBetaMap#J02_P_Boccato";
        for (int i = 5; i < names.Length; i++)
        {
            names[i] = "Arena_Map2";
        }
        return names;
    }
}
