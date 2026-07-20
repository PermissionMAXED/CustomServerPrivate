"""Migration plan generation and configuration validation."""

from __future__ import annotations

import json
import re
from dataclasses import dataclass
from pathlib import Path, PurePosixPath
from typing import Any

from .project import ProjectError, ProjectInfo

BUNDLE_ID_RE = re.compile(
    r"^[A-Za-z][A-Za-z0-9-]*(?:\.[A-Za-z0-9][A-Za-z0-9-]*)+$"
)
SCENE_PATH_RE = re.compile(r"^Assets/.+\.unity$", re.IGNORECASE)


@dataclass(frozen=True)
class PorterConfig:
    bundle_id: str
    team_id: str = ""
    export_method: str = "development"
    configuration: str = "Release"
    scheme: str = "Unity-iPhone"
    unity_path: str = ""
    managed_stripping_level: str = ""

    def to_dict(self) -> dict[str, str]:
        return {
            "bundleId": self.bundle_id,
            "teamId": self.team_id,
            "exportMethod": self.export_method,
            "configuration": self.configuration,
            "scheme": self.scheme,
            "unityPath": self.unity_path,
            "managedStrippingLevel": self.managed_stripping_level,
        }


def validate_bundle_id(value: str) -> str:
    value = value.strip()
    if not BUNDLE_ID_RE.fullmatch(value) or "*" in value or ".." in value:
        raise ProjectError(
            "bundle identifier must be reverse-DNS syntax, for example com.example.game"
        )
    return value


def _read_project_settings(root: Path) -> str:
    path = root / "ProjectSettings/ProjectSettings.asset"
    if not path.is_file():
        return ""
    try:
        return path.read_text(encoding="utf-8")
    except (OSError, UnicodeError):
        return ""


def infer_bundle_id(project: ProjectInfo) -> str:
    text = _read_project_settings(Path(project.root))
    candidates = (
        re.search(
            r"^\s*(?:iPhone|iOS):\s*(?P<value>[A-Za-z0-9.-]+)\s*$",
            text,
            re.MULTILINE,
        ),
        re.search(
            r"^\s*applicationIdentifier:\s*(?P<value>[A-Za-z0-9.-]+)\s*$",
            text,
            re.MULTILINE,
        ),
    )
    for match in candidates:
        if match:
            try:
                return validate_bundle_id(match.group("value"))
            except ProjectError:
                continue
    return ""


def load_config(
    path: str | Path | None,
    project: ProjectInfo,
    *,
    bundle_id: str = "",
    team_id: str = "",
    export_method: str = "",
    unity_path: str = "",
) -> PorterConfig:
    payload: dict[str, Any] = {}
    if path:
        try:
            with Path(path).expanduser().open(encoding="utf-8") as stream:
                loaded = json.load(stream)
        except (OSError, UnicodeError, json.JSONDecodeError) as exc:
            raise ProjectError(f"invalid configuration file: {exc}") from exc
        if not isinstance(loaded, dict):
            raise ProjectError("configuration root must be a JSON object")
        payload = loaded

    selected_bundle_id = bundle_id or str(
        payload.get("bundleId") or infer_bundle_id(project)
    )
    if not selected_bundle_id:
        raise ProjectError(
            "bundle identifier is required (--bundle-id or config bundleId)"
        )
    selected_bundle_id = validate_bundle_id(selected_bundle_id)
    selected_method = export_method or str(payload.get("exportMethod", "development"))
    allowed_methods = {
        "app-store",
        "ad-hoc",
        "development",
        "enterprise",
        "debugging",
        "release-testing",
    }
    if selected_method not in allowed_methods:
        raise ProjectError(
            "export method must be one of: " + ", ".join(sorted(allowed_methods))
        )

    stripping = str(payload.get("managedStrippingLevel", ""))
    if stripping and stripping not in {"Disabled", "Low", "Medium", "High", "Minimal"}:
        raise ProjectError(
            "managedStrippingLevel must be Disabled, Minimal, Low, Medium, or High"
        )
    return PorterConfig(
        bundle_id=selected_bundle_id,
        team_id=team_id or str(payload.get("teamId", "")),
        export_method=selected_method,
        configuration=str(payload.get("configuration", "Release")),
        scheme=str(payload.get("scheme", "Unity-iPhone")),
        unity_path=unity_path or str(payload.get("unityPath", "")),
        managed_stripping_level=stripping,
    )


