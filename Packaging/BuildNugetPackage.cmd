@echo off

msbuild ..\GoogleMapsAPI.NET.Core\GoogleMapsAPI.NET.csproj /t:Build /p:Configuration="Release"
nuget pack GoogleMapsAPI.NET.nuspec -OutputDirectory .\Release
