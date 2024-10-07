

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
	ARCH="x32"
elif [[ $arch == arm* ]]; then
	ARCH="arm"
fi

dotnet publish -r $PLATFORM-$ARCH
