# A6 — Compiled/Shipped Mod vs Current Source (Medusa)

Date: 2026-06-01
Scope: Cross-verify the SHIPPED/compiled `BAPBAP.Medusa` mod against the current source.
Mode: READ-ONLY. No source/build/deploy changes performed.

---

## 0. TL;DR

- **Current source = v1.6.28**; **live/AMP-shipped build = v1.6.27**. The source is **one version ahead of what is shipped**, and the doc-pinned hash is now stale.
- The **"decompiled v1.6.4" baseline is empty** — `artifacts\medusa-v164-decompiled\BAPBAP.Medusa` and `...\Properties` contain **0 files**. There is no extractable decompiled `.cs` anywhere under `artifacts\`, so a class/method/registry diff against the decompiled v164 could not be performed from that artifact.
- **DLL drift**: AMP package DLL `4D3050CA` (162,816 B, v1.6.27) ≠ local/game-deployed DLL `999D4BDF` (168,448 B, v1.6.28).
- **Bundle drift**: THREE different `medusa.bundle` files coexist (1,283,507 / 1,567,424 / 1,275,524 bytes). The shipped bundle is **not** the one used by the local game copy.
- Net: **the live AMP server runs v1.6.27 + the smaller `2F2CCF12` bundle**, while **local testing runs v1.6.28 + the larger `C4872D6E` bundle** — different ability/VFX code AND different assets. Any "it works locally but not live" symptom is consistent with this drift.

---

## 1. Version constants (source side)

| Location | Evidence | Version |
|---|---|---|
| `BAPBAPModdingAPI\medusa-mod\BAPBAP.Medusa.csproj:9` | `<Version>1.6.28</Version>` | 1.6.28 |
| `BAPBAPModdingAPI\medusa-mod\MedusaMelonAttributes.cs:3` | `[assembly: MelonInfo(typeof(...MedusaMelon), "Medusa", "1.6.28", "BAPBAPCommunity", null)]` | 1.6.28 |
| `BAPBAPModdingAPI\medusa-mod\MedusaMod.cs:1526` | `Log.Info("[Medusa] Loaded (v1.6.28). ...")` | 1.6.28 |
| `BAPBAPModdingAPI\medusa-mod\MedusaMod.cs:1527` | `"[Medusa] v1.6.28: normal prematch selection by default + one-shot live visual repair guards + stable visual cheap health checks + no repeated CharMaterial/material alpha churn after graft. ..."` | 1.6.28 |

Source version is internally consistent at **1.6.28**.

### Registry/identity constants (current source — the baseline a decompile would be compared to)
| Constant | File:Line | Value |
|---|---|---|
| `MedusaMirrorAssetId` | `MedusaMod.cs:1237` | `1296385109u` = `0x4D454455` = ASCII **"MEDU"** |
| `ExpectedMedusaCharId` | `MedusaMod.cs:1387` | `15` |
| `MedusaCharId` (runtime, assigned at register) | `MedusaMod.cs:1497` | `{ get; private set; } = -1;` |
| Asset-id log proof | `MedusaMod.cs:1752` | `assetId=0x{1296385109u:X8}` |

These match the doc's claim of "stable asset id `0x4D454455` (`MEDU`)" and `charId=15`.

---

## 2. Decompiled v1.6.4 artifact — EMPTY

Path: `C:\Users\Administrator\Downloads\CustomServer\artifacts\medusa-v164-decompiled\`

```
medusa-v164-decompiled\BAPBAP.Medusa   <Directory, 0 files>
medusa-v164-decompiled\Properties      <Directory, 0 files>
```

- `Get-ChildItem -Recurse -File -Force` over the tree returns **0 files** (verified twice; folder mtime 2026-05-31 18:12:30).
- No `.cs` files exist anywhere under `artifacts\` (recursive `*.cs` search returned nothing).
- **Consequence**: cannot enumerate classes/methods/registry from the decompiled v164 artifact. The only authoritative version evidence for the older build is the **embedded DLL version** of the shipped binary (see §3), which is **1.6.27**, not 1.6.4. The folder name (`v164`) corresponds to git tag `bapcustomserver-20260531-medusa-v164`, a *release label*, distinct from the assembly version.
- Git tags present (mirror `deployment\github-main-inspect`): `...-medusa`, `-medusa-spawnfix`, `-medusa-v163`, `-medusa-v164`, `-medusa-v165`, `-medusa-v170`. (No `v172` tag in this local mirror; doc says v172 was pushed to the separate AMP-templates repo.)

---

## 3. Deployed DLL / bundle inventory (size · date · SHA256 · embedded version)

### BAPBAP.Medusa.dll
| Path | Size (B) | Modified | SHA256 (prefix) | FileVersion |
|---|---|---|---|---|
| `CustomServer\deployment\amp-full-linux-wine\package\BapCustomServer\game\Mods\BAPBAP.Medusa.dll` | **162,816** | 05-31 18:09:08 | **4D3050CA** | **1.6.27.0** |
| `CustomServer\Spiel\Battleroyalebuild\Mods\BAPBAP.Medusa.dll` | 168,448 | 05-31 20:21:58 | 999D4BDF | 1.6.28.0 |
| `BAPBAPModdingAPI\Battleroyalebuild\Mods\BAPBAP.Medusa.dll` | 168,448 | 05-31 20:21:58 | 999D4BDF | 1.6.28.0 |
| `BAPBAPModdingAPI\medusa-mod\bin\Release\BAPBAP.Medusa.dll` | 168,448 | 05-31 20:21:58 | 999D4BDF | 1.6.28.0 |
| `...medusa-mod\obj\Release\BAPBAP.Medusa.dll` | 168,448 | 05-31 20:21:58 | 999D4BDF | 1.6.28.0 |
| `...medusa-mod\obj\Release\ref|refint\BAPBAP.Medusa.dll` | 25,600 | 05-31 20:21:58 | 92EADC89 | (ref-assembly) |

Full hashes:
```
4D3050CAC36C94AA726F575DE2F271A34248EB70CC81D6C55D27F2248CFBA16C  (AMP, v1.6.27, 162816)
999D4BDF5C60E9F6BFC5E30FA3BBF071AB2AB4204890AE5FA3A30772B9C2BFC0  (local+game, v1.6.28, 168448)
```

### medusa.bundle (THREE distinct artifacts)
| Path | Size (B) | Modified | SHA256 (prefix) |
|---|---|---|---|
| `CustomServer\deployment\amp-full-linux-wine\package\...\UserData\Medusa\medusa.bundle` | **1,283,507** | 05-31 15:01:35 | **2F2CCF12** |
| `CustomServer\deployment\client-bundle\BAPBAP-CustomServer-Client\UserData\Medusa\medusa.bundle` | 1,283,507 | 05-31 15:01:34 | 2F2CCF12 |
| `CustomServer\Spiel\Battleroyalebuild\UserData\Medusa\medusa.bundle` | **1,567,424** | 05-31 20:21:37 | **C4872D6E** |
| `BAPBAPModdingAPI\medusa-mod\medusa.bundle` (source) | 1,567,424 | 05-31 20:21:37 | C4872D6E |
| `BAPBAPModdingAPI\Battleroyalebuild\UserData\Medusa\medusa.bundle` | **1,275,524** | 05-30 18:09:40 | **6350111185** |

Full hashes:
```
2F2CCF12032185E8ED66652417BDEADA764299C523073B7A77205391BA8A2A02  (AMP+client bundle, 1283507, doc-pinned)
C4872D6E124E76F9F4B4EC75482FFC2795D051D3CA65EB7C25E9FE68023B1D70  (source + CustomServer\Spiel game, 1567424)
63501111... (6350111185A9B1C6...)                                  (BAPBAPModdingAPI game copy, 1275524, 05-30)
```

---

## 4. Doc-pinned SHA256 vs reality

`docs\MEDUSA_SERVER_INTEGRATION.md` (Date: 2026-05-31) pins, under
"Current locally built hashes after the v1.6.27 native spawn/log cleanup fix":
```
BAPBAP.Medusa.dll  4D3050CAC36C94AA726F575DE2F271A34248EB70CC81D6C55D27F2248CFBA16C
medusa.bundle      2F2CCF12032185E8ED66652417BDEADA764299C523073B7A77205391BA8A2A02
```
and states AMP `/health` reports `medusa.medusaDllSha256=4D3050CA...`, release `bapcustomserver-20260531-medusa-v172`.

- The pinned DLL hash `4D3050CA` = **v1.6.27** and matches **only** the AMP package copy.
- The current source compiles to **v1.6.28 / `999D4BDF`** (168,448 B), which is what is actually in both game `Mods\` folders and `bin\Release\`.
- **The doc's pinned hash is stale w.r.t. the current source/build.** The doc itself acknowledges the kit is "Kitsu-based ... plus Medusa visuals/status/effect bridges" and that "this old BAPBAP build does not contain official Medusa ability ScriptableObjects" — i.e., green/Kitsu fallback FX are an accepted limit of the *shipped* build.

---

## 5. Drift summary — does the shipped build match current VFX/ability logic?

**No.** Two independent axes of drift:

1. **Code drift (DLL):** Shipped/live = **v1.6.27** (`4D3050CA`, 162,816 B, built 18:09). Source + local game + `bin\Release` = **v1.6.28** (`999D4BDF`, 168,448 B, built 20:21). The v1.6.28 delta (per `MedusaMod.cs:1527`) adds "one-shot live visual repair guards + stable visual cheap health checks + no repeated CharMaterial/material alpha churn after graft" — exactly the kind of logic that affects transparency/visibility/FPS symptoms. **None of that is in the shipped DLL.** The build was bumped/rebuilt (18:20 source edit → 20:21 rebuild) AFTER the 18:09 AMP package was produced, so the AMP package never picked it up.

2. **Asset drift (bundle):** Shipped/live bundle = `2F2CCF12` (1,283,507 B). Local game bundle = `C4872D6E` (1,567,424 B — ~283 KB / +22% larger, newer by ~5h). A third, older bundle `6350111185` (1,275,524 B, 05-30) sits in the `BAPBAPModdingAPI` game copy. The two game checkouts therefore boot **different VFX asset sets**. The larger local bundle plausibly contains additional/updated Medusa VFX prefabs that the shipped bundle lacks.

**Implication for the broader investigation:**
- Live AMP testing exercises **v1.6.27 + `2F2CCF12`**; local testing exercises **v1.6.28 + `C4872D6E`**. "Green lines + Kitsu FX live, but real Medusa VFX exist in LatestBuild" is consistent with the live package shipping the older, smaller bundle and older DLL while the richer assets/logic stayed local-only.
- The two game copies (`CustomServer\Spiel` vs `BAPBAPModdingAPI\Battleroyalebuild`) have **identical DLLs but different bundles** — a reproducibility hazard for any visual repro.

---

## 6. AMP persistence (A6 contribution to item 5)

Direct mechanism evidence: the **only** place the pinned `4D3050CA` (v1.6.27) DLL and `2F2CCF12` bundle live is inside `deployment\amp-full-linux-wine\package\...`, and the doc states AMP `/health` reports that same `4D3050CA` after an Update from GitHub release `...-medusa-v172`.

- **Why a live-uploaded newer DLL resets:** AMP's Update stage re-downloads the full GitHub-release package (`bapcustomserver-amp-full-linux-wine.zip`, which contains `4D3050CA`/v1.6.27) and overwrites the instance files. A hand-uploaded `999D4BDF`/v1.6.28 DLL survives only until the next `Update`. (Confidence: HIGH that the package is the source-of-truth that overwrites; the AMP-side overwrite step is documented behavior in README/integration doc, not re-verified live here.)
- **Real persistent path:** rebuild the AMP full package from the **v1.6.28** artifacts and cut a new GitHub release, then `Update`. SFTP/webupload only persists between Updates unless the released package is also refreshed.

---

## 7. Hypotheses + confidence (A6)

| # | Hypothesis | Confidence | Basis |
|---|---|---|---|
| H1 | Live/AMP runs v1.6.27 while source/local is v1.6.28 (one-version drift) | **HIGH** | Embedded FileVersion 1.6.27.0 vs 1.6.28.0; hashes 4D3050CA vs 999D4BDF; build timestamps 18:09 vs 20:21 |
| H2 | Doc-pinned `4D3050CA` is stale; not the current build | **HIGH** | csproj/MelonInfo/log all say 1.6.28; current build hash 999D4BDF |
| H3 | Shipped bundle (`2F2CCF12`, 1.28 MB) differs from local bundle (`C4872D6E`, 1.57 MB) → different VFX assets live vs local | **HIGH** | Direct hash+size diff |
| H4 | The decompiled-v164 baseline is unusable (empty) → no compiled-vs-decompiled class diff possible; comparison must rely on embedded DLL version | **HIGH** | 0 files in artifact tree (verified) |
| H5 | Live "green lines + Kitsu FX" vs richer LatestBuild VFX is partly explained by shipping older DLL+smaller bundle, compounded by the documented Kitsu-bridge design (no native Medusa ability SOs) | **MEDIUM-HIGH** | Drift in §5 + doc "Known limits"; not visually re-verified here |
| H6 | Two game checkouts with identical DLL but different bundles create non-deterministic visual repros | **MEDIUM** | Bundle hash diff between the two Battleroyalebuild copies |

---

## 8. Evidence index (paths used)

- Source: `BAPBAPModdingAPI\medusa-mod\{MedusaMod.cs, MedusaMelon.cs, MedusaMelonAttributes.cs, BAPBAP.Medusa.csproj, medusa.bundle}`
- Doc: `CustomServer\docs\MEDUSA_SERVER_INTEGRATION.md`
- Empty decompile: `CustomServer\artifacts\medusa-v164-decompiled\{BAPBAP.Medusa, Properties}`
- Shipped: `CustomServer\deployment\amp-full-linux-wine\package\BapCustomServer\game\{Mods\BAPBAP.Medusa.dll, UserData\Medusa\medusa.bundle}`, `CustomServer\deployment\client-bundle\...\UserData\Medusa\medusa.bundle`
- Game copies: `CustomServer\Spiel\Battleroyalebuild\{Mods, UserData\Medusa}`, `BAPBAPModdingAPI\Battleroyalebuild\{Mods, UserData\Medusa}`
- Build output: `BAPBAPModdingAPI\medusa-mod\bin\Release\`, `...\obj\Release\`
- Git tags mirror: `CustomServer\deployment\github-main-inspect`
