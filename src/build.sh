#!/usr/bin/bash

# MUST BE RUN FROM ./src

# detect OS
if [[ $RUNNER_OS == "Windows" ]]; then
    PLATFORM="win"
elif [[ $RUNNER_OS == "Linux" ]]; then
    PLATFORM="linux"
fi
echo Platform detected: $RUNNER_OS

# detect architecture
ARCH=$(uname -m)
if [[ $ARCH == x86_64* ]]; then
	ARCH="x64"
elif [[ $ARCH == i*86 ]]; then
	ARCH="x86"
elif [[ $arch == arm* ]]; then
	ARCH="arm"
fi
echo Architecture detected: $ARCH

# build
rm -rf ../build/$RUNNER_OS-$ARCH

echo Building library...

dotnet publish LoadingDialogs.csproj --os $PLATFORM --arch $ARCH -c Release --output ../build/$RUNNER_OS-$ARCH/library

echo Building demo...

dotnet publish demo.csproj --os $PLATFORM --arch $ARCH -c Release --output ../build/$RUNNER_OS-$ARCH/demo

rm -rf bin
rm -rf obj

echo Build complete.
