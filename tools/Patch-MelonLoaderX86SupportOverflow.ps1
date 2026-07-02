param(
    [string]$MelonLoaderDll = (Join-Path $PSScriptRoot "..\Spiel\Battleroyalebuild\MelonLoader\net6\MelonLoader.dll"),
    [switch]$Force
)

$ErrorActionPreference = "Stop"

$MelonLoaderDll = [System.IO.Path]::GetFullPath($MelonLoaderDll)
if (-not (Test-Path -LiteralPath $MelonLoaderDll)) {
    throw "MelonLoader.dll not found: $MelonLoaderDll"
}

$melonDir = Split-Path -Parent $MelonLoaderDll
$cecilPath = Join-Path $melonDir "Mono.Cecil.dll"
if (-not (Test-Path -LiteralPath $cecilPath)) {
    throw "Mono.Cecil.dll not found next to MelonLoader.dll: $cecilPath"
}

Add-Type -Path $cecilPath

$resolver = [Mono.Cecil.DefaultAssemblyResolver]::new()
$resolver.AddSearchDirectory($melonDir)
foreach ($sharedRoot in @(
    "C:\Program Files\dotnet\shared\Microsoft.NETCore.App",
    "C:\Program Files (x86)\dotnet\shared\Microsoft.NETCore.App",
    "C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App",
    "C:\Program Files (x86)\dotnet\shared\Microsoft.WindowsDesktop.App"
)) {
    if (Test-Path -LiteralPath $sharedRoot) {
        Get-ChildItem -LiteralPath $sharedRoot -Directory | ForEach-Object {
            $resolver.AddSearchDirectory($_.FullName)
        }
    }
}

$readerParams = [Mono.Cecil.ReaderParameters]::new()
$readerParams.ReadWrite = $false
$readerParams.InMemory = $true
$readerParams.AssemblyResolver = $resolver
$assembly = [Mono.Cecil.AssemblyDefinition]::ReadAssembly($MelonLoaderDll, $readerParams)
$module = $assembly.MainModule

$fixType = $module.Types | Where-Object { $_.FullName -eq "MelonLoader.Fixes.Il2CppInterop.Il2CppInteropFixes" } | Select-Object -First 1
if ($null -eq $fixType) {
    throw "Could not find MelonLoader.Fixes.Il2CppInterop.Il2CppInteropFixes"
}

$iterator = $fixType.NestedTypes |
    Where-Object { $_.Name -like "<FindCallersOf>*" } |
    Select-Object -First 1
if ($null -eq $iterator) {
    throw "Could not find FindCallersOf iterator nested type"
}

$moveNext = $iterator.Methods | Where-Object { $_.Name -eq "MoveNext" } | Select-Object -First 1
if ($null -eq $moveNext) {
    throw "Could not find FindCallersOf.MoveNext"
}

$intPtrExplicitCall = $moveNext.Body.Instructions |
    Where-Object {
        $_.OpCode.Code -eq [Mono.Cecil.Cil.Code]::Call -and
        $_.Operand -is [Mono.Cecil.MethodReference] -and
        $_.Operand.DeclaringType.FullName -eq "System.IntPtr" -and
        $_.Operand.Name -eq "op_Explicit" -and
        $_.Operand.Parameters.Count -eq 1 -and
        $_.Operand.Parameters[0].ParameterType.FullName -eq "System.Int64"
    } |
    Select-Object -First 1
if ($null -eq $intPtrExplicitCall) {
    if (-not $Force) {
        throw "Could not find IntPtr(long) call in FindCallersOf.MoveNext. Use -Force only if the DLL is already patched."
    }
    $intPtrType = [Mono.Cecil.TypeReference]::new("System", "IntPtr", $module, $module.TypeSystem.CoreLibrary)
}
else {
    $intPtrType = $intPtrExplicitCall.Operand.DeclaringType
}

