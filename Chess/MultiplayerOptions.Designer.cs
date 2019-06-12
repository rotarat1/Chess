using System;
using System.Windows.Forms;

namespace Chess
{
	partial class MultiplayerOptions
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
			this.firstPlayerName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.secondPlayerName = new System.Windows.Forms.TextBox();
			Button Player2NameInfoButton = new System.Windows.Forms.Button();
			Button Player1NameInfoButton = new System.Windows.Forms.Button();
			Button PlayButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.SystemColors.Control;
			this.label1.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.label1.Location = new System.Drawing.Point(12, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(121, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Player 1 name:";
			// 
			// firstPlayerName
			// 
			this.firstPlayerName.Location = new System.Drawing.Point(16, 44);
			this.firstPlayerName.Name = "firstPlayerName";
			this.firstPlayerName.Size = new System.Drawing.Size(235, 20);
			this.firstPlayerName.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.SystemColors.Control;
			this.label2.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.label2.Location = new System.Drawing.Point(12, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(123, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Player 2 name:";
			// 
			// secondPlayerName
			// 
			this.secondPlayerName.Location = new System.Drawing.Point(16, 101);
			this.secondPlayerName.Name = "secondPlayerName";
			this.secondPlayerName.Size = new System.Drawing.Size(235, 20);
			this.secondPlayerName.TabIndex = 3;
			// 
			// Player2NameInfoButton
			// 
			Player2NameInfoButton.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			Player2NameInfoButton.ForeColor = System.Drawing.SystemColors.Highlight;
			Player2NameInfoButton.Location = new System.Drawing.Point(279, 89);
			Player2NameInfoButton.Name = "Player2NameInfoButton";
			Player2NameInfoButton.Size = new System.Drawing.Size(71, 39);
			Player2NameInfoButton.TabIndex = 5;
			Player2NameInfoButton.Text = "Enter";
			Player2NameInfoButton.UseMnemonic = false;
			Player2NameInfoButton.UseVisualStyleBackColor = true;
			Player2NameInfoButton.Click += new System.EventHandler(this.Player2NameInfoButton_Clicked);
			// 
			// Player1NameInfoButton
			// 
			Player1NameInfoButton.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			Player1NameInfoButton.ForeColor = System.Drawing.SystemColors.Highlight;
			Player1NameInfoButton.Location = new System.Drawing.Point(279, 32);
			Player1NameInfoButton.Name = "Player1NameInfoButton";
			Player1NameInfoButton.Size = new System.Drawing.Size(71, 39);
			Player1NameInfoButton.TabIndex = 7;
			Player1NameInfoButton.Text = "Enter";
			Player1NameInfoButton.UseMnemonic = false;
			Player1NameInfoButton.UseVisualStyleBackColor = true;
			Player1NameInfoButton.Click += new System.EventHandler(this.Player1NameInfoButton_Clicked);
			// 
			// PlayButton
			// 
			PlayButton.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			PlayButton.ForeColor = System.Drawing.SystemColors.Highlight;
			PlayButton.Location = new System.Drawing.Point(99, 148);
			PlayButton.Name = "PlayButton";
			PlayButton.Size = new System.Drawing.Size(152, 38);
			PlayButton.TabIndex = 8;
			PlayButton.Text = "Play!";
			PlayButton.UseVisualStyleBackColor = true;
			PlayButton.Click += new System.EventHandler(this.PlayButton_Clicked);
			// 
			// MultyPlayerOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(369, 198);
			this.Controls.Add(PlayButton);
			this.Controls.Add(Player1NameInfoButton);
			this.Controls.Add(Player2NameInfoButton);
			this.Controls.Add(this.secondPlayerName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.firstPlayerName);
			this.Controls.Add(this.label1);
			this.Name = "MultyPlayerOptions";
			this.Text = "MultyPlayerOptions";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void Player2NameInfoButton_Clicked(object sender, EventArgs e)
		{
			player2Name = label1.Text;
			player1Assigned = true;
		}

		private void Player1NameInfoButton_Clicked(object sender, EventArgs e)
		{
			player1Name = label1.Text;
			player2Assigned = true;
		}

		private void PlayButton_Clicked(object sender, EventArgs e)
		{
			if (player1Assigned && player2Assigned)
			{
				var chessBoard = new Chessboard();
				chessBoard.Show();
				this.Hide();
			}
		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox firstPlayerName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox secondPlayerName;
	}
	#endregion
}