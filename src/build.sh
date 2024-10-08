#!/usr/bin/bash

# MUST BE RUN FROM ./src

# detect platform and architecture
if [[ $RUNNER_OS == "Windows" ]]; then
    PLATFORM="win"
elif [[ $RUNNER_OS == "Linux" ]]; then
    PLATFORM="linux"
fi
echo Platform detected: $RUNNER_OS

ARCH=$(uname -m)
if [[ $ARCH == x86_64* ]]; then
	ARCH="x64"
elif [[ $ARCH == i*86 ]]; then
	ARCH="x86"
elif [[ $arch == arm* ]]; then
	ARCH="arm"
fi
echo Architecture detected: $ARCH

echo Building...
dotnet publish --os $PLATFORM --arch $ARCH -c Release --disable-build-servers --output ../build/$RUNNER_OS-$ARCH
rm -rf bin
rm -rf obj
echo Build complete.
