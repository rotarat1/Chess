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
	public partial class Chessboard : Form
	{
		public Tile[,] board;
        public Colour turnColor;
        public int clickCount;

		public Chessboard()
		{
			board = new Tile[8, 8];
            turnColor = Colour.White;
            clickCount = 0;
			InitializeComponent();
			Paint += new PaintEventHandler(DrawBoard);
		}

		private void DrawBoard(object sender, PaintEventArgs e)
		{
			const int tileSize = 90;
			Rectangle[,] chessBoardRects = new Rectangle[8, 8];
            SolidBrush blueBrush = new SolidBrush(Color.DeepSkyBlue);
            for (int row = 0; row < 8; row++)
			{
				// Drawing chessboard
				for (int col = 0; col < 8; col++)
				{
					Rectangle rect = new Rectangle(tileSize * row, tileSize * col, tileSize, tileSize);
					chessBoardRects[row, col] = rect;
					e.Graphics.DrawRectangle(new Pen(Color.RoyalBlue, 2), rect);

					if (col % 2 != 0 && row % 2 == 0)
					{
						e.Graphics.FillRectangle(blueBrush, rect);
					}
					else if (col % 2 == 0 && row % 2 != 0)
					{
						e.Graphics.FillRectangle(blueBrush, rect);
					}
				}
			}
        }
	}
}
