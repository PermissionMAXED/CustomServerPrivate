"""Staging, environment checks, and external command construction."""

from __future__ import annotations

import json
import os
import plistlib
import platform
import shutil
import subprocess
from pathlib import Path
from typing import Callable, Sequence

from .planner import PorterConfig
from .project import ProjectError, ProjectInfo

TOOL_ROOT = Path(__file__).resolve().parent.parent
BRIDGE_TEMPLATE = TOOL_ROOT / "templates/BatchEntry.cs"
CI_TEMPLATE = TOOL_ROOT / "templates/unity-ios-porter.yml"


def _path_is_within(child: Path, parent: Path) -> bool:
    try:
        child.resolve().relative_to(parent.resolve())
        return True
    except ValueError:
        return False


def workspace_paths(work_dir: str | Path) -> dict[str, Path]:
    root = Path(work_dir).expanduser().resolve()
    return {
        "root": root,
        "staged": root / "staged-project",
        "xcode": root / "xcode",
        "plan": root / "build-plan.json",
        "result": root / "result.json",
        "log": root / "unity.log",
        "archive": root / "archives/UnityIosPorter.xcarchive",
        "export": root / "export",
        "export_options": root / "ExportOptions.plist",
    }


def stage_project(
    project: ProjectInfo,
    work_dir: str | Path,
    plan: dict[str, object],
    *,
    dry_run: bool = False,
) -> dict[str, str]:
    paths = workspace_paths(work_dir)
    source = Path(project.root)
    if _path_is_within(paths["root"], source):
        raise ProjectError(
            "work directory must be outside the source project to prevent recursive "
            "copies and guarantee source immutability"
        )
    if paths["root"].exists():
        raise ProjectError(
            f"work directory already exists: {paths['root']} (choose an empty path)"
        )
    if dry_run:
        return {key: str(value) for key, value in paths.items()}

    paths["root"].mkdir(parents=True)
    def ignore(directory: str, names: list[str]) -> set[str]:
        current = Path(directory).resolve()
        if current == source:
            return {
                name
                for name in names
                if name in {".git", "Library", "Logs", "Temp", "obj"}
            }
        if current == source / "Assets" and "UnityIosPorter.Generated" in names:
            return {"UnityIosPorter.Generated"}
        return set()

    shutil.copytree(source, paths["staged"], symlinks=False, ignore=ignore)
    bridge = (
        paths["staged"]
        / "Assets"
        / "UnityIosPorter.Generated"
        / "Editor"
        / "BatchEntry.cs"
    )
    bridge.parent.mkdir(parents=True)
    bridge.write_text(BRIDGE_TEMPLATE.read_text(encoding="utf-8"), encoding="utf-8")
    paths["plan"].write_text(
        json.dumps(plan, indent=2, sort_keys=True) + "\n", encoding="utf-8"
    )
    return {key: str(value) for key, value in paths.items()}


def locate_unity(unity_path: str, unity_version: str) -> Path | None:
    candidates: list[Path] = []
    if unity_path:
        candidates.append(Path(unity_path).expanduser())
    discovered = shutil.which("Unity") or shutil.which("unity-editor")
    if discovered:
        candidates.append(Path(discovered))
    if platform.system() == "Darwin":
        candidates.append(
            Path(
                f"/Applications/Unity/Hub/Editor/{unity_version}/"
                "Unity.app/Contents/MacOS/Unity"
            )
        )
    return next((candidate.resolve() for candidate in candidates if candidate.is_file()), None)


