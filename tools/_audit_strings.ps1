param([string]$Path)
$bytes = [System.IO.File]::ReadAllBytes($Path)
$ascii = [System.Text.Encoding]::ASCII.GetString($bytes)
$utf16 = [System.Text.Encoding]::Unicode.GetString($bytes)
$keywords = @(
  'Custom Server Setup',
  'SetupBody',
  'SetupTitle',
  'SetupContinue',
  'CustomServerIdentitySetup',
  'identitySetupRequired',
  'identity setup required',
  'first-start',
  'A local Account ID is generated',
  'Choose your player name',
  'Created first-start',
  'Player name',
  'CompleteIdentitySetupFromGui',
  'UpdateIdentitySetupRequirement',
  'HasCompleteLocalIdentity',
  'Waiting for player setup',
  'PrimeCustomServerLoginPrefs',
  'GenerateLocalAccountId',
  'CharacterIsUnlockedPrefix',
  'CharacterIsUnlocked',
  '/api/chars/listing',
  '/api/load',
  'AutoGuestLogin',
  'splashGuestLogin',
  'SplashGuestLogin',
  'ClearCustomServerLoginPrefs'
)
foreach ($k in $keywords) {
  $a1 = $ascii.IndexOf($k)
  $u1 = $utf16.IndexOf($k)
  Write-Output ("  " + $k + " | ascii_at=" + $a1 + " utf16_at=" + $u1)
}
Write-Output ("File size: " + $bytes.Length)
