using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
	class Pawn : ChessPiece
	{
		public bool hasDoubleMoved;
		public Pawn(Colour color) : base(color)
		{
			hasDoubleMoved = false;
			Type = PieceType.Pawn;
            hasMoved = false;
            if (color == Colour.Black)
            {
                ImageAfterClick = Properties.Resources.b_p_attack;
                DefaultImage = Properties.Resources.b_p;
            } else
            {
                ImageAfterClick = Properties.Resources.w_p_attack;
                DefaultImage = Properties.Resources.w_p;
            }
        }

		public override void FillPossibleMoves()
		{
            possibleMoves.Clear();
            possibleMoves.Add(Tuple.Create(Direction.Forward, MovementType.Single));
            if (hasMoved == false)
            {
			    possibleMoves.Add(Tuple.Create(Direction.Forward, MovementType.Double));
            }
			possibleMoves.Add(Tuple.Create(Direction.ForwardLeft, MovementType.PawnTake));
			possibleMoves.Add(Tuple.Create(Direction.ForwardRight, MovementType.PawnTake));
		}
	}
}
