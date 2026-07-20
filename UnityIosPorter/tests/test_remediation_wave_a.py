"""Wave A remediation tests: batch target, artifact contracts, and honesty."""

from __future__ import annotations

import json
import os
import shutil
import subprocess
import sys
import tempfile
import unittest
from pathlib import Path
from unittest import mock

from fake_tools import write_fake_unity
from helpers import make_project
from unity_ios_porter.operations import (
    BRIDGE_TEMPLATE,
    locate_xcodebuild,
    looks_like_xcode_export,
    run_external,
    source_digest,
    stage_project,
    unity_build_command,
    validate_unity_result,
    verify_archive_output,
    verify_export_output,
    verify_workspace_manifest,
    workspace_paths,
    write_workspace_manifest,
)
from unity_ios_porter.planner import discover_scenes, generate_plan, load_config
from unity_ios_porter.project import ProjectError, inspect_project
from unity_ios_porter.scanner import scan_project

TOOL_ROOT = Path(__file__).resolve().parents[1]
PORTER = TOOL_ROOT / "porter.py"


class BatchTargetContractTests(unittest.TestCase):
    def test_cli_command_pins_build_target_ios(self) -> None:
        command = unity_build_command("/Unity", "/s", "/p.json", "/r.json", "/l.log")
        self.assertIn("-batchmode", command)
        self.assertIn("-buildTarget", command)
        self.assertEqual(command[command.index("-buildTarget") + 1], "iOS")

    def test_bridge_asserts_target_instead_of_switching_in_batchmode(self) -> None:
        template = BRIDGE_TEMPLATE.read_text(encoding="utf-8")
        self.assertIn("EnsureIosBuildTarget", template)
        self.assertIn("Application.isBatchMode", template)
        self.assertIn("EditorUserBuildSettings.activeBuildTarget", template)
        self.assertIn("-buildTarget iOS", template)
        # The batch-mode branch must throw before any switch attempt; the
        # only SwitchActiveBuildTarget call is the guarded non-batch fallback.
        batch_guard = template.index("Application.isBatchMode")
        switch_call = template.index("EditorUserBuildSettings.SwitchActiveBuildTarget")
        self.assertLess(batch_guard, switch_call)
        self.assertEqual(
            template.count("EditorUserBuildSettings.SwitchActiveBuildTarget"), 1
        )
        # The fallback must verify the switch took effect rather than trust it.
        self.assertIn("switched", template)
        self.assertIn(
            "EditorUserBuildSettings.activeBuildTarget != BuildTarget.iOS",
            template,
        )


