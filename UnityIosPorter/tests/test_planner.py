from __future__ import annotations

import json
import tempfile
import unittest
from pathlib import Path

from helpers import make_project
from unity_ios_porter.planner import (
    discover_scenes,
    generate_plan,
    infer_bundle_id,
    load_config,
    validate_bundle_id,
)
from unity_ios_porter.project import ProjectError, inspect_project
from unity_ios_porter.scanner import scan_project


class PlannerTests(unittest.TestCase):
    def setUp(self) -> None:
        self.temp = tempfile.TemporaryDirectory()
        self.root = make_project(Path(self.temp.name) / "OwnedGame")
        self.project = inspect_project(self.root)

    def tearDown(self) -> None:
        self.temp.cleanup()

    def test_bundle_identifier_validation(self) -> None:
        self.assertEqual(validate_bundle_id("com.example.game"), "com.example.game")
        for value in ("game", "*.example.game", "com..game", "1com.example"):
            with self.subTest(value=value), self.assertRaises(ProjectError):
                validate_bundle_id(value)

    def test_bundle_identifier_is_inferred(self) -> None:
        self.assertEqual(infer_bundle_id(self.project), "com.example.game")
        config = load_config(None, self.project)
        self.assertEqual(config.bundle_id, "com.example.game")

    def test_json_configuration_and_overrides(self) -> None:
        path = Path(self.temp.name) / "porter.json"
        path.write_text(
            json.dumps(
                {
                    "bundleId": "com.config.game",
                    "teamId": "TEAM123",
                    "exportMethod": "ad-hoc",
                    "managedStrippingLevel": "Low",
                }
            ),
            encoding="utf-8",
        )
        config = load_config(
            path,
            self.project,
            bundle_id="com.override.game",
            team_id="OTHERTEAM",
        )
        self.assertEqual(config.bundle_id, "com.override.game")
        self.assertEqual(config.team_id, "OTHERTEAM")
        self.assertEqual(config.export_method, "ad-hoc")
        self.assertEqual(config.managed_stripping_level, "Low")

    def test_invalid_configuration_is_rejected(self) -> None:
        path = Path(self.temp.name) / "porter.json"
        path.write_text("[]", encoding="utf-8")
        with self.assertRaises(ProjectError):
            load_config(path, self.project)
        path.write_text(
            json.dumps(
                {"bundleId": "com.example.game", "exportMethod": "unlisted"}
            ),
            encoding="utf-8",
        )
        with self.assertRaises(ProjectError):
            load_config(path, self.project)

    def test_enabled_scene_discovery(self) -> None:
        settings = self.root / "ProjectSettings/EditorBuildSettings.asset"
        settings.write_text(
            "EditorBuildSettings:\n"
            "  m_Scenes:\n"
            "  - enabled: 0\n"
            "    path: Assets/Scenes/Disabled.unity\n"
            "  - enabled: 1\n"
            "    path: Assets/Scenes/Main.unity\n",
            encoding="utf-8",
        )
        scenes, warnings = discover_scenes(self.project)
        self.assertEqual(scenes, ["Assets/Scenes/Main.unity"])
        self.assertEqual(warnings, [])

    def test_missing_or_empty_scene_settings_warn(self) -> None:
        (self.root / "ProjectSettings/EditorBuildSettings.asset").unlink()
        scenes, warnings = discover_scenes(self.project)
        self.assertEqual(scenes, [])
        self.assertGreaterEqual(len(warnings), 2)

    def test_plan_encodes_il2cpp_arm64_truth(self) -> None:
        scan = scan_project(self.project)
        plan = generate_plan(self.project, load_config(None, self.project), scan)
        truth = plan["technicalTruth"]
        settings = plan["settings"]
        self.assertEqual(truth["sourceBackend"], "Mono")  # type: ignore[index]
        self.assertEqual(truth["targetBackend"], "IL2CPP")  # type: ignore[index]
        self.assertEqual(truth["architecture"], "ARM64")  # type: ignore[index]
        self.assertEqual(settings["scriptingBackend"], "IL2CPP")  # type: ignore[index]
        self.assertEqual(settings["managedStrippingLevel"], "Medium")  # type: ignore[index]
        self.assertFalse(plan["riskSummary"]["blocking"])  # type: ignore[index]

    def test_reflection_plan_recommends_low_stripping(self) -> None:
        (self.root / "Assets/Scripts/Main.cs").write_text(
            "using System.Reflection;\nclass R {}\n", encoding="utf-8"
        )
        scan = scan_project(self.project)
        plan = generate_plan(self.project, load_config(None, self.project), scan)
        self.assertEqual(plan["settings"]["managedStrippingLevel"], "Low")  # type: ignore[index]

    def test_scan_errors_make_plan_blocking(self) -> None:
        (self.root / "Assets/Scripts/Main.cs").write_text(
            "using System.Drawing;\nclass R {}\n", encoding="utf-8"
        )
        scan = scan_project(self.project)
        plan = generate_plan(self.project, load_config(None, self.project), scan)
        self.assertTrue(plan["riskSummary"]["blocking"])  # type: ignore[index]
        self.assertEqual(plan["riskSummary"]["errors"], 1)  # type: ignore[index]


if __name__ == "__main__":
    unittest.main()
