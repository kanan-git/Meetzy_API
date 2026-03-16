#!/bin/bash
dotnet restore
dotnet build
dotnet public WebAPI/WebAPI.csproj -c Release -o out
dptmet out/WebAPI.dll
