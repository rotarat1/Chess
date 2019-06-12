using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Chess
{
	partial class EndGame
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
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Sitka Small", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
			this.label1.Location = new System.Drawing.Point(109, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(462, 106);
			this.label1.TabIndex = 0;
			this.label1.Text = "Game over!";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.button1.Font = new System.Drawing.Font("Sitka Text", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.SystemColors.Highlight;
			this.button1.Location = new System.Drawing.Point(35, 218);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(306, 93);
			this.button1.TabIndex = 1;
			this.button1.Text = "Game Log";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.GameLog);

			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.button2.Font = new System.Drawing.Font("Sitka Small", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.button2.Location = new System.Drawing.Point(381, 217);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(295, 93);
			this.button2.TabIndex = 2;
			this.button2.Text = "Exit";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.Exit);

			// 
			// EndGame
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(700, 358);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Name = "EndGame";
			this.Text = "EndGame";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void GameLog(object sender, EventArgs e)
		{
			var gameLog = new GameLog();
			gameLog.ShowDialog();
		}

		private void Exit(object sender, EventArgs e)
		{
			Application.Exit();
		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}