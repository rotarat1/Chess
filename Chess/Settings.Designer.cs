using System;

namespace Chess
{
	partial class Settings
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
			this.enableMusic = new System.Windows.Forms.Button();
			this.disableMusic = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Enable music
			// 
			this.enableMusic.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.enableMusic.ForeColor = System.Drawing.SystemColors.Highlight;
			this.enableMusic.Location = new System.Drawing.Point(38, 113);
			this.enableMusic.Name = "enableMusic";
			this.enableMusic.Size = new System.Drawing.Size(130, 30);
			this.enableMusic.TabIndex = 2;
			this.enableMusic.Text = "Yes";
			this.enableMusic.UseVisualStyleBackColor = true;
			this.enableMusic.Click += new System.EventHandler(this.enableMusicButton_Clicked);
			// 
			// Disable music
			// 
			this.disableMusic.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.disableMusic.ForeColor = System.Drawing.SystemColors.Highlight;
			this.disableMusic.Location = new System.Drawing.Point(192, 113);
			this.disableMusic.Name = "disableMusic";
			this.disableMusic.Size = new System.Drawing.Size(130, 30);
			this.disableMusic.TabIndex = 3;
			this.disableMusic.Text = "No";
			this.disableMusic.UseVisualStyleBackColor = true;
			this.disableMusic.Click += new System.EventHandler(this.disableMusicButton_Clicked);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.label1.Location = new System.Drawing.Point(21, 43);
			this.label1.Name = "label2";
			this.label1.Size = new System.Drawing.Size(325, 30);
			this.label1.TabIndex = 1;
			this.label1.Text = "Do you want to listen to music?";
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(370, 170);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.disableMusic);
			this.Controls.Add(this.enableMusic);
			this.Name = "Settings";
			this.Text = "Settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void disableMusicButton_Clicked(object sender, EventArgs e)
		{
			// turn on music
			this.Close();
		}

		private void enableMusicButton_Clicked(object sender, EventArgs e)
		{
			// stop music
			this.Close();
		}

		#endregion

		private System.Windows.Forms.Button enableMusic;
		private System.Windows.Forms.Button disableMusic;
		private System.Windows.Forms.Label label1;
	}
}