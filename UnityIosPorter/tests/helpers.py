"""Synthetic Unity source fixtures used only by UnityIosPorter tests."""

from __future__ import annotations

import json
import sys
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parents[1]))


def make_project(root: Path, *, source: str = "") -> Path:
    (root / "Assets/Scripts").mkdir(parents=True)
    (root / "Assets/Scenes").mkdir(parents=True)
    (root / "ProjectSettings").mkdir(parents=True)
    (root / "Packages").mkdir(parents=True)
    (root / "Assets/Scripts/Main.cs").write_text(
        source or "public sealed class Main {}\n", encoding="utf-8"
    )
    (root / "Assets/Scenes/Main.unity").write_text(
        "%YAML 1.1\n--- !u!1 &1\nGameObject:\n", encoding="utf-8"
    )
    (root / "ProjectSettings/ProjectVersion.txt").write_text(
        "m_EditorVersion: 2022.3.41f1\n"
        "m_EditorVersionWithRevision: 2022.3.41f1 (abc123)\n",
        encoding="utf-8",
    )
    (root / "ProjectSettings/EditorBuildSettings.asset").write_text(
        "%YAML 1.1\n"
        "EditorBuildSettings:\n"
        "  m_Scenes:\n"
        "  - enabled: 1\n"
        "    path: Assets/Scenes/Main.unity\n"
        "    guid: 00000000000000000000000000000000\n",
        encoding="utf-8",
    )
    (root / "ProjectSettings/ProjectSettings.asset").write_text(
        "PlayerSettings:\n"
        "  applicationIdentifier:\n"
        "    Standalone: com.example.game\n"
        "    iPhone: com.example.game\n"
        "  scriptingBackend:\n"
        "    Standalone: 0\n"
        "    iPhone: 0\n",
        encoding="utf-8",
    )
    (root / "Packages/manifest.json").write_text(
        json.dumps(
            {
                "dependencies": {
                    "com.unity.modules.ui": "1.0.0",
                    "com.unity.textmeshpro": "3.0.6",
                }
            }
        )
        + "\n",
        encoding="utf-8",
    )
    return root
