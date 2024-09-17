using System;
using System.Threading;
using LoadingDialogs;

class Program
{
    public static void Main()
    {
        Console.Clear();
        LoadingDialog loadingDlg = new LoadingDialog("Demo loading dialog:");
        loadingDlg.Create();
        for (int i = 1; i <= 100; i++)
        {
            loadingDlg.SetPercentage(i);
            loadingDlg.Update();
            Thread.Sleep(200);
        }
        Console.WriteLine("");
        loadingDlg = new LoadingDialog("Another loading dialog!");
        loadingDlg.Create();
        for (int i = 1; i <= 100; i++)
        {
            loadingDlg.SetPercentage(i);
            loadingDlg.Update();
            Thread.Sleep(50);
        }
    }
}