class UnityResultContractTests(unittest.TestCase):
    def setUp(self) -> None:
        self.temp = tempfile.TemporaryDirectory()
        self.base = Path(self.temp.name)
        self.xcode = self.base / "xcode"
        self.result = self.base / "result.json"

    def tearDown(self) -> None:
        self.temp.cleanup()

    def write_result(self, **overrides: object) -> None:
        payload: dict[str, object] = {
            "schemaVersion": 1,
            "phase": "build-xcode",
            "success": True,
            "outputPath": str(self.xcode),
        }
        payload.update(overrides)
        self.result.write_text(json.dumps(payload), encoding="utf-8")

    def make_xcode_project(self) -> None:
        project = self.xcode / "Unity-iPhone.xcodeproj"
        project.mkdir(parents=True)
        (project / "project.pbxproj").write_text("// pbxproj\n", encoding="utf-8")

    def test_valid_result_and_export_pass(self) -> None:
        self.make_xcode_project()
        self.write_result()
        self.assertEqual(validate_unity_result(self.result, self.xcode), [])

    def test_missing_result_file_fails(self) -> None:
        errors = validate_unity_result(self.result, self.xcode)
        self.assertTrue(any("did not write" in error for error in errors))

    def test_success_false_fails_even_when_file_exists(self) -> None:
        self.make_xcode_project()
        self.write_result(success=False, error="hidden failure")
        errors = validate_unity_result(self.result, self.xcode)
        self.assertTrue(any("hidden failure" in error for error in errors))

    def test_wrong_schema_version_fails(self) -> None:
        self.make_xcode_project()
        self.write_result(schemaVersion=2)
        errors = validate_unity_result(self.result, self.xcode)
        self.assertTrue(any("schemaVersion" in error for error in errors))

    def test_wrong_output_path_fails(self) -> None:
        self.make_xcode_project()
        self.write_result(outputPath=str(self.base / "elsewhere"))
        errors = validate_unity_result(self.result, self.xcode)
        self.assertTrue(any("outputPath" in error for error in errors))

    def test_output_without_xcode_project_fails(self) -> None:
        self.xcode.mkdir()
        (self.xcode / "random.txt").write_text("x", encoding="utf-8")
        self.write_result()
        errors = validate_unity_result(self.result, self.xcode)
        self.assertTrue(any("Xcode export" in error for error in errors))

    def test_non_object_result_fails(self) -> None:
        self.result.write_text("[]", encoding="utf-8")
        errors = validate_unity_result(self.result, self.xcode)
        self.assertTrue(any("JSON object" in error for error in errors))

    def test_looks_like_xcode_export_accepts_workspace(self) -> None:
        workspace = self.xcode / "Unity-iPhone.xcworkspace"
        workspace.mkdir(parents=True)
        (workspace / "contents.xcworkspacedata").write_text(
            "<Workspace/>\n", encoding="utf-8"
        )
        self.assertEqual(looks_like_xcode_export(self.xcode), [])


class WorkspaceManifestTests(unittest.TestCase):
    def setUp(self) -> None:
        self.temp = tempfile.TemporaryDirectory()
        self.base = Path(self.temp.name)
        self.root = make_project(self.base / "OwnedGame")
        self.project = inspect_project(self.root)
        self.config = load_config(None, self.project)
        self.plan = generate_plan(
            self.project, self.config, scan_project(self.project)
        )
        self.paths = workspace_paths(self.base / "work")

    def tearDown(self) -> None:
        self.temp.cleanup()

    def bind_workspace(self) -> None:
        stage_project(self.project, self.base / "work", self.plan)
        project_dir = self.paths["xcode"] / "Unity-iPhone.xcodeproj"
        project_dir.mkdir(parents=True)
        (project_dir / "project.pbxproj").write_text("// pbxproj\n", encoding="utf-8")
        write_workspace_manifest(self.paths, self.project.root)

    def test_manifest_roundtrip_verifies(self) -> None:
        self.bind_workspace()
        self.assertEqual(
            verify_workspace_manifest(self.paths, self.project.root), []
        )

    def test_missing_manifest_is_refused(self) -> None:
        errors = verify_workspace_manifest(self.paths, self.project.root)
        self.assertTrue(any("manifest is missing" in error for error in errors))

    def test_different_project_is_refused(self) -> None:
        self.bind_workspace()
        other = make_project(self.base / "OtherGame")
        errors = verify_workspace_manifest(self.paths, other)
        self.assertTrue(
            any("different source project" in error for error in errors)
        )

    def test_tampered_plan_is_refused(self) -> None:
        self.bind_workspace()
        self.paths["plan"].write_text("{}\n", encoding="utf-8")
        errors = verify_workspace_manifest(self.paths, self.project.root)
        self.assertTrue(any("plan digest" in error for error in errors))

    def test_tampered_staged_source_is_refused(self) -> None:
        self.bind_workspace()
        (self.paths["staged"] / "Assets/Scripts/Main.cs").write_text(
            "public sealed class Main { /* padded */ }\n", encoding="utf-8"
        )
        errors = verify_workspace_manifest(self.paths, self.project.root)
        self.assertTrue(any("source digest" in error for error in errors))

    def test_missing_xcode_export_is_refused(self) -> None:
        self.bind_workspace()
        pbxproj = self.paths["xcode"] / "Unity-iPhone.xcodeproj/project.pbxproj"
        pbxproj.unlink()
        errors = verify_workspace_manifest(self.paths, self.project.root)
        self.assertTrue(any("Xcode export" in error for error in errors))

    def test_source_digest_is_stable(self) -> None:
        self.bind_workspace()
        self.assertEqual(
            source_digest(self.paths["staged"]),
            source_digest(self.paths["staged"]),
        )


