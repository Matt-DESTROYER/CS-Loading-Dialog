@echo off

REM build the dll
echo Building dll...
csc /t:library /out:../build/LoadingDialogs.dll LoadingDialogs.cs > nul
echo Built dll.

REM build the demo
echo Building demo...
csc /t:exe /out:../build/demo.exe main.cs LoadingDialogs.cs > nul
echo Built demo.
