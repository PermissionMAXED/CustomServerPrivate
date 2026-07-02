param(
    [Parameter(Mandatory=$true)]
    [string]$InputDll,

    [Parameter(Mandatory=$true)]
    [string]$OutputDll,

    [string]$Version = '1.6.62'
)

$ErrorActionPreference = 'Stop'

$cecil = Join-Path $env:USERPROFILE '.nuget\packages\mono.cecil\0.11.6\lib\netstandard2.0\Mono.Cecil.dll'
if (-not (Test-Path -LiteralPath $cecil)) {
    throw "Mono.Cecil not found at $cecil"
}

Add-Type -Path $cecil

$inputFull = [System.IO.Path]::GetFullPath($InputDll)
$outputFull = [System.IO.Path]::GetFullPath($OutputDll)
if (-not (Test-Path -LiteralPath $inputFull -PathType Leaf)) {
    throw "Input DLL not found: $inputFull"
}

$outDir = [System.IO.Path]::GetDirectoryName($outputFull)
if (-not [string]::IsNullOrWhiteSpace($outDir)) {
    New-Item -ItemType Directory -Path $outDir -Force | Out-Null
}

$reader = [Mono.Cecil.ReaderParameters]::new()
$reader.ReadWrite = $false
$assembly = [Mono.Cecil.AssemblyDefinition]::ReadAssembly($inputFull, $reader)
$module = $assembly.MainModule
$type = $module.Types | Where-Object { $_.FullName -eq 'BAPBAP.Medusa.MedusaMod' } | Select-Object -First 1
if ($null -eq $type) {
    throw 'BAPBAP.Medusa.MedusaMod type not found.'
}

function Get-Method([string]$name) {
    $method = $type.Methods | Where-Object { $_.Name -eq $name } | Select-Object -First 1
    if ($null -eq $method) {
        throw "Method not found: $name"
    }
    return $method
}

function Set-Nop($instruction) {
    $instruction.OpCode = [Mono.Cecil.Cil.OpCodes]::Nop
    $instruction.Operand = $null
}

function Get-InstructionIndex($instructions, $instruction) {
    for ($i = 0; $i -lt $instructions.Count; $i++) {
        if ([object]::ReferenceEquals($instructions[$i], $instruction)) {
            return $i
        }
    }
    return -1
}

# Keep the old headless-safe binary, but make logs/metadata identify this IL guard build.
$assembly.Name.Version = [Version]::Parse("$Version.0")
foreach ($attr in $assembly.CustomAttributes) {
    if ($attr.AttributeType.Name -eq 'MelonInfoAttribute' -and $attr.ConstructorArguments.Count -ge 3) {
        $args = [System.Collections.Generic.List[Mono.Cecil.CustomAttributeArgument]]::new($attr.ConstructorArguments)
        $args[2] = [Mono.Cecil.CustomAttributeArgument]::new($module.TypeSystem.String, $Version)
        $attr.ConstructorArguments.Clear()
        foreach ($arg in $args) {
            $attr.ConstructorArguments.Add($arg)
        }
    }
}

foreach ($method in $type.Methods) {
    if (-not $method.HasBody) { continue }
    foreach ($instruction in $method.Body.Instructions) {
        if ($instruction.OpCode.Code -eq [Mono.Cecil.Cil.Code]::Ldstr -and $instruction.Operand -is [string]) {
            $text = [string]$instruction.Operand
            if ($text.Contains('v1.6.58')) {
                $instruction.Operand = $text.Replace('v1.6.58', "v$Version")
            }
        }
    }
}

# Remove FindBestLocalMedusaEntity's unsafe fallbacks without rewriting the
# try/catch tail. Replacing ranges that cross handler boundaries can produce
# CLR-invalid IL in the Melon runtime, so only flip existing operands inside
# the original control flow.
$findBest = Get-Method 'FindBestLocalMedusaEntity'
$findIns = $findBest.Body.Instructions
$sole = $findIns | Where-Object { $_.OpCode.Code -eq [Mono.Cecil.Cil.Code]::Ldstr -and $_.Operand -eq 'soleMedusaEntity' } | Select-Object -First 1
$last = $findIns | Where-Object { $_.OpCode.Code -eq [Mono.Cecil.Cil.Code]::Ldstr -and $_.Operand -eq 'lastLiveEntity' } | Select-Object -First 1
if ($null -eq $sole -or $null -eq $last) {
    throw 'Expected FindBestLocalMedusaEntity fallback markers were not found.'
}
$soleIndex = Get-InstructionIndex $findIns $sole
$lastIndex = Get-InstructionIndex $findIns $last
$soleCountOne = $null
for ($i = $soleIndex; $i -ge 0; $i--) {
    if ($findIns[$i].OpCode.Code -eq [Mono.Cecil.Cil.Code]::Ldc_I4_1) {
        $soleCountOne = $findIns[$i]
        break
    }
}
if ($null -eq $soleCountOne) {
    throw 'Could not find soleMedusaEntity medusaCount == 1 constant.'
}
$soleCountOne.OpCode = [Mono.Cecil.Cil.OpCodes]::Ldc_I4_0
$soleCountOne.Operand = $null

