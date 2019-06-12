using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
	class Rook : ChessPiece
	{
		public Rook(Colour color) : base(color)
		{
			Type = PieceType.Rook;
            hasMoved = false;
            if (color == Colour.Black)
            {
                ImageAfterClick = Properties.Resources.b_r_attack;
                DefaultImage = Properties.Resources.b_r;
            }
            else
            {
                ImageAfterClick = Properties.Resources.w_r_attack;
                DefaultImage = Properties.Resources.w_r;
            }
        }

		public override void FillPossibleMoves()
		{
			possibleMoves.Clear();
            possibleMoves.Add(Tuple.Create(Direction.Forward, MovementType.Multiple));
			possibleMoves.Add(Tuple.Create(Direction.Backward, MovementType.Multiple));
			possibleMoves.Add(Tuple.Create(Direction.Left, MovementType.Multiple));
			possibleMoves.Add(Tuple.Create(Direction.Right, MovementType.Multiple));
		}
	}
}
