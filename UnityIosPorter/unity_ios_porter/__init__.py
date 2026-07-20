"""UnityIosPorter: owned-source Unity Mono to iOS/IL2CPP migration tooling."""

from .project import (
    EXIT_BUILD,
    EXIT_DOCTOR,
    EXIT_EXPORT,
    EXIT_OK,
    EXIT_POLICY,
    EXIT_RISKS,
    EXIT_ARCHIVE,
    PolicyError,
    ProjectError,
    ProjectInfo,
    inspect_project,
)

__all__ = [
    "EXIT_OK",
    "EXIT_RISKS",
    "EXIT_DOCTOR",
    "EXIT_BUILD",
    "EXIT_ARCHIVE",
    "EXIT_EXPORT",
    "EXIT_POLICY",
    "PolicyError",
    "ProjectError",
    "ProjectInfo",
    "inspect_project",
]

__version__ = "1.0.0"