def _validate_scene_path(root: Path, scene: str) -> str | None:
    if "\\" in scene:
        return f"enabled scene path must use forward slashes: {scene}"
    # Split the raw string: PurePosixPath silently normalizes away "."
    # segments, which would defeat the canonical-path requirement.
    segments = scene.split("/")
    if (
        PurePosixPath(scene).is_absolute()
        or not SCENE_PATH_RE.fullmatch(scene)
        or any(segment in {"", ".", ".."} for segment in segments)
        or segments[0] != "Assets"
    ):
        return f"invalid enabled scene path (must be under Assets): {scene}"
    assets = (root / "Assets").resolve()
    candidate = (root / scene).resolve()
    try:
        candidate.relative_to(assets)
    except ValueError:
        return f"enabled scene escapes Assets: {scene}"
    if not candidate.is_file():
        return f"enabled scene is missing: {scene}"
    return None


def discover_scenes(project: ProjectInfo) -> tuple[list[str], list[str]]:
    root = Path(project.root)
    settings = root / "ProjectSettings/EditorBuildSettings.asset"
    errors: list[str] = []
    scenes: list[str] = []
    if settings.is_file():
        try:
            lines = settings.read_text(encoding="utf-8").splitlines()
        except (OSError, UnicodeError) as exc:
            errors.append(f"could not read EditorBuildSettings.asset: {exc}")
            lines = []
        enabled: bool | None = None
        for line in lines:
            enabled_match = re.match(r"^\s*-\s*enabled:\s*([01])\s*$", line)
            if enabled_match:
                enabled = enabled_match.group(1) == "1"
                continue
            path_match = re.match(r"^\s*path:\s*(.+?)\s*$", line)
            if path_match and enabled is not None:
                scene = path_match.group(1).strip().strip('"')
                if enabled:
                    error = _validate_scene_path(root, scene)
                    if error:
                        errors.append(error)
                    else:
                        scenes.append(scene)
                enabled = None
    else:
        errors.append(
            "EditorBuildSettings.asset is absent; no enabled build scenes were discovered"
        )

    if not scenes:
        errors.append("the plan has no valid enabled scenes; build is blocked")
    return scenes, errors


def _current_backend(project: ProjectInfo) -> str:
    text = _read_project_settings(Path(project.root))
    section = re.search(
        r"^\s*scriptingBackend:\s*$"
        r"(?P<body>(?:\n\s+\S[^\n]*)+)",
        text,
        re.MULTILINE,
    )
    if not section:
        return "Unknown"
    ios = re.search(r"^\s*(?:iPhone|iOS):\s*(\d+)\s*$", section.group("body"), re.MULTILINE)
    if not ios:
        return "Unknown"
    return {"0": "Mono", "1": "IL2CPP"}.get(ios.group(1), f"Unknown({ios.group(1)})")


def generate_plan(
    project: ProjectInfo,
    config: PorterConfig,
    scan: dict[str, object],
    *,
    staged_project: str = "",
    xcode_output: str = "",
    result_path: str = "",
) -> dict[str, object]:
    scenes, scene_errors = discover_scenes(project)
    findings = scan["findings"]
    assert isinstance(findings, list)
    scan_summary = scan.get("summary", {})
    reflection_sensitive = any(
        str(item.get("code", "")).startswith("AOT") for item in findings
    ) or bool(
        isinstance(scan_summary, dict) and scan_summary.get("reflectionUses", 0)
    )
    recommended_stripping = (
        config.managed_stripping_level
        or ("Low" if reflection_sensitive else "Medium")
    )
    errors = sum(1 for item in findings if item.get("severity") == "error")
    warnings = sum(1 for item in findings if item.get("severity") == "warning")
    return {
        "schemaVersion": 1,
        "tool": "UnityIosPorter",
        "technicalTruth": {
            "sourceBackend": _current_backend(project),
            "targetBackend": "IL2CPP",
            "targetPlatform": "iOS",
            "architecture": "ARM64",
            "xcodeExportRequired": True,
        },
        "project": project.to_dict(),
        "settings": {
            **config.to_dict(),
            "scriptingBackend": "IL2CPP",
            "architecture": "ARM64",
            "managedStrippingLevel": recommended_stripping,
            "scenes": scenes,
        },
        "paths": {
            "stagedProject": staged_project,
            "xcodeOutput": xcode_output,
            "result": result_path,
        },
        "riskSummary": {
            "errors": errors,
            "warnings": warnings,
            "sceneErrors": scene_errors,
            "blocking": errors > 0 or bool(scene_errors),
        },
        "scan": scan,
    }
