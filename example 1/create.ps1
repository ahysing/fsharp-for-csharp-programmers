#Requires -Version 4.0
param (
    [switch]$Force = $false
)
Set-PSDebug -Trace 1

If ($Force)
{
    Remove-Item .\HelloWorld -Recurse
    Remove-Item .\HelloWorld.sln
}

dotnet new -h
dotnet new sln -n HelloWorld
dotnet new console --language "F#" -o HelloWorld
dotnet sln HelloWorld.sln add HelloWorld