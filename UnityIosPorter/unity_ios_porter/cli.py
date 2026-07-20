"""Command-line interface for UnityIosPorter."""

from __future__ import annotations

import argparse
import json
import shlex
import sys
from pathlib import Path
from typing import Any, Sequence

from . import __version__
from .operations import (
    archive_command,
    doctor,
    export_command,
    initialize_ci,
    locate_unity,
    locate_xcodebuild,
    run_external,
    stage_project,
    unity_build_command,
    unity_timeout,
    validate_unity_result,
    verify_archive_output,
    verify_export_output,
    verify_workspace_manifest,
    workspace_paths,
    write_export_options,
    write_workspace_manifest,
    xcodebuild_timeout,
)
from .planner import PorterConfig, generate_plan, load_config
from .project import (
    EXIT_ARCHIVE,
    EXIT_BUILD,
    EXIT_DOCTOR,
    EXIT_EXPORT,
    EXIT_OK,
    EXIT_POLICY,
    EXIT_RISKS,
    PolicyError,
    ProjectError,
    inspect_project,
    require_owned_source_attestation,
)
from .scanner import scan_project


class PorterArgumentParser(argparse.ArgumentParser):
    def error(self, message: str) -> None:
        self.print_usage(sys.stderr)
        self.exit(EXIT_POLICY, f"{self.prog}: error: {message}\n")


def _common_project(parser: argparse.ArgumentParser) -> None:
    parser.add_argument(
        "--project",
        default=".",
        help="Unity source project root (default: current directory)",
    )


def _dry_run(parser: argparse.ArgumentParser) -> None:
    parser.add_argument(
        "--dry-run",
        action="store_true",
        help="print planned writes/commands without changing files or running tools",
    )


def _attestation(parser: argparse.ArgumentParser) -> None:
    parser.add_argument(
        "--attest-owned-source",
        action="store_true",
        help="attest that the input is an owned, authorized Unity source project",
    )


def _config(parser: argparse.ArgumentParser) -> None:
    parser.add_argument("--config", help="path to UnityIosPorter JSON configuration")
    parser.add_argument("--bundle-id", default="", help="reverse-DNS iOS bundle identifier")
    parser.add_argument("--team-id", default="", help="Apple Developer team identifier")
    parser.add_argument(
        "--export-method",
        default="",
        help="development, ad-hoc, app-store, enterprise, debugging, or release-testing",
    )
    parser.add_argument("--unity-path", default="", help="Unity Editor executable")


def build_parser() -> argparse.ArgumentParser:
    parser = PorterArgumentParser(
        prog="porter.py",
        description=(
            "Port an owned Unity source project from Mono assumptions to an "
            "iOS IL2CPP/ARM64 Xcode export."
        ),
    )
    parser.add_argument("--version", action="version", version=f"%(prog)s {__version__}")
    commands = parser.add_subparsers(dest="command", required=True)

    detect = commands.add_parser("detect", help="validate and identify a Unity source project")
    _common_project(detect)

    doctor_parser = commands.add_parser(
        "doctor", help="check Unity, iOS module, macOS, and Xcode prerequisites"
    )
    _common_project(doctor_parser)
    doctor_parser.add_argument("--config", help="optional configuration JSON")
    doctor_parser.add_argument("--unity-path", default="", help="Unity Editor executable")

    scan = commands.add_parser("scan", help="scan source and plugins for iOS/AOT risks")
    _common_project(scan)

    plan = commands.add_parser("plan", help="generate an IL2CPP/ARM64 migration plan")
    _common_project(plan)
    _config(plan)
    _dry_run(plan)
    plan.add_argument("--output", help="optional path for build-plan.json")

    build = commands.add_parser(
        "build-xcode", help="stage the project and invoke Unity's Xcode export"
    )
    _common_project(build)
    _config(build)
    _dry_run(build)
    _attestation(build)
    build.add_argument("--work-dir", required=True, help="new external staging directory")

    archive = commands.add_parser("archive", help="create an Xcode .xcarchive")
    _common_project(archive)
    _config(archive)
    _dry_run(archive)
    _attestation(archive)
    archive.add_argument("--work-dir", required=True, help="existing porter work directory")

    export = commands.add_parser("export", help="export an IPA from an Xcode archive")
    _common_project(export)
    _config(export)
    _dry_run(export)
    _attestation(export)
    export.add_argument("--work-dir", required=True, help="existing porter work directory")

    all_parser = commands.add_parser(
        "all", help="plan, stage, build Xcode, archive, and export"
    )
    _common_project(all_parser)
    _config(all_parser)
    _dry_run(all_parser)
    _attestation(all_parser)
    all_parser.add_argument("--work-dir", required=True, help="new external staging directory")

    ci = commands.add_parser("ci", help="CI integration commands")
    ci_commands = ci.add_subparsers(dest="ci_command", required=True)
    ci_init = ci_commands.add_parser(
        "init", help="copy the owner-project workflow template"
    )
    _common_project(ci_init)
    _dry_run(ci_init)
    _attestation(ci_init)
    ci_init.add_argument("--force", action="store_true", help="replace an existing workflow")
    return parser


