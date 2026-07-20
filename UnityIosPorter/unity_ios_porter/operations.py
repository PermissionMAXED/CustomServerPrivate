"""Staging, environment checks, and external command construction."""

from __future__ import annotations

import hashlib
import json
import os
import plistlib
import platform
import shutil
import subprocess
from pathlib import Path
from typing import Callable, Sequence

from . import __version__
from .planner import PorterConfig
from .project import ProjectError, ProjectInfo

TOOL_ROOT = Path(__file__).resolve().parent.parent
BRIDGE_TEMPLATE = TOOL_ROOT / "templates/BatchEntry.cs"
CI_TEMPLATE = TOOL_ROOT / "templates/unity-ios-porter.yml"

MANIFEST_SCHEMA_VERSION = 1
MANIFEST_TOOL = "UnityIosPorter"
# Path+size only: cheap and detects accidental workspace mixups, not content
# tampering by an adversary. The algorithm name states exactly what is hashed.
SOURCE_DIGEST_ALGORITHM = "sha256/relative-path-and-size-v1"

DEFAULT_UNITY_TIMEOUT_SECONDS = 7200
DEFAULT_XCODEBUILD_TIMEOUT_SECONDS = 3600


def timeout_seconds(environment_name: str, default: int) -> int:
    """Read a positive integer timeout override from the environment."""
    try:
        value = int(os.environ.get(environment_name, ""))
    except ValueError:
        return default
    return value if value > 0 else default


def unity_timeout() -> int:
    return timeout_seconds(
        "UNITY_IOS_PORTER_UNITY_TIMEOUT", DEFAULT_UNITY_TIMEOUT_SECONDS
    )


def xcodebuild_timeout() -> int:
    return timeout_seconds(
        "UNITY_IOS_PORTER_XCODEBUILD_TIMEOUT", DEFAULT_XCODEBUILD_TIMEOUT_SECONDS
    )


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
        "manifest": root / "workspace-manifest.json",
        "log": root / "unity.log",
        "unity_stdout_log": root / "logs/unity-stdout.log",
        "archive_log": root / "logs/xcodebuild-archive.log",
        "export_log": root / "logs/xcodebuild-export.log",
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
    generated_source = source / "Assets/UnityIosPorter.Generated"
    if os.path.lexists(generated_source):
        raise ProjectError(
            "source already contains Assets/UnityIosPorter.Generated; refusing to "
            "omit or overwrite project content. Rename that directory (it is "
            "reserved for the injected build bridge) and retry"
        )
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


def source_digest(staged_root: str | Path) -> str:
    """Digest the staged tree by relative path and size (see algorithm name)."""
    root = Path(staged_root).resolve()
    digest = hashlib.sha256()
    for path in sorted(root.rglob("*")):
        if path.is_symlink() or not path.is_file():
            continue
        relative = path.relative_to(root).as_posix()
        digest.update(f"{relative}\x00{path.stat().st_size}\n".encode("utf-8"))
    return digest.hexdigest()


def plan_digest(plan_path: str | Path) -> str:
    return hashlib.sha256(Path(plan_path).read_bytes()).hexdigest()


def write_workspace_manifest(
    paths: dict[str, Path], project_root: str | Path
) -> Path:
    """Bind the workspace to its source project, plan, and Xcode output.

    Written by build-xcode only after the Unity result contract validates, so
    archive/export refuse unbound or unrelated workspaces.
    """
    manifest = {
        "schemaVersion": MANIFEST_SCHEMA_VERSION,
        "tool": MANIFEST_TOOL,
        "toolVersion": __version__,
        "phase": "build-xcode",
        "projectPath": str(Path(project_root).resolve()),
        "workDir": str(paths["root"]),
        "stagedProject": str(paths["staged"]),
        "xcodeOutput": str(paths["xcode"]),
        "planPath": str(paths["plan"]),
        "planDigest": {"algorithm": "sha256", "value": plan_digest(paths["plan"])},
        "sourceDigest": {
            "algorithm": SOURCE_DIGEST_ALGORITHM,
            "value": source_digest(paths["staged"]),
        },
    }
    paths["manifest"].write_text(
        json.dumps(manifest, indent=2, sort_keys=True) + "\n", encoding="utf-8"
    )
    return paths["manifest"]


