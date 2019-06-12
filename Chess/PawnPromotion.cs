using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
	public partial class PawnPromotion : Form
	{
		private Tile[] pawPromotionTiles;
		public Colour color;
		public Tile clickedTile;
		public PawnPromotion(Colour color)
		{
			this.color = color;
			clickedTile = null;
			pawPromotionTiles = new Tile[4];
			InitializeComponent();
			Paint += new PaintEventHandler(DrawPromotionOptions);
		}

		private void DrawPromotionOptions(object sender, PaintEventArgs e)
		{
			const int tileSize = 90;
			Rectangle[] chessBoardRects = new Rectangle[4];
			SolidBrush blueBrush = new SolidBrush(Color.DeepSkyBlue);
			SolidBrush whiteBrush = new SolidBrush(Color.WhiteSmoke);

			for (int col = 0; col < 4; col++)
			{
				Rectangle rect = new Rectangle(tileSize * col, tileSize * 0, tileSize, tileSize);
				chessBoardRects[col] = rect;
				e.Graphics.DrawRectangle(new Pen(Color.RoyalBlue, 2), rect);

				if (col % 2 != 0)
				{
					e.Graphics.FillRectangle(blueBrush, rect);
				}
				else if (col % 2 == 0)
				{
					e.Graphics.FillRectangle(whiteBrush, rect);
				}
			}
		}
	}
}