def _print(payload: dict[str, object]) -> None:
    print(json.dumps(payload, indent=2, sort_keys=True))


def _config_for(args: argparse.Namespace, project: Any) -> PorterConfig:
    return load_config(
        args.config,
        project,
        bundle_id=args.bundle_id,
        team_id=args.team_id,
        export_method=args.export_method,
        unity_path=args.unity_path,
    )


def _has_scan_risks(scan: dict[str, object]) -> bool:
    summary = scan.get("summary", {})
    return bool(isinstance(summary, dict) and summary.get("total", 0))


def _is_blocking(plan: dict[str, object]) -> bool:
    summary = plan.get("riskSummary", {})
    return bool(isinstance(summary, dict) and summary.get("blocking"))


def _prepare_plan(
    args: argparse.Namespace,
) -> tuple[Any, PorterConfig, dict[str, object], dict[str, object]]:
    project = inspect_project(args.project)
    config = _config_for(args, project)
    scan = scan_project(project)
    paths = workspace_paths(args.work_dir)
    plan = generate_plan(
        project,
        config,
        scan,
        staged_project=str(paths["staged"]),
        xcode_output=str(paths["xcode"]),
        result_path=str(paths["result"]),
    )
    return project, config, scan, plan


def _write_failure_result(
    result_path: Path, phase: str, command: Sequence[str], returncode: int, stderr: str
) -> None:
    result_path.parent.mkdir(parents=True, exist_ok=True)
    result_path.write_text(
        json.dumps(
            {
                "schemaVersion": 1,
                "success": False,
                "phase": phase,
                "exitCode": returncode,
                "command": list(command),
                "error": stderr,
            },
            indent=2,
            sort_keys=True,
        )
        + "\n",
        encoding="utf-8",
    )


