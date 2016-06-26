@echo off
setlocal
rem log-counter.bat
rem This is bat file to build this project.
rem .NET Framework requires 4.X or later.

rem change this path depending on your environment.
rem MSBuild.exe ====================
set MSBuild="C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe"

rem build
if not exist "dist/" (
  md dist
)

%MSBuild% /p:Configuration=Release /p:Platform="Any CPU" /p:DebugSymbols=false /p:DebugType="none" /t:Clean;Rebuild /p:OutputPath="..\dist" LogCounter.sln
pause
