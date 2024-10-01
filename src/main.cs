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
