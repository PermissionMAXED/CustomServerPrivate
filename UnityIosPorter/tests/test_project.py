from __future__ import annotations

import json
import shutil
import tempfile
import unittest
from pathlib import Path

from helpers import make_project
from unity_ios_porter.project import (
    PolicyError,
    ProjectError,
    find_suspicious_markers,
    inspect_project,
    require_owned_source_attestation,
)


class ProjectTests(unittest.TestCase):
    def setUp(self) -> None:
        self.temp = tempfile.TemporaryDirectory()
        self.root = make_project(Path(self.temp.name) / "OwnedGame")

    def tearDown(self) -> None:
        self.temp.cleanup()

    def test_valid_project_is_detected(self) -> None:
        project = inspect_project(self.root)
        self.assertEqual(project.unity_version, "2022.3.41f1")
        self.assertEqual(
            project.manifest_dependencies,
            ("com.unity.modules.ui", "com.unity.textmeshpro"),
        )
        payload = project.to_dict()
        self.assertIs(payload["suspicious_markers_absent"], True)
        # The old key overclaimed a "passed ownership policy"; only the
        # advisory marker check is reported now.
        self.assertNotIn("owned_source_policy", payload)

    def test_required_project_paths_are_enforced(self) -> None:
        cases = (
            "Assets",
            "ProjectSettings",
            "ProjectSettings/ProjectVersion.txt",
            "Packages/manifest.json",
        )
        for relative in cases:
            with self.subTest(relative=relative):
                other = make_project(Path(self.temp.name) / relative.replace("/", "_"))
                target = other / relative
                if target.is_dir():
                    shutil.rmtree(target)
                else:
                    target.unlink()
                with self.assertRaises(ProjectError):
                    inspect_project(other)

    def test_required_directories_cannot_be_files(self) -> None:
        (self.root / "Assets/Scripts/Main.cs").unlink()
        (self.root / "Assets/Scripts").rmdir()
        (self.root / "Assets/Scenes/Main.unity").unlink()
        (self.root / "Assets/Scenes").rmdir()
        (self.root / "Assets").rmdir()
        (self.root / "Assets").write_text("not a directory", encoding="utf-8")
        with self.assertRaises(ProjectError):
            inspect_project(self.root)

    def test_invalid_project_version_is_rejected(self) -> None:
        (self.root / "ProjectSettings/ProjectVersion.txt").write_text(
            "m_EditorVersion: unknown\n", encoding="utf-8"
        )
        with self.assertRaisesRegex(ProjectError, "m_EditorVersion"):
            inspect_project(self.root)

    def test_invalid_manifest_json_is_rejected(self) -> None:
        (self.root / "Packages/manifest.json").write_text("{", encoding="utf-8")
        with self.assertRaisesRegex(ProjectError, "manifest"):
            inspect_project(self.root)

    def test_manifest_requires_dependencies_object(self) -> None:
        (self.root / "Packages/manifest.json").write_text(
            json.dumps({"dependencies": []}), encoding="utf-8"
        )
        with self.assertRaisesRegex(ProjectError, "dependencies"):
            inspect_project(self.root)

    def test_reconstruction_directory_is_rejected(self) -> None:
        (self.root / "DummyDll").mkdir()
        (self.root / "DummyDll/Recovered.cs").write_text("class X {}", encoding="utf-8")
        with self.assertRaises(PolicyError) as caught:
            inspect_project(self.root)
        self.assertIn("DummyDll/", caught.exception.markers)

    def test_prefixed_reconstruction_tool_directory_is_rejected(self) -> None:
        (self.root / "Il2CppDumper-output").mkdir()
        with self.assertRaises(PolicyError):
            inspect_project(self.root)

    def test_shipped_il2cpp_artifacts_are_rejected(self) -> None:
        for name in ("global-metadata.dat", "GameAssembly.dll", "dump.cs", "game.ipa"):
            with self.subTest(name=name):
                path = self.root / "Assets" / name
                path.write_bytes(b"synthetic marker")
                markers = find_suspicious_markers(self.root)
                self.assertIn(f"Assets/{name}", markers)
                path.unlink()

    def test_app_bundle_directory_is_rejected(self) -> None:
        (self.root / "Assets/ExportedGame.app").mkdir()
        with self.assertRaises(PolicyError):
            inspect_project(self.root)

    def test_attestation_is_required_for_writes(self) -> None:
        with self.assertRaises(PolicyError):
            require_owned_source_attestation(False)
        require_owned_source_attestation(True)

    def test_symlinks_are_rejected_before_staging(self) -> None:
        target = self.root / "Assets/Scripts/Main.cs"
        link = self.root / "Assets/Scripts/Linked.cs"
        try:
            link.symlink_to(target)
        except OSError as exc:
            self.skipTest(f"symlinks unavailable: {exc}")
        with self.assertRaisesRegex(ProjectError, "symbolic links"):
            inspect_project(self.root)


if __name__ == "__main__":
    unittest.main()