class ArchiveExportVerificationTests(unittest.TestCase):
    def setUp(self) -> None:
        self.temp = tempfile.TemporaryDirectory()
        self.base = Path(self.temp.name)

    def tearDown(self) -> None:
        self.temp.cleanup()

    def test_archive_output_verification(self) -> None:
        archive = self.base / "Game.xcarchive"
        self.assertTrue(verify_archive_output(archive))
        (archive / "Products/Applications/Game.app").mkdir(parents=True)
        errors = verify_archive_output(archive)
        self.assertTrue(any("Info.plist" in error for error in errors))
        (archive / "Info.plist").write_text("<plist/>\n", encoding="utf-8")
        self.assertEqual(verify_archive_output(archive), [])

    def test_export_output_verification(self) -> None:
        export = self.base / "export"
        self.assertTrue(verify_export_output(export))
        export.mkdir()
        self.assertTrue(verify_export_output(export))
        (export / "Game.ipa").write_bytes(b"synthetic")
        self.assertEqual(verify_export_output(export), [])


class SubprocessHygieneTests(unittest.TestCase):
    def setUp(self) -> None:
        self.temp = tempfile.TemporaryDirectory()
        self.base = Path(self.temp.name)

    def tearDown(self) -> None:
        self.temp.cleanup()

    def test_locate_xcodebuild_returns_absolute_path(self) -> None:
        fake = self.base / "xcodebuild"
        fake.write_text("#!/bin/sh\nexit 0\n", encoding="utf-8")
        fake.chmod(0o755)
        with mock.patch.dict(os.environ, {"PATH": str(self.base)}):
            located = locate_xcodebuild()
        self.assertIsNotNone(located)
        assert located is not None
        self.assertTrue(Path(located).is_absolute())
        self.assertEqual(Path(located), fake.resolve())

    def test_run_external_times_out_with_code_124(self) -> None:
        result = run_external(
            [sys.executable, "-c", "import time; time.sleep(30)"],
            timeout=0.5,
        )
        self.assertEqual(result.returncode, 124)
        self.assertIn("timed out", result.stderr)

    def test_run_external_writes_log_file_instead_of_stdout(self) -> None:
        log = self.base / "logs/tool.log"
        result = run_external(
            [sys.executable, "-c", "print('captured-line')"],
            log_path=log,
        )
        self.assertEqual(result.returncode, 0)
        self.assertIn("captured-line", log.read_text(encoding="utf-8"))
        self.assertFalse(result.stdout)

    def test_run_external_captures_output_without_log_path(self) -> None:
        result = run_external([sys.executable, "-c", "print('inline-line')"])
        self.assertEqual(result.returncode, 0)
        self.assertIn("inline-line", result.stdout)

    def test_run_external_missing_binary_is_127(self) -> None:
        result = run_external([str(self.base / "does-not-exist")])
        self.assertEqual(result.returncode, 127)


