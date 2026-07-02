param(
  [string]$AmpBaseUrl = "https://ark.atomi23.de",
  [string]$Username   = "Sonic0810",
  [string]$InstanceId = "a8556e48-c8be-4f34-b7a1-517607f96b3b",
  [string]$SessionOut = (Join-Path $env:TEMP "amp_session.txt")
)
$ErrorActionPreference = "Stop"
$edge = Join-Path $env:LOCALAPPDATA "Microsoft\Edge\User Data"

# --- 1) AES key from Local State (DPAPI, CurrentUser) ---
Add-Type -AssemblyName System.Security
$ls = Get-Content (Join-Path $edge "Local State") -Raw | ConvertFrom-Json
$encKey = [Convert]::FromBase64String($ls.os_crypt.encrypted_key)
$dpapi  = [byte[]]($encKey[5..($encKey.Length-1)])   # strip "DPAPI" prefix
$aesKey = [System.Security.Cryptography.ProtectedData]::Unprotect($dpapi, $null, [System.Security.Cryptography.DataProtectionScope]::CurrentUser)

# --- 2) Read the saved password blob for the AMP host via winsqlite3 ---
$dbCopy = Join-Path $env:TEMP "ld_amp.db"
Copy-Item (Join-Path $edge "Default\Login Data") $dbCopy -Force
Add-Type -TypeDefinition @"
using System;using System.Runtime.InteropServices;
public static class WS {
 [DllImport("winsqlite3.dll",EntryPoint="sqlite3_open16",CharSet=CharSet.Unicode)] public static extern int Open(string f,out IntPtr db);
 [DllImport("winsqlite3.dll",EntryPoint="sqlite3_prepare16_v2",CharSet=CharSet.Unicode)] public static extern int Prep(IntPtr db,string sql,int n,out IntPtr st,IntPtr tail);
 [DllImport("winsqlite3.dll",EntryPoint="sqlite3_step")] public static extern int Step(IntPtr st);
 [DllImport("winsqlite3.dll",EntryPoint="sqlite3_column_blob")] public static extern IntPtr Blob(IntPtr st,int c);
 [DllImport("winsqlite3.dll",EntryPoint="sqlite3_column_bytes")] public static extern int Bytes(IntPtr st,int c);
 [DllImport("winsqlite3.dll",EntryPoint="sqlite3_column_text16",CharSet=CharSet.Unicode)] public static extern IntPtr Text(IntPtr st,int c);
 [DllImport("winsqlite3.dll",EntryPoint="sqlite3_finalize")] public static extern int Fin(IntPtr st);
 [DllImport("winsqlite3.dll",EntryPoint="sqlite3_close")] public static extern int Close(IntPtr db);
}
"@
$db=[IntPtr]::Zero; $st=[IntPtr]::Zero
[void][WS]::Open($dbCopy,[ref]$db)
[void][WS]::Prep($db,"SELECT username_value,password_value FROM logins WHERE origin_url LIKE '%atomi23%' OR action_url LIKE '%atomi23%'",-1,[ref]$st,[IntPtr]::Zero)
$blob=$null; $matchUser=$null; $firstBlob=$null; $firstUser=$null
while([WS]::Step($st) -eq 100){
  $u=[Runtime.InteropServices.Marshal]::PtrToStringUni([WS]::Text($st,0))
  $bp=[WS]::Blob($st,1); $bl=[WS]::Bytes($st,1)
  if($bl -gt 0){
    $b=New-Object byte[] $bl; [Runtime.InteropServices.Marshal]::Copy($bp,$b,0,$bl)
    if(-not $firstBlob){ $firstBlob=$b; $firstUser=$u }
    if($u -eq $Username -and -not $blob){ $blob=$b; $matchUser=$u }
  }
}
[void][WS]::Fin($st); [void][WS]::Close($db)
if(-not $blob){ $blob=$firstBlob; $matchUser=$firstUser }
if(-not $blob){ Write-Output "NO_SAVED_PASSWORD"; return }
Remove-Item $dbCopy -Force -ErrorAction SilentlyContinue