$helperName = "BapCustomServer_IntPtrFromUInt64Unchecked"
$helper = $fixType.Methods | Where-Object { $_.Name -eq $helperName } | Select-Object -First 1
if ($null -eq $helper) {
    $attrs = [Mono.Cecil.MethodAttributes](
        [int][Mono.Cecil.MethodAttributes]::Private -bor
        [int][Mono.Cecil.MethodAttributes]::Static -bor
        [int][Mono.Cecil.MethodAttributes]::HideBySig
    )
    $helper = [Mono.Cecil.MethodDefinition]::new($helperName, $attrs, $intPtrType)
    $helper.Parameters.Add([Mono.Cecil.ParameterDefinition]::new("value", [Mono.Cecil.ParameterAttributes]::None, $module.TypeSystem.UInt64))
    $fixType.Methods.Add($helper)

    $il = $helper.Body.GetILProcessor()
    $intPtrSize = [Mono.Cecil.MethodReference]::new("get_Size", $module.TypeSystem.Int32, $intPtrType)
    $intPtrSize.HasThis = $false
    $intCtor = [Mono.Cecil.MethodReference]::new(".ctor", $module.TypeSystem.Void, $intPtrType)
    $intCtor.HasThis = $true
    $intCtor.Parameters.Add([Mono.Cecil.ParameterDefinition]::new($module.TypeSystem.Int32))
    $longCtor = [Mono.Cecil.MethodReference]::new(".ctor", $module.TypeSystem.Void, $intPtrType)
    $longCtor.HasThis = $true
    $longCtor.Parameters.Add([Mono.Cecil.ParameterDefinition]::new($module.TypeSystem.Int64))

    $widePath = $il.Create([Mono.Cecil.Cil.OpCodes]::Ldarg_0)
    $il.Append($il.Create([Mono.Cecil.Cil.OpCodes]::Call, $intPtrSize))
    $il.Append($il.Create([Mono.Cecil.Cil.OpCodes]::Ldc_I4_4))
    $il.Append($il.Create([Mono.Cecil.Cil.OpCodes]::Bne_Un_S, $widePath))
    $il.Append($il.Create([Mono.Cecil.Cil.OpCodes]::Ldarg_0))
    $il.Append($il.Create([Mono.Cecil.Cil.OpCodes]::Conv_U4))
    $il.Append($il.Create([Mono.Cecil.Cil.OpCodes]::Newobj, $intCtor))
    $il.Append($il.Create([Mono.Cecil.Cil.OpCodes]::Ret))
    $il.Append($widePath)
    $il.Append($il.Create([Mono.Cecil.Cil.OpCodes]::Conv_I8))
    $il.Append($il.Create([Mono.Cecil.Cil.OpCodes]::Newobj, $longCtor))
    $il.Append($il.Create([Mono.Cecil.Cil.OpCodes]::Ret))
}

$patched = 0
foreach ($instruction in $moveNext.Body.Instructions) {
    if ($instruction.OpCode.Code -eq [Mono.Cecil.Cil.Code]::Call -and
        $instruction.Operand -is [Mono.Cecil.MethodReference] -and
        $instruction.Operand.DeclaringType.FullName -eq "System.IntPtr" -and
        $instruction.Operand.Name -eq "op_Explicit" -and
        $instruction.Operand.Parameters.Count -eq 1 -and
        $instruction.Operand.Parameters[0].ParameterType.FullName -eq "System.Int64") {
        $instruction.Operand = $helper
        $patched++
    }
}

if ($patched -eq 0 -and -not $Force) {
    throw "No IntPtr(long) calls were patched. Use -Force only if the DLL is already patched."
}

$backup = "$MelonLoaderDll.pre-x86support-20260504"
if (-not (Test-Path -LiteralPath $backup)) {
    Copy-Item -LiteralPath $MelonLoaderDll -Destination $backup
}

$temp = "$MelonLoaderDll.tmp"
Remove-Item -LiteralPath $temp -ErrorAction SilentlyContinue
$writerParams = [Mono.Cecil.WriterParameters]::new()
$assembly.Write($temp, $writerParams)
Move-Item -LiteralPath $temp -Destination $MelonLoaderDll -Force

[pscustomobject]@{
    MelonLoaderDll = $MelonLoaderDll
    Backup = $backup
    PatchedCalls = $patched
    Helper = $helperName
    SHA256 = (Get-FileHash -LiteralPath $MelonLoaderDll -Algorithm SHA256).Hash
} | ConvertTo-Json -Compress
