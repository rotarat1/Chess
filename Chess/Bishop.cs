using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
	class Bishop : ChessPiece
	{
		public Bishop(Colour color) : base(color)
		{
			Type = PieceType.Bishop;
            if (color == Colour.Black)
            {
                ImageAfterClick = Properties.Resources.b_b_attack;
                DefaultImage = Properties.Resources.b_b;
            }
            else
            {
                ImageAfterClick = Properties.Resources.w_b_attack;
                DefaultImage = Properties.Resources.w_b;
            }
        }

		public override void FillPossibleMoves()
		{
			possibleMoves.Clear();
			possibleMoves.Add(Tuple.Create(Direction.ForwardLeft, MovementType.Multiple));
			possibleMoves.Add(Tuple.Create(Direction.ForwardRight, MovementType.Multiple));
			possibleMoves.Add(Tuple.Create(Direction.BackwardRight, MovementType.Multiple));
			possibleMoves.Add(Tuple.Create(Direction.BackwardLeft, MovementType.Multiple));
		}

		//public override List<int> PossibleMoves()
		//{
		//	// move on left upper diagonal
		//	for (int rowBoard = position[0] - 1, colBoard = position[1] - 1; rowBoard >= 0; rowBoard--, colBoard--)
		//	{
		//		if (colBoard < 0)
		//		{
		//			break;
		//		}
		//		possibleMoves[rowPossibleMoves, 0] = rowBoard;
		//		possibleMoves[rowPossibleMoves, 1] = colBoard;
		//		++rowPossibleMoves;
		//	}
		//	// move on right upper diagonal
		//	for (int rowBoard = position[0] - 1, colBoard = position[1] + 1; rowBoard >= 0; rowBoard--, colBoard++)
		//	{
		//		if (colBoard > 7)
		//		{
		//			break;
		//		}
		//		possibleMoves[rowPossibleMoves, 0] = rowBoard;
		//		possibleMoves[rowPossibleMoves, 1] = colBoard;
		//		++rowPossibleMoves;
		//	}
		//	// move on left lower diagonal
		//	for (int rowBoard = position[0] + 1, colBoard = position[1] - 1; rowBoard <= 7; rowBoard++, colBoard--)
		//	{
		//		if (colBoard < 0)
		//		{
		//			break;
		//		}
		//		possibleMoves[rowPossibleMoves, 0] = rowBoard;
		//		possibleMoves[rowPossibleMoves, 1] = colBoard;
		//		++rowPossibleMoves;
		//	}
		//	// move on right lower diagonal
		//	for (int rowBoard = position[0] + 1, colBoard = position[1] + 1; rowBoard <= 7; rowBoard++, colBoard++)
		//	{
		//		if (colBoard > 7)
		//		{
		//			break;
		//		}
		//		possibleMoves[rowPossibleMoves, 0] = rowBoard;
		//		possibleMoves[rowPossibleMoves, 1] = colBoard;
		//		++rowPossibleMoves;
		//	}
		//	if (rowPossibleMoves < 8)
		//	{
		//		possibleMoves[rowPossibleMoves, 0] = 8;
		//	}
		//	return possibleMoves;
		//}
	}
}
