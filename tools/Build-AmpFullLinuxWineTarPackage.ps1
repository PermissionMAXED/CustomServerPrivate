param(
    [string]$Configuration = "Release",
    [switch]$SkipRebuild
)

$ErrorActionPreference = "Stop"

$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$OutRoot = Join-Path $Root "deployment\amp-full-linux-wine"
$TarPath = Join-Path $OutRoot "bapcustomserver-amp-full-linux-wine.tar.gz"

if (-not $SkipRebuild.IsPresent) {
    & (Join-Path $Root "tools\Build-AmpFullLinuxWinePackage.ps1") -Configuration $Configuration | Out-Host
}

$packageRoot = Get-ChildItem -LiteralPath $OutRoot -Directory |
    Where-Object { $_.Name -eq "package" -or $_.Name -like "package-build-*" } |
    Sort-Object LastWriteTime -Descending |
    Select-Object -First 1

if ($null -eq $packageRoot) {
    throw "No AMP full package staging folder found under $OutRoot"
}

$python = @'
import os
import pathlib
import tarfile

src = pathlib.Path(os.environ["BAPCUSTOM_TAR_SOURCE"])
out = pathlib.Path(os.environ["BAPCUSTOM_TAR_OUTPUT"])

if out.exists():
    out.unlink()

exec_names = {
    "BapCustomServer/BapCustomServer",
    "BapCustomServer/amp-webpanel-start.sh",
    "BapCustomServer/start-linux-wine.sh",
    "BapCustomServer/createdump",
}

with tarfile.open(out, "w:gz", compresslevel=6) as archive:
    for path in sorted(src.rglob("*")):
        rel = path.relative_to(src).as_posix()
        info = archive.gettarinfo(str(path), arcname=rel)
        info.uid = 0
        info.gid = 0
        info.uname = ""
        info.gname = ""

        if path.is_dir():
            info.mode = 0o755
            archive.addfile(info)
        elif path.is_file():
            info.mode = 0o755 if rel in exec_names else 0o644
            with path.open("rb") as stream:
                archive.addfile(info, stream)

print(out)
'@

$tempPython = Join-Path $env:TEMP ("build-bapcustomserver-tar-" + [Guid]::NewGuid().ToString("N") + ".py")
try {
    Set-Content -LiteralPath $tempPython -Value $python -Encoding UTF8
    $env:BAPCUSTOM_TAR_SOURCE = $packageRoot.FullName
    $env:BAPCUSTOM_TAR_OUTPUT = $TarPath
    python $tempPython
}
finally {
    Remove-Item -LiteralPath $tempPython -Force -ErrorAction SilentlyContinue
    Remove-Item Env:\BAPCUSTOM_TAR_SOURCE -ErrorAction SilentlyContinue
    Remove-Item Env:\BAPCUSTOM_TAR_OUTPUT -ErrorAction SilentlyContinue
}

[pscustomobject]@{
    tar = $TarPath
    packageRoot = $packageRoot.FullName
    sizeGB = [math]::Round((Get-Item -LiteralPath $TarPath).Length / 1GB, 2)
} | ConvertTo-Json -Compress
