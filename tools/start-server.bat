@echo off
set ASPNETCORE_URLS=http://127.0.0.1:5198
set CustomServer__PublicBaseUrl=http://127.0.0.1:5198
set CustomServer__LaunchGameServers=true
set CustomServer__RequireGameServerBootstrap=true
set CustomServer__GameServerReadyTimeoutSeconds=120
set CustomServer__GameExecutablePath=C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild\bapbap.exe
set CustomServer__GameWorkingDirectory=C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild
set CustomServer__GameLogDirectory=C:\Users\Administrator\Downloads\CustomServer\CustomMatchServer\logs\game-servers
set CustomServer__AdditionalGameArguments=--melonloader.agfoffline --melonloader.captureplayerlogs
cd /d C:\Users\Administrator\Downloads\CustomServer
dotnet CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll > tools\logs\manual-srv.log 2>&1
