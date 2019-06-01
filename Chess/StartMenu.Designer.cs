using System;
using System.Windows.Forms;

namespace Chess
{
	partial class StartMenu
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Start = new System.Windows.Forms.Button();
			this.Settings = new System.Windows.Forms.Button();
			this.Exit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Start
			// 
			this.Start.BackColor = System.Drawing.Color.Transparent;
			this.Start.BackgroundImage = global::Chess.Properties.Resources.start;
			this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Start.Location = new System.Drawing.Point(354, 253);
			this.Start.Name = "Start";
			this.Start.Size = new System.Drawing.Size(108, 54);
			this.Start.TabIndex = 0;
			this.Start.UseVisualStyleBackColor = false;
			this.Start.Click += new System.EventHandler(this.startButton_Clicked);
			// 
			// Settings
			// 
			this.Settings.BackColor = System.Drawing.Color.Transparent;
			this.Settings.BackgroundImage = global::Chess.Properties.Resources.settings;
			this.Settings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Settings.Location = new System.Drawing.Point(332, 313);
			this.Settings.Name = "Settings";
			this.Settings.Size = new System.Drawing.Size(151, 58);
			this.Settings.TabIndex = 1;
			this.Settings.UseVisualStyleBackColor = false;
			this.Settings.Click += new System.EventHandler(this.settingsButton_Clicked);
			// 
			// Exit
			// 
			this.Exit.BackColor = System.Drawing.Color.Transparent;
			this.Exit.BackgroundImage = global::Chess.Properties.Resources.exit;
			this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Exit.Location = new System.Drawing.Point(365, 377);
			this.Exit.Name = "Exit";
			this.Exit.Size = new System.Drawing.Size(87, 54);
			this.Exit.TabIndex = 2;
			this.Exit.UseVisualStyleBackColor = false;
			this.Exit.Click += new System.EventHandler(this.exitButton);
			// 
			// ChessBoard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::Chess.Properties.Resources.start_screen;
			this.ClientSize = new System.Drawing.Size(800, 640);
			this.Controls.Add(this.Exit);
			this.Controls.Add(this.Settings);
			this.Controls.Add(this.Start);
			this.Name = "ChessBoard";
			this.Text = "ChessBoard";
			this.ResumeLayout(false);

		}

		private void exitButton(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void settingsButton_Clicked(object sender, EventArgs e)
		{
			var settingsForm = new Settings();
			settingsForm.ShowDialog();
		}

		private void startButton_Clicked(object sender, EventArgs e)
		{
			var gameOptionsForm = new GameOptions();
			gameOptionsForm.ShowDialog();
			this.Hide();
		}

		#endregion

		private System.Windows.Forms.Button Start;
		private System.Windows.Forms.Button Settings;
		private System.Windows.Forms.Button Exit;
	}
}

