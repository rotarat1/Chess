using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class EmptyPiece : ChessPiece
    {
        public EmptyPiece(Colour color) : base(color)
        {
			Type = PieceType.EmptyPiece;
            ImageAfterClick = Properties.Resources.move_dot;
            SpecialImageAfterClick = Properties.Resources.special_move_dot;
        }

        public override void FillPossibleMoves()
        {
            possibleMoves.Add(Tuple.Create(Direction.None, MovementType.None));
        }
    }
}
