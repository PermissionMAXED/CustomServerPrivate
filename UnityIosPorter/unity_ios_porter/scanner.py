"""Static AOT/iOS compatibility scanners for owned Unity C# source."""

from __future__ import annotations

import re
from dataclasses import asdict, dataclass
from pathlib import Path
from typing import Iterator

from .project import ProjectInfo


@dataclass(frozen=True)
class Finding:
    code: str
    severity: str
    path: str
    line: int
    message: str
    evidence: str

    def to_dict(self) -> dict[str, object]:
        return asdict(self)


@dataclass(frozen=True)
class PatternRule:
    code: str
    severity: str
    pattern: re.Pattern[str]
    message: str


RULES = (
    PatternRule(
        "AOT001",
        "error",
        re.compile(r"\bReflection\s*\.\s*Emit\b|\bSystem\s*\.\s*Reflection\s*\.\s*Emit\b"),
        "Reflection.Emit is unavailable under iOS IL2CPP AOT.",
    ),
    PatternRule(
        "AOT002",
        "error",
        re.compile(r"\bDynamicMethod\b"),
        "DynamicMethod generates runtime code and is unavailable under iOS AOT.",
    ),
    PatternRule(
        "AOT003",
        "error",
        re.compile(
            r"\bAssembly\s*\.\s*Load\s*\(\s*(?:new\s+byte|File\s*\.\s*ReadAllBytes|"
            r"Convert\s*\.\s*FromBase64String|[A-Za-z_]\w*\b)"
        ),
        "Loading assembly bytes at runtime is incompatible with iOS code-signing/AOT.",
    ),
    PatternRule(
        "AOT004",
        "warning",
        re.compile(r"\bdynamic\s+[A-Za-z_]\w*"),
        "The C# dynamic runtime may require preserved AOT generic instantiations.",
    ),
    PatternRule(
        "SEC001",
        "error",
        re.compile(r"\bBinaryFormatter\b"),
        "BinaryFormatter is insecure, obsolete, and unsuitable for the iOS port.",
    ),
    PatternRule(
        "IOS002",
        "error",
        re.compile(r"\bSystem\s*\.\s*Drawing\b"),
        "System.Drawing is not a supported Unity iOS runtime API.",
    ),
)

REFLECTION_RE = re.compile(
    r"\bSystem\s*\.\s*Reflection\b|\bType\s*\.\s*GetType\s*\(|"
    r"\.\s*Get(?:Method|Methods|Field|Fields|Property|Properties)\s*\(|"
    r"\bActivator\s*\.\s*CreateInstance\s*\("
)
EXPRESSION_CONTEXT_RE = re.compile(
    r"\bSystem\s*\.\s*Linq\s*\.\s*Expressions\b|"
    r"\busing\s+System\s*\.\s*Linq\s*\.\s*Expressions\s*;|"
    r"\bExpression\s*<"
)
EXPRESSION_COMPILE_RE = re.compile(r"\.\s*Compile\s*\(")
DLL_IMPORT_RE = re.compile(
    r"\bDllImport\s*\(\s*(?:@|\$)?[\"'](?P<library>[^\"']+)[\"']",
    re.IGNORECASE,
)
WINDOWS_LIBRARIES = {
    "advapi32",
    "comdlg32",
    "gdi32",
    "kernel32",
    "msvcrt",
    "ntdll",
    "ole32",
    "shell32",
    "user32",
    "winhttp",
    "wininet",
    "winmm",
    "ws2_32",
}
NATIVE_EXTENSIONS = {".a", ".dylib", ".so", ".dll", ".bundle"}


