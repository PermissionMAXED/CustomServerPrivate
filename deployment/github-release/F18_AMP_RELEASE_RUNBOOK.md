# Legacy AMP release runbook

This file used to describe the older `bapcustomserver-20260526-222401` release
flow and an obsolete mod DLL hash. It is intentionally kept only as a pointer so
operators do not follow stale instructions.

Use these current documents instead:

- `docs/AMP_LINUX_WINE_ROOT_CAUSE.md`
- `deployment/github-release/README.md`
- `deployment/amp-github-autoinstall/README.md`

Current proven release:

```text
bapcustomserver-20260531-medusa-v172
```

Current tested mod DLL SHA256:

```text
3E796F1E22D124F6433DAE5BC67149A4A25D0CB5FD607DAB11FFE6934EA15E8D
```

The safe rule is simple: do not update the pinned hash or publish a new AMP
release until a live AMP client test proves queue, match bootstrap, real match,
result/exit, and cleanup.
