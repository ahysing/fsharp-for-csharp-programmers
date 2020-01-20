#Requires -Version 4.0
Set-PSDebug -Trace 1
If (-Not (Test-Path .\HelloWorld\HelloWorld.fsproj))
{
    Write-Host "Recreating HelloWorld project..."
    .\create.ps1
}

dotnet run --project HelloWorld\HelloWorld.fsproj