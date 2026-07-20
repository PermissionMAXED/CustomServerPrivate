from __future__ import annotations

import tempfile
import unittest
from pathlib import Path

from helpers import make_project
from unity_ios_porter.project import inspect_project
from unity_ios_porter.scanner import mask_csharp_comments_and_strings, scan_project


class ScannerTests(unittest.TestCase):
    def setUp(self) -> None:
        self.temp = tempfile.TemporaryDirectory()
        self.root = make_project(Path(self.temp.name) / "OwnedGame")

    def tearDown(self) -> None:
        self.temp.cleanup()

    def scan_source(self, source: str) -> dict[str, object]:
        (self.root / "Assets/Scripts/Main.cs").write_text(source, encoding="utf-8")
        return scan_project(inspect_project(self.root))

    @staticmethod
    def codes(report: dict[str, object]) -> list[str]:
        return [item["code"] for item in report["findings"]]  # type: ignore[index]

    def test_clean_source_has_no_findings(self) -> None:
        report = self.scan_source(
            "using UnityEngine;\npublic sealed class Main : MonoBehaviour {}\n"
        )
        self.assertEqual(report["summary"]["total"], 0)  # type: ignore[index]

    def test_comments_and_strings_are_masked(self) -> None:
        source = (
            '// DynamicMethod Reflection.Emit BinaryFormatter\n'
            'string a = "System.Drawing and UnityEditor";\n'
            'string b = @"Assembly.Load(new byte[1])";\n'
            "char c = '\\'';\n"
        )
        report = self.scan_source(source)
        self.assertEqual(self.codes(report), [])
        masked = mask_csharp_comments_and_strings(source)
        self.assertEqual(masked.count("\n"), source.count("\n"))
        self.assertEqual(len(masked), len(source))

    def test_runtime_code_generation_patterns_are_found(self) -> None:
        report = self.scan_source(
            "using System.Reflection.Emit;\n"
            "class Bad { DynamicMethod m; void X(byte[] rawBytes) {\n"
            "  var a = Assembly.Load(rawBytes);\n"
            "} }\n"
        )
        codes = self.codes(report)
        self.assertIn("AOT001", codes)
        self.assertIn("AOT002", codes)
        self.assertIn("AOT003", codes)

    def test_dynamic_expression_and_binary_formatter_are_found(self) -> None:
        report = self.scan_source(
            "using System.Linq.Expressions;\n"
            "class Bad { dynamic value; BinaryFormatter formatter;\n"
            "void X(Expression<System.Action> expression) { expression.Compile(); } }\n"
        )
        codes = self.codes(report)
        self.assertIn("AOT004", codes)
        self.assertIn("AOT005", codes)
        self.assertIn("SEC001", codes)

    def test_unity_editor_outside_editor_directory_is_an_error(self) -> None:
        report = self.scan_source("using UnityEditor;\nclass Bad {}\n")
        self.assertIn("IOS001", self.codes(report))

    def test_unity_editor_inside_editor_directory_is_allowed(self) -> None:
        editor = self.root / "Assets/Tools/Editor"
        editor.mkdir(parents=True)
        (editor / "Window.cs").write_text(
            "using UnityEditor;\nclass Window {}\n", encoding="utf-8"
        )
        report = scan_project(inspect_project(self.root))
        self.assertNotIn("IOS001", self.codes(report))

    def test_system_drawing_is_found(self) -> None:
        report = self.scan_source("using System.Drawing;\nclass Bad {}\n")
        self.assertIn("IOS002", self.codes(report))

    def test_windows_dllimport_is_found_but_comment_is_not(self) -> None:
        report = self.scan_source(
            "using System.Runtime.InteropServices;\n"
            '// [DllImport("kernel32.dll")]\n'
            "class Bad { [DllImport(\"user32.dll\")] static extern void X(); }\n"
        )
        ios003 = [
            item
            for item in report["findings"]  # type: ignore[index]
            if item["code"] == "IOS003"
        ]
        self.assertEqual(len(ios003), 1)
        self.assertIn("user32.dll", ios003[0]["message"])

    def test_heavy_reflection_without_link_xml_warns(self) -> None:
        report = self.scan_source(
            "using System;\nusing System.Reflection;\nclass R { void X() {\n"
            'Type.GetType("A"); typeof(R).GetMethod("X"); '
            "Activator.CreateInstance(typeof(R)); } }\n"
        )
        self.assertIn("AOT006", self.codes(report))
        (self.root / "Assets/link.xml").write_text("<linker />\n", encoding="utf-8")
        report = scan_project(inspect_project(self.root))
        self.assertNotIn("AOT006", self.codes(report))

    def test_plugin_extensions_and_meta_are_checked(self) -> None:
        plugins = self.root / "Assets/Plugins"
        plugins.mkdir()
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
        report = scan_project(inspect_project(self.root))
        codes = self.codes(report)
        self.assertIn("PLG001", codes)
        self.assertIn("PLG002", codes)
        self.assertIn("PLG003", codes)

    def test_finding_line_numbers_and_paths_are_stable(self) -> None:
        report = self.scan_source("\n\nusing System.Drawing;\n")
        finding = report["findings"][0]  # type: ignore[index]
        self.assertEqual(finding["line"], 3)
        self.assertEqual(finding["path"], "Assets/Scripts/Main.cs")


if __name__ == "__main__":
    unittest.main()