def verify_workspace_manifest(
    paths: dict[str, Path], project_root: str | Path
) -> list[str]:
    """Return every reason this workspace cannot be archived/exported."""
    manifest_path = paths["manifest"]
    if not manifest_path.is_file():
        return [
            f"workspace manifest is missing: {manifest_path}; run build-xcode on "
            "this work directory first"
        ]
    try:
        manifest = json.loads(manifest_path.read_text(encoding="utf-8"))
    except (OSError, UnicodeError, json.JSONDecodeError) as exc:
        return [f"workspace manifest is unreadable: {exc}"]
    if not isinstance(manifest, dict):
        return ["workspace manifest root must be a JSON object"]

    errors: list[str] = []
    if manifest.get("schemaVersion") != MANIFEST_SCHEMA_VERSION:
        errors.append(
            "workspace manifest schemaVersion must be "
            f"{MANIFEST_SCHEMA_VERSION}: {manifest.get('schemaVersion')!r}"
        )
    if manifest.get("tool") != MANIFEST_TOOL:
        errors.append(
            f"workspace manifest was not written by {MANIFEST_TOOL}: "
            f"{manifest.get('tool')!r}"
        )
    expected_project = str(Path(project_root).resolve())
    if manifest.get("projectPath") != expected_project:
        errors.append(
            "workspace is bound to a different source project: manifest has "
            f"{manifest.get('projectPath')!r}, command received {expected_project!r}"
        )
    for key, expected in (
        ("workDir", paths["root"]),
        ("stagedProject", paths["staged"]),
        ("xcodeOutput", paths["xcode"]),
        ("planPath", paths["plan"]),
    ):
        if manifest.get(key) != str(expected):
            errors.append(
                f"workspace manifest {key} does not match this work directory: "
                f"{manifest.get(key)!r} != {str(expected)!r}"
            )

    recorded_plan = manifest.get("planDigest")
    if not paths["plan"].is_file():
        errors.append(f"build-plan.json is missing: {paths['plan']}")
    elif (
        not isinstance(recorded_plan, dict)
        or recorded_plan.get("algorithm") != "sha256"
        or recorded_plan.get("value") != plan_digest(paths["plan"])
    ):
        errors.append("build-plan.json does not match the manifest plan digest")

    recorded_source = manifest.get("sourceDigest")
    if not paths["staged"].is_dir():
        errors.append(f"staged project is missing: {paths['staged']}")
    elif (
        not isinstance(recorded_source, dict)
        or recorded_source.get("algorithm") != SOURCE_DIGEST_ALGORITHM
        or recorded_source.get("value") != source_digest(paths["staged"])
    ):
        errors.append(
            "staged project does not match the manifest source digest "
            f"({SOURCE_DIGEST_ALGORITHM})"
        )

    errors.extend(looks_like_xcode_export(paths["xcode"]))
    return errors


def looks_like_xcode_export(xcode_output: str | Path) -> list[str]:
    """Check the directory contains a real Xcode project or workspace."""
    output = Path(xcode_output)
    if not output.is_dir():
        return [f"Unity Xcode output directory is missing: {output}"]
    projects = [
        candidate
        for candidate in sorted(output.glob("*.xcodeproj"))
        if (candidate / "project.pbxproj").is_file()
    ]
    workspaces = [
        candidate
        for candidate in sorted(output.glob("*.xcworkspace"))
        if (candidate / "contents.xcworkspacedata").is_file()
    ]
    if not projects and not workspaces:
        return [
            f"{output} contains no *.xcodeproj/project.pbxproj or "
            "*.xcworkspace/contents.xcworkspacedata; it is not a Unity Xcode export"
        ]
    return []


def validate_unity_result(
    result_path: str | Path, xcode_output: str | Path
) -> list[str]:
    """Strictly validate the Unity result.json contract, not just exit codes."""
    result_file = Path(result_path)
    if not result_file.is_file():
        return [f"Unity did not write the required result contract: {result_file}"]
    try:
        payload = json.loads(result_file.read_text(encoding="utf-8"))
    except (OSError, UnicodeError, json.JSONDecodeError) as exc:
        return [f"result.json is unreadable: {exc}"]
    if not isinstance(payload, dict):
        return ["result.json root must be a JSON object"]

    errors: list[str] = []
    if payload.get("schemaVersion") != 1:
        errors.append(
            f"result.json schemaVersion must be 1: {payload.get('schemaVersion')!r}"
        )
    if payload.get("phase") != "build-xcode":
        errors.append(
            f"result.json phase must be 'build-xcode': {payload.get('phase')!r}"
        )
    if payload.get("success") is not True:
        detail = payload.get("error") or payload.get("result") or "unspecified"
        errors.append(f"Unity reported success={payload.get('success')!r}: {detail}")
    output_path = payload.get("outputPath")
    expected_output = Path(xcode_output).resolve()
    if not isinstance(output_path, str) or not output_path:
        errors.append("result.json outputPath is missing or empty")
    elif Path(output_path).resolve() != expected_output:
        errors.append(
            f"result.json outputPath {output_path!r} is not the expected "
            f"workspace Xcode directory {str(expected_output)!r}"
        )
    errors.extend(looks_like_xcode_export(expected_output))
    return errors


def verify_archive_output(archive_path: str | Path) -> list[str]:
    archive = Path(archive_path)
    if not archive.is_dir():
        return [f"xcarchive was not created: {archive}"]
    errors: list[str] = []
    if not (archive / "Info.plist").is_file():
        errors.append(f"xcarchive has no Info.plist: {archive}")
    applications = archive / "Products/Applications"
    if not any(applications.glob("*.app")):
        errors.append(f"xcarchive has no Products/Applications/*.app: {archive}")
    return errors


