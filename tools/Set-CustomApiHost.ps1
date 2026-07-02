param(
    [string]$BuildRoot = (Join-Path $PSScriptRoot "..\Spiel\Battleroyalebuild"),
    [string]$ExportedProjectRoot = (Join-Path $PSScriptRoot "..\AssetRip\ExportedProject"),
    [string]$ApiHost = "http://127.0.0.1:5055",
    [switch]$SkipBinaryPatch
)

$ErrorActionPreference = "Stop"

Add-Type -TypeDefinition @"
using System;

public static class BapBinarySearch
{
    public static int IndexOf(byte[] haystack, byte[] needle, int startIndex)
    {
        if (haystack == null || needle == null || needle.Length == 0 || haystack.Length < needle.Length)
        {
            return -1;
        }

        int max = haystack.Length - needle.Length;
        byte first = needle[0];

        for (int i = Math.Max(0, startIndex); i <= max; i++)
        {
            if (haystack[i] != first)
            {
                continue;
            }

            int j = 1;
            for (; j < needle.Length && haystack[i + j] == needle[j]; j++)
            {
            }

            if (j == needle.Length)
            {
                return i;
            }
        }

        return -1;
    }
}
"@

function Convert-ToAsciiBytes {
    param([Parameter(Mandatory = $true)][string]$Value)
    return [System.Text.Encoding]::ASCII.GetBytes($Value)
}

function Find-Sequence {
    param(
        [Parameter(Mandatory = $true)][byte[]]$Data,
        [Parameter(Mandatory = $true)][byte[]]$Needle,
        [int]$StartIndex = 0
    )

    return [BapBinarySearch]::IndexOf($Data, $Needle, $StartIndex)
}

function Patch-BinaryString {
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$OldValue,
        [Parameter(Mandatory = $true)][string]$NewValue
    )

    if (!(Test-Path -LiteralPath $Path)) {
        return
    }

    $oldBytes = Convert-ToAsciiBytes $OldValue
    $newBytes = Convert-ToAsciiBytes $NewValue

    if ($oldBytes.Length -ne $newBytes.Length) {
        throw "Binary asset patch requires equal byte length. '$OldValue' is $($oldBytes.Length) bytes, '$NewValue' is $($newBytes.Length) bytes."
    }

    $fullPath = (Resolve-Path -LiteralPath $Path).Path
    $data = [System.IO.File]::ReadAllBytes($fullPath)
    $index = Find-Sequence -Data $data -Needle $oldBytes
    $count = 0

    while ($index -ge 0) {
        [Array]::Copy($newBytes, 0, $data, $index, $newBytes.Length)
        $count++
        $index = Find-Sequence -Data $data -Needle $oldBytes -StartIndex ($index + $newBytes.Length)
    }

    if ($count -gt 0) {
        $backupPath = "$fullPath.bak"
        if (!(Test-Path -LiteralPath $backupPath)) {
            Copy-Item -LiteralPath $fullPath -Destination $backupPath
        }

        [System.IO.File]::WriteAllBytes($fullPath, $data)
        Write-Host "Patched $count occurrence(s) in $fullPath"
    }
}

function Patch-ExportedClientJson {
    param(
        [Parameter(Mandatory = $true)][string]$ProjectRoot,
        [Parameter(Mandatory = $true)][string]$NewApiHost
    )

    $clientJson = Join-Path $ProjectRoot "Assets\Resources\Client.json"
    if (!(Test-Path -LiteralPath $clientJson)) {
        return
    }

    $raw = Get-Content -Raw -LiteralPath $clientJson
    $json = $raw | ConvertFrom-Json
    $json.ApiHost = $NewApiHost
    $json | ConvertTo-Json -Compress | Set-Content -NoNewline -LiteralPath $clientJson
    Write-Host "Updated exported project Client.json -> $NewApiHost"
}

$sourceApiHost = "https://bapbap.gg:443"

Patch-ExportedClientJson -ProjectRoot $ExportedProjectRoot -NewApiHost $ApiHost

if (!$SkipBinaryPatch) {
    Patch-BinaryString -Path (Join-Path $BuildRoot "bapbap_Data\resources.assets") -OldValue $sourceApiHost -NewValue $ApiHost
    Patch-BinaryString -Path (Join-Path $BuildRoot "bapbap_Data\sharedassets0.assets") -OldValue $sourceApiHost -NewValue $ApiHost
}