# --- 3) AES-256-GCM decrypt (Chromium v10) via BCrypt/CNG ---
Add-Type -TypeDefinition @"
using System;using System.Runtime.InteropServices;
public static class Gcm {
 [DllImport("bcrypt.dll",CharSet=CharSet.Unicode)] static extern int BCryptOpenAlgorithmProvider(out IntPtr h,string alg,string impl,int flags);
 [DllImport("bcrypt.dll",CharSet=CharSet.Unicode)] static extern int BCryptSetProperty(IntPtr h,string prop,byte[] val,int cb,int flags);
 [DllImport("bcrypt.dll")] static extern int BCryptGenerateSymmetricKey(IntPtr hAlg,out IntPtr hKey,IntPtr keyObj,int cbKeyObj,byte[] secret,int cbSecret,int flags);
 [DllImport("bcrypt.dll")] static extern int BCryptDecrypt(IntPtr hKey,byte[] inp,int cbIn,ref INFO pInfo,byte[] iv,int cbIv,byte[] outp,int cbOut,out int res,int flags);
 [DllImport("bcrypt.dll")] static extern int BCryptDestroyKey(IntPtr h);
 [DllImport("bcrypt.dll")] static extern int BCryptCloseAlgorithmProvider(IntPtr h,int flags);
 [StructLayout(LayoutKind.Sequential)] struct INFO {
  public int cbSize; public int dwInfoVersion;
  public IntPtr pbNonce; public int cbNonce; public IntPtr pbAuthData; public int cbAuthData;
  public IntPtr pbTag; public int cbTag; public IntPtr pbMacContext; public int cbMacContext;
  public int cbAAD; public long cbData; public int dwFlags;
 }
 public static byte[] Decrypt(byte[] key,byte[] nonce,byte[] ct,byte[] tag){
  IntPtr hAlg,hKey;
  if(BCryptOpenAlgorithmProvider(out hAlg,"AES",null,0)!=0) throw new Exception("open");
  byte[] mode=System.Text.Encoding.Unicode.GetBytes("ChainingModeGCM\0");
  if(BCryptSetProperty(hAlg,"ChainingMode",mode,mode.Length,0)!=0) throw new Exception("setmode");
  if(BCryptGenerateSymmetricKey(hAlg,out hKey,IntPtr.Zero,0,key,key.Length,0)!=0) throw new Exception("genkey");
  INFO info=new INFO();
  info.cbSize=Marshal.SizeOf(typeof(INFO)); info.dwInfoVersion=1;
  GCHandle gn=GCHandle.Alloc(nonce,GCHandleType.Pinned); GCHandle gt=GCHandle.Alloc(tag,GCHandleType.Pinned);
  info.pbNonce=gn.AddrOfPinnedObject(); info.cbNonce=nonce.Length;
  info.pbTag=gt.AddrOfPinnedObject(); info.cbTag=tag.Length;
  byte[] outp=new byte[ct.Length]; int res;
  int s=BCryptDecrypt(hKey,ct,ct.Length,ref info,null,0,outp,outp.Length,out res,0);
  gn.Free(); gt.Free(); BCryptDestroyKey(hKey); BCryptCloseAlgorithmProvider(hAlg,0);
  if(s!=0) throw new Exception("decrypt 0x"+s.ToString("X8"));
  if(res!=outp.Length){ byte[] r=new byte[res]; Array.Copy(outp,r,res); return r; }
  return outp;
 }
}
"@
$nonce=[byte[]]($blob[3..14])
$tag=[byte[]]($blob[($blob.Length-16)..($blob.Length-1)])
$ct=[byte[]]($blob[15..($blob.Length-17)])
$ptBytes=[Gcm]::Decrypt($aesKey,$nonce,$ct,$tag)
$password=[Text.Encoding]::UTF8.GetString($ptBytes)

# --- 4) Core/Login ---
Add-Type -AssemblyName System.Net.Http
$client=[System.Net.Http.HttpClient]::new(); $client.Timeout=[TimeSpan]::FromMinutes(2)
function Api($path,$bodyHash,$sid){
  $json=($bodyHash + @{SESSIONID=$sid}) | ConvertTo-Json -Compress
  $req=[System.Net.Http.HttpRequestMessage]::new([System.Net.Http.HttpMethod]::Post,"$AmpBaseUrl$path")
  [void]$req.Headers.Accept.ParseAdd("application/json")
  if($sid){ $req.Headers.Authorization=[System.Net.Http.Headers.AuthenticationHeaderValue]::new("Bearer",$sid) }
  $req.Content=[System.Net.Http.StringContent]::new($json,[Text.Encoding]::UTF8,"application/json")
  $resp=$client.SendAsync($req).GetAwaiter().GetResult()
  return ($resp.Content.ReadAsStringAsync().GetAwaiter().GetResult() | ConvertFrom-Json)
}
$login=Api "/API/Core/Login" @{username=$Username;password=$password;token="";rememberMe=$true} ""
$password=$null; $ptBytes=$null; $aesKey=$null
if(-not $login.success -or [string]::IsNullOrWhiteSpace($login.sessionID)){ Write-Output ("LOGIN_FAILED user=$matchUser result=" + ($login.resultReason)); return }
$sid=[string]$login.sessionID

# --- 5) Validate (no secrets printed) ---
$status=Api "/API/Core/GetStatus" @{} $sid
$inst=Api "/API/ADSModule/GetInstance" @{InstanceId=$InstanceId} $sid
Set-Content -Path $SessionOut -Value $sid -Encoding ASCII -NoNewline
Write-Output ("SESSION_OK adsState=" + $status.State + " instanceRunning=" + $inst.Running + " appState=" + $inst.AppState + " savedTo=" + $SessionOut)