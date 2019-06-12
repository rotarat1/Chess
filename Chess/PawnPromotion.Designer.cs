using System;

namespace Chess
{
	partial class PawnPromotion
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
			pawPromotionTiles[0] = new Tile(0, 0, new Rook(color));
			pawPromotionTiles[0].Image = pawPromotionTiles[0].ChessPiece.DefaultImage;
			pawPromotionTiles[0].Click += new EventHandler(pic_Clicked);
			this.Controls.Add(pawPromotionTiles[0]);
			pawPromotionTiles[1] = new Tile(0, 1, new Bishop(color));
			pawPromotionTiles[1].Image = pawPromotionTiles[1].ChessPiece.DefaultImage;
			pawPromotionTiles[1].Click += new EventHandler(pic_Clicked);
			this.Controls.Add(pawPromotionTiles[1]);
			pawPromotionTiles[2] = new Tile(0, 2, new Knight(color));
			pawPromotionTiles[2].Image = pawPromotionTiles[2].ChessPiece.DefaultImage;
			pawPromotionTiles[2].Click += new EventHandler(pic_Clicked);
			this.Controls.Add(pawPromotionTiles[2]);
			pawPromotionTiles[3] = new Tile(0, 3, new Queen(color));
			pawPromotionTiles[3].Image = pawPromotionTiles[3].ChessPiece.DefaultImage;
			pawPromotionTiles[3].Click += new EventHandler(pic_Clicked);
			this.Controls.Add(pawPromotionTiles[3]);

			this.components = new System.ComponentModel.Container();
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(360, 90);
			this.Text = "PawnPromotion";
		}

		private void pic_Clicked(object sender, EventArgs e)
		{
			clickedTile = (Tile)sender;
			this.Hide();
		}

		#endregion
	}
}