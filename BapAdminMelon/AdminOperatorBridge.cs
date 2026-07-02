using System.Collections.Concurrent;
using System.Reflection;
using UnityEngine;

namespace BapAdminMelon;

internal static class AdminOperatorBridge
{
    private static readonly ConcurrentDictionary<string, Type> TypeCache = new();
    private static float _nextApplyAt;

    public static string Status { get; private set; } = "Waiting for admin authentication";

    public static void EnsureAdminAccess()
    {
        if (Time.realtimeSinceStartup < _nextApplyAt) return;
        _nextApplyAt = Time.realtimeSinceStartup + 1f;

        try
        {
            Type? debugManagerType = FindType("BAPBAP.Debugging.DebugManager");
            if (debugManagerType is null)
            {
                Status = "Waiting for DebugManager";
                return;
            }

            object? manager = GetStaticMember(debugManagerType, "Instance");
            if (manager is null)
            {
                Status = "Waiting for DebugManager instance";
                return;
            }

            Type? operatorLevel = debugManagerType.GetNestedType("OperatorLevel", BindingFlags.Public | BindingFlags.NonPublic);
            if (operatorLevel is null || !operatorLevel.IsEnum)
            {
                Status = "Operator level type unavailable";
                return;
            }

            object admin = Enum.Parse(operatorLevel, "Admin", ignoreCase: true);

            // Only write + notify when the level actually differs. The unconditional per-second
            // SetMember + OnOperatorChanged invoked whatever UI/refresh work the game hangs off
            // that callback every second, forever.
            if (!OperatorLevelEquals(GetMember(manager, "userOpLevel"), admin))
            {
                SetMember(manager, "userOpLevel", admin);
                Invoke(manager, "OnOperatorChanged");
            }

            Status = "Operator level: Admin";
        }
        catch (Exception ex)
        {
            Status = $"Operator bridge: {ex.GetBaseException().Message}";
        }
    }

    public static void ToggleUnityConsole()
    {
        try
        {
            Type? debugManagerType = FindType("BAPBAP.Debugging.DebugManager");
            object? manager = debugManagerType is null ? null : GetStaticMember(debugManagerType, "Instance");
            if (manager is null)
            {
                Status = "Unity console unavailable outside a loaded scene";
                return;
            }

            bool isOpen = GetBool(manager, "isOpen");
            Invoke(manager, isOpen ? "CloseWindowAndEnableInputs" : "OpenWindowAndDisableInputs");
            Status = isOpen ? "Unity developer console closed" : "Unity developer console opened";
        }
        catch (Exception ex)
        {
            Status = $"Unity console: {ex.GetBaseException().Message}";
        }
    }

    private static Type? FindType(string fullName)
    {
        if (TypeCache.TryGetValue(fullName, out Type? cached)) return cached;

        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            try
            {
                Type? type = assembly.GetType(fullName, throwOnError: false) ?? assembly.GetType("Il2Cpp" + fullName, throwOnError: false);
                if (type is null) continue;
                TypeCache.TryAdd(fullName, type);
                return type;
            }
            catch { }
        }

        return null;
    }

    private static object? GetStaticMember(Type type, string name)
    {
        const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
        return type.GetProperty(name, flags)?.GetValue(null) ?? type.GetField(name, flags)?.GetValue(null);
    }

    private static object? GetMember(object instance, string name)
    {
        const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        return instance.GetType().GetProperty(name, flags)?.GetValue(instance) ??
               instance.GetType().GetField(name, flags)?.GetValue(instance);
    }

    // The read-back value may come boxed as the managed enum, an Il2Cpp enum wrapper, or a raw
    // int depending on the interop path; compare numerically so all spellings match.
    private static bool OperatorLevelEquals(object? current, object expected)
    {
        if (current is null) return false;
        if (expected.Equals(current)) return true;
        try
        {
            return Convert.ToInt64(current) == Convert.ToInt64(expected);
        }
        catch
        {
            return false;
        }
    }

    private static void SetMember(object instance, string name, object value)
    {
        const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        PropertyInfo? property = instance.GetType().GetProperty(name, flags);
        if (property?.CanWrite == true)
        {
            property.SetValue(instance, value);
            return;
        }

        FieldInfo? field = instance.GetType().GetField(name, flags);
        field?.SetValue(instance, value);
    }

    private static bool GetBool(object instance, string name)
    {
        const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        object? value = instance.GetType().GetProperty(name, flags)?.GetValue(instance) ??
                        instance.GetType().GetField(name, flags)?.GetValue(instance);
        return value is bool boolean && boolean;
    }

    private static void Invoke(object instance, string name)
    {
        instance.GetType().GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null)?.Invoke(instance, null);
    }
}
