from __future__ import annotations

import subprocess
import sys
import tempfile
import unittest
from pathlib import Path

from helpers import make_project
from unity_ios_porter.operations import initialize_ci
from unity_ios_porter.project import inspect_project
from unity_ios_porter.scanner import scan_project


TOOL_ROOT = Path(__file__).resolve().parents[1]
REPOSITORY_ROOT = TOOL_ROOT.parent
PORTER = TOOL_ROOT / "porter.py"


class ScannerRemediationTests(unittest.TestCase):
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

    def test_embedded_package_csharp_is_scanned(self) -> None:
        package = self.root / "Packages/com.owner.local/Runtime"
        package.mkdir(parents=True)
        (package / "Risk.cs").write_text(
            "using System.Drawing;\npublic sealed class Risk {}\n",
            encoding="utf-8",
        )

        findings = self.findings(self.scan(), "IOS002")

        self.assertEqual(len(findings), 1)
        self.assertEqual(
            findings[0]["path"], "Packages/com.owner.local/Runtime/Risk.cs"
        )

    def test_interpolation_expression_is_scanned_without_scanning_literal_text(self) -> None:
        (self.root / "Assets/Scripts/Main.cs").write_text(
            "using System.Reflection;\n"
            "public sealed class Risk {\n"
            "  string Load(byte[] bytes) => "
            '$"literal Assembly.Load(fake): {Assembly.Load(bytes)}";\n'
            "}\n",
            encoding="utf-8",
        )

        findings = self.findings(self.scan(), "AOT003")

        self.assertEqual(len(findings), 1)
        self.assertIn("Assembly.Load(bytes)", findings[0]["evidence"])

    def test_expression_compile_has_one_precise_finding(self) -> None:
        (self.root / "Assets/Scripts/Main.cs").write_text(
            "using System;\n"
            "using System.Linq.Expressions;\n"
            "public sealed class Risk {\n"
            "  dynamic Build(Expression<Func<int>> expression) "
            "=> expression.Compile();\n"
            "}\n",
            encoding="utf-8",
        )

        report = self.scan()

        self.assertEqual(len(self.findings(report, "AOT005")), 1)
        self.assertEqual(len(self.findings(report, "AOT004")), 1)

    def test_link_xml_directory_does_not_suppress_reflection_warning(self) -> None:
        (self.root / "Assets/Scripts/Main.cs").write_text(
            "using System;\n"
            "using System.Reflection;\n"
            "public sealed class Risk { void Run() {\n"
            '  Type.GetType("A"); GetType().GetMethod("Run");\n'
            "  Activator.CreateInstance(typeof(Risk));\n"
            "} }\n",
            encoding="utf-8",
        )
        (self.root / "Assets/link.xml").mkdir()

        report = self.scan()

        self.assertEqual(len(self.findings(report, "AOT006")), 1)
        self.assertFalse(report["summary"]["linkXmlPresent"])  # type: ignore[index]

    def test_android_disabled_does_not_override_iphone_enabled(self) -> None:
        plugins = self.root / "Assets/Plugins"
        plugins.mkdir()
        (plugins / "managed.dll").write_bytes(b"synthetic")
        (plugins / "managed.dll.meta").write_text(
            "PluginImporter:\n"
            "  platformData:\n"
            "  - first:\n"
            "      iPhone: iPhone\n"
            "    second:\n"
            "      enabled: 1\n"
            "  - first:\n"
            "      Android: Android\n"
            "    second:\n"
            "      enabled: 0\n",
            encoding="utf-8",
        )

        report = self.scan()

        self.assertEqual(len(self.findings(report, "PLG002")), 1)
        self.assertEqual(self.findings(report, "PLG003"), [])


class CliAndWorkflowRemediationTests(unittest.TestCase):
    def setUp(self) -> None:
        self.temp = tempfile.TemporaryDirectory()
        self.root = make_project(Path(self.temp.name) / "OwnedGame")

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

    def test_non_object_manifests_exit_cleanly(self) -> None:
        manifest = self.root / "Packages/manifest.json"
        for malformed_root in ("[]\n", "null\n"):
            with self.subTest(manifest=malformed_root.strip()):
                manifest.write_text(malformed_root, encoding="utf-8")
                result = self.run_cli("detect", "--project", str(self.root))
                self.assertEqual(result.returncode, 64)
                self.assertIn("root must be a JSON object", result.stderr)
                self.assertNotIn("Traceback", result.stderr)

    def test_generated_owner_workflow_has_pinned_push_preflight(self) -> None:
        workflow = initialize_ci(self.root)
        text = workflow.read_text(encoding="utf-8")

        self.assertIn("  push:\n", text)
        self.assertIn("  pull_request:\n", text)
        self.assertEqual(
            text.count('      - ".github/workflows/unity-ios-porter.yml"\n'),
            2,
        )
        self.assertIn("actions/setup-python@", text)
        self.assertIn('python-version: "3.11"', text)
        self.assertIn("run: python UnityIosPorter/porter.py detect", text)

    def test_tool_ci_uses_setup_python_interpreter(self) -> None:
        workflow = (
            REPOSITORY_ROOT / ".github/workflows/unity-ios-porter-ci.yml"
        ).read_text(encoding="utf-8")

        self.assertIn("actions/setup-python@", workflow)
        self.assertIn('python-version: ["3.11", "3.12"]', workflow)
        self.assertIn("run: python -m compileall", workflow)
        self.assertIn("run: python -m unittest", workflow)


if __name__ == "__main__":
    unittest.main()
