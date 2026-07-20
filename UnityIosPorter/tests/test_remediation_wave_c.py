"""Wave C remediation tests for policy walks, shipped code, and fake tools."""

from __future__ import annotations

import json
import os
import subprocess
import sys
import tempfile
import unittest
from pathlib import Path

from fake_tools import write_fake_unity, write_fake_xcodebuild
from helpers import make_project
from unity_ios_porter.operations import (
    source_digest,
    stage_project,
    workspace_paths,
    write_export_options,
)
from unity_ios_porter.planner import generate_plan, load_config
from unity_ios_porter.project import (
    GENERATED_ROOT_DIRECTORY_NAMES,
    PolicyError,
    ProjectError,
    inspect_project,
)
from unity_ios_porter.scanner import mask_unity_editor_regions, scan_project


TOOL_ROOT = Path(__file__).resolve().parents[1]
PORTER = TOOL_ROOT / "porter.py"


class GeneratedRootPolicyTests(unittest.TestCase):
    def setUp(self) -> None:
        self.temp = tempfile.TemporaryDirectory()
        self.base = Path(self.temp.name)
        self.root = make_project(self.base / "OwnedGame")

    def tearDown(self) -> None:
        self.temp.cleanup()

    def test_generated_roots_are_accepted_and_match_staging_ignores(self) -> None:
        self.assertEqual(
            GENERATED_ROOT_DIRECTORY_NAMES,
            frozenset({".git", "Library", "Logs", "Temp", "obj"}),
        )
        for name in GENERATED_ROOT_DIRECTORY_NAMES:
            generated = self.root / name / "PackageCache/extracted"
            generated.mkdir(parents=True)
            (generated / "dump.cs").write_text("synthetic\n", encoding="utf-8")

        try:
            (self.root / "Library/Bee").symlink_to(
                self.root / "Assets", target_is_directory=True
            )
        except OSError as exc:
            self.skipTest(f"symlinks unavailable: {exc}")

        project = inspect_project(self.root)
        plan = generate_plan(
            project, load_config(None, project), scan_project(project)
        )
        paths = stage_project(project, self.base / "work", plan)
        staged = Path(paths["staged"])

        for name in GENERATED_ROOT_DIRECTORY_NAMES:
            self.assertFalse((staged / name).exists(), name)

    def test_suspicious_markers_outside_generated_roots_still_refuse(self) -> None:
        cases = (
            "Assets/Library/extracted/Recovered.cs",
            "Packages/com.owner.local/dump.cs",
            "ProjectSettings/GameAssembly.dll",
        )
        for index, relative in enumerate(cases):
            with self.subTest(relative=relative):
                root = make_project(self.base / f"OwnedGame{index}")
                marker = root / relative
                marker.parent.mkdir(parents=True, exist_ok=True)
                marker.write_text("synthetic\n", encoding="utf-8")
                with self.assertRaises(PolicyError):
                    inspect_project(root)

    def test_symlink_in_nested_library_directory_still_refuses(self) -> None:
        nested = self.root / "Assets/Library"
        nested.mkdir()
        link = nested / "Linked.cs"
        try:
            link.symlink_to(self.root / "Assets/Scripts/Main.cs")
        except OSError as exc:
            self.skipTest(f"symlinks unavailable: {exc}")

        with self.assertRaisesRegex(ProjectError, "symbolic links"):
            inspect_project(self.root)