def _build_xcode(
    args: argparse.Namespace,
    project: Any,
    config: PorterConfig,
    plan: dict[str, object],
) -> tuple[int, dict[str, object]]:
    paths = workspace_paths(args.work_dir)
    if _is_blocking(plan):
        return EXIT_RISKS, {
            "ok": False,
            "phase": "plan",
            "message": "blocking scan findings or missing build scenes",
            "plan": plan,
        }
    staged = stage_project(project, args.work_dir, plan, dry_run=args.dry_run)
    unity = locate_unity(config.unity_path, project.unity_version)
    if not unity and not args.dry_run:
        _write_failure_result(
            paths["result"], "build-xcode", [], 127, "Unity Editor was not found"
        )
        return EXIT_BUILD, {
            "ok": False,
            "phase": "build-xcode",
            "message": "Unity Editor was not found; run doctor and set --unity-path",
            "paths": staged,
        }
    command = unity_build_command(
        unity or config.unity_path or "Unity",
        paths["staged"],
        paths["plan"],
        paths["result"],
        paths["log"],
    )
    result = run_external(
        command,
        dry_run=args.dry_run,
        timeout=unity_timeout(),
        log_path=None if args.dry_run else paths["unity_stdout_log"],
    )
    if result.returncode != 0:
        if not paths["result"].exists():
            _write_failure_result(
                paths["result"],
                "build-xcode",
                command,
                result.returncode,
                result.stderr or "",
            )
        return EXIT_BUILD, {
            "ok": False,
            "phase": "build-xcode",
            "command": command,
            "exitCode": result.returncode,
            "unityLog": str(paths["log"]),
            "paths": staged,
        }
    if not args.dry_run:
        # A zero Unity exit code is not proof of success: validate the
        # result.json contract and that a real Xcode project was exported.
        contract_errors = validate_unity_result(paths["result"], paths["xcode"])
        if contract_errors:
            return EXIT_BUILD, {
                "ok": False,
                "phase": "build-xcode",
                "message": "Unity result contract validation failed",
                "errors": contract_errors,
                "command": command,
                "unityLog": str(paths["log"]),
                "paths": staged,
            }
        manifest = write_workspace_manifest(paths, project.root)
        staged["manifest"] = str(manifest)
    return EXIT_OK, {
        "ok": True,
        "phase": "build-xcode",
        "dryRun": args.dry_run,
        "command": command,
        "paths": staged,
    }


def _archive(
    args: argparse.Namespace, project: Any, config: PorterConfig
) -> tuple[int, dict[str, object]]:
    paths = workspace_paths(args.work_dir)
    if not args.dry_run:
        input_errors = verify_workspace_manifest(paths, project.root)
        pbxproj = paths["xcode"] / "Unity-iPhone.xcodeproj/project.pbxproj"
        if not input_errors and not pbxproj.is_file():
            input_errors.append(
                f"archive requires Unity's export at {pbxproj.parent}; "
                "found no project.pbxproj"
            )
        if input_errors:
            return EXIT_ARCHIVE, {
                "ok": False,
                "phase": "archive",
                "message": "workspace verification failed; refusing to archive",
                "errors": input_errors,
            }
    xcodebuild = locate_xcodebuild() or "xcodebuild"
    command = archive_command(
        paths["xcode"], paths["archive"], config, xcodebuild=xcodebuild
    )
    result = run_external(
        command,
        dry_run=args.dry_run,
        timeout=xcodebuild_timeout(),
        log_path=None if args.dry_run else paths["archive_log"],
    )
    output_errors: list[str] = []
    if not args.dry_run and result.returncode == 0:
        # xcodebuild exit 0 alone is not proof the archive exists and is sane.
        output_errors = verify_archive_output(paths["archive"])
    ok = result.returncode == 0 and not output_errors
    payload: dict[str, object] = {
        "ok": ok,
        "phase": "archive",
        "dryRun": args.dry_run,
        "command": command,
        "exitCode": result.returncode,
        "archive": str(paths["archive"]),
        "log": str(paths["archive_log"]),
    }
    if output_errors:
        payload["errors"] = output_errors
    return (EXIT_OK if ok else EXIT_ARCHIVE), payload


def _export(
    args: argparse.Namespace, project: Any, config: PorterConfig
) -> tuple[int, dict[str, object]]:
    paths = workspace_paths(args.work_dir)
    if not args.dry_run:
        manifest_errors = verify_workspace_manifest(paths, project.root)
        input_errors = verify_archive_output(paths["archive"])
        if manifest_errors or input_errors:
            return EXIT_EXPORT, {
                "ok": False,
                "phase": "export",
                "message": "workspace verification failed; refusing to export",
                "errors": [*manifest_errors, *input_errors],
            }
    write_export_options(
        paths["export_options"], config, dry_run=args.dry_run
    )
    xcodebuild = locate_xcodebuild() or "xcodebuild"
    command = export_command(
        paths["archive"], paths["export"], paths["export_options"],
        xcodebuild=xcodebuild,
    )
    result = run_external(
        command,
        dry_run=args.dry_run,
        timeout=xcodebuild_timeout(),
        log_path=None if args.dry_run else paths["export_log"],
    )
    output_errors: list[str] = []
    if not args.dry_run and result.returncode == 0:
        output_errors = verify_export_output(paths["export"])
    ok = result.returncode == 0 and not output_errors
    payload: dict[str, object] = {
        "ok": ok,
        "phase": "export",
        "dryRun": args.dry_run,
        "command": command,
        "exitCode": result.returncode,
        "exportPath": str(paths["export"]),
        "exportOptions": str(paths["export_options"]),
        "log": str(paths["export_log"]),
    }
    if output_errors:
        payload["errors"] = output_errors
    return (EXIT_OK if ok else EXIT_EXPORT), payload