$lastLiveLoad = $null
for ($i = $lastIndex; $i -ge 0; $i--) {
    if ($findIns[$i].OpCode.Code -eq [Mono.Cecil.Cil.Code]::Ldsfld -and
        $findIns[$i].Operand -is [Mono.Cecil.FieldReference] -and
        $findIns[$i].Operand.Name -eq '_lastLiveMedusaEntity') {
        $lastLiveLoad = $findIns[$i]
        break
    }
}
if ($null -eq $lastLiveLoad) {
    throw 'Could not find _lastLiveMedusaEntity load.'
}
$lastLiveLoad.OpCode = [Mono.Cecil.Cil.OpCodes]::Ldnull
$lastLiveLoad.Operand = $null

# Remove RepairLocalMedusaBinding's ownerless force path. Real owner/ref matches
# remain valid. Again, do not nop ranges; preserve stack shape and branches.
$repair = Get-Method 'RepairLocalMedusaBinding'
$repairIns = $repair.Body.Instructions
$forceStore = $null
foreach ($instruction in $repairIns) {
    if ($instruction.OpCode.Code -eq [Mono.Cecil.Cil.Code]::Stloc_S -and $instruction.Operand -is [Mono.Cecil.Cil.VariableDefinition] -and $instruction.Operand.Index -eq 12) {
        $forceStore = $instruction
        break
    }
}
if ($null -eq $forceStore) {
    throw 'Could not find RepairLocalMedusaBinding forceAllowed store.'
}
$forceStoreIndex = Get-InstructionIndex $repairIns $forceStore
$forceStart = -1
for ($i = $forceStoreIndex; $i -ge 0; $i--) {
    if ($repairIns[$i].OpCode.Code -eq [Mono.Cecil.Cil.Code]::Ldarg_2) {
        $forceStart = $i
        break
    }
}
if ($forceStart -lt 0) {
    throw 'Could not find RepairLocalMedusaBinding forceAllowed start.'
}
$repairIns[$forceStart].OpCode = [Mono.Cecil.Cil.OpCodes]::Ldc_I4_0
$repairIns[$forceStart].Operand = $null

$ownerlessStart = -1
for ($i = $forceStoreIndex + 1; $i -lt $repairIns.Count - 2; $i++) {
    if ($repairIns[$i].OpCode.Code -eq [Mono.Cecil.Cil.Code]::Ldloc_S -and
        $repairIns[$i].Operand -is [Mono.Cecil.Cil.VariableDefinition] -and $repairIns[$i].Operand.Index -eq 9 -and
        $repairIns[$i + 1].OpCode.Code -eq [Mono.Cecil.Cil.Code]::Ldloc_S -and
        $repairIns[$i + 1].Operand -is [Mono.Cecil.Cil.VariableDefinition] -and $repairIns[$i + 1].Operand.Index -eq 11) {
        $ownerlessStart = $i
        break
    }
}
if ($ownerlessStart -lt 0) {
    throw 'Could not find ownerless localPrimaryMissing bypass.'
}
$repairIns[$ownerlessStart].OpCode = [Mono.Cecil.Cil.OpCodes]::Ldc_I4_0
$repairIns[$ownerlessStart].Operand = $null

$writer = [Mono.Cecil.WriterParameters]::new()
$assembly.Write($outputFull, $writer)

[pscustomobject]@{
    input = $inputFull
    output = $outputFull
    version = $Version
    inputSha256 = (Get-FileHash -LiteralPath $inputFull -Algorithm SHA256).Hash.ToUpperInvariant()
    outputSha256 = (Get-FileHash -LiteralPath $outputFull -Algorithm SHA256).Hash.ToUpperInvariant()
    patched = @(
        'FindBestLocalMedusaEntity: removed soleMedusaEntity and lastLiveEntity fallbacks',
        'RepairLocalMedusaBinding: removed ownerless localPrimaryMissing/forceAllowed binding bypass',
        'Version/log markers updated'
    )
} | ConvertTo-Json -Depth 5