class ScannerShippedCodeTests(unittest.TestCase):
    def setUp(self) -> None:
        self.temp = tempfile.TemporaryDirectory()
        self.root = make_project(Path(self.temp.name) / "OwnedGame")

    def tearDown(self) -> None:
        self.temp.cleanup()

    def scan(self) -> dict[str, object]:
        return scan_project(inspect_project(self.root))

    @staticmethod
    def findings(report: dict[str, object], code: str) -> list[dict[str, object]]:
        return [
            finding
            for finding in report["findings"]  # type: ignore[index]
            if finding["code"] == code
        ]

    def write_main(self, source: str) -> None:
        (self.root / "Assets/Scripts/Main.cs").write_text(source, encoding="utf-8")

    def test_embedded_package_plugins_use_existing_rules(self) -> None:
        plugins = self.root / "Packages/com.owner.local/Plugins"
        plugins.mkdir(parents=True)
        (plugins / "native.so").write_bytes(b"synthetic")
        (plugins / "managed.dll").write_bytes(b"synthetic")
        (plugins / "managed.dll.meta").write_text(
            "PluginImporter:\n"
            "  platformData:\n"
            "  - first:\n"
            "      iPhone: iPhone\n"
            "    second:\n"
            "      enabled: 0\n",
            encoding="utf-8",
        )

        report = self.scan()

        self.assertEqual(
            self.findings(report, "PLG001")[0]["path"],
            "Packages/com.owner.local/Plugins/native.so",
        )
        self.assertEqual(len(self.findings(report, "PLG002")), 1)
        self.assertEqual(len(self.findings(report, "PLG003")), 1)

    def test_token_exact_unity_editor_branch_is_masked(self) -> None:
        self.write_main(
            "#if UNITY_EDITOR\n"
            "using System.Drawing;\n"
            "class EditorOnly {\n"
            "  dynamic Value; BinaryFormatter Formatter; DynamicMethod Method;\n"
            '  [DllImport("user32.dll")] static extern void Native();\n'
            '  void Reflect() { Type.GetType("A"); GetType().GetMethod("B"); '
            "Activator.CreateInstance(typeof(EditorOnly)); }\n"
            "}\n"
            "#endif\n"
        )

        report = self.scan()

        self.assertEqual(report["findings"], [])
        self.assertEqual(report["summary"]["reflectionUses"], 0)  # type: ignore[index]

    def test_else_branch_stays_scanned_with_correct_line_number(self) -> None:
        self.write_main(
            "#if UNITY_EDITOR\n"
            "using System.Drawing;\n"
            "#else\n"
            "\n"
            "using System.Drawing;\n"
            "#endif\n"
        )

        findings = self.findings(self.scan(), "IOS002")

        self.assertEqual(len(findings), 1)
        self.assertEqual(findings[0]["line"], 5)

    def test_compound_unity_editor_condition_stays_scanned(self) -> None:
        self.write_main(
            "#if UNITY_EDITOR || DEVELOPMENT_BUILD\n"
            "using System.Drawing;\n"
            "#endif\n"
        )

        self.assertEqual(len(self.findings(self.scan(), "IOS002")), 1)

    def test_nested_regions_mask_only_the_unity_editor_branch(self) -> None:
        self.write_main(
            "#if UNITY_EDITOR\n"
            "#if INNER\n"
            "using System.Drawing;\n"
            "#else\n"
            "DynamicMethod Hidden;\n"
            "#endif\n"
            "#else\n"
            "BinaryFormatter RuntimeFormatter;\n"
            "#endif\n"
        )

        report = self.scan()

        self.assertEqual(self.findings(report, "IOS002"), [])
        self.assertEqual(self.findings(report, "AOT002"), [])
        self.assertEqual(len(self.findings(report, "SEC001")), 1)
        self.assertEqual(self.findings(report, "SEC001")[0]["line"], 8)

    def test_unity_editor_mask_preserves_offsets_and_newlines(self) -> None:
        source = "#if UNITY_EDITOR\r\nSystem.Drawing;\r\n#endif\r\n"
        masked = mask_unity_editor_regions(source)

        self.assertEqual(len(masked), len(source))
        self.assertEqual(masked.count("\n"), source.count("\n"))
        self.assertNotIn("System.Drawing", masked)

    def test_editor_folder_skips_runtime_rules_and_reflection_counting(self) -> None:
        editor = self.root / "Assets/Tools/Editor"
        editor.mkdir(parents=True)
        (editor / "Risk.cs").write_text(
            "using System.Drawing;\n"
            "using System.Linq.Expressions;\n"
            "class Risk { dynamic Value; BinaryFormatter Formatter; DynamicMethod Method;\n"
            '  [DllImport("kernel32.dll")] static extern void Native();\n'
            "  void Compile(Expression<System.Action> value) { value.Compile(); }\n"
            '  void Reflect() { Type.GetType("A"); GetType().GetMethod("B"); '
            "Activator.CreateInstance(typeof(Risk)); }\n"
            "}\n",
            encoding="utf-8",
        )

        report = self.scan()

        self.assertEqual(report["findings"], [])
        self.assertEqual(report["summary"]["reflectionUses"], 0)  # type: ignore[index]

    def test_non_utf8_editor_source_keeps_src001(self) -> None:
        editor = self.root / "Assets/Editor"
        editor.mkdir()
        (editor / "Unreadable.cs").write_bytes(b"\xff")

        report = self.scan()

        self.assertEqual(len(self.findings(report, "SRC001")), 1)


