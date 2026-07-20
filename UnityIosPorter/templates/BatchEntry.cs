// Generated into the staging copy only. The owned source project is never edited.
using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace UnityIosPorter.Generated
{
    public static class BatchEntry
    {
        [Serializable]
        private sealed class Plan
        {
            public Settings settings;
            public Paths paths;
        }

        [Serializable]
        private sealed class Settings
        {
            public string bundleId;
            public string teamId;
            public string managedStrippingLevel;
            public string[] scenes;
        }

        [Serializable]
        private sealed class Paths
        {
            public string xcodeOutput;
            public string result;
        }

        [Serializable]
        private sealed class Result
        {
            public int schemaVersion = 1;
            public bool success;
            public string phase = "build-xcode";
            public string unityVersion;
            public string outputPath;
            public string result;
            public ulong totalSize;
            public double durationSeconds;
            public int errors;
            public int warnings;
            public string error;
        }

        public static void Build()
        {
            string planPath = Argument("-porterConfig");
            string resultPath = Argument("-porterResult");
            var outcome = new Result
            {
                unityVersion = Application.unityVersion,
                outputPath = string.Empty,
                result = "Unknown"
            };

            try
            {
                if (string.IsNullOrEmpty(planPath) || string.IsNullOrEmpty(resultPath))
                    throw new ArgumentException(
                        "-porterConfig and -porterResult are required");

                var plan = JsonUtility.FromJson<Plan>(File.ReadAllText(planPath));
                if (plan == null || plan.settings == null || plan.paths == null)
                    throw new InvalidDataException("Invalid build-plan.json contract");
                if (plan.settings.scenes == null || plan.settings.scenes.Length == 0)
                    throw new InvalidDataException("At least one enabled scene is required");
                string projectRoot = Directory.GetParent(Application.dataPath).FullName;
                if (plan.settings.scenes.Any(
                    scene => !File.Exists(Path.Combine(projectRoot, scene))))
                    throw new FileNotFoundException("A configured build scene is missing");

                EditorUserBuildSettings.SwitchActiveBuildTarget(
                    BuildTargetGroup.iOS, BuildTarget.iOS);
                PlayerSettings.SetScriptingBackend(
                    BuildTargetGroup.iOS, ScriptingImplementation.IL2CPP);
#pragma warning disable 618
                PlayerSettings.SetArchitecture(BuildTargetGroup.iOS, 1);
#pragma warning restore 618
                PlayerSettings.SetApplicationIdentifier(
                    BuildTargetGroup.iOS, plan.settings.bundleId);
                PlayerSettings.iOS.sdkVersion = iOSSdkVersion.DeviceSDK;

                ManagedStrippingLevel stripping;
                if (!Enum.TryParse(plan.settings.managedStrippingLevel, true, out stripping))
                    stripping = ManagedStrippingLevel.Low;
                PlayerSettings.SetManagedStrippingLevel(BuildTargetGroup.iOS, stripping);

                if (!string.IsNullOrEmpty(plan.settings.teamId))
                    PlayerSettings.iOS.appleDeveloperTeamID = plan.settings.teamId;

                Directory.CreateDirectory(plan.paths.xcodeOutput);
                outcome.outputPath = plan.paths.xcodeOutput;
                BuildReport report = BuildPipeline.BuildPlayer(new BuildPlayerOptions
                {
                    scenes = plan.settings.scenes,
                    locationPathName = plan.paths.xcodeOutput,
                    target = BuildTarget.iOS,
                    targetGroup = BuildTargetGroup.iOS,
                    options = BuildOptions.None
                });
                outcome.result = report.summary.result.ToString();
                outcome.success = report.summary.result == BuildResult.Succeeded;
                outcome.totalSize = report.summary.totalSize;
                outcome.durationSeconds = report.summary.totalTime.TotalSeconds;
                outcome.errors = report.summary.totalErrors;
                outcome.warnings = report.summary.totalWarnings;
                if (!outcome.success)
                    throw new BuildFailedException(
                        "Unity iOS build failed: " + report.summary.result);
            }
            catch (Exception exception)
            {
                outcome.success = false;
                outcome.error = exception.ToString();
                throw;
            }
            finally
            {
                if (!string.IsNullOrEmpty(resultPath))
                {
                    string directory = Path.GetDirectoryName(resultPath);
                    if (!string.IsNullOrEmpty(directory))
                        Directory.CreateDirectory(directory);
                    File.WriteAllText(
                        resultPath, JsonUtility.ToJson(outcome, true) + Environment.NewLine);
                }
            }
        }

        private static string Argument(string name)
        {
            string[] args = Environment.GetCommandLineArgs();
            for (int index = 0; index < args.Length - 1; index++)
            {
                if (string.Equals(args[index], name, StringComparison.Ordinal))
                    return args[index + 1];
            }
            return string.Empty;
        }
    }
}
