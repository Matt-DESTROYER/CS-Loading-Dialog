# C# Console Loading Dialog

## How do I use this?
Just download the `LoadingDialogs.cs` file and include the `LoadingDialog` namespace (`using LoadingDialog;`) where you want to use it.

## Documentation

### `LoadingDialog`
```cs
LoadingDialog myLoadingBar = LoadingDialog(string message = "Loading...", int totalProgress = 10, int barWidth = 20);
```
Parameters:
 - `message`: The description of your loading bar (this will be displayed above the loading bar).
 - `totalProgress`: How many tasks or items are being completed (this will be used to calculate a percentage based on current progress).
 - `barWidth`: The width of the loading bar in characters.

Properties:
```cs
public string message;
public int progress = 0;
public int totalProgress;
public int barWidth;
public ConsoleColor completeColour = ConsoleColor.Green;
public ConsoleColor incompleteColour = ConsoleColor.Gray;
```
 - `message`: The description of your loading bar.
 - `progress`: The current progress of the loading bar.
 - `totalProgress`: How many tasks or items are being completed.
 - `barWidth`: The width of the loading bar in characters.
 - `completeColor`: The colour of the complete section of the loading bar.
 - `incompleteColor`: The colour of the incomplete section of the loading bar.

## Demo
```cs
using System;
using System.Threading;
using LoadingDialogs;

class Program {
	public static void Main() {
		// create a loading dialog
		LoadingDialog loadingDlg = new LoadingDialog("Demo loading dialog:", 100, 20);
		// start it
		loadingDlg.Start();

		// every 200 milliseconds increment the progress
		for (int i = 0; i < 100; i++) {
			loadingDlg.IncrementProgress();
			Thread.Sleep(200);
		}

		// add a new line
		Console.WriteLine("");

		// create a new loading dialog
		loadingDlg = new LoadingDialog("Another loading dialog!", 100, 30);
		// start it
		loadingDlg.Start();

		// every 100 milliseconds set the progress to the current progress
		for (int i = 1; i <= 100; i += 3) {
			loadingDlg.SetProgress(i);
			Thread.Sleep(100);
		}
		loadingDlg.SetProgress(100);

		// add a new line
		Console.WriteLine("");

		// pause exit (if exe is not run from command line)
		Console.WriteLine("Press any key to exit...");
		Console.ReadKey(true);
	}
}
```

## Compatibility
 - `LoadingDialog` is compatibile with C# 5+.

## Building the demo yourself
 - The demo can be built with `csc` (which comes with the .NET Framework and Visual Studio).
 - You can find `csc` in `C:\Windows\Microsoft.NET\Framework\<version>`, either add this to your `PATH` environment variable or call `csc` using the full path.
 - Just set the target to `exe` and include the C# files: `csc /t:exe main.cs LoadingDialogs.cs`
 - Run the compiled executable.
