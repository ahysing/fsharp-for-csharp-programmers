#Requires -Version 4.0
param (
    [switch]$Force = $false
)
Set-PSDebug -Trace 1

If ($Force)
{
    Remove-Item .\DependencyInjection.FSharp -Recurse
    Remove-Item .\DependencyInjection.CSharp -Recurse
    Remove-Item .\DependencyInjection.sln
}

dotnet new -h
dotnet new sln -n DependencyInjection
dotnet new console --language "F#" -o DependencyInjection.FSharp
dotnet sln DependencyInjection.sln add DependencyInjection.FSharp
dotnet new console --language "C#" -o DependencyInjection.CSharp
dotnet sln DependencyInjection.sln add DependencyInjection.CSharp
