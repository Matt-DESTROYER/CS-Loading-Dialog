using System;

namespace LoadingDialogs {
	public class LoadingDialog {
		public  string Message = "";  // the loading bar description
		public  int    Progress = 0;  // the current progress
		public  int    TotalProgress; // the number of steps to complete
		public  int    BarWidth;      // the width of the loading bar
		private int    cursorTop;     // the position of the loading bar

		public ConsoleColor CompleteColour = ConsoleColor.Green;  // the color of the completed part of the loading bar
		public ConsoleColor IncompleteColour = ConsoleColor.Gray; // the color of the incomplete part of the loading bar

		public LoadingDialog(string message = "Loading...", int totalProgress = 10, int barWidth = 20) {
			this.Message = message;
			this.TotalProgress = totalProgress;
			this.BarWidth = barWidth;
		}

		/*
		 * Set the progress of the loading bar.
		 */
		public LoadingDialog SetProgress(int progress) {
			this.Progress = progress;
			this.Update();

			return this;
		}

		/*
		 * Increment the progress of the loading
		 * bar by one step.
		 */
		public LoadingDialog IncrementProgress() {
			this.Progress++;
			this.Update();

			return this;
		}

		/*
		 * Write the initial message and create the loading bar.
		 */
		private void WriteInitialMessage() {
			// write the initial message
			Console.ResetColor();
			Console.WriteLine(this.Message);

			// store the cursor position
			cursorTop = Console.CursorTop;
			
			// create the loading bar
			Console.BackgroundColor = this.IncompleteColour;
			Console.Write(new string(' ', this.BarWidth));
			Console.ResetColor();
			Console.Write(" 0%\n");
		}

		/*
		 * Start the loading bar.
		 */
		public LoadingDialog Start() {
			// write the initial message
			this.WriteInitialMessage();

			return this;
		}

		/*
		 * Update the loading bar.
		 */
		public LoadingDialog Update() {
			// remember the current cursor position
			int savedCursorLeft = Console.CursorLeft;
			int savedCursorTop = Console.CursorTop;

			// move cursor to the position of the current percentage
			Console.ResetColor();
			Console.SetCursorPosition(0, this.cursorTop);

			// calculate the current progress
			float progressPercentage = (float)this.Progress / this.TotalProgress;
			int completedWidth = (int)Math.Floor(progressPercentage * this.BarWidth);
			int remainingWidth = this.BarWidth - completedWidth;

			// write the current progress
			Console.BackgroundColor = this.CompleteColour;
			Console.Write(new string(' ', completedWidth));

			// write the remaining progress
			Console.BackgroundColor = this.IncompleteColour;
			Console.Write(new string(' ', remainingWidth));

			// write the percentage completed
			Console.SetCursorPosition(this.BarWidth, Console.CursorTop);
			Console.ResetColor();
			Console.Write(" {0}%", Math.Round(progressPercentage * 100, 2));

			// restore the cursor position
			Console.SetCursorPosition(savedCursorLeft, savedCursorTop);

			return this;
		}
	}
}
