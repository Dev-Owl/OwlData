#!/usr/bin/env bash
#exit if any command fails
set -e
cd "$(dirname "$0")"
#clean up what was left over
cd OwlDataModel
artifactsFolder="./nuget"
if [ -d $artifactsFolder ]; then  
  rm -R $artifactsFolder
fi
#restore and build lib
dotnet restore
dotnet build
#go to test dir
cd ../OwlDataModelTests
#restore,build and run tests
dotnet restore
dotnet build
dotnet test
#back to root
cd ..
#create a nuget to test release building as last step
dotnet pack ./OwlDataModel/OwlDataModel.csproj  -c Release -o ./nuget
