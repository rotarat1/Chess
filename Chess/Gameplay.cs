using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Gameplay
    {
        public bool kingAttacked { get; set; }
        public List<Tuple<Tile, Direction>> forbiddenTilesKing;

        public Gameplay()
        {
            kingAttacked = false;
            forbiddenTilesKing = new List<Tuple<Tile, Direction>>();
        }

		public Colour ChangeColor(Colour color)
		{
			if (color == Colour.White)
			{
				color = Colour.Black;
			}
			else
			{
				color = Colour.White;
			}
			return color;
		}
        public void ShowPossibleMoves (Tile currTile, Colour turnColor, Tuple<int, int> currIndex, Tile [,] board, List<Tuple<Direction, MovementType>> possibleMoves)
        {
            bool isUsable = true;
            foreach (var possibleMove in possibleMoves)
            {
                Tuple<int, int> mod = Tuple.Create(0,0);
                int moveTypeOnBoard = 0;

                if (currTile.ChessPiece.Type != "Knight")
                {
                    if (turnColor == Colour.Black)
                    {
                        moveTypeOnBoard = 1;
                    }
                    else if (turnColor == Colour.White)
                    {
                        moveTypeOnBoard = -1;
                    }

                    // possibleMove.Item1 = Direction of the chess piece
                    // Creating the direction where possible moves will be shown
                    switch (possibleMove.Item1)
                    {
                        case Direction.Forward:
                            mod = Tuple.Create(moveTypeOnBoard, 0);
                            break;
                        case Direction.Backward:
                            mod = Tuple.Create(-moveTypeOnBoard, 0);
                            break;
                        case Direction.Left:
                            mod = Tuple.Create(0, moveTypeOnBoard);
                            break;
                        case Direction.Right:
                            mod = Tuple.Create(0, -moveTypeOnBoard);
                            break;
                        case Direction.ForwardLeft:
                            mod = Tuple.Create(moveTypeOnBoard, moveTypeOnBoard);
                            break;
                        case Direction.ForwardRight:
                            mod = Tuple.Create(moveTypeOnBoard, -moveTypeOnBoard);
                            break;
                        case Direction.BackwardLeft:
                            mod = Tuple.Create(-moveTypeOnBoard, moveTypeOnBoard);
                            break;
                        case Direction.BackwardRight:
                            mod = Tuple.Create(-moveTypeOnBoard, -moveTypeOnBoard);
                            break;
                        default:
                            break;
                    }

                    // IndexOutOfRangeException
                    if (currIndex.Item1 + mod.Item1 > 7 || currIndex.Item1 + mod.Item1 < 0 || currIndex.Item2 + mod.Item2 > 7 || currIndex.Item2 + mod.Item2 < 0)
                    {
                        continue;
                    }

                    // Secures the accuracity of the shown possible moves   
                    int guard = 0;

                    // possibleMove.Item2 = The movement of the chess piece
                    // Creating the number of times possible moves will be shown
                    switch (possibleMove.Item2)
                    {
                        case MovementType.PawnTake:
                            if (board[currIndex.Item1 + mod.Item1, currIndex.Item2 + mod.Item2].ChessPiece.Type == "Empty Piece")
                            {
                                break;
                            }
                            guard = 1;
                            break;
                        case MovementType.Single:
                            guard = 1;
                            break;
                        case MovementType.Double:
                            guard = 2;
                            break;
                        case MovementType.Multiple:
                            guard = 7;
                            break;
                        case MovementType.Castling:
                            if (board[currIndex.Item1, currIndex.Item2 - 4].ChessPiece.Type == "Rook" && board[currIndex.Item1, currIndex.Item2 - 4].ChessPiece.hasMoved == false
                                || board[currIndex.Item1, currIndex.Item2 + 3].ChessPiece.Type == "Rook" && board[currIndex.Item1, currIndex.Item2 + 3].ChessPiece.hasMoved == false)
                            {
                                for (int i = 1; i < 4; i++)
                                {
									var enemyColor = ChangeColor(turnColor);
									var attackedTiles = GetTilesHitByColor(board, enemyColor);
									if (board[currIndex.Item1, i].ChessPiece.Type != "Empty Piece")
                                    {
                                        isUsable = false;
                                        break;
                                    }
									else if (i != 1 && attackedTiles.Exists(x => x.Item1 == board[currIndex.Item1,i]))
									{
										isUsable = false;
										break;
									}
                                }
                                if (isUsable)
                                {
                                    board[currIndex.Item1, 2].Image = board[currIndex.Item1, 2].ChessPiece.SpecialImageAfterClick;
                                }
                                isUsable = true;
                                for (int i = 5; i < 7; i++)
                                {
									var enemyColor = ChangeColor(turnColor);
									var attackedTiles = GetTilesHitByColor(board, enemyColor);
									if (board[currIndex.Item1, i].ChessPiece.Type != "Empty Piece")
                                    {
                                        isUsable = false;
                                        break;
									}
									else if (attackedTiles.Exists(x => x.Item1 == board[currIndex.Item1, i]))
									{
										isUsable = false;
										break;
									}
								}
                                if (isUsable)
                                {
                                    board[currIndex.Item1, 6].Image = board[currIndex.Item1, 6].ChessPiece.SpecialImageAfterClick;
                                }
                            }
                            break;
                        default:
                            break;
                    }

                    // Showing the possible moves
                    for (int i = 1; i <= guard; i++)
                    {
                        int row = currIndex.Item1 + mod.Item1 * i;
                        int col = currIndex.Item2 + mod.Item2 * i;

                        if (row > 7 || row < 0 || col > 7 || col < 0)
                        {
                            break;
                        }
                        else if (board[row, col].ChessPiece.Color == turnColor)
                        {
                            break;
                        }
                        else if (board[row, col].ChessPiece.Type != "Empty Piece" && board[row, col].ChessPiece.Color != turnColor)
                        {
                            if (currTile.ChessPiece.Type == "Pawn" && possibleMove.Item1 == Direction.Forward)
                            {
                                break;
                            }
                            board[row, col].Image = board[row, col].ChessPiece.ImageAfterClick;
                            break;
                        }
                        else
                        {
                            if (currTile.ChessPiece.Type == "Pawn" && possibleMove.Item1 == Direction.Forward && possibleMove.Item2 == MovementType.Double && i == 2)
                            {
                                board[row, col].Image = board[row, col].ChessPiece.SpecialImageAfterClick;
                                break;
                            }
                            board[row, col].Image = board[row, col].ChessPiece.ImageAfterClick;
                        }
                    }
                }
                // possible moves for Knight
                else
                {
                    switch (possibleMove.Item1)
                    {
                        case Direction.Forward:
                            try
                            {
                                if (board[currIndex.Item1 + 2, currIndex.Item2 + 1].ChessPiece.Color != turnColor)
                                {
                                    board[currIndex.Item1 + 2, currIndex.Item2 + 1].Image = board[currIndex.Item1 + 2, currIndex.Item2 + 1].ChessPiece.ImageAfterClick;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                            }
                            finally
                            {
                                try
                                {
                                    if (board[currIndex.Item1 + 2, currIndex.Item2 - 1].ChessPiece.Color != turnColor)
                                    {
                                        board[currIndex.Item1 + 2, currIndex.Item2 - 1].Image = board[currIndex.Item1 + 2, currIndex.Item2 - 1].ChessPiece.ImageAfterClick;
                                    }
                                }
                                catch (IndexOutOfRangeException)
                                {

                                }
                            }
                            break;
                        case Direction.Backward:
                            try
                            {
                                if (board[currIndex.Item1 - 2, currIndex.Item2 + 1].ChessPiece.Color != turnColor)
                                {
                                    board[currIndex.Item1 - 2, currIndex.Item2 + 1].Image = board[currIndex.Item1 - 2, currIndex.Item2 + 1].ChessPiece.ImageAfterClick;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                            }
                            finally
                            {
                                try
                                {
                                    if (board[currIndex.Item1 - 2, currIndex.Item2 - 1].ChessPiece.Color != turnColor)
                                    {
                                        board[currIndex.Item1 - 2, currIndex.Item2 - 1].Image = board[currIndex.Item1 - 2, currIndex.Item2 - 1].ChessPiece.ImageAfterClick;
                                    }
                                }
                                catch (IndexOutOfRangeException)
                                {

                                }
                            }
                            break;
                        case Direction.Right:
                            try
                            {
                                if (board[currIndex.Item1 + 1, currIndex.Item2 + 2].ChessPiece.Color != turnColor)
                                {
                                    board[currIndex.Item1 + 1, currIndex.Item2 + 2].Image = board[currIndex.Item1 + 1, currIndex.Item2 + 2].ChessPiece.ImageAfterClick;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                            }
                            finally
                            {
                                try
                                {
                                    if (board[currIndex.Item1 - 1, currIndex.Item2 + 2].ChessPiece.Color != turnColor)
                                    {
                                        board[currIndex.Item1 - 1, currIndex.Item2 + 2].Image = board[currIndex.Item1 - 1, currIndex.Item2 + 2].ChessPiece.ImageAfterClick;
                                    }
                                }
                                catch (IndexOutOfRangeException)
                                {

                                }
                            }
                            break;
                        case Direction.Left:
                            try
                            {
                                if (board[currIndex.Item1 - 1, currIndex.Item2 - 2].ChessPiece.Color != turnColor)
                                {
                                    board[currIndex.Item1 - 1, currIndex.Item2 - 2].Image = board[currIndex.Item1 - 1, currIndex.Item2 - 2].ChessPiece.ImageAfterClick;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                            }
                            finally
                            {
                                try
                                {
                                    if (board[currIndex.Item1 + 1, currIndex.Item2 - 2].ChessPiece.Color != turnColor)
                                    {
                                        board[currIndex.Item1 + 1, currIndex.Item2 - 2].Image = board[currIndex.Item1 + 1, currIndex.Item2 - 2].ChessPiece.ImageAfterClick;
                                    }
                                }
                                catch (IndexOutOfRangeException)
                                {

                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public void Castling (Tile[,] board,Tile currTile, int row, int col)
        {
            if (col == 2)
            {
                var temp1 = board[row, 3];
                board[row, 3] = board[row, 0];
                board[row, 3].Location = new Point(3 * 90, row * 90);
                board[row, 3].Image = board[row, 3].ChessPiece.DefaultImage;
                board[row, 3].BringToFront();
                board[row, 0] = null;
                board[row, 0] = temp1;
                board[row, 0].ChessPiece = new EmptyPiece(Colour.Colorless, "Empty Piece");
                board[row, 0].Index = Tuple.Create(row, 0);
                board[row, 0].Location = new Point(0, row * 90);
                board[row, 0].Image = board[row, 0].ChessPiece.DefaultImage;
                board[row, 0].BringToFront();
            }
            else if (col == 6)
            {
                var temp1 = board[row, 5];
                board[row, 5] = board[row, 7];
                board[row, 5].Location = new Point(5 * 90, row * 90);
                board[row, 5].Image = board[row, 5].ChessPiece.DefaultImage;
                board[row, 5].BringToFront();
                board[row, 7] = null;
                board[row, 7] = temp1;
                board[row, 7].ChessPiece = new EmptyPiece(Colour.Colorless, "Empty Piece");
                board[row, 7].Index = Tuple.Create(row, 7);
                board[row, 7].Location = new Point(7 * 90, row * 90);
                board[row, 7].Image = board[row, 7].ChessPiece.DefaultImage;
                board[row, 7].BringToFront();
            }
            
        }
        public void Move(Tile[,] board, int row, int col, int prevRow, int prevCol)
        {
            var temp = board[row, col];
            board[row, col] = null;
            board[row, col] = board[prevRow, prevCol];
            board[row, col].Index = Tuple.Create(row, col);
            board[row, col].Location = new Point(col * 90, row * 90);
            board[row, col].Image = board[row, col].ChessPiece.DefaultImage;
            board[row, col].BringToFront();
            board[prevRow, prevCol] = null;
            board[prevRow, prevCol] = temp;
            board[prevRow, prevCol].ChessPiece = new EmptyPiece(Colour.Colorless, "Empty Piece");
            board[prevRow, prevCol].Index = Tuple.Create(prevRow, prevCol);
            board[prevRow, prevCol].Location = new Point(prevCol * 90, prevRow * 90);
            board[prevRow, prevCol].Image = board[row, col].ChessPiece.DefaultImage;
            board[prevRow, prevCol].BringToFront();
        }
		public List<Tuple<Tile, Direction>> GetTilesHitByColor (Tile[,] board, Colour color)
		{
			foreach (var tile in board)
			{
				if (tile.ChessPiece.Color != color)
				{
					continue;
				}
				if (tile.ChessPiece.Type != "Empty Piece")
				{
					tile.ChessPiece.FillPossibleMoves();
					var possibleMoves = tile.ChessPiece.GetPossibleMoves();

					if (tile.ChessPiece.Type != "Knight")
					{
						foreach(var possibleMove in possibleMoves)
						{
							Tuple<int, int> mod = Tuple.Create(0, 0);
							int moveTypeOnBoard = 0;

							if (tile.ChessPiece.Color == Colour.Black)
							{
								moveTypeOnBoard = 1;
							}
							else if (tile.ChessPiece.Color == Colour.White)
							{
								moveTypeOnBoard = -1;
							}

							switch (possibleMove.Item1)
							{
								case Direction.Forward:
									mod = Tuple.Create(moveTypeOnBoard, 0);
									break;
								case Direction.Backward:
									mod = Tuple.Create(-moveTypeOnBoard, 0);
									break;
								case Direction.Left:
									mod = Tuple.Create(0, moveTypeOnBoard);
									break;
								case Direction.Right:
									mod = Tuple.Create(0, -moveTypeOnBoard);
									break;
								case Direction.ForwardLeft:
									mod = Tuple.Create(moveTypeOnBoard, moveTypeOnBoard);
									break;
								case Direction.ForwardRight:
									mod = Tuple.Create(moveTypeOnBoard, -moveTypeOnBoard);
									break;
								case Direction.BackwardLeft:
									mod = Tuple.Create(-moveTypeOnBoard, moveTypeOnBoard);
									break;
								case Direction.BackwardRight:
									mod = Tuple.Create(-moveTypeOnBoard, -moveTypeOnBoard);
									break;
								default:
									break;
							}

							if (tile.Index.Item1 + mod.Item1 > 7 || tile.Index.Item1 + mod.Item1 < 0 || tile.Index.Item2 + mod.Item2 > 7 || tile.Index.Item2 + mod.Item2 < 0)
							{
								continue;
							}

							int guard = 0;

							switch (possibleMove.Item2)
							{
								case MovementType.PawnTake:
									if (board[tile.Index.Item1 + mod.Item1, tile.Index.Item2 + mod.Item2].ChessPiece.Type == "Empty Piece")
									{
										break;
									}
									guard = 1;
									break;
								case MovementType.Single:
									guard = 1;
									break;
								case MovementType.Double:
									guard = 2;
									break;
								case MovementType.Multiple:
									guard = 7;
									break;
								default:
									break;
							}

							for (int i = 1; i <= guard; i++)
							{
								int row = tile.Index.Item1 + mod.Item1 * i;
								int col = tile.Index.Item2 + mod.Item2 * i;

								if (row > 7 || row < 0 || col > 7 || col < 0)
								{
									break;
								}
								else if (board[row, col].ChessPiece.Color == tile.ChessPiece.Color)
								{
									break;
								}
								else if (board[row, col].ChessPiece.Type != "Empty Piece" && board[row, col].ChessPiece.Color != tile.ChessPiece.Color)
								{
									if (tile.ChessPiece.Type == "Pawn" && possibleMove.Item1 == Direction.Forward)
									{
										break;
									}
									forbiddenTilesKing.Add(Tuple.Create(board[row, col], possibleMove.Item1));
									break;
								}
								else
								{
									if (tile.ChessPiece.Type == "Pawn" && possibleMove.Item1 == Direction.Forward && possibleMove.Item2 == MovementType.Double && i == 2)
									{
										forbiddenTilesKing.Add(Tuple.Create(board[row, col], possibleMove.Item1));
										break;
									}
									forbiddenTilesKing.Add(Tuple.Create(board[row, col], possibleMove.Item1));
								}
							}
						}
					} 
					else
					{
						foreach(var possibleMove in possibleMoves)
						{
							switch (possibleMove.Item1)
							{
								case Direction.Forward:
									try
									{
										if (board[tile.Index.Item1 + 2, tile.Index.Item2 + 1].ChessPiece.Color != tile.ChessPiece.Color)
										{
											forbiddenTilesKing.Add(Tuple.Create(board[tile.Index.Item1 + 2, tile.Index.Item2 + 1], possibleMove.Item1));
										}
									}
									catch (IndexOutOfRangeException)
									{
									}
									finally
									{
										try
										{
											if (board[tile.Index.Item1 + 2, tile.Index.Item2 - 1].ChessPiece.Color != tile.ChessPiece.Color)
											{
												forbiddenTilesKing.Add(Tuple.Create(board[tile.Index.Item1 + 2, tile.Index.Item2 - 1], possibleMove.Item1));
											}
										}
										catch (IndexOutOfRangeException)
										{

										}
									}
									break;
								case Direction.Backward:
									try
									{
										if (board[tile.Index.Item1 - 2, tile.Index.Item2 + 1].ChessPiece.Color != tile.ChessPiece.Color)
										{
											forbiddenTilesKing.Add(Tuple.Create(board[tile.Index.Item1 - 2, tile.Index.Item2 + 1], possibleMove.Item1));
										}
									}
									catch (IndexOutOfRangeException)
									{
									}
									finally
									{
										try
										{
											if (board[tile.Index.Item1 - 2, tile.Index.Item2 - 1].ChessPiece.Color != tile.ChessPiece.Color)
											{
												forbiddenTilesKing.Add(Tuple.Create(board[tile.Index.Item1 - 2, tile.Index.Item2 - 1], possibleMove.Item1));
											}
										}
										catch (IndexOutOfRangeException)
										{

										}
									}
									break;
								case Direction.Right:
									try
									{
										if (board[tile.Index.Item1 + 1, tile.Index.Item2 + 2].ChessPiece.Color != tile.ChessPiece.Color)
										{
											forbiddenTilesKing.Add(Tuple.Create(board[tile.Index.Item1 + 1, tile.Index.Item2 + 2], possibleMove.Item1));
										}
									}
									catch (IndexOutOfRangeException)
									{
									}
									finally
									{
										try
										{
											if (board[tile.Index.Item1 - 1, tile.Index.Item2 + 2].ChessPiece.Color != tile.ChessPiece.Color)
											{
												forbiddenTilesKing.Add(Tuple.Create(board[tile.Index.Item1 - 1, tile.Index.Item2 + 2], possibleMove.Item1));
											}
										}
										catch (IndexOutOfRangeException)
										{

										}
									}
									break;
								case Direction.Left:
									try
									{
										if (board[tile.Index.Item1 - 1, tile.Index.Item2 - 2].ChessPiece.Color != tile.ChessPiece.Color)
										{
											forbiddenTilesKing.Add(Tuple.Create(board[tile.Index.Item1 - 1, tile.Index.Item2 - 2], possibleMove.Item1));
										}
									}
									catch (IndexOutOfRangeException)
									{
									}
									finally
									{
										try
										{
											if (board[tile.Index.Item1 + 1, tile.Index.Item2 - 2].ChessPiece.Color != tile.ChessPiece.Color)
											{
												forbiddenTilesKing.Add(Tuple.Create(board[tile.Index.Item1 + 1, tile.Index.Item2 - 2], possibleMove.Item1));
											}
										}
										catch (IndexOutOfRangeException)
										{

										}
									}
									break;
								default:
									break;
							}
						}
					}
				}
			}
			return forbiddenTilesKing;
		}
    }
}
