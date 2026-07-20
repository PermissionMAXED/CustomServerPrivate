"""Executable fake Unity and xcodebuild tools for CLI contract tests."""

from __future__ import annotations

from pathlib import Path


FAKE_UNITY_TEMPLATE = """#!/usr/bin/env python3
import json, os, sys

def argument(name):
    argv = sys.argv
    for index, value in enumerate(argv[:-1]):
        if value == name:
            return argv[index + 1]
    return ""

mode = {mode!r}
result_path = argument("-porterResult")
plan_path = argument("-porterConfig")
plan = json.load(open(plan_path, encoding="utf-8"))
xcode = plan["paths"]["xcodeOutput"]
payload = {{
    "schemaVersion": 1,
    "phase": "build-xcode",
    "unityVersion": "2022.3.41f1",
    "outputPath": xcode,
    "result": "Succeeded",
    "success": True,
    "totalSize": 1,
    "durationSeconds": 0.1,
    "errors": 0,
    "warnings": 0,
    "error": "",
}}
if mode == "liar":
    payload["success"] = False
    payload["result"] = "Failed"
    payload["error"] = "synthetic build failure hidden behind exit 0"
elif mode == "good":
    project = os.path.join(xcode, "Unity-iPhone.xcodeproj")
    os.makedirs(project, exist_ok=True)
    open(os.path.join(project, "project.pbxproj"), "w").write("// pbxproj\\n")
elif mode == "no-xcode":
    pass
os.makedirs(os.path.dirname(result_path), exist_ok=True)
json.dump(payload, open(result_path, "w", encoding="utf-8"))
sys.exit(0)
"""


FAKE_XCODEBUILD_TEMPLATE = """#!/usr/bin/env python3
import os, sys

def argument(name):
    argv = sys.argv
    for index, value in enumerate(argv[:-1]):
        if value == name:
            return argv[index + 1]
    return ""

mode = {mode!r}
if mode == "liar":
    sys.exit(0)
if "-exportArchive" in sys.argv:
    export_path = argument("-exportPath")
    os.makedirs(export_path, exist_ok=True)
    open(os.path.join(export_path, "Fake.ipa"), "wb").write(b"synthetic ipa")
elif "archive" in sys.argv:
    archive_path = argument("-archivePath")
    applications = os.path.join(archive_path, "Products", "Applications")
    os.makedirs(os.path.join(applications, "Fake.app"), exist_ok=True)
    open(os.path.join(archive_path, "Info.plist"), "wb").write(b"<plist/>\\n")
sys.exit(0)
"""


def _write_executable(path: Path, content: str) -> Path:
    path.write_text(content, encoding="utf-8")
    path.chmod(0o755)
    return path


def write_fake_unity(path: Path, mode: str) -> Path:
    return _write_executable(path, FAKE_UNITY_TEMPLATE.format(mode=mode))


def write_fake_xcodebuild(path: Path, mode: str = "good") -> Path:
    return _write_executable(path, FAKE_XCODEBUILD_TEMPLATE.format(mode=mode))
