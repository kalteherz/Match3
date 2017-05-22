/*
 * Author: Bolotin S.E.
 */

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Match3
{
	public class Game
	{
		private Field field;
		private Control screen;
		private int scores;
		private long length;
		private Stopwatch frameTime = new Stopwatch();
		private Stopwatch gameTime = new Stopwatch();
		private Point[] changedCells = new Point[2];
		
		public long TimeLeft {
			get {
				return length - gameTime.ElapsedMilliseconds / 1000;
			}
		}
		
		public int Scores {
			get {
				return scores;
			}
		}
		
		public bool Run {
			get; set;
		}
		
		public Game(Size fieldSize, Control screen)
		{
			field = new Field(screen.Size, fieldSize.Width, fieldSize.Height);
			this.screen = screen;
		}
		
		public void Start(int gameLength) {
			Run = true;
			scores = 0;
			length = gameLength;
			frameTime.Restart();
			gameTime.Restart();
		}
		
		public void Stop() {
			Run = false;
			field.CellsMatched = true;
			screen.Refresh();
			field.CellsMatched = false;
			gameTime.Stop();
			frameTime.Stop();
		}
		
		public void GameTick() {
			if (!Run)
				return;
			field.FrameTime = frameTime.ElapsedMilliseconds;
			frameTime.Restart();
			field.CalcPositions();
			screen.Refresh();
			
			if (!field.Animation && field.CellsChanged) {
				scores += field.FindRemoveMatch();
				if (!field.CellsMatched) {
					field.SwapCells(changedCells[0], changedCells[1]);
				}
				field.CellsChanged = false;
			}
			
			if (!field.Animation && field.CellsMatched) {
				scores += field.FindRemoveMatch();
			}
			
			if (gameTime.ElapsedMilliseconds / 1000 >= length) {
				Stop();
			}
		}

		public void UpdateScreen(Graphics canvas) {
			field.DrawField(canvas);
		}

		public void MouseMove(MouseEventArgs e)
		{
			if (!Run)
				return;
			field.MousePosition = new Point(e.X, e.Y);
		}
		
		public void MouseLeave(EventArgs e)
		{
			if (!Run)
				return;
			field.MousePosition = new Point(-1, -1);
		}
		
		public void MouseClick(EventArgs e)
		{
			if (field.Busy || !Run) 
				return;
			if (field.CellOnScreen(field.SelectedCell)) {
				if (field.CellOnScreen(field.MousePosition) &&
					(Math.Abs(field.MousePosition.X - field.SelectedCell.X) +
				     Math.Abs(field.MousePosition.Y - field.SelectedCell.Y) == 1))
				{
					changedCells[0] = field.SelectedCell;
					changedCells[1] = field.MousePosition;
					field.SwapCells(changedCells[0], changedCells[1]);
					field.CellsChanged = true;
				}
				field.SelectedCell = new Point(-1, -1);
			} else {
				field.SelectedCell = field.MousePosition;
			}
		}
	}
}
