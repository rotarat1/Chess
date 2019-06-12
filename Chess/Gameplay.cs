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
        private bool kingAttacked { get; set; }
        private List<Tuple<Tile, Tile>> forbiddenTilesKing;
		public static Logger logger = new Logger();

        public Gameplay()
        {
            kingAttacked = false;
            forbiddenTilesKing = new List<Tuple<Tile, Tile>>();
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
            foreach (var possibleMove in possibleMoves)
            {
                Tuple<int, int> mod = Tuple.Create(0,0);
                int moveTypeOnBoard = 0;

                if (currTile.ChessPiece.Type != PieceType.Knight)
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
                            if (board[currIndex.Item1 + mod.Item1, currIndex.Item2 + mod.Item2].ChessPiece.Type == PieceType.EmptyPiece)
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
                        else if (board[row, col].ChessPiece.Type != PieceType.EmptyPiece && board[row, col].ChessPiece.Color != turnColor)
                        {
                            if (currTile.ChessPiece.Type == PieceType.Pawn && possibleMove.Item1 == Direction.Forward)
                            {
                                break;
                            }
                            board[row, col].Image = board[row, col].ChessPiece.ImageAfterClick;
                            break;
                        }
                        else
                        {
                            if (currTile.ChessPiece.Type == PieceType.Pawn && possibleMove.Item1 == Direction.Forward && possibleMove.Item2 == MovementType.Double && i == 2)
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
        public void Castling (Tile[,] board, int row, int col)
        {
            if (col == 2)
            {
				Move(board, row, 3, row, 0);
            }
            else if (col == 6)
            {
				Move(board, row, 5, row, 7);
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
            board[prevRow, prevCol].ChessPiece = new EmptyPiece(Colour.Colorless);
            board[prevRow, prevCol].Index = Tuple.Create(prevRow, prevCol);
            board[prevRow, prevCol].Location = new Point(prevCol * 90, prevRow * 90);
            board[prevRow, prevCol].Image = board[row, col].ChessPiece.DefaultImage;
            board[prevRow, prevCol].BringToFront();
			Move move = new Move();
			move.startIndex = Tuple.Create(prevRow, prevCol);
			move.endIndex = Tuple.Create(row, col);
			logger.LogMove(move);
		}
		public List<Tuple<Tile, Tile>> GetTilesHitByColor (Tile[,] board, Colour color, bool needKing = false)
		{
			forbiddenTilesKing.Clear();

			Tile king = null;
			if (!needKing)
			{
				var turnColor = ChangeColor(color);
				king = FindKing(board, turnColor);
				board[king.Index.Item1, king.Index.Item2] = new Tile(king.Index.Item1, king.Index.Item2, new EmptyPiece(Colour.Colorless));
			}

			foreach (var tile in board)
			{
				if (tile.ChessPiece.Color != color || tile.ChessPiece.Type == PieceType.EmptyPiece)
				{
					continue;
				}

				tile.ChessPiece.FillPossibleMoves();
				var possibleMoves = tile.ChessPiece.GetPossibleMoves();

				if (tile.ChessPiece.Type != PieceType.Knight)
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
						
						int guard = 0;

						switch (possibleMove.Item2)
						{
							case MovementType.PawnTake:
								guard = 1;
								break;
							case MovementType.Single:
								if (tile.ChessPiece.Type == PieceType.Pawn)
								{
									break;
								}
								guard = 1;
								break;
							case MovementType.Double:
								if (tile.ChessPiece.Type == PieceType.Pawn)
								{
									break;
								}
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
							else if (board[row, col].ChessPiece.Type != PieceType.EmptyPiece)
							{
								if (!needKing)
								{
									forbiddenTilesKing.Add(Tuple.Create(row == king.Index.Item1 && col == king.Index.Item2 ? king : board[row, col], tile));
								}
								else
								{
									forbiddenTilesKing.Add(Tuple.Create(board[row, col], tile));
								}
								break;
							}
							else
							{
								if (!needKing)
								{
									forbiddenTilesKing.Add(Tuple.Create(row == king.Index.Item1 && col == king.Index.Item2 ? king : board[row, col], tile));
								}
								else
								{
									forbiddenTilesKing.Add(Tuple.Create(board[row, col], tile));
								}
							}
						}
					}
				} 
				else
				{
					foreach(var possibleMove in possibleMoves)
					{
						int row1 = -1, col1 = -1, row2 = -1, col2 = -1;
						switch (possibleMove.Item1)
						{
							case Direction.Forward:
								row1 = tile.Index.Item1 + 2;
								col1 = tile.Index.Item2 + 1;
								row2 = tile.Index.Item1 + 2;
								col2 = tile.Index.Item2 - 1;
								break;
							case Direction.Backward:
								row1 = tile.Index.Item1 - 2;
								col1 = tile.Index.Item2 + 1;
								row2 = tile.Index.Item1 - 2;
								col2 = tile.Index.Item2 - 1;
								break;
							case Direction.Right:
								row1 = tile.Index.Item1 + 1;
								col1 = tile.Index.Item2 + 2;
								row2 = tile.Index.Item1 - 1;
								col2 = tile.Index.Item2 + 2;
								break;
							case Direction.Left:
								row1 = tile.Index.Item1 - 1;
								col1 = tile.Index.Item2 - 2;
								row2 = tile.Index.Item1 + 1;
								col2 = tile.Index.Item2 - 2;
								break;
							default:
								break;
						}

						try
						{
							if (!needKing)
							{
								forbiddenTilesKing.Add(Tuple.Create(row1 == king.Index.Item1 && col1 == king.Index.Item2 ? king : board[row1, col1], tile));
							}
							else
							{
								forbiddenTilesKing.Add(Tuple.Create(board[row1, col1], tile));
							}
						}
						catch (IndexOutOfRangeException)
						{
						}

						try
						{
							if (!needKing)
							{
								forbiddenTilesKing.Add(Tuple.Create(row2 == king.Index.Item1 && col2 == king.Index.Item2 ? king : board[row2, col2], tile));
							}
							else
							{
								forbiddenTilesKing.Add(Tuple.Create(board[row2, col2], tile));
							}
						}
						catch (IndexOutOfRangeException)
						{
						}
					}
				}
			}
			if (!needKing)
			{
				board[king.Index.Item1, king.Index.Item2] = king;
			}
			return forbiddenTilesKing;
		}
		public bool CheckForCheck(Tile[,] board, Colour turnColor)
		{
			var attackedTiles = GetTilesHitByColor(board, turnColor, true);

			foreach (var tile in board)
			{
				if (tile.ChessPiece.Type == PieceType.EmptyPiece || tile.ChessPiece.Color == turnColor)
				{
					continue;
				}
				else if (tile.ChessPiece.Type == PieceType.King)
				{
					var king = tile;
					if (attackedTiles.Exists(x => x.Item1 == king))
					{
						return true;
					}
					break;
				}
			}
			return false;
		}
		public bool CheckForExistence(List<Tuple<Tile, Direction>> listToCheck, Tile tile)
		{
			if (listToCheck.Exists(x => x.Item1 == tile))
			{
				return true;
			}

			else return false;
		}
		public List<Tile> GetPossibleMoves (Tile currTile, Colour turnColor, Tuple<int, int> currIndex, Tile[,] board, List<Tuple<Direction, MovementType>> possibleMoves, bool check = false)
		{
			List<Tile> moves = new List<Tile>();
			bool isUsable = true;
			foreach (var possibleMove in possibleMoves)
			{
				Tuple<int, int> mod = Tuple.Create(0, 0);
				int moveTypeOnBoard = 0;

				if (currTile.ChessPiece.Type != PieceType.Knight)
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
					// Secures the accuracity of the shown possible moves   
					int guard = 0;

					// possibleMove.Item2 = The movement of the chess piece
					switch (possibleMove.Item2)
					{
						case MovementType.PawnTake:
							int row = currIndex.Item1 + mod.Item1;
							int col = currIndex.Item2 + mod.Item2;
							if (row > 7 || row < 0 || col > 7 || col < 0)
							{
								break;
							}
							else if (board[row, col].ChessPiece.Type == PieceType.EmptyPiece)
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
							if (board[currIndex.Item1, currIndex.Item2 - 4].ChessPiece.Type == PieceType.Rook && board[currIndex.Item1, currIndex.Item2 - 4].ChessPiece.hasMoved == false
								|| board[currIndex.Item1, currIndex.Item2 + 3].ChessPiece.Type == PieceType.Rook && board[currIndex.Item1, currIndex.Item2 + 3].ChessPiece.hasMoved == false)
							{
								for (int i = 1; i < 4; i++)
								{
									var enemyColor = ChangeColor(turnColor);
									var attackedTiles = GetTilesHitByColor(board, enemyColor);
									if (board[currIndex.Item1, i].ChessPiece.Type != PieceType.EmptyPiece)
									{
										isUsable = false;
										break;
									}
									else if (i != 1 && attackedTiles.Exists(x => x.Item1 == board[currIndex.Item1, i]))
									{
										isUsable = false;
										break;
									}
								}
								if (isUsable && !check)
								{
									board[currIndex.Item1, 2].Image = board[currIndex.Item1, 2].ChessPiece.SpecialImageAfterClick;
								}
								isUsable = true;
								for (int i = 5; i < 7; i++)
								{
									var enemyColor = ChangeColor(turnColor);
									var attackedTiles = GetTilesHitByColor(board, enemyColor);
									if (board[currIndex.Item1, i].ChessPiece.Type != PieceType.EmptyPiece)
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
								if (isUsable && !check)
								{
									board[currIndex.Item1, 6].Image = board[currIndex.Item1, 6].ChessPiece.SpecialImageAfterClick;
								}
							}
							break;
						default:
							break;
					}
					
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
						else if (board[row, col].ChessPiece.Type != PieceType.EmptyPiece && board[row, col].ChessPiece.Color != turnColor)
						{
							if (currTile.ChessPiece.Type == PieceType.Pawn && possibleMove.Item1 == Direction.Forward)
							{
								break;
							} 
							moves.Add(board[row, col]);
							break;
						}
						else
						{
							if (currTile.ChessPiece.Type == PieceType.Pawn && possibleMove.Item1 == Direction.Forward && possibleMove.Item2 == MovementType.Double && i == 2)
							{
								moves.Add(board[row, col]);
								break;
							}
							moves.Add(board[row, col]);
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
									moves.Add(board[currIndex.Item1 + 2, currIndex.Item2 + 1]);
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
										moves.Add(board[currIndex.Item1 + 2, currIndex.Item2 - 1]);
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
									moves.Add(board[currIndex.Item1 - 2, currIndex.Item2 + 1]);
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
										moves.Add(board[currIndex.Item1 - 2, currIndex.Item2 - 1]);
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
									moves.Add(board[currIndex.Item1 + 1, currIndex.Item2 + 2]);
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
										moves.Add(board[currIndex.Item1 - 1, currIndex.Item2 + 2]);
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
									moves.Add(board[currIndex.Item1 - 1, currIndex.Item2 - 2]);
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
										moves.Add(board[currIndex.Item1 + 1, currIndex.Item2 - 2]);
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
			return moves;
		}
		public List<Tile> GetAttackedTiles (Tuple<Tile, Tile> attacker, Tile king, Tile[,] board)
		{
			int row = Math.Abs(attacker.Item2.Index.Item1 - king.Index.Item1);
			int col = Math.Abs(attacker.Item2.Index.Item2 - king.Index.Item2);
			int tilesCount = 0;

			if (row > col)
			{
				tilesCount = row;
			}
			else
			{
				tilesCount = col;
			}
			row = (attacker.Item2.Index.Item1 - king.Index.Item1) / tilesCount;
			col = (attacker.Item2.Index.Item2 - king.Index.Item2) / tilesCount;
			Tuple<int, int> mod = Tuple.Create(row, col);
			List<Tile> tilesToCheck = new List<Tile>();

			for (int i = 1; i <= tilesCount; i++)
			{
				tilesToCheck.Add(board[attacker.Item1.Index.Item1 + mod.Item1 * i, attacker.Item1.Index.Item2 + mod.Item2 * i]);
			}

			return tilesToCheck;
		}
		public Tile FindKing (Tile[,] board, Colour turnColor)
		{
			Tile king = null; 
			foreach (var tile in board)
			{
				if (tile.ChessPiece.Type == PieceType.King && tile.ChessPiece.Color == turnColor)
				{
					king = tile;
					break;
				}
			}
			return king;
		}
		public bool CheckIfCanBeMoved(Tile[,] board, Tile clickedTile, Colour turnColor)
		{
			Tile temp = clickedTile;
			board[temp.Index.Item1, temp.Index.Item2] = new Tile(temp.Index.Item1, temp.Index.Item2, new EmptyPiece(Colour.Colorless));

			var enemyColor = ChangeColor(turnColor);
			if (CheckForCheck(board, enemyColor))
			{
				board[temp.Index.Item1, temp.Index.Item2] = temp;
				return false;
			}
			board[temp.Index.Item1, temp.Index.Item2] = temp;
			return true;
		}
	}
}