class ScenePathValidationTests(unittest.TestCase):
    def setUp(self) -> None:
        self.temp = tempfile.TemporaryDirectory()
        self.root = make_project(Path(self.temp.name) / "OwnedGame")
        self.project = inspect_project(self.root)

    def tearDown(self) -> None:
        self.temp.cleanup()

    def set_scene(self, scene: str) -> None:
        (self.root / "ProjectSettings/EditorBuildSettings.asset").write_text(
            "EditorBuildSettings:\n"
            "  m_Scenes:\n"
            "  - enabled: 1\n"
            f"    path: {scene}\n",
            encoding="utf-8",
        )

    def test_traversal_absolute_and_backslash_scenes_are_rejected(self) -> None:
        for scene in (
            "Assets/../Secrets/Main.unity",
            "/etc/Main.unity",
            "Assets\\Scenes\\Main.unity",
            "../Assets/Scenes/Main.unity",
            "Assets/./Scenes/Main.unity",
        ):
            with self.subTest(scene=scene):
                self.set_scene(scene)
                scenes, errors = discover_scenes(self.project)
                self.assertEqual(scenes, [])
                self.assertTrue(errors)

    def test_missing_scene_blocks_instead_of_warning(self) -> None:
        self.set_scene("Assets/Scenes/Gone.unity")
        scenes, errors = discover_scenes(self.project)
        self.assertEqual(scenes, [])
        self.assertTrue(any("missing" in error for error in errors))
        config = load_config(None, self.project)
        plan = generate_plan(self.project, config, scan_project(self.project))
        self.assertTrue(plan["riskSummary"]["blocking"])  # type: ignore[index]


class StagingCollisionTests(unittest.TestCase):
    def setUp(self) -> None:
        self.temp = tempfile.TemporaryDirectory()
        self.base = Path(self.temp.name)
        self.root = make_project(self.base / "OwnedGame")
        self.project = inspect_project(self.root)
        self.plan = generate_plan(
            self.project,
            load_config(None, self.project),
            scan_project(self.project),
        )

    def tearDown(self) -> None:
        self.temp.cleanup()

    def test_generated_directory_collision_is_rejected(self) -> None:
        owned = self.root / "Assets/UnityIosPorter.Generated"
        owned.mkdir()
        (owned / "Owned.cs").write_text("public class Owned {}\n", encoding="utf-8")
        with self.assertRaisesRegex(ProjectError, "UnityIosPorter.Generated"):
            stage_project(self.project, self.base / "work", self.plan)
        self.assertFalse((self.base / "work").exists())
        self.assertTrue((owned / "Owned.cs").is_file())