class WorkspaceHardeningTests(unittest.TestCase):
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

    def test_source_digest_ignores_generated_library_content(self) -> None:
        paths = stage_project(self.project, self.base / "work", self.plan)
        staged = Path(paths["staged"])
        before = source_digest(staged)
        library = staged / "Library"
        library.mkdir()
        (library / "BuildCache.bin").write_bytes(b"generated")

        self.assertEqual(source_digest(staged), before)

        (staged / "Assets/Scripts/Main.cs").write_text(
            "public sealed class Main { public int Changed; }\n", encoding="utf-8"
        )
        self.assertNotEqual(source_digest(staged), before)

    def test_export_options_refuse_symlink_without_overwriting_target(self) -> None:
        victim = self.base / "victim.plist"
        victim.write_bytes(b"keep")
        target = workspace_paths(self.base / "work")["export_options"]
        target.parent.mkdir()
        try:
            target.symlink_to(victim)
        except OSError as exc:
            self.skipTest(f"symlinks unavailable: {exc}")

        with self.assertRaisesRegex(ProjectError, "refusing to overwrite"):
            write_export_options(target, self.config)

        self.assertEqual(victim.read_bytes(), b"keep")


class FakeToolCliTests(unittest.TestCase):
    def setUp(self) -> None:
        self.temp = tempfile.TemporaryDirectory()
        self.base = Path(self.temp.name)
        self.root = make_project(self.base / "OwnedGame")
        self.tools = self.base / "tools"
        self.tools.mkdir()
        self.unity = write_fake_unity(self.tools / "Unity", "good")
        write_fake_xcodebuild(self.tools / "xcodebuild")
        self.environment = {
            **os.environ,
            "PATH": str(self.tools) + os.pathsep + os.environ.get("PATH", ""),
        }

    def tearDown(self) -> None:
        self.temp.cleanup()

    def run_cli(self, *arguments: str) -> subprocess.CompletedProcess[str]:
        return subprocess.run(
            [sys.executable, str(PORTER), *arguments],
            check=False,
            capture_output=True,
            text=True,
            cwd=TOOL_ROOT,
            env=self.environment,
        )

    def common(self, work: Path) -> tuple[str, ...]:
        return (
            "--project",
            str(self.root),
            "--work-dir",
            str(work),
            "--attest-owned-source",
        )

    def build(self, work: Path) -> subprocess.CompletedProcess[str]:
        return self.run_cli(
            "build-xcode",
            *self.common(work),
            "--unity-path",
            str(self.unity),
        )

    def archive(self, work: Path) -> subprocess.CompletedProcess[str]:
        return self.run_cli("archive", *self.common(work))

    def test_archive_succeeds_and_verifies_fake_xcarchive(self) -> None:
        work = self.base / "archive-work"
        self.assertEqual(self.build(work).returncode, 0)

        result = self.archive(work)

        self.assertEqual(result.returncode, 0, result.stdout + result.stderr)
        archive = workspace_paths(work)["archive"]
        self.assertTrue((archive / "Info.plist").is_file())
        self.assertTrue((archive / "Products/Applications/Fake.app").is_dir())

    def test_export_succeeds_and_verifies_fake_ipa(self) -> None:
        work = self.base / "export-work"
        self.assertEqual(self.build(work).returncode, 0)
        self.assertEqual(self.archive(work).returncode, 0)

        result = self.run_cli("export", *self.common(work))

        self.assertEqual(result.returncode, 0, result.stdout + result.stderr)
        self.assertTrue((workspace_paths(work)["export"] / "Fake.ipa").is_file())

    def test_all_runs_build_archive_export_and_writes_logs(self) -> None:
        work = self.base / "all-work"

        result = self.run_cli(
            "all",
            *self.common(work),
            "--unity-path",
            str(self.unity),
        )

        self.assertEqual(result.returncode, 0, result.stdout + result.stderr)
        payload = json.loads(result.stdout)
        self.assertEqual(
            [phase["phase"] for phase in payload["phases"]],
            ["build-xcode", "archive", "export"],
        )
        paths = workspace_paths(work)
        self.assertTrue(paths["manifest"].is_file())
        self.assertTrue(paths["archive"].is_dir())
        self.assertTrue((paths["export"] / "Fake.ipa").is_file())
        self.assertTrue(paths["unity_stdout_log"].is_file())
        self.assertTrue(paths["archive_log"].is_file())
        self.assertTrue(paths["export_log"].is_file())

    def test_xcodebuild_exit_zero_without_archive_still_exits_five(self) -> None:
        work = self.base / "liar-work"
        self.assertEqual(self.build(work).returncode, 0)
        write_fake_xcodebuild(self.tools / "xcodebuild", "liar")

        result = self.archive(work)

        self.assertEqual(result.returncode, 5, result.stdout + result.stderr)
        payload = json.loads(result.stdout)
        self.assertTrue(any("xcarchive" in error for error in payload["errors"]))
        self.assertTrue(workspace_paths(work)["archive_log"].is_file())


if __name__ == "__main__":
    unittest.main()
