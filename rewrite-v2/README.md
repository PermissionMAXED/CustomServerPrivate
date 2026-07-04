# rewrite-v2 — BAP Custom Server Rewrite Plan

This folder contains the complete architecture and migration plan for incrementally rewriting the
BAP Custom Server stack (lobby/match server, MelonLoader client mod, client proxy) into a cleaner,
modular, testable system — **without ever breaking the unmodified BAPBAP game client**.

Nothing in this folder is executable code. It is a design + migration package meant to be read in
order and then executed phase by phase (see `04-migration-plan.md`). No existing source file in the
repository is modified by this plan's creation; the plan itself prescribes a strangler-fig migration,
not a big-bang rewrite.

## Why a rewrite plan (one paragraph)

The system works in production (AMP + Linux/Wine, 375-test xUnit suite), but three files carry most
of the complexity: `CustomMatchServer/Program.cs` (2,776 lines — DI + config post-processing + every
HTTP endpoint), `CustomMatchServer/LobbyService.cs` (3,512 lines — WS loop, lobby state, match
lifecycle, admin handshake, payload building), and `BapCustomServerMelon/CustomServerMod.cs`
(15,604 lines — one class doing config, host patching, identity, proxy management, bootstrap
listener, dedicated-host logic, UI, network tuning, and a dozen Harmony patch families). The
dominant risk in any rewrite is the wire protocol: the IL2CPP game client is unmodifiable, so the
HTTP/WS contract it speaks is frozen. This plan locks that contract with golden/contract tests
first, then migrates module by module.

## Document index

| Doc | Contents |
| --- | --- |
| `00-goals-and-constraints.md` | Goals (modularity, testability, maintainability, performance) and the HARD constraints: 100% client protocol compatibility, Linux+Wine/AMP deployment, single-DLL mod, permissive metagame stubs, catalog-sync invariant. |
| `01-current-state-assessment.md` | Concrete findings: file sizes, responsibility tangles, coupling, duplication, config sprawl, risk areas — with real file/line citations. |
| `02-target-architecture.md` | Target modular design for the server (layered projects: Protocol / Domain / Application / Infrastructure / Host) and the mod (cohesive components), with mermaid diagrams, solution layout, and dependency rules. |
| `03-protocol-compatibility.md` | The exact wire contract that must be preserved (HTTP routes + aliases, uppercase WS events, the `/setup-game` → `/add-teams` → `/queue-matched` bootstrap), and how to lock it with contract/golden tests. |
| `04-migration-plan.md` | Phased strangler-fig migration: ordered phases, what ships each phase, side-by-side operation, rollback, and exit criteria per phase. |
| `05-testing-and-tooling.md` | Test pyramid (unit/contract/integration/e2e smoke), analyzers/.editorconfig/warnings-as-errors, CI outline, and the catalog-sync enforcement test. |
| `06-risks-and-open-questions.md` | Top risks, unknowns (e.g. IL2CPP-stripped event strings), and decisions that need an owner. |
| `07-evaluation-and-revisions.md` | Provenance: the plan was reviewed by three independent audits; this doc lists the corrections applied (with repo-verified citations). |

## How to use this folder

1. Read `00` and `03` first — they define what may NOT change.
2. Read `01` to understand where the current pain actually is (not where it looks like it is).
3. Read `02` for the destination, `04` for the route, `05` for the guardrails, `06` for what could
   go wrong.
4. Execute Phase 0 of `04-migration-plan.md` (contract lock) before touching any production code.

## Ground rules inherited by every phase

- The game client is an unmodifiable IL2CPP binary. Every observable HTTP/WS behavior it depends on
  is a public API. If the current server answers a route, the new one answers it identically.
- The existing xUnit suite (`tests/BapCustomServer.Tests`, 375 tests) keeps passing at every phase.
- PowerShell smoke scripts under `tools/` remain the e2e verification on a Windows/game-build
  machine; Linux CI covers everything that doesn't need `bapbap.exe`.
- The old and new implementations run side by side during migration; each phase has a rollback
  switch (config flag or project reference swap), never a one-way door.
