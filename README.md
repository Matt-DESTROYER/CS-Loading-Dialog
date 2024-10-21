# C# Console Loading Dialog

## How do I use this?
Just download the `LoadingDialogs.cs` file and include the `LoadingDialog` namespace (`using LoadingDialog;`) where you want to use it.

## Documentation

### `LoadingDialog`
```cs
LoadingDialog myLoadingBar = LoadingDialog(string message = "Loading...", int totalProgress = 10, int barWidth = 20);
```
#### Parameters:
 - `Message`: The description of your loading bar (this will be displayed above the loading bar).
 - `TotalProgress`: How many tasks or items are being completed (this will be used to calculate a percentage based on current progress).
 - `BarWidth`: The width of the loading bar in characters.

#### Properties:
```cs
public string Message;
public int Progress = 0;
public int TotalProgress;
public int BarWidth;
public ConsoleColor CompleteColour = ConsoleColor.Green;
public ConsoleColor IncompleteColour = ConsoleColor.Gray;
```
 - `Message`: The description of your loading bar.
 - `Progress`: The current progress of the loading bar.
 - `TotalProgress`: How many tasks or items are being completed.
 - `BarWidth`: The width of the loading bar in characters.
 - `CompleteColor`: The colour of the complete section of the loading bar.
 - `IncompleteColor`: The colour of the incomplete section of the loading bar.

#### Methods:
```cs
public LoadingDialog SetProgress(int progress);
public LoadingDialog IncrementProgress();
public LoadingDialog Start();
public LoadingDialog Update();
```
 > All methods with return type `LoadingDialog` are chainable.

 - `SetProgress`: Set's the progress out of the `totalProgress` of the loading bar.
 - `IncrementProgress`: Increment the progress of the loading bar by one (useful for when an individual task completes).
 - `Start`: Initialises and displays the loading bar.
 - `Update`: Updates the loading bar based on changes (automatically called by `SetProgress` and `IncrementProgress`, you should call this if you are manually changing properties rather than calling these methods).

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

## Advanced usage

### Customising colours

You can customise the colours of the loading bar to match your application's theme:
```cs
loadingDlg.CompleteColour   = ConsoleColor.Blue;
loadingDlg.IncompleteColour = ConsoleColor.Red;
```

### Update progress from multiple threads

If you are performing tasks in parallel, you can safely update the progress from multiple threads:

```cs
using System.Threading.Tasks;

LoadingDialog loadingDlg = new LoadingDialog("Parallel tasks loading:", 100, 20);
loadingDlg.Start();

// Example with parallel tasks
Parallel.For(0, 100, i => {
	// Simulate work
	Thread.Sleep(100);
	lock (loadingDlg) {
		loadingDlg.IncrementProgress();
	}
});
```

### File download progress

You can use the loading dialog to show file download progress:

```cs
using System.Net.Http;

LoadingDialog downloadProgress = new LoadingDialog("Downloading file:", 100, 20);
downloadProgress.Start();

HttpClient client = new HttpClient();
HttpResponseMessage response = await client.GetAsync("http://example.com/file", HttpCompletionOption.ResponseHeadersRead);
var totalBytes = response.Content.Headers.ContentLength ?? 1L;

using (var stream = await response.Content.ReadAsStreamAsync())
using (var fileStream = new FileStream("file", FileMode.Create, FileAccess.Write, FileShare.None, 8192, true)) {
	var buffer = new byte[8192];
	long totalRead = 0L;
	int bytesRead;
	while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0) {
		await fileStream.WriteAsync(buffer, 0, bytesRead);
		totalRead += bytesRead;
		downloadProgress.SetProgress((int)(totalRead * 100 / totalBytes));
	}
}
```

## Building the demo yourself
 - The demo can be built with [`dotnet`](https://dotnet.microsoft.com/en-us/download).
 - Once installed, simply enter the `/src` directory and run the `build` or `publish` commands, specifying the `demo.csproj` file.
	 - Example 1 (Windows with 64-bit architecture in Release mode): `dotnet publish demo.csproj -r win-x64 -c Release --output ../build`
	 - Example 2 (Linux with 32-bit architecture in Debug mode): `dotnet publish demo.csproj -r linux-x86 -c Debug --output ../build`
	 - See more on command line arguments [here](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-publish#arguments).
 - Run the compiled executable.
