using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
	class Knight : ChessPiece
	{
		public Knight(Colour color) : base(color)
		{
			Type = PieceType.Knight;
            if (color == Colour.Black)
            {
                ImageAfterClick = Properties.Resources.b_kn_attack;
                DefaultImage = Properties.Resources.b_kn;
            }
            else
            {
                ImageAfterClick = Properties.Resources.w_kn_attack;
                DefaultImage = Properties.Resources.w_kn;
            }
        }

		public override void FillPossibleMoves()
		{
			possibleMoves.Clear();
			possibleMoves.Add(Tuple.Create(Direction.Forward, MovementType.Knight));
			possibleMoves.Add(Tuple.Create(Direction.Backward, MovementType.Knight));
			possibleMoves.Add(Tuple.Create(Direction.Right, MovementType.Knight));
			possibleMoves.Add(Tuple.Create(Direction.Left, MovementType.Knight));
		}

		//public override int[,] PossibleMoves()
		//{
		//	// move up - left
		//	if (position[0] < 2 || position[1] - 1 < 0)
		//	{
		//		throw new Exception("Index out of range");
		//	}
		//	else
		//	{
		//		possibleMoves[rowPossibleMoves, 0] = position[0] - 2;
		//		possibleMoves[rowPossibleMoves, 1] = position[1] - 1;
		//		++rowPossibleMoves;
		//	}
		//	// move up - right
		//	if (position[0] < 2 || position[1] + 1 > 7)
		//	{
		//		throw new Exception("Index out of range");
		//	}
		//	else
		//	{
		//		possibleMoves[rowPossibleMoves, 0] = position[0] - 2;
		//		possibleMoves[rowPossibleMoves, 1] = position[1] + 1;
		//		++rowPossibleMoves;
		//	}
		//	// move left - up
		//	if (position[0] - 1 < 0 || position[1] < 2)
		//	{
		//		throw new Exception("Index out of range");
		//	}
		//	else
		//	{
		//		possibleMoves[rowPossibleMoves, 0] = position[0] - 1;
		//		possibleMoves[rowPossibleMoves, 1] = position[1] - 2;
		//		++rowPossibleMoves;
		//	}
		//	// move left - down
		//	if (position[0] + 1 > 7 || position[1] < 2)
		//	{
		//		throw new Exception("Index out of range");
		//	}
		//	else
		//	{
		//		possibleMoves[rowPossibleMoves, 0] = position[0] + 1;
		//		possibleMoves[rowPossibleMoves, 1] = position[1] - 2;
		//		++rowPossibleMoves;
		//	}
		//	// move right - up
		//	if (position[0] - 1 < 0 || position[1] + 2 > 7)
		//	{
		//		throw new Exception("Index out of range");
		//	}
		//	else
		//	{
		//		possibleMoves[rowPossibleMoves, 0] = position[0] - 1;
		//		possibleMoves[rowPossibleMoves, 1] = position[1] + 2;
		//		++rowPossibleMoves;
		//	}
		//	// move right - down
		//	if (position[0] + 1 > 7 || position[1] + 2 > 7)
		//	{
		//		throw new Exception("Index out of range");
		//	}
		//	else
		//	{
		//		possibleMoves[rowPossibleMoves, 0] = position[0] + 1;
		//		possibleMoves[rowPossibleMoves, 1] = position[1] + 2;
		//		++rowPossibleMoves;
		//	}
		//	// move down - left
		//	if (position[0] + 2 > 7 || position[1] - 1 < 0)
		//	{
		//		throw new Exception("Index out of range");
		//	}
		//	else
		//	{
		//		possibleMoves[rowPossibleMoves, 0] = position[0] + 2;
		//		possibleMoves[rowPossibleMoves, 1] = position[1] - 1;
		//		++rowPossibleMoves;
		//	}
		//	// move down - left
		//	if (position[0] + 2 > 7 || position[1] + 1 > 7)
		//	{
		//		throw new Exception("Index out of range");
		//	}
		//	else
		//	{
		//		possibleMoves[rowPossibleMoves, 0] = position[0] + 2;
		//		possibleMoves[rowPossibleMoves, 1] = position[1] + 1;
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
