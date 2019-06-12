using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public class Tile : PictureBox
    {
        static int tileSize = 90;
        static Size buttonSize = new Size(tileSize, tileSize);
        public ChessPiece ChessPiece { get; set; }
        public Tuple<int, int> Index { get; set; }
        public Tile(int row, int col, ChessPiece chessPiece)
        {
            ChessPiece = chessPiece;
            Index = Tuple.Create(row, col);
            Location = new Point(tileSize * col, tileSize * row);
            Size = buttonSize;
            BackColor = Color.Transparent;
            SizeMode = PictureBoxSizeMode.CenterImage;
        }
    }
}