def doctor(
    project: ProjectInfo, config: PorterConfig | None = None
) -> dict[str, object]:
    unity_path = config.unity_path if config else ""
    unity = locate_unity(unity_path, project.unity_version)
    checks: list[dict[str, str]] = []

    def add(name: str, status: str, detail: str) -> None:
        checks.append({"name": name, "status": status, "detail": detail})

    add("Unity source project", "PASS", project.root)
    add("Unity version", "PASS", project.unity_version)
    if unity:
        add("Unity Editor", "PASS", str(unity))
        ios_support = unity.parent.parent / "PlaybackEngines/iOSSupport"
        add(
            "Unity iOS Build Support",
            "PASS" if ios_support.is_dir() else "FAIL",
            str(ios_support),
        )
    else:
        add(
            "Unity Editor",
            "UNKNOWN",
            "not found; set unityPath or --unity-path",
        )
        add(
            "Unity iOS Build Support",
            "UNKNOWN",
            "cannot verify without a Unity Editor installation",
        )

    if platform.system() != "Darwin":
        add("macOS", "FAIL", f"host is {platform.system()}; Xcode requires macOS")
        add("Xcode", "FAIL", "xcodebuild is available only on macOS")
    else:
        add("macOS", "PASS", platform.mac_ver()[0])
        xcodebuild = shutil.which("xcodebuild")
        if xcodebuild:
            result = subprocess.run(
                [xcodebuild, "-version"],
                check=False,
                capture_output=True,
                text=True,
            )
            detail = (result.stdout or result.stderr).strip().replace("\n", "; ")
            add("Xcode", "PASS" if result.returncode == 0 else "FAIL", detail)
        else:
            add("Xcode", "FAIL", "xcodebuild not found")
    statuses = [check["status"] for check in checks]
    return {
        "schemaVersion": 1,
        "checks": checks,
        "summary": {
            "pass": statuses.count("PASS"),
            "fail": statuses.count("FAIL"),
            "unknown": statuses.count("UNKNOWN"),
            "ready": "FAIL" not in statuses and "UNKNOWN" not in statuses,
        },
    }


def unity_build_command(
    unity: str | Path,
    staged_project: str | Path,
    plan_path: str | Path,
    result_path: str | Path,
    log_path: str | Path,
) -> list[str]:
    return [
        str(unity),
        "-batchmode",
        "-quit",
        "-nographics",
        "-projectPath",
        str(staged_project),
        "-executeMethod",
        "UnityIosPorter.Generated.BatchEntry.Build",
        "-porterConfig",
        str(plan_path),
        "-porterResult",
        str(result_path),
        "-logFile",
        str(log_path),
    ]


def archive_command(
    xcode_output: str | Path,
    archive_path: str | Path,
    config: PorterConfig,
) -> list[str]:
    project = Path(xcode_output) / "Unity-iPhone.xcodeproj"
    command = [
        "xcodebuild",
        "-project",
        str(project),
        "-scheme",
        config.scheme,
        "-configuration",
        config.configuration,
        "-sdk",
        "iphoneos",
        "-destination",
        "generic/platform=iOS",
        "-archivePath",
        str(archive_path),
    ]
    if config.team_id:
        command.append(f"DEVELOPMENT_TEAM={config.team_id}")
    command.append("archive")
    return command


def export_command(
    archive_path: str | Path,
    export_path: str | Path,
    export_options_path: str | Path,
) -> list[str]:
    return [
        "xcodebuild",
        "-exportArchive",
        "-archivePath",
        str(archive_path),
        "-exportPath",
        str(export_path),
        "-exportOptionsPlist",
        str(export_options_path),
    ]


def export_options(config: PorterConfig) -> dict[str, object]:
    options: dict[str, object] = {
        "method": config.export_method,
        "signingStyle": "automatic",
        "stripSwiftSymbols": True,
        "uploadBitcode": False,
    }
    if config.team_id:
        options["teamID"] = config.team_id
    return options


def write_export_options(
    path: str | Path, config: PorterConfig, *, dry_run: bool = False
) -> bytes:
    payload = plistlib.dumps(export_options(config), fmt=plistlib.FMT_XML, sort_keys=True)
    if not dry_run:
        target = Path(path)
        target.parent.mkdir(parents=True, exist_ok=True)
        target.write_bytes(payload)
    return payload


def run_external(
    command: Sequence[str],
    *,
    dry_run: bool = False,
    runner: Callable[..., subprocess.CompletedProcess[str]] = subprocess.run,
) -> subprocess.CompletedProcess[str]:
    if dry_run:
        return subprocess.CompletedProcess(list(command), 0, "", "")
    try:
        return runner(list(command), check=False, text=True)
    except OSError as exc:
        return subprocess.CompletedProcess(list(command), 127, "", str(exc))


def initialize_ci(
    target: str | Path, *, force: bool = False, dry_run: bool = False
) -> Path:
    target_root = Path(target).expanduser().resolve()
    destination = target_root / ".github/workflows/unity-ios-porter.yml"
    if destination.exists() and not force:
        raise ProjectError(f"workflow already exists: {destination} (use --force)")
    if not dry_run:
        destination.parent.mkdir(parents=True, exist_ok=True)
        destination.write_text(CI_TEMPLATE.read_text(encoding="utf-8"), encoding="utf-8")
    return destination
