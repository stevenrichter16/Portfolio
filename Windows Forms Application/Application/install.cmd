@echo off
PUSHD %~dp0

Powershell.exe -ExecutionPolicy Bypass -File ".\install.ps1"

POPD