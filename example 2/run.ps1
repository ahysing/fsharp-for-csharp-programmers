#Requires -Version 4.0
Set-PSDebug -Trace 1
If (-Not (Test-Path .\MainFeatures\MainFeatures.fsproj))
{
    Write-Host "Recreating MainFeatures project..."
    .\create.ps1
}

dotnet run --project MainFeatures\MainFeatures.fsproj
