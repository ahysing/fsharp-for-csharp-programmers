#Requires -Version 4.0
Set-PSDebug -Trace 1
dotnet new -h
dotnet new sln -n HelloWorld
dotnet new console --language "F#" -o HelloWorld
dotnet sln HelloWorld.sln add HelloWorld