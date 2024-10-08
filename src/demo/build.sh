#!/bin/bash

# MUST BE RUN FROM ./src/demo

# detect OS
if [[ $RUNNER_OS == "Windows" ]]; then
    PLATFORM="win"
elif [[ $RUNNER_OS == "Linux" ]]; then
    PLATFORM="linux"
elif [[ $RUNNER_OS == "MacOS" ]]; then
	PLATFORM="osx"
else
	echo Environment variable RUNNER_OS not specified...
	if [[ $OSTYPE == "linux" ]]; then 
		RUNNER_OS="Linux"
		PLATFORM="linux"
	elif [[ $OSTYPE == "msys" || $OSTYPE == "cygwin" ]]; then
		RUNNER_OS="Windows"
		PLATFORM="win"
	else
		echo Failed to autodetect platform... >&2
		exit 1
	fi
fi
echo Platform detected: $RUNNER_OS

# detect architecture
if [[ -z "${ARCH}" ]]; then
	ARCH=$(uname -m)
	if [[ $ARCH == x86_64* ]]; then
		ARCH="x64"
	elif [[ $ARCH == i*86 ]]; then
		ARCH="x86"
	elif [[ $arch == arm* ]]; then
		ARCH="arm"
	fi
fi
echo Architecture detected: $ARCH

# build
rm -rf ../../build/$RUNNER_OS/$ARCH/demo

dotnet publish demo.csproj --os $PLATFORM --arch $ARCH -c Release --output ../../build/$RUNNER_OS/$ARCH/demo
