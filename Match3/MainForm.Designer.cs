/*
 * Created by SharpDevelop.
 * User: тест
 * Date: 18.05.2017
 * Time: 23:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Match3
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Timer gameTimer;
		private System.Windows.Forms.PictureBox screen;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.ToolStripStatusLabel timeLeftText;
		private System.Windows.Forms.ToolStripStatusLabel scoresText;
		private System.Windows.Forms.Button playButton;
		private System.Windows.Forms.ToolStripStatusLabel timeLeft;
		private System.Windows.Forms.ToolStripStatusLabel scores;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.gameTimer = new System.Windows.Forms.Timer(this.components);
			this.screen = new System.Windows.Forms.PictureBox();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.timeLeftText = new System.Windows.Forms.ToolStripStatusLabel();
			this.timeLeft = new System.Windows.Forms.ToolStripStatusLabel();
			this.scoresText = new System.Windows.Forms.ToolStripStatusLabel();
			this.scores = new System.Windows.Forms.ToolStripStatusLabel();
			this.playButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.screen)).BeginInit();
			this.statusBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// gameTimer
			// 
			this.gameTimer.Interval = 1;
			this.gameTimer.Tick += new System.EventHandler(this.GameTimerTick);
			// 
			// screen
			// 
			this.screen.Location = new System.Drawing.Point(12, 26);
			this.screen.Name = "screen";
			this.screen.Size = new System.Drawing.Size(320, 320);
			this.screen.TabIndex = 0;
			this.screen.TabStop = false;
			this.screen.Visible = false;
			this.screen.Click += new System.EventHandler(this.ScreenMouseClick);
			this.screen.Paint += new System.Windows.Forms.PaintEventHandler(this.ScreenPaint);
			this.screen.MouseLeave += new System.EventHandler(this.ScreenMouseLeave);
			this.screen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenMouseMove);
			// 
			// statusBar
			// 
			this.statusBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.timeLeftText,
			this.timeLeft,
			this.scoresText,
			this.scores});
			this.statusBar.Location = new System.Drawing.Point(0, 0);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(346, 24);
			this.statusBar.SizingGrip = false;
			this.statusBar.TabIndex = 5;
			this.statusBar.Text = "statusStrip1";
			this.statusBar.Visible = false;
			// 
			// timeLeftText
			// 
			this.timeLeftText.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.timeLeftText.Name = "timeLeftText";
			this.timeLeftText.Size = new System.Drawing.Size(88, 19);
			this.timeLeftText.Text = "Time left:";
			// 
			// timeLeft
			// 
			this.timeLeft.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.timeLeft.Name = "timeLeft";
			this.timeLeft.Size = new System.Drawing.Size(24, 19);
			this.timeLeft.Text = "60";
			// 
			// scoresText
			// 
			this.scoresText.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.scoresText.Name = "scoresText";
			this.scoresText.Size = new System.Drawing.Size(80, 19);
			this.scoresText.Text = "| Scores:";
			// 
			// scores
			// 
			this.scores.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.scores.Name = "scores";
			this.scores.Size = new System.Drawing.Size(16, 19);
			this.scores.Text = "0";
			// 
			// playButton
			// 
			this.playButton.Location = new System.Drawing.Point(136, 157);
			this.playButton.Name = "playButton";
			this.playButton.Size = new System.Drawing.Size(75, 32);
			this.playButton.TabIndex = 6;
			this.playButton.Text = "Play";
			this.playButton.UseVisualStyleBackColor = true;
			this.playButton.Click += new System.EventHandler(this.PlayButtonClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(346, 357);
			this.Controls.Add(this.playButton);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.screen);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Match3 | Bolotin S.E.";
			((System.ComponentModel.ISupportInitialize)(this.screen)).EndInit();
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
