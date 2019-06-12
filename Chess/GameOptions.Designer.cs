using System;

namespace Chess
{
	partial class GameOptions
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
			this.multiPlayer = new System.Windows.Forms.Button();
			this.singlePlayer = new System.Windows.Forms.Button();
			this.SuspendLayout();

			// 
			// multiPlayer
			// 
			this.multiPlayer.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.multiPlayer.ForeColor = System.Drawing.SystemColors.Highlight;
			this.multiPlayer.Location = new System.Drawing.Point(12, 32);
			this.multiPlayer.Name = "multiPlayer";
			this.multiPlayer.Size = new System.Drawing.Size(150, 35);
			this.multiPlayer.TabIndex = 1;
			this.multiPlayer.Text = "Multiplayer";
			this.multiPlayer.UseVisualStyleBackColor = true;
			this.multiPlayer.Click += new System.EventHandler(this.multiPlayer_Click);
			// 
			// singlePlayer
			// 
			this.singlePlayer.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.singlePlayer.ForeColor = System.Drawing.SystemColors.Highlight;
			this.singlePlayer.Location = new System.Drawing.Point(184, 32);
			this.singlePlayer.Name = "singlePlayer";
			this.singlePlayer.Size = new System.Drawing.Size(150, 35);
			this.singlePlayer.TabIndex = 0;
			this.singlePlayer.Text = "Single Player";
			this.singlePlayer.UseVisualStyleBackColor = true;
			this.singlePlayer.Click += new System.EventHandler(this.singlePlayer_Click);
			// 
			// GameOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(346, 94);
			this.Controls.Add(this.multiPlayer);
			this.Controls.Add(this.singlePlayer);
			this.Name = "GameOptions";
			this.Text = "GameOptions";
			this.ResumeLayout(false);

		}

		private void multiPlayer_Click(object sender, EventArgs e)
		{
			var multiplayerOptions = new MultiplayerOptions();
			multiplayerOptions.ShowDialog();
			this.Hide();
		}

		private void singlePlayer_Click(object sender, EventArgs e)
		{
			// Still not made
		}

		#endregion

		private System.Windows.Forms.Button singlePlayer;
		private System.Windows.Forms.Button multiPlayer;
	}
}