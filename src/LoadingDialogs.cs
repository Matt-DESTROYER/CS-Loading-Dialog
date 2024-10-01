using System;

namespace LoadingDialogs {
	public class LoadingDialog {
		public string message;    // the loading bar description
		public int progress = 0;  // the current progress
		public int totalProgress; // the number of steps to complete
		public int barWidth;      // the width of the loading bar
		private int cursorTop;    // the position of the loading bar

		public ConsoleColor completeColour = ConsoleColor.Green;  // the color of the completed part of the loading bar
		public ConsoleColor incompleteColour = ConsoleColor.Gray; // the color of the incomplete part of the loading bar

		public LoadingDialog(string message = "Loading...", int totalProgress = 10, int barWidth = 20) {
			this.message = message;
			this.totalProgress = totalProgress;
			this.barWidth = barWidth;
		}

		/*
		 * Set the progress of the loading bar.
		 */
		public void SetProgress(int progress) {
			this.progress = progress;
			this.Update();
		}

		/*
		 * Increment the progress of the loading
		 * bar by one step.
		 */
		public void IncrementProgress() {
			this.progress++;
			this.Update();
		}

		/*
		 * Start the loading bar.
		 */
		public void Start() {
			// write the initial message
			Console.ResetColor();
			Console.WriteLine(this.message);

			// store the cursor position
			cursorTop = Console.CursorTop;
			
			// create the loading bar
			Console.BackgroundColor = this.incompleteColour;
			Console.Write(new string(' ', this.barWidth));
			Console.ResetColor();
			Console.Write(" 0%\n");
		}

		/*
		 * Update the loading bar.
		 */
		public void Update() {
			// remember the current cursor position
			int currentCursorLeft = Console.CursorLeft;
			int currentCursorTop = Console.CursorTop;

			// move cursor to the position of the current percentage
			Console.ResetColor();
			Console.SetCursorPosition(0, this.cursorTop);

			// calculate the current progress
			float currentProgress = (float)this.progress / this.totalProgress;
			
			// write the current progress
			Console.BackgroundColor = this.completeColour;
			Console.Write(new string(' ', (int)Math.Floor(currentProgress * barWidth)));

			// write the percentage completed
			Console.SetCursorPosition(this.barWidth, Console.CursorTop);
			Console.ResetColor();
			Console.Write(" {0}%", Math.Round(currentProgress * 100, 2));

			// restore the cursor position
			Console.SetCursorPosition(currentCursorLeft, currentCursorTop);
		}
	}
}
