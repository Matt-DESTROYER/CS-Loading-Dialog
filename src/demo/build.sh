#!/bin/bash

# MUST BE RUN FROM ./src/demo

# detect OS
if [[ $RUNNER_OS == "Windows" ]]; then
    PLATFORM="win"
elif [[ $RUNNER_OS == "Linux" ]]; then
    PLATFORM="linux"
elif [[ $RUNNER_OS == "macOS" ]]; then
	PLATFORM="osx"
else
	echo Environment variable RUNNER_OS not specified...
	if [[ $OSTYPE == "linux" ]]; then 
		RUNNER_OS="Linux"
		PLATFORM="linux"
	elif [[ $OSTYPE == "msys" || $OSTYPE == "cygwin" ]]; then
		RUNNER_OS="Windows"
		PLATFORM="win"
	elif [[ $OSTYPE == "darwin" ]]; then
		RUNNER_OS="macOS"
		PLATFORM="osx"
	else
		echo Failed to autodetect platform... >&2
		exit 1
	fi
fi
echo Platform detected: $RUNNER_OS

# detect architecture
if [[ -z $ARCH ]]; then
	ARCH=$(uname -m)
	if [[ $ARCH == "x64" || $ARCH == "x86_64" || $ARCH == "amd64" ]]; then
		ARCH="x64"
	elif [[ $ARCH == "x32" || $ARCH == "i686" || $ARCH == "amd" ]]; then
		ARCH="x86"
	elif [[ $ARCH == "arm" ]]; then
		ARCH="arm"
  	elif [[ $ARCH == "arm64" ]]; then
   		ARCH="arm64"
	fi
fi
echo Architecture detected: $ARCH

# build
rm -rf ../../build/$RUNNER_OS/$ARCH/demo

cp ../LoadingDialogs.cs ./

dotnet publish demo.csproj --os $PLATFORM --arch $ARCH -c Release --output ../../build/$RUNNER_OS/$ARCH/demo

rm ./LoadingDialogs.cs
rm -rf ./bin
rm -rf ./obj
