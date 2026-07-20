"""Unity project detection and strict owned-source policy enforcement."""

from __future__ import annotations

import json
import re
from dataclasses import asdict, dataclass
from pathlib import Path
from typing import Iterable

EXIT_OK = 0
EXIT_RISKS = 2
EXIT_DOCTOR = 3
EXIT_BUILD = 4
EXIT_ARCHIVE = 5
EXIT_EXPORT = 6
EXIT_POLICY = 64

REQUIRED_PATHS = (
    "Assets",
    "ProjectSettings",
    "ProjectSettings/ProjectVersion.txt",
    "Packages/manifest.json",
)

SUSPICIOUS_DIRECTORY_NAMES = {
    "assetrip",
    "il2cppdumper",
    "dummydll",
    "dummy_dll",
    ".decomp",
    "decomp",
    "decompiled",
    "decompiler",
    "dumped",
    "extracted",
}
SUSPICIOUS_FILE_NAMES = {
    "global-metadata.dat",
    "global-metadata.dat.bak",
    "dump.cs",
}
SUSPICIOUS_FILE_SUFFIXES = (".ipa",)
GAME_ASSEMBLY_RE = re.compile(r"^gameassembly(?:\.(?:dll|so|dylib))?$", re.IGNORECASE)
DUMP_CS_RE = re.compile(r"(?:^|[_-])dump\.cs$", re.IGNORECASE)
UNITY_VERSION_RE = re.compile(
    r"^\s*m_EditorVersion:\s*"
    r"(?P<version>\d+\.\d+\.\d+[abfp]\d+(?:c\d+)?)\s*$",
    re.MULTILINE,
)


class ProjectError(ValueError):
    """The supplied path is not an intact Unity source project."""


class PolicyError(ProjectError):
    """The supplied path appears to contain reconstructed or shipped binaries."""

    def __init__(self, markers: Iterable[str]):
        self.markers = tuple(sorted(set(markers)))
        joined = ", ".join(self.markers[:8])
        if len(self.markers) > 8:
            joined += f", and {len(self.markers) - 8} more"
        super().__init__(
            "refusing non-source or suspicious input; provide an owned Unity source "
            f"project only (markers: {joined})"
        )


@dataclass(frozen=True)
class ProjectInfo:
    root: str
    unity_version: str
    manifest_dependencies: tuple[str, ...]
    required_paths: tuple[str, ...] = REQUIRED_PATHS

    def to_dict(self) -> dict[str, object]:
        value = asdict(self)
        value["manifest_dependencies"] = list(self.manifest_dependencies)
        value["required_paths"] = list(self.required_paths)
        value["suspicious_markers_absent"] = True
        return value


def _relative(path: Path, root: Path) -> str:
    try:
        return path.relative_to(root).as_posix()
    except ValueError:
        return str(path)


def find_suspicious_markers(root: Path) -> list[str]:
    """Return policy markers without reading or attempting to reconstruct content."""
    markers: list[str] = []
    root = root.resolve()
    for part in root.parts:
        lowered_part = part.casefold()
        if (
            lowered_part in SUSPICIOUS_DIRECTORY_NAMES
            or lowered_part.startswith(("assetrip", "il2cppdumper", "dummydll", "decomp"))
        ):
            markers.append(f"<input-path:{part}>")
    for path in root.rglob("*"):
        relative = _relative(path, root)
        lowered_name = path.name.casefold()
        if path.is_dir():
            if (
                lowered_name in SUSPICIOUS_DIRECTORY_NAMES
                or lowered_name.startswith(
                    ("assetrip", "il2cppdumper", "dummydll", "decomp")
                )
                or lowered_name.endswith(".app")
            ):
                markers.append(relative + "/")
            continue
        if lowered_name in SUSPICIOUS_FILE_NAMES:
            markers.append(relative)
        elif GAME_ASSEMBLY_RE.fullmatch(path.name):
            markers.append(relative)
        elif DUMP_CS_RE.search(path.name):
            markers.append(relative)
        elif lowered_name.endswith(SUSPICIOUS_FILE_SUFFIXES):
            markers.append(relative)
    return markers


def parse_unity_version(project_version_file: Path) -> str:
    try:
        text = project_version_file.read_text(encoding="utf-8")
    except (OSError, UnicodeError) as exc:
        raise ProjectError(f"cannot read {project_version_file}: {exc}") from exc
    match = UNITY_VERSION_RE.search(text)
    if not match:
        raise ProjectError(
            f"{project_version_file} does not contain a valid m_EditorVersion"
        )
    return match.group("version")


def _parse_manifest(manifest_file: Path) -> tuple[str, ...]:
    try:
        with manifest_file.open(encoding="utf-8") as stream:
            payload = json.load(stream)
    except (OSError, UnicodeError, json.JSONDecodeError) as exc:
        raise ProjectError(f"invalid Packages/manifest.json: {exc}") from exc
    if not isinstance(payload, dict):
        raise ProjectError("Packages/manifest.json root must be a JSON object")
    dependencies = payload.get("dependencies")
    if not isinstance(dependencies, dict):
        raise ProjectError("Packages/manifest.json must contain a dependencies object")
    return tuple(sorted(str(key) for key in dependencies))


def inspect_project(path: str | Path, *, enforce_policy: bool = True) -> ProjectInfo:
    root = Path(path).expanduser().resolve()
    if not root.is_dir():
        raise ProjectError(f"project path is not a directory: {root}")

    missing = [
        item
        for item in ("Assets", "ProjectSettings")
        if not (root / item).is_dir()
    ]
    missing.extend(
        item
        for item in ("ProjectSettings/ProjectVersion.txt", "Packages/manifest.json")
        if not (root / item).is_file()
    )
    if missing:
        raise ProjectError(
            "not a Unity source project; missing required paths: " + ", ".join(missing)
        )

    if enforce_policy:
        markers = find_suspicious_markers(root)
        if markers:
            raise PolicyError(markers)
        unsafe_links = [
            _relative(candidate, root)
            for candidate in root.rglob("*")
            if candidate.is_symlink()
        ]
        if unsafe_links:
            raise ProjectError(
                "symbolic links are not accepted in staged source projects because "
                "Unity could write through them: " + ", ".join(unsafe_links[:8])
            )

    version = parse_unity_version(root / "ProjectSettings/ProjectVersion.txt")
    dependencies = _parse_manifest(root / "Packages/manifest.json")
    return ProjectInfo(str(root), version, dependencies)


def require_owned_source_attestation(attested: bool) -> None:
    if not attested:
        raise PolicyError(
            [
                "missing --attest-owned-source",
                "the flag is required for commands that stage or build",
            ]
        )
