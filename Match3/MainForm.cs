/*
 * Author: Bolotin S.E.
 */
 
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Match3
{

	public partial class MainForm : Form
	{
		private Game game;

		public MainForm()
		{
			AutoScaleMode = AutoScaleMode.Dpi;
			InitializeComponent();
			playButton.Left = (ClientSize.Width - playButton.Width) / 2;
			playButton.Top = (ClientSize.Height - playButton.Height) / 2;
		}
		
		private bool ScreenVisible {
			set {
				playButton.Visible = !value;
				statusBar.Visible = value;
				screen.Visible = value;
			}
		}
		
		private void ScreenPaint(object sender, PaintEventArgs e) {
			if (game != null)
				game.UpdateScreen(e.Graphics);
		}
		
		private void ScreenMouseMove(object sender, MouseEventArgs e)
		{
			if (game != null)
				game.MouseMove(e);
		}
		
		private void ScreenMouseLeave(object sender, EventArgs e)
		{
			if (game != null)
				game.MouseLeave(e);
		}
		
		private void ScreenMouseClick(object sender, EventArgs e)
		{
			if (game != null)
				game.MouseClick(e);
		}

		public void GameTimerTick(object sender, EventArgs e) {
			if (game != null) {
				game.GameTick();
				scores.Text = game.Scores.ToString("D3");
				timeLeft.Text = game.TimeLeft.ToString("D2");
				if (!game.Run) {
					gameTimer.Enabled = false;
					MessageBox.Show("Game Over", "", MessageBoxButtons.OK, MessageBoxIcon.None);
					ScreenVisible = false;
					game = null;
				}
			}
		}
		
		private void PlayButtonClick(object sender, EventArgs e)
		{
			game = new Game(new Size(8, 8), screen);
			ScreenVisible = true;
			game.Start(60);
			gameTimer.Enabled = true;
		}
	}
}
