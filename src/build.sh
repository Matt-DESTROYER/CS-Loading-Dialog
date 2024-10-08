#!/bin/bash

# MUST BE RUN FROM ./src

OS_NAMES=("Windows" "Linux" "Mac OS")
BUILD_PLATFORMS=("win" "linux" "osx")
BUILD_ARCHS=("x86" "x64" "arm" "arm64")

# build
rm -rf ../build

for i in "${!BUILD_PLATFORMS[@]}"; do
	RUNNER_OS=${OS_NAMES[$i]}
	PLATFORM=${BUILD_PLATFORMS[$i]}

	for j in "${!BUILD_ARCHS[@]}"; do
		ARCH=${BUILD_ARCHS[$j]}
	
		echo Building for $RUNNER_OS $ARCH...

		echo Building library...
		dotnet publish LoadingDialogs.csproj --os $PLATFORM --arch $ARCH -c Release --output ../build/$RUNNER_OS/$ARCH/library

		echo Building demo...
		dotnet publish demo.csproj --os $PLATFORM --arch $ARCH -c Release --output ../build/$RUNNER_OS/$ARCH/demo

		rm -rf bin
		rm -rf obj
	done
done

echo Build complete
