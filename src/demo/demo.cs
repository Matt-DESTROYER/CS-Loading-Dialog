using System;
using System.Threading;
using LoadingDialogs;

class Program {
	public static void Main() {
		// create a loading dialog
		LoadingDialog loadingDlg1 = new LoadingDialog("Demo loading dialog:", 100, 20);
		// start it
		loadingDlg1.Start();

		// every 200 milliseconds increment the progress
		for (int i = 0; i < 100; i++) {
			loadingDlg1.IncrementProgress();
			Thread.Sleep(200);
		}

		// add a new line
		Console.WriteLine("");

		// create a new loading dialog
		LoadingDialog loadingDlg2 = new LoadingDialog("Another loading dialog!", 100, 30);
		// start it
		loadingDlg2.Start();

		// every 100 milliseconds set the progress to the current progress
		for (int i = 1; i <= 100; i += 3) {
			loadingDlg2.SetProgress(i);
			Thread.Sleep(100);
		}
		loadingDlg2.SetProgress(100);

		// add a new line
		Console.WriteLine("");

		// pause exit (if exe is not run from command line)
		Console.WriteLine("Press any key to exit...");
		Console.ReadKey(true);
	}
}