def verify_export_output(export_path: str | Path) -> list[str]:
    export = Path(export_path)
    if not export.is_dir():
        return [f"export directory was not created: {export}"]
    if not any(export.glob("*.ipa")):
        return [f"export directory contains no .ipa: {export}"]
    return []


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
    return next(
        (
            candidate.resolve()
            for candidate in candidates
            if candidate.is_file() and os.access(candidate, os.X_OK)
        ),
        None,
    )


def locate_xcodebuild() -> str | None:
    """Resolve an absolute xcodebuild path when possible."""
    discovered = shutil.which("xcodebuild")
    if discovered:
        return str(Path(discovered).resolve())
    fallback = Path("/usr/bin/xcodebuild")
    if fallback.is_file() and os.access(fallback, os.X_OK):
        return str(fallback)
    return None


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
        try:
            probe = subprocess.run(
                [str(unity), "-version", "-batchmode", "-quit", "-nographics"],
                check=False,
                capture_output=True,
                text=True,
                timeout=30,
            )
            probe_detail = (probe.stdout or probe.stderr).strip().replace("\n", "; ")
            if probe.returncode != 0:
                add(
                    "Unity version probe",
                    "FAIL",
                    probe_detail or f"Unity exited {probe.returncode}",
                )
            elif not probe_detail:
                add("Unity version probe", "UNKNOWN", "Unity returned no version text")
            elif project.unity_version not in probe_detail:
                add(
                    "Unity version probe",
                    "FAIL",
                    f"expected {project.unity_version}; reported {probe_detail}",
                )
            else:
                add("Unity version probe", "PASS", probe_detail)
        except subprocess.TimeoutExpired:
            add("Unity version probe", "FAIL", "Unity version probe timed out")
        except OSError as exc:
            add("Unity version probe", "FAIL", f"could not execute Unity: {exc}")
        ios_support = unity.parent.parent / "PlaybackEngines/iOSSupport"
        add(
            "Unity iOS Build Support",
            "PASS" if ios_support.is_dir() else "FAIL",
            str(ios_support),
        )
    else:
        explicit = Path(unity_path).expanduser() if unity_path else None
        add(
            "Unity Editor",
            "FAIL" if explicit and explicit.is_file() else "UNKNOWN",
            (
                f"not executable: {explicit}"
                if explicit and explicit.is_file()
                else "not found; set unityPath or --unity-path"
            ),
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
        xcodebuild = locate_xcodebuild()
        if xcodebuild:
            try:
                result = subprocess.run(
                    [xcodebuild, "-version"],
                    check=False,
                    capture_output=True,
                    text=True,
                    timeout=60,
                )
                detail = (result.stdout or result.stderr).strip().replace("\n", "; ")
                add("Xcode", "PASS" if result.returncode == 0 else "FAIL", detail)
            except subprocess.TimeoutExpired:
                add("Xcode", "FAIL", "xcodebuild -version timed out")
            except OSError as exc:
                add("Xcode", "FAIL", f"could not execute xcodebuild: {exc}")
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
    # -buildTarget iOS is the only reliable way to select the target for a
    # -batchmode -quit run; BatchEntry asserts it instead of switching.
    return [
        str(unity),
        "-batchmode",
        "-quit",
        "-nographics",
        "-buildTarget",
        "iOS",
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
    *,
    xcodebuild: str | Path = "xcodebuild",
) -> list[str]:
    project = Path(xcode_output) / "Unity-iPhone.xcodeproj"
    command = [
        str(xcodebuild),
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
    *,
    xcodebuild: str | Path = "xcodebuild",
) -> list[str]:
    return [
        str(xcodebuild),
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
    timeout: float | None = None,
    log_path: str | Path | None = None,
    runner: Callable[..., subprocess.CompletedProcess[str]] = subprocess.run,
) -> subprocess.CompletedProcess[str]:
    """Run a tool, capturing its output so JSON stdout stays uncontaminated.

    Output goes to log_path when given, otherwise into the returned result.
    Timeouts return exit code 124; a missing executable returns 127.
    """
    if dry_run:
        return subprocess.CompletedProcess(list(command), 0, "", "")
    try:
        if log_path is not None:
            log_file = Path(log_path)
            log_file.parent.mkdir(parents=True, exist_ok=True)
            with log_file.open("w", encoding="utf-8") as stream:
                stream.write(f"# command: {command}\n")
                stream.flush()
                return runner(
                    list(command),
                    check=False,
                    text=True,
                    stdout=stream,
                    stderr=subprocess.STDOUT,
                    timeout=timeout,
                )
        return runner(
            list(command),
            check=False,
            text=True,
            capture_output=True,
            timeout=timeout,
        )
    except subprocess.TimeoutExpired as exc:
        return subprocess.CompletedProcess(
            list(command),
            124,
            "",
            f"timed out after {exc.timeout} seconds",
        )
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
