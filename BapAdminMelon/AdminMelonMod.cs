using BapCustomServerMelon;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(BapAdminMelon.AdminMelonMod), "BAP Admin Tools", "1.0.0", "Sonic0810")]

namespace BapAdminMelon;

public sealed class AdminMelonMod : MelonMod
{
    private AdminModSettings? _settings;
    private float _nextSettingsReloadAt;
    private DateTime _settingsLastWriteUtc;
    private string[]? _commandLineArgs;

    public override void OnInitializeMelon()
    {
        ReloadSettings();
        MelonLogger.Msg("[BAP Admin] Separate admin mod initialized. F8 opens the admin overlay; F9 toggles the Unity developer console.");
    }

    public override void OnUpdate()
    {
        if (Time.realtimeSinceStartup >= _nextSettingsReloadAt)
        {
            ReloadSettings();
        }

        AdminModSettings? settings = _settings;
        if (settings is null || !settings.Enabled) return;

        if (!AdminAuthClient.IsAdminAuthenticated &&
            !string.IsNullOrWhiteSpace(settings.AccountId) &&
            !string.IsNullOrWhiteSpace(settings.Token))
        {
            AdminAuthClient.TryAuthenticate(settings.Host, settings.Port, settings.AccountId, settings.Username);
        }

        if (AdminAuthClient.IsAdminAuthenticated)
        {
            AdminOperatorBridge.EnsureAdminAccess();
            if (Input.GetKeyDown(KeyCode.F9))
            {
                AdminOperatorBridge.ToggleUnityConsole();
            }
        }

        AdminOverlay.OnUpdate();
    }

    public override void OnGUI()
    {
        AdminOverlay.OnGUI();
    }

    public override void OnApplicationQuit()
    {
        AdminAuthClient.Reset();
    }

    private void ReloadSettings()
    {
        _nextSettingsReloadAt = Time.realtimeSinceStartup + 5f;

        // Only re-parse when the ini actually changed. The unconditional 5s reload was synchronous
        // file I/O (File.Exists + ReadLines) on the Unity main thread - a stutter-spike candidate
        // on slow disks / with antivirus scanning the file.
        _commandLineArgs ??= Environment.GetCommandLineArgs();
        if (_settings is not null)
        {
            DateTime lastWriteUtc = SafeGetLastWriteUtc(_settings.IniPath);
            if (lastWriteUtc == _settingsLastWriteUtc)
            {
                return;
            }
        }

        AdminModSettings settings = AdminModSettings.Load(_commandLineArgs);
        _settings = settings;
        _settingsLastWriteUtc = SafeGetLastWriteUtc(settings.IniPath);
        AdminAuthClient.SetIniPath(settings.IniPath);
    }

    private static DateTime SafeGetLastWriteUtc(string path)
    {
        try
        {
            return File.GetLastWriteTimeUtc(path);
        }
        catch
        {
            return DateTime.MinValue;
        }
    }
}
