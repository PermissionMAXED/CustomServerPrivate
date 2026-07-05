# Test fixtures

**`routes.contract.json`** is the frozen route+method manifest asserted by
`RouteManifestContractTests` (Phase 0 protocol lock). The shipped game client depends on this exact
route surface, so any diff is a wire-contract change, not a formality.

Regenerating after an **intentional** route change:

1. Run `RouteManifest_MatchesCheckedInContract`. On drift it writes the sorted actual dump to
   `<temp>/routes.actual.json` (the exact path is named in the failure message).
2. Review the diff against this file line-by-line — every added/removed pair must be explained by
   your change.
3. Copy the dump over `routes.contract.json`.

Never regenerate to silence a failure you can't explain.

**`bapcustomservergithubconfig.json`** (present in the build output, not in this source dir) is the
real AMP catalog source, link-copied at build time from `deployment/amp-github-autoinstall/` via the
test csproj's Content include and consumed by `CatalogSyncTests` (HC5). Do not hand-edit the copy —
it mirrors the deployment file.