class CliEndToEndContractTests(unittest.TestCase):
    def setUp(self) -> None:
        self.temp = tempfile.TemporaryDirectory()
        self.base = Path(self.temp.name)
        self.root = make_project(self.base / "OwnedGame")

    def tearDown(self) -> None:
        self.temp.cleanup()

    def run_cli(self, *arguments: str) -> subprocess.CompletedProcess[str]:
        return subprocess.run(
            [sys.executable, str(PORTER), *arguments],
            check=False,
            capture_output=True,
            text=True,
            cwd=TOOL_ROOT,
        )

    def build(self, mode: str, work: Path) -> subprocess.CompletedProcess[str]:
        unity = write_fake_unity(self.base / f"fake-unity-{mode}", mode)
        return self.run_cli(
            "build-xcode",
            "--project",
            str(self.root),
            "--work-dir",
            str(work),
            "--unity-path",
            str(unity),
            "--attest-owned-source",
        )

    def test_fake_unity_success_false_with_exit_0_fails_build(self) -> None:
        work = self.base / "work-liar"
        result = self.build("liar", work)
        self.assertEqual(result.returncode, 4, result.stdout + result.stderr)
        payload = json.loads(result.stdout)
        self.assertFalse(payload["ok"])
        self.assertTrue(
            any("success=False" in error for error in payload["errors"]),
            payload["errors"],
        )
        self.assertFalse((work / "workspace-manifest.json").exists())

    def test_fake_unity_without_xcode_output_fails_build(self) -> None:
        work = self.base / "work-noxcode"
        result = self.build("no-xcode", work)
        self.assertEqual(result.returncode, 4, result.stdout + result.stderr)
        payload = json.loads(result.stdout)
        self.assertTrue(
            any(
                "Xcode export" in error or "Xcode output directory" in error
                for error in payload["errors"]
            ),
            payload["errors"],
        )

    def test_good_fake_unity_build_writes_manifest(self) -> None:
        work = self.base / "work-good"
        result = self.build("good", work)
        self.assertEqual(result.returncode, 0, result.stdout + result.stderr)
        manifest = json.loads(
            (work / "workspace-manifest.json").read_text(encoding="utf-8")
        )
        self.assertEqual(manifest["schemaVersion"], 1)
        self.assertEqual(manifest["projectPath"], str(self.root.resolve()))
        self.assertTrue((work / "logs/unity-stdout.log").is_file())

    def test_archive_refuses_unbound_workspace(self) -> None:
        work = self.base / "work-unbound"
        work.mkdir()
        result = self.run_cli(
            "archive",
            "--project",
            str(self.root),
            "--work-dir",
            str(work),
            "--attest-owned-source",
        )
        self.assertEqual(result.returncode, 5, result.stdout + result.stderr)
        payload = json.loads(result.stdout)
        self.assertIn("refusing", payload["message"])
        self.assertTrue(
            any("manifest is missing" in error for error in payload["errors"])
        )

    def test_archive_refuses_workspace_bound_to_other_project(self) -> None:
        work = self.base / "work-good2"
        self.assertEqual(self.build("good", work).returncode, 0)
        other = make_project(self.base / "OtherGame")
        result = self.run_cli(
            "archive",
            "--project",
            str(other),
            "--work-dir",
            str(work),
            "--attest-owned-source",
        )
        self.assertEqual(result.returncode, 5, result.stdout + result.stderr)
        payload = json.loads(result.stdout)
        self.assertTrue(
            any("different source project" in error for error in payload["errors"])
        )

    @unittest.skipIf(
        shutil.which("xcodebuild") is not None,
        "host has a real xcodebuild; the missing-binary exit code is Linux-only",
    )
    def test_bound_workspace_reaches_xcodebuild_execution(self) -> None:
        work = self.base / "work-good3"
        self.assertEqual(self.build("good", work).returncode, 0)
        result = self.run_cli(
            "archive",
            "--project",
            str(self.root),
            "--work-dir",
            str(work),
            "--attest-owned-source",
        )
        # Verification passed; the failure is the absent xcodebuild binary
        # (127), not a workspace refusal.
        self.assertEqual(result.returncode, 5, result.stdout + result.stderr)
        payload = json.loads(result.stdout)
        self.assertNotIn("message", payload)
        self.assertEqual(payload["exitCode"], 127)

    def test_export_refuses_missing_archive(self) -> None:
        work = self.base / "work-good4"
        self.assertEqual(self.build("good", work).returncode, 0)
        result = self.run_cli(
            "export",
            "--project",
            str(self.root),
            "--work-dir",
            str(work),
            "--attest-owned-source",
        )
        self.assertEqual(result.returncode, 6, result.stdout + result.stderr)
        payload = json.loads(result.stdout)
        self.assertIn("refusing", payload["message"])
        self.assertTrue(
            any("xcarchive" in error for error in payload["errors"])
        )

    def test_plan_with_missing_scene_exits_2(self) -> None:
        (self.root / "Assets/Scenes/Main.unity").unlink()
        result = self.run_cli(
            "plan",
            "--project",
            str(self.root),
            "--bundle-id",
            "com.owner.game",
        )
        self.assertEqual(result.returncode, 2, result.stdout + result.stderr)
        payload = json.loads(result.stdout)
        self.assertTrue(payload["riskSummary"]["blocking"])
        self.assertTrue(payload["riskSummary"]["sceneErrors"])

    def test_build_with_missing_scene_exits_2_before_staging(self) -> None:
        (self.root / "Assets/Scenes/Main.unity").unlink()
        work = self.base / "work-noscene"
        result = self.build("good", work)
        self.assertEqual(result.returncode, 2, result.stdout + result.stderr)
        self.assertFalse(work.exists())


if __name__ == "__main__":
    unittest.main()
