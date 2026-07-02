$env:ASPNETCORE_URLS = "http://127.0.0.1:5198"
$env:CustomServer__PublicBaseUrl = "http://127.0.0.1:5198"
$env:CustomServer__LaunchGameServers = "true"
$env:CustomServer__RequireGameServerBootstrap = "true"
$env:CustomServer__GameServerReadyTimeoutSeconds = "150"
$env:CustomServer__GameExecutablePath = "C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild\bapbap.exe"
$env:CustomServer__GameWorkingDirectory = "C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild"
$env:CustomServer__GameLogDirectory = "C:\Users\Administrator\Downloads\CustomServer\CustomMatchServer\logs\game-servers"
$env:CustomServer__AdditionalGameArguments = "--melonloader.agfoffline --melonloader.captureplayerlogs"
Set-Location C:\Users\Administrator\Downloads\CustomServer
dotnet CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll *> tools\logs\manual-srv.log
