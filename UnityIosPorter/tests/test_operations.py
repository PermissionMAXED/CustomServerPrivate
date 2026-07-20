from __future__ import annotations

import plistlib
import tempfile
import unittest
from pathlib import Path
from unittest import mock

from helpers import make_project
from unity_ios_porter.operations import (
    archive_command,
    doctor,
    export_command,
    initialize_ci,
    locate_unity,
    run_external,
    stage_project,
    unity_build_command,
    workspace_paths,
    write_export_options,
)
from unity_ios_porter.planner import generate_plan, load_config
from unity_ios_porter.project import ProjectError, inspect_project
from unity_ios_porter.scanner import scan_project


class OperationsTests(unittest.TestCase):
    def setUp(self) -> None:
        self.temp = tempfile.TemporaryDirectory()
        self.base = Path(self.temp.name)
        self.root = make_project(self.base / "OwnedGame")
        self.project = inspect_project(self.root)
        self.config = load_config(None, self.project)
        self.plan = generate_plan(
            self.project, self.config, scan_project(self.project)
        )

    def tearDown(self) -> None:
        self.temp.cleanup()

    def test_workspace_paths_are_deterministic(self) -> None:
        paths = workspace_paths(self.base / "work")
        self.assertEqual(paths["staged"].name, "staged-project")
        self.assertEqual(paths["xcode"].name, "xcode")
        self.assertEqual(paths["plan"].name, "build-plan.json")
        self.assertEqual(paths["result"].name, "result.json")

    def test_staging_copies_source_and_injects_bridge(self) -> None:
        (self.root / "Library").mkdir()
        (self.root / "Library/cache").write_text("cache", encoding="utf-8")
        original = (self.root / "Assets/Scripts/Main.cs").read_bytes()
        work = self.base / "work"
        paths = stage_project(self.project, work, self.plan)
        staged = Path(paths["staged"])
        self.assertTrue(
            (
                staged
                / "Assets/UnityIosPorter.Generated/Editor/BatchEntry.cs"
            ).is_file()
        )
        self.assertTrue(Path(paths["plan"]).is_file())
        self.assertFalse((staged / "Library").exists())
        self.assertEqual((self.root / "Assets/Scripts/Main.cs").read_bytes(), original)
        self.assertFalse(
            (self.root / "Assets/UnityIosPorter.Generated").exists()
        )

    def test_staging_dry_run_does_not_write(self) -> None:
        work = self.base / "work"
        paths = stage_project(self.project, work, self.plan, dry_run=True)
        self.assertFalse(work.exists())
        self.assertEqual(Path(paths["root"]), work)

    def test_staging_rejects_work_inside_source(self) -> None:
        with self.assertRaisesRegex(ProjectError, "outside"):
            stage_project(
                self.project, self.root / "Build/Porter", self.plan, dry_run=True
            )

    def test_staging_rejects_existing_work_directory(self) -> None:
        work = self.base / "work"
        work.mkdir()
        with self.assertRaisesRegex(ProjectError, "already exists"):
            stage_project(self.project, work, self.plan)

    def test_unity_command_uses_execute_method_contract(self) -> None:
        command = unity_build_command(
            "/Unity",
            "/stage",
            "/work/build-plan.json",
            "/work/result.json",
            "/work/unity.log",
        )
        self.assertEqual(command[0], "/Unity")
        self.assertIn("UnityIosPorter.Generated.BatchEntry.Build", command)
        self.assertEqual(command[command.index("-porterResult") + 1], "/work/result.json")

    def test_archive_and_export_commands(self) -> None:
        archive = archive_command("/xcode", "/out/Game.xcarchive", self.config)
        self.assertEqual(archive[0], "xcodebuild")
        self.assertIn("/xcode/Unity-iPhone.xcodeproj", archive)
        self.assertEqual(archive[-1], "archive")
        export = export_command(
            "/out/Game.xcarchive", "/out/export", "/out/ExportOptions.plist"
        )
        self.assertEqual(export[1], "-exportArchive")
        self.assertIn("/out/ExportOptions.plist", export)

    def test_export_options_are_valid_plist(self) -> None:
        path = self.base / "ExportOptions.plist"
        payload = write_export_options(path, self.config)
        self.assertEqual(path.read_bytes(), payload)
        parsed = plistlib.loads(payload)
        self.assertEqual(parsed["method"], "development")
        self.assertEqual(parsed["signingStyle"], "automatic")

    def test_doctor_reports_linux_prerequisites_without_crashing(self) -> None:
        with mock.patch("unity_ios_porter.operations.platform.system", return_value="Linux"):
            report = doctor(self.project)
        self.assertFalse(report["summary"]["ready"])  # type: ignore[index]
        by_name = {item["name"]: item for item in report["checks"]}  # type: ignore[index]
        self.assertEqual(by_name["macOS"]["status"], "FAIL")
        self.assertEqual(by_name["Xcode"]["status"], "FAIL")
        self.assertEqual(by_name["Unity iOS Build Support"]["status"], "UNKNOWN")

    def test_locate_unity_uses_explicit_executable(self) -> None:
        executable = self.base / "Unity"
        executable.write_text("#!/bin/sh\n", encoding="utf-8")
        self.assertIsNone(
            locate_unity(str(executable), self.project.unity_version),
            "a non-executable file must not be accepted as the Unity Editor",
        )
        executable.chmod(0o755)
        self.assertEqual(
            locate_unity(str(executable), self.project.unity_version), executable
        )

    def test_dry_run_never_calls_external_runner(self) -> None:
        runner = mock.Mock()
        result = run_external(["missing"], dry_run=True, runner=runner)
        self.assertEqual(result.returncode, 0)
        runner.assert_not_called()

    def test_ci_init_copies_template_and_honors_force(self) -> None:
        workflow = initialize_ci(self.root)
        self.assertTrue(workflow.is_file())
        self.assertIn("Unity iOS Porter Preflight", workflow.read_text(encoding="utf-8"))
        with self.assertRaises(ProjectError):
            initialize_ci(self.root)
        initialize_ci(self.root, force=True)


if __name__ == "__main__":
    unittest.main()