def mask_csharp_comments_and_strings(text: str) -> str:
    """Mask comments and literals, preserving code inside interpolations."""
    output = list(text)
    length = len(text)

    def blank(start: int, end: int) -> None:
        for position in range(start, end):
            if output[position] not in "\r\n":
                output[position] = " "

    def mask_quoted(
        start: int, prefix_length: int, quote: str, *, verbatim: bool = False
    ) -> int:
        index = start + prefix_length
        blank(start, index)
        while index < length:
            if verbatim and text.startswith('""', index):
                blank(index, index + 2)
                index += 2
            elif not verbatim and text[index] == "\\":
                blank(index, min(index + 2, length))
                index += 2
            elif text[index] == quote:
                blank(index, index + 1)
                return index + 1
            else:
                blank(index, index + 1)
                index += 1
        return index

    def mask_expression(index: int) -> int:
        depth = 1
        while index < length:
            if text.startswith("//", index):
                end = text.find("\n", index + 2)
                end = length if end == -1 else end
                blank(index, end)
                index = end
            elif text.startswith("/*", index):
                end = text.find("*/", index + 2)
                end = length if end == -1 else end + 2
                blank(index, end)
                index = end
            elif text.startswith(('$@"', '@$"'), index):
                index = mask_interpolated(index, 3, verbatim=True)
            elif text.startswith('$"', index):
                index = mask_interpolated(index, 2, verbatim=False)
            elif text.startswith('@"', index):
                index = mask_quoted(index, 2, '"', verbatim=True)
            elif text[index] in {'"', "'"}:
                index = mask_quoted(index, 1, text[index])
            elif text[index] == "{":
                depth += 1
                index += 1
            elif text[index] == "}":
                depth -= 1
                if depth == 0:
                    blank(index, index + 1)
                    return index + 1
                index += 1
            else:
                index += 1
        return index

    def mask_interpolated(start: int, prefix_length: int, *, verbatim: bool) -> int:
        index = start + prefix_length
        blank(start, index)
        while index < length:
            if verbatim and text.startswith('""', index):
                blank(index, index + 2)
                index += 2
            elif not verbatim and text[index] == "\\":
                blank(index, min(index + 2, length))
                index += 2
            elif text[index] == '"':
                blank(index, index + 1)
                return index + 1
            elif text.startswith(("{{", "}}"), index):
                blank(index, index + 2)
                index += 2
            elif text[index] == "{":
                blank(index, index + 1)
                index = mask_expression(index + 1)
            else:
                blank(index, index + 1)
                index += 1
        return index

    index = 0
    while index < length:
        if text.startswith("//", index):
            end = text.find("\n", index + 2)
            end = length if end == -1 else end
            blank(index, end)
            index = end
        elif text.startswith("/*", index):
            end = text.find("*/", index + 2)
            end = length if end == -1 else end + 2
            blank(index, end)
            index = end
        elif text.startswith(('$@"', '@$"'), index):
            index = mask_interpolated(index, 3, verbatim=True)
        elif text.startswith('$"', index):
            index = mask_interpolated(index, 2, verbatim=False)
        elif text.startswith('@"', index):
            index = mask_quoted(index, 2, '"', verbatim=True)
        elif text[index] in {'"', "'"}:
            index = mask_quoted(index, 1, text[index])
        else:
            index += 1
    return "".join(output)


def _line_number(text: str, offset: int) -> int:
    return text.count("\n", 0, offset) + 1


def _evidence(text: str, offset: int) -> str:
    start = text.rfind("\n", 0, offset) + 1
    end = text.find("\n", offset)
    end = len(text) if end == -1 else end
    return text[start:end].strip()[:180]


def _relative(path: Path, root: Path) -> str:
    return path.relative_to(root).as_posix()


def _source_files(root: Path) -> Iterator[Path]:
    for source_root in (root / "Assets", root / "Packages"):
        for path in source_root.rglob("*.cs"):
            if path.is_file():
                yield path


def _has_editor_segment(path: Path, root: Path) -> bool:
    return any(part.casefold() == "editor" for part in path.relative_to(root).parts[:-1])


