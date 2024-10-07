#!/usr/bin/env bash

# MUST BE RUN FROM ./src

# detect platform and architecture
if [[ $RUNNER_OS == "Windows" ]]; then
    PLATFORM="win"
elif [[ $RUNNER_OS == "Linux" ]]; then
    PLATFORM="linux"
fi

ARCH=$(uname -m)
if [[ $ARCH == x86_64* ]]; then
	ARCH="x64"
elif [[ $ARCH == i*86 ]]; then
	ARCH="x86"
elif [[ $arch == arm* ]]; then
	ARCH="arm"
fi

# ensure the build directory exists
if [ ! -d "../build" ]; then
    mkdir ../build
fi

dotnet publish ~/LoadingDialogs.csproj --os $PLATFORM --arch $ARCH -c Release --disable-build-servers --output ../build
