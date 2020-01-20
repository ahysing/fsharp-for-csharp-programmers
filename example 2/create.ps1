#Requires -Version 4.0
param (
    [switch]$Force = $false
)
Set-PSDebug -Trace 1

If ($Force)
{
    Remove-Item .\MainFeatures -Recurse
    Remove-Item .\MainFeatures.sln
}

dotnet new -h
dotnet new sln -n MainFeatures
dotnet new console --language "F#" -o MainFeatures
dotnet sln MainFeatures.sln add MainFeatures
