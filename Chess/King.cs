using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
	public class King : ChessPiece
	{
		public King(Colour color) : base(color)
		{
			Type = PieceType.King;
            hasMoved = false;

            if (color == Colour.Black)
            {
                ImageAfterClick = Properties.Resources.b_k_attack;
                DefaultImage = Properties.Resources.b_k;
            }
            else
            {
                ImageAfterClick = Properties.Resources.w_k_attack;
                DefaultImage = Properties.Resources.w_k;
            }
        }

		public override void FillPossibleMoves()
		{
            possibleMoves.Clear();
            possibleMoves.Add(Tuple.Create(Direction.Forward, MovementType.Single));
			possibleMoves.Add(Tuple.Create(Direction.Backward, MovementType.Single));
			possibleMoves.Add(Tuple.Create(Direction.Left, MovementType.Single));
			possibleMoves.Add(Tuple.Create(Direction.Right, MovementType.Single));
			possibleMoves.Add(Tuple.Create(Direction.ForwardRight, MovementType.Single));
			possibleMoves.Add(Tuple.Create(Direction.ForwardLeft, MovementType.Single));
			possibleMoves.Add(Tuple.Create(Direction.BackwardLeft, MovementType.Single));
			possibleMoves.Add(Tuple.Create(Direction.BackwardRight, MovementType.Single));
            if (hasMoved == false)
            {
			    possibleMoves.Add(Tuple.Create(Direction.Special, MovementType.Castling));
            }
        }
	}
}
