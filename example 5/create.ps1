#Requires -Version 4.0
param (
    [switch]$Force = $false
)
Set-PSDebug -Trace 1

If ($Force)
{
    Remove-Item .\PartialApplication -Recurse
    Remove-Item .\PartialApplication.sln
}

dotnet new -h
dotnet new sln -n PartialApplication
dotnet new console --language "F#" -o PartialApplication
dotnet sln PartialApplication.sln add PartialApplication
