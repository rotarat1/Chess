using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
	public class Queen : ChessPiece
	{
		public Queen(Colour color) : base(color)
		{
			Type = PieceType.Queen;
            if (color == Colour.Black)
            {
                ImageAfterClick = Properties.Resources.b_q_attack;
                DefaultImage = Properties.Resources.b_q;
            }
            else
            {
                ImageAfterClick = Properties.Resources.w_q_attack;
                DefaultImage = Properties.Resources.w_q;
            }
        }

		public override void FillPossibleMoves()
		{
			possibleMoves.Clear();
			possibleMoves.Add(Tuple.Create(Direction.Forward, MovementType.Multiple));
			possibleMoves.Add(Tuple.Create(Direction.Backward, MovementType.Multiple));
			possibleMoves.Add(Tuple.Create(Direction.ForwardLeft, MovementType.Multiple));
			possibleMoves.Add(Tuple.Create(Direction.ForwardRight, MovementType.Multiple));
			possibleMoves.Add(Tuple.Create(Direction.BackwardLeft, MovementType.Multiple));
			possibleMoves.Add(Tuple.Create(Direction.BackwardRight, MovementType.Multiple));
			possibleMoves.Add(Tuple.Create(Direction.Left, MovementType.Multiple));
			possibleMoves.Add(Tuple.Create(Direction.Right, MovementType.Multiple));
		}

		//public override int[,] PossibleMoves()
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
		//	for (int colBoard = position[1] - 1; colBoard >= 0; colBoard--)
		//	{
		//		possibleMoves[rowPossibleMoves, 1] = colBoard;
		//		++rowPossibleMoves;
		//	}
		//	// move right
		//	//		col in possibleMoves -> row is the same, col ++
		//	for (int colBoard = position[1] + 1; colBoard <= 7; colBoard++)
		//	{
		//		possibleMoves[rowPossibleMoves, 1] = colBoard;
		//		++rowPossibleMoves;
		//	}
		//	//		row in possibleMoves for right/left movement is const
		//	for (int i = 0; i < rowPossibleMoves; i++)
		//	{
		//		possibleMoves[i, 0] = position[0];
		//	}
		//	//		col in possibleMoves upper/lower movement is const
		//	int tempRowPossibleMoves = rowPossibleMoves;
		//	for (int i = tempRowPossibleMoves; i < 14; i++)
		//	{
		//		possibleMoves[i, 1] = position[1];
		//	}
		//	// move up
		//	for (int rowBoard = position[0] - 1; rowBoard >= 0; rowBoard--)
		//	{
		//		possibleMoves[rowPossibleMoves, 0] = rowBoard;
		//		++rowPossibleMoves;
		//	}
		//	// move down
		//	for (int rowBoard = position[0] + 1; rowBoard <= 7; rowBoard++)
		//	{
		//		possibleMoves[rowPossibleMoves, 0] = rowBoard;
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
