from __future__ import annotations

import json
import subprocess
import sys
import tempfile
import unittest
from pathlib import Path

from helpers import make_project

TOOL_ROOT = Path(__file__).resolve().parents[1]
PORTER = TOOL_ROOT / "porter.py"


class CliTests(unittest.TestCase):
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

    def test_version(self) -> None:
        result = self.run_cli("--version")
        self.assertEqual(result.returncode, 0)
        self.assertIn("1.0.0", result.stdout)

    def test_usage_errors_use_exit_64(self) -> None:
        result = self.run_cli()
        self.assertEqual(result.returncode, 64)
        self.assertIn("usage:", result.stderr)

    def test_detect_outputs_project_contract(self) -> None:
        result = self.run_cli("detect", "--project", str(self.root))
        self.assertEqual(result.returncode, 0, result.stderr)
        payload = json.loads(result.stdout)
        self.assertEqual(payload["schemaVersion"], 1)
        self.assertEqual(payload["project"]["unity_version"], "2022.3.41f1")

    def test_suspicious_input_is_exit_64(self) -> None:
        (self.root / "Assets/Export.ipa").write_bytes(b"synthetic marker")
        result = self.run_cli("detect", "--project", str(self.root))
        self.assertEqual(result.returncode, 64)
        self.assertIn("refusing", result.stderr)

    def test_scan_clean_and_risky_exit_codes(self) -> None:
        clean = self.run_cli("scan", "--project", str(self.root))
        self.assertEqual(clean.returncode, 0, clean.stderr)
        (self.root / "Assets/Scripts/Main.cs").write_text(
            "using System.Drawing;\n", encoding="utf-8"
        )
        risky = self.run_cli("scan", "--project", str(self.root))
        self.assertEqual(risky.returncode, 2)
        self.assertEqual(json.loads(risky.stdout)["summary"]["error"], 1)

    def test_doctor_is_exit_3_on_linux(self) -> None:
        result = self.run_cli("doctor", "--project", str(self.root))
        self.assertEqual(result.returncode, 3, result.stderr)
        self.assertFalse(json.loads(result.stdout)["summary"]["ready"])

    def test_plan_outputs_migration_contract(self) -> None:
        result = self.run_cli(
            "plan",
            "--project",
            str(self.root),
            "--bundle-id",
            "com.owner.game",
        )
        self.assertEqual(result.returncode, 0, result.stderr)
        payload = json.loads(result.stdout)
        self.assertEqual(payload["settings"]["scriptingBackend"], "IL2CPP")
        self.assertEqual(payload["technicalTruth"]["architecture"], "ARM64")

    def test_build_requires_attestation(self) -> None:
        result = self.run_cli(
            "build-xcode",
            "--project",
            str(self.root),
            "--work-dir",
            str(self.base / "work"),
        )
        self.assertEqual(result.returncode, 64)
        self.assertIn("--attest-owned-source", result.stderr)

    def test_build_dry_run_prints_command_without_writing(self) -> None:
        work = self.base / "work"
        result = self.run_cli(
            "build-xcode",
            "--project",
            str(self.root),
            "--work-dir",
            str(work),
            "--attest-owned-source",
            "--dry-run",
        )
        self.assertEqual(result.returncode, 0, result.stderr)
        payload = json.loads(result.stdout)
        self.assertIn("-executeMethod", payload["command"])
        self.assertFalse(work.exists())

    def test_blocking_scan_prevents_build(self) -> None:
        (self.root / "Assets/Scripts/Main.cs").write_text(
            "using System.Drawing;\n", encoding="utf-8"
        )
        result = self.run_cli(
            "build-xcode",
            "--project",
            str(self.root),
            "--work-dir",
            str(self.base / "work"),
            "--attest-owned-source",
            "--dry-run",
        )
        self.assertEqual(result.returncode, 2)
        self.assertFalse((self.base / "work").exists())

    def test_missing_unity_is_exit_4_with_result_contract(self) -> None:
        work = self.base / "work"
        result = self.run_cli(
            "build-xcode",
            "--project",
            str(self.root),
            "--work-dir",
            str(work),
            "--unity-path",
            str(self.base / "missing-unity"),
            "--attest-owned-source",
        )
        self.assertEqual(result.returncode, 4, result.stderr)
        contract = json.loads((work / "result.json").read_text(encoding="utf-8"))
        self.assertFalse(contract["success"])
        self.assertEqual(contract["phase"], "build-xcode")

    def test_archive_and_export_dry_runs(self) -> None:
        common = (
            "--project",
            str(self.root),
            "--work-dir",
            str(self.base / "work"),
            "--attest-owned-source",
            "--dry-run",
        )
        archive = self.run_cli("archive", *common)
        export = self.run_cli("export", *common)
        self.assertEqual(archive.returncode, 0, archive.stderr)
        self.assertEqual(export.returncode, 0, export.stderr)
        self.assertEqual(json.loads(archive.stdout)["phase"], "archive")
        self.assertEqual(json.loads(export.stdout)["phase"], "export")
        self.assertFalse((self.base / "work").exists())

    def test_all_dry_run_executes_all_command_builders(self) -> None:
        result = self.run_cli(
            "all",
            "--project",
            str(self.root),
            "--work-dir",
            str(self.base / "work"),
            "--attest-owned-source",
            "--dry-run",
        )
        self.assertEqual(result.returncode, 0, result.stderr)
        phases = json.loads(result.stdout)["phases"]
        self.assertEqual(
            [phase["phase"] for phase in phases],
            ["build-xcode", "archive", "export"],
        )

    def test_ci_init_dry_run_and_write(self) -> None:
        dry = self.run_cli(
            "ci",
            "init",
            "--project",
            str(self.root),
            "--attest-owned-source",
            "--dry-run",
        )
        self.assertEqual(dry.returncode, 0, dry.stderr)
        destination = self.root / ".github/workflows/unity-ios-porter.yml"
        self.assertFalse(destination.exists())
        write = self.run_cli(
            "ci",
            "init",
            "--project",
            str(self.root),
            "--attest-owned-source",
        )
        self.assertEqual(write.returncode, 0, write.stderr)
        self.assertTrue(destination.is_file())


if __name__ == "__main__":
    unittest.main()
