# Risk rules

The scanner masks C# comments, string literals, character literals, and the
body of token-exact `#if UNITY_EDITOR` branches before matching APIs. It is
intentionally conservative and does not replace a Roslyn build, Unity
compilation, or physical-device test.

| Rule | Severity | Signal | Required review |
|---|---|---|---|
| `AOT001` | error | `System.Reflection.Emit` | Replace runtime code generation with ahead-of-time source. |
| `AOT002` | error | `DynamicMethod` | Replace generated methods with compiled source. |
| `AOT003` | error | `Assembly.Load` from a runtime value/bytes | Statically include authorized code; iOS does not permit runtime assembly loading. |
| `AOT004` | warning | C# `dynamic` | Verify binder support and all AOT generic instantiations. |
| `AOT005` | error | expression-tree `Compile()` | Replace runtime compilation or use an interpreter where supported and tested. |
| `AOT006` | warning | heavy reflection without `link.xml` | Add targeted preservation or attributes and test stripping. |
| `SEC001` | error | `BinaryFormatter` | Migrate to a safe, explicit serialization format. |
| `IOS001` | error | `UnityEditor` outside an `Editor/` path | Move editor-only code or add a correct editor-only assembly boundary. |
| `IOS002` | error | `System.Drawing` | Replace with Unity/iOS-supported image APIs. |
| `IOS003` | error | Windows `DllImport` | Supply an iOS implementation, commonly a static library/framework and `__Internal`. |
| `PLG001` | error | Linux `.so` plugin | Supply a compatible iOS binary and source rights. |
| `PLG002` | warning | `.dll` plugin | Determine whether it is managed IL2CPP-compatible code or a Windows native DLL. |
| `PLG003` | warning | plugin `.meta` disables iPhone/iOS | Correct importer settings only after confirming plugin compatibility. |
| `SRC001` | warning | non-UTF-8 C# source | Normalize encoding or inspect the skipped file manually. |

Any finding makes `scan` exit `2`. Error findings and scene errors (no
enabled scenes, a missing scene file, or a non-canonical scene path such as
an absolute path, backslashes, or `..` segments) make a plan blocking, so
`build-xcode` and `all` stop with exit `2` before staging. Warnings remain
visible in `build-plan.json`; they do not alone block staging.

## False positives and negatives

The scanner traverses C# files under both `Assets/` and `Packages/`, including
embedded or local package source physically present in `Packages/`. It does not
scan Unity's generated `Library/PackageCache/` or follow `file:` dependencies
outside the project tree. Resolve and review those package sources separately.

C# files with an `Editor/` path segment are excluded from runtime compatibility
rules and reflection counts because Unity's Editor special folders are not
included in player builds. An unreadable file still reports `SRC001`. The
scanner does not evaluate `.asmdef` platform constraints, so editor-only
assemblies outside an `Editor/` path and other assemblies excluded from iOS can
still produce findings.

Only a preprocessor condition that is exactly the token `UNITY_EDITOR` is
masked. Its `#else` and `#elif` branches remain scanned. Compound or parenthesized
conditions such as `UNITY_EDITOR || DEVELOPMENT_BUILD` remain scanned
conservatively.

Simple source matching can also miss aliases, generated code, other conditional
compilation, reflection hidden behind wrappers, and plugin binary architecture.
Review each finding in the actual Unity compilation context.

The plugin scan reads extensions and adjacent `.meta` importer data but does
not execute or disassemble binaries. That limitation is deliberate.

## Linker guidance

Do not preserve every assembly as a default workaround. Prefer the narrowest
`link.xml`, `[Preserve]`, or dependency annotation that covers runtime
reflection, then run a release device build. Excess preservation increases app
size and can conceal missing AOT instantiations without fixing them.
