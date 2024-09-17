using System;

// v1.0
/*
 * To use:
 *  - Download LoadingDialogs.cs
 *  - Add the downloaded file to
 *    the directory of your C#
 *    Console App.
 *  - Simply add using LoadingDialogs;
 *    at the top of your C# file
 *    and you're ready to start
 *    loading!
 * Note:
 *  - Once a loading dialog's
 *    percentage is set to 100
 *    (or above) it is no longer
 *    usable.
 */
namespace LoadingDialogs
{
    public class LoadingDialog
    {
        string message;
        int percentage = 0;

        public LoadingDialog(string message)
        {
            this.message = message;
        }

        public void SetPercentage(int percent)
        {
            this.percentage = percent;
        }

        public void Create()
        {
            Console.ResetColor();
            Console.WriteLine(this.message);
            this.Update();
        }

        public void Update()
        {
            Console.ResetColor();
            Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
            for (int i = 1; i < 20; i++)
            {
                if (i <= Math.Floor((decimal)percentage / 5))
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                Console.Write(" ");
            }
            Console.ResetColor();
            Console.Write(" " + this.percentage + "%");
            if (this.percentage == 100)
            {
                Console.Write("\n");
            }
        }
    }
}