def _scan_source(path: Path, root: Path) -> tuple[list[Finding], int]:
    try:
        original = path.read_text(encoding="utf-8")
    except (OSError, UnicodeError):
        return (
            [
                Finding(
                    "SRC001",
                    "warning",
                    _relative(path, root),
                    1,
                    "Source file could not be decoded as UTF-8 and was skipped.",
                    "",
                )
            ],
            0,
        )
    masked = mask_csharp_comments_and_strings(original)
    relative = _relative(path, root)
    findings: list[Finding] = []
    for rule in RULES:
        for match in rule.pattern.finditer(masked):
            findings.append(
                Finding(
                    rule.code,
                    rule.severity,
                    relative,
                    _line_number(masked, match.start()),
                    rule.message,
                    _evidence(original, match.start()),
                )
            )

    if EXPRESSION_CONTEXT_RE.search(masked):
        for match in EXPRESSION_COMPILE_RE.finditer(masked):
            findings.append(
                Finding(
                    "AOT005",
                    "error",
                    relative,
                    _line_number(masked, match.start()),
                    "Expression.Compile attempts runtime code generation under AOT.",
                    _evidence(original, match.start()),
                )
            )

    if not _has_editor_segment(path, root):
        for match in re.finditer(r"\bUnityEditor\b", masked):
            findings.append(
                Finding(
                    "IOS001",
                    "error",
                    relative,
                    _line_number(masked, match.start()),
                    "UnityEditor API is referenced outside an Editor directory.",
                    _evidence(original, match.start()),
                )
            )

    # DllImport needs its literal argument, so inspect raw source only at attributes
    # whose start is still visible after comment masking.
    for match in DLL_IMPORT_RE.finditer(original):
        if masked[match.start() : match.start() + 9].strip().casefold() != "dllimport":
            continue
        library = Path(match.group("library")).name.casefold()
        stem = library.removesuffix(".dll")
        if stem in WINDOWS_LIBRARIES or library.endswith(".dll"):
            findings.append(
                Finding(
                    "IOS003",
                    "error",
                    relative,
                    _line_number(original, match.start()),
                    f"Windows DllImport '{match.group('library')}' is unavailable on iOS.",
                    _evidence(original, match.start()),
                )
            )
    return findings, len(REFLECTION_RE.findall(masked))


def _iphone_disabled(meta_text: str) -> bool:
    blocks = re.split(r"(?=^\s*-\s*first:\s*$)", meta_text, flags=re.MULTILINE)
    return any(
        re.search(r"^\s*(?:iPhone|iOS):", block, re.IGNORECASE | re.MULTILINE)
        and re.search(r"^\s*enabled:\s*0\s*$", block, re.IGNORECASE | re.MULTILINE)
        for block in blocks
    )


def _scan_plugins(root: Path) -> list[Finding]:
    findings: list[Finding] = []
    for path in (root / "Assets").rglob("*"):
        if not path.is_file() or path.suffix.casefold() not in NATIVE_EXTENSIONS:
            continue
        relative = _relative(path, root)
        extension = path.suffix.casefold()
        meta_path = Path(str(path) + ".meta")
        meta_text = ""
        if meta_path.is_file():
            try:
                meta_text = meta_path.read_text(encoding="utf-8")
            except (OSError, UnicodeError):
                pass

        if extension == ".so":
            findings.append(
                Finding(
                    "PLG001",
                    "error",
                    relative,
                    1,
                    "Linux .so native plugin cannot link into an iOS application.",
                    path.name,
                )
            )
        elif extension == ".dll":
            findings.append(
                Finding(
                    "PLG002",
                    "warning",
                    relative,
                    1,
                    "DLL plugin requires review; managed assemblies may work, native Windows DLLs do not.",
                    path.name,
                )
            )
        if meta_text and _iphone_disabled(meta_text):
            findings.append(
                Finding(
                    "PLG003",
                    "warning",
                    relative + ".meta",
                    1,
                    "Plugin importer metadata explicitly disables the iPhone/iOS target.",
                    "iPhone/iOS enabled: 0",
                )
            )
    return findings


def scan_project(project: ProjectInfo) -> dict[str, object]:
    root = Path(project.root)
    findings: list[Finding] = []
    reflection_uses = 0
    for path in _source_files(root):
        source_findings, source_reflection = _scan_source(path, root)
        findings.extend(source_findings)
        reflection_uses += source_reflection

    has_link_xml = any(
        path.is_file()
        for source_root in (root / "Assets", root / "Packages")
        for path in source_root.rglob("link.xml")
    )
    if reflection_uses >= 3 and not has_link_xml:
        findings.append(
            Finding(
                "AOT006",
                "warning",
                "Assets",
                1,
                "Heavy reflection was detected without a link.xml preservation file.",
                f"{reflection_uses} reflection-sensitive calls",
            )
        )
    findings.extend(_scan_plugins(root))
    findings.sort(key=lambda item: (item.path.casefold(), item.line, item.code))
    counts = {
        severity: sum(1 for finding in findings if finding.severity == severity)
        for severity in ("error", "warning", "info")
    }
    return {
        "schemaVersion": 1,
        "project": project.to_dict(),
        "findings": [finding.to_dict() for finding in findings],
        "summary": {
            "total": len(findings),
            **counts,
            "reflectionUses": reflection_uses,
            "linkXmlPresent": has_link_xml,
        },
    }