def execute(args: argparse.Namespace) -> int:
    if args.command == "detect":
        _print({"schemaVersion": 1, "project": inspect_project(args.project).to_dict()})
        return EXIT_OK

    if args.command == "doctor":
        project = inspect_project(args.project)
        config = None
        if args.config:
            config = load_config(
                args.config, project, unity_path=args.unity_path
            )
        elif args.unity_path:
            inferred = load_config(
                None,
                project,
                bundle_id="com.unityiosporter.doctor",
                unity_path=args.unity_path,
            )
            config = inferred
        report = doctor(project, config)
        _print(report)
        return EXIT_OK if report["summary"]["ready"] else EXIT_DOCTOR  # type: ignore[index]

    if args.command == "scan":
        report = scan_project(inspect_project(args.project))
        _print(report)
        return EXIT_RISKS if _has_scan_risks(report) else EXIT_OK

    if args.command == "plan":
        project = inspect_project(args.project)
        config = _config_for(args, project)
        report = scan_project(project)
        plan = generate_plan(project, config, report)
        if args.output and not args.dry_run:
            output = Path(args.output).expanduser().resolve()
            output.parent.mkdir(parents=True, exist_ok=True)
            output.write_text(
                json.dumps(plan, indent=2, sort_keys=True) + "\n", encoding="utf-8"
            )
        _print(plan)
        return EXIT_RISKS if _is_blocking(plan) or _has_scan_risks(report) else EXIT_OK

    if args.command == "ci" and args.ci_command == "init":
        require_owned_source_attestation(args.attest_owned_source)
        project = inspect_project(args.project)
        destination = initialize_ci(
            project.root, force=args.force, dry_run=args.dry_run
        )
        _print(
            {
                "schemaVersion": 1,
                "ok": True,
                "dryRun": args.dry_run,
                "workflow": str(destination),
            }
        )
        return EXIT_OK

    require_owned_source_attestation(args.attest_owned_source)
    if args.command == "build-xcode":
        project, config, _, plan = _prepare_plan(args)
        code, payload = _build_xcode(args, project, config, plan)
        _print(payload)
        return code

    project = inspect_project(args.project)
    config = _config_for(args, project)
    if args.command == "archive":
        code, payload = _archive(args, project, config)
        _print(payload)
        return code
    if args.command == "export":
        code, payload = _export(args, project, config)
        _print(payload)
        return code
    if args.command == "all":
        _, _, _, plan = _prepare_plan(args)
        code, build_payload = _build_xcode(args, project, config, plan)
        phases: list[dict[str, object]] = [build_payload]
        if code == EXIT_OK:
            code, payload = _archive(args, project, config)
            phases.append(payload)
        if code == EXIT_OK:
            code, payload = _export(args, project, config)
            phases.append(payload)
        _print({"schemaVersion": 1, "ok": code == EXIT_OK, "phases": phases})
        return code
    raise ProjectError(f"unsupported command: {args.command}")


def main(argv: Sequence[str] | None = None) -> int:
    parser = build_parser()
    try:
        return execute(parser.parse_args(argv))
    except (PolicyError, ProjectError) as exc:
        print(f"error: {exc}", file=sys.stderr)
        return EXIT_POLICY
    except KeyboardInterrupt:
        print("error: interrupted", file=sys.stderr)
        return EXIT_POLICY


def command_for_display(command: Sequence[str]) -> str:
    """Return a shell-escaped command for logs and tests; execution never uses a shell."""
    return shlex.join(command)
