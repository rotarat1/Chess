using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
	partial class Chessboard
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();

            // Adding chess pieces pictures for every position
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (row == 1)
                    {
                        board[row, col] = new Tile(row, col, new Pawn(Colour.Black, "Pawn"));
                        board[row, col].Image = global::Chess.Properties.Resources.b_p;
                        
                    }
                    else if (row == 6)
                    {
                        board[row, col] = new Tile(row, col, new Pawn(Colour.White, "Pawn"));
                        board[row, col].Image = global::Chess.Properties.Resources.w_p;
                    }
                    else if (row == 0 && col == 0 || row == 0 && col == 7)
                    {
                        board[row, col] = new Tile(row, col, new Rook(Colour.Black, "Rook"));
                        board[row, col].Image = global::Chess.Properties.Resources.b_r;
                    }
                    else if (row == 7 && col == 0 || row == 7 && col == 7)
                    {
                        board[row, col] = new Tile(row, col, new Rook(Colour.White, "Rook"));
                        board[row, col].Image = global::Chess.Properties.Resources.w_r;
                    }
                    else if (row == 0 && col == 1 || row == 0 && col == 6)
                    {
                        board[row, col] = new Tile(row, col, new Knight(Colour.Black, "Knight"));
                        board[row, col].Image = global::Chess.Properties.Resources.b_kn;
                    }
                    else if (row == 7 && col == 1 || row == 7 && col == 6)
                    {
                        board[row, col] = new Tile(row, col, new Knight(Colour.White, "Knight"));
                        board[row, col].Image = global::Chess.Properties.Resources.w_kn;
                    }
                    else if (row == 0 && col == 2 || row == 0 && col == 5)
                    {
                        board[row, col] = new Tile(row, col, new Bishop(Colour.Black, "Bishop"));
                        board[row, col].Image = global::Chess.Properties.Resources.b_b;
                    }
                    else if (row == 7 && col == 2 || row == 7 && col == 5)
                    {
                        board[row, col] = new Tile(row, col, new Bishop(Colour.White, "Bishop"));
                        board[row, col].Image = global::Chess.Properties.Resources.w_b;
                    }
                    else if (row == 0 && col == 3)
                    {
                        board[row, col] = new Tile(row, col, new Queen(Colour.Black, "Queen"));
                        board[row, col].Image = global::Chess.Properties.Resources.b_q;
                    }
                    else if (row == 7 && col == 3)
                    {
                        board[row, col] = new Tile(row, col, new Queen(Colour.White, "Queen"));
                        board[row, col].Image = global::Chess.Properties.Resources.w_q;
                    }
                    else if (row == 0 && col == 4)
                    {
                        board[row, col] = new Tile(row, col, new King(Colour.Black, "King"));
                        board[row, col].Image = global::Chess.Properties.Resources.b_k;
                    }
                    else if (row == 7 && col == 4)
                    {
                        board[row, col] = new Tile(row, col, new King(Colour.White, "King"));
                        board[row, col].Image = global::Chess.Properties.Resources.w_k;
                    }
                    else
					{
						board[row, col] = new Tile(row, col, new EmptyPiece(Colour.Colorless, "Empty Piece"));
					}

					board[row, col].Click += new EventHandler(pic_Clicked);
					this.Controls.Add(board[row, col]);
				}
			}

			// 
			// Chessboard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(900, 720);
			this.Name = "Chessboard";
			this.Text = "Chess";
			this.ResumeLayout(false);
		}

        Tuple<int, int> prevIndex = Tuple.Create(0, 0);
        bool isClicked = false;
        bool isEmpty = true;
        bool kingClicked = false;
        bool kingAttacked = false;
        List<Tile> piecesMovesKingAttacked = new List<Tile>();
        bool noKingPossibleMoves = false;   

        private void pic_Clicked(object sender, EventArgs e)
        {
            Tile currTile = (Tile)sender;

            if (!isClicked)
            {
                if (currTile.ChessPiece.Color != turnColor && currTile.ChessPiece.Color != Colour.Colorless)
                {
                    MessageBox.Show("It's enemy's team turn.");
                } else if (currTile.ChessPiece.Color == Colour.Colorless)
                {
                    MessageBox.Show("Choose a chesspiece.");
                } else
                {
                    isClicked = true;
                    kingClicked = true;
                    Tuple<int, int> currIndex = Tuple.Create(currTile.Index.Item1, currTile.Index.Item2);
                    prevIndex = currIndex;
                    currTile.ChessPiece.FillPossibleMoves();
                    var possibleMoves = currTile.ChessPiece.GetPossibleMoves();
            
                    foreach (Tuple<Direction, MovementType> possibleMove in possibleMoves)
                    {
                        Tuple<int, int> mod = Tuple.Create(0, 0);
                        int m = 0;

                        if (currTile.ChessPiece.Type != "Knight")
                        {
                            if (turnColor == Colour.Black)
                            {
                                m = 1;
                            }
                            else if(turnColor  == Colour.White)
                            {
                                m = -1;
                            }

                            switch (possibleMove.Item1)
                            {
                                case Direction.Forward:
                                    mod = Tuple.Create(m, 0);
                                    break;
                                case Direction.Backward:
                                    mod = Tuple.Create(-m, 0);
                                    break;
                                case Direction.Left:
                                    mod = Tuple.Create(0, m);
                                    break;
                                case Direction.Right:
                                    mod = Tuple.Create(0, -m);
                                    break;
                                case Direction.ForwardLeft:
                                    mod = Tuple.Create(m, m);
                                    break;
                                case Direction.ForwardRight:
                                    mod = Tuple.Create(m, -m);
                                    break;
                                case Direction.BackwardLeft:
                                    mod = Tuple.Create(-m, m);
                                    break;
                                case Direction.BackwardRight:
                                    mod = Tuple.Create(-m, -m);
                                    break;
                                default:
                                    break;
                            }
                            if (currIndex.Item1 + mod.Item1 > 7 || currIndex.Item1 + mod.Item1 < 0|| currIndex.Item2 + mod.Item2 > 7 || currIndex.Item2 + mod.Item2 < 0)
                            {
                                continue;
                            }
                            int guard = 0;
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
                                            if (board[currIndex.Item1, i].ChessPiece.Type != "Empty Piece")
                                            {
                                                isEmpty = false;
                                                break;
                                            }
                                        }
                                        if (isEmpty)
                                        {
                                            board[currIndex.Item1, 2].Image = board[currIndex.Item1, 2].ChessPiece.SpecialImageAfterClick;
                                        }
                                        isEmpty = true;
                                        for (int i = 5; i < 7; i++)
                                        {
                                            if (board[currIndex.Item1, i].ChessPiece.Type != "Empty Piece")
                                            {
                                                isEmpty = false;
                                                break;
                                            }
                                        }
                                        if (isEmpty)
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
                                else if (board[row, col].ChessPiece.Type != "Empty Piece" && board[row, col].ChessPiece.Color != turnColor)
                                {
                                    if (currTile.ChessPiece.Type == "Pawn" && possibleMove.Item1 == Direction.Forward)
                                    {
                                        break;
                                    } else if (board[row, col].ChessPiece.Type == "King")
                                    {
                                        kingAttacked = true;
                                    }
                                    board[row, col].Image = board[row, col].ChessPiece.ImageAfterClick;
                                    if (kingAttacked)
                                    {
                                        piecesMovesKingAttacked.Add(board[row, col]);
                                    }
                                    break;
                                } else
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
                                        if (kingAttacked)
                                        {
                                            piecesMovesKingAttacked.Add(board[currIndex.Item1 + 2, currIndex.Item2 + 1]);
                                        }
                                    } catch (IndexOutOfRangeException)
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
                                            if (kingAttacked)
                                            {
                                                piecesMovesKingAttacked.Add(board[currIndex.Item1 + 2, currIndex.Item2 - 1]);
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
                                        if (kingAttacked)
                                        {
                                            piecesMovesKingAttacked.Add(board[currIndex.Item1 - 2, currIndex.Item2 + 1]);
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
                                            if (kingAttacked)
                                            {
                                                piecesMovesKingAttacked.Add(board[currIndex.Item1 - 2, currIndex.Item2 - 1]);
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
                                        if (kingAttacked)
                                        {
                                            piecesMovesKingAttacked.Add(board[currIndex.Item1 + 1, currIndex.Item2 + 2]);
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
                                            if (kingAttacked)
                                            {
                                                piecesMovesKingAttacked.Add(board[currIndex.Item1 - 1, currIndex.Item2 + 2]);
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
                                        if (kingAttacked)
                                        {
                                            piecesMovesKingAttacked.Add(board[currIndex.Item1 - 1, currIndex.Item2 - 2]);
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
                                            if (kingAttacked)
                                            {
                                                piecesMovesKingAttacked.Add(board[currIndex.Item1 + 1, currIndex.Item2 - 2]);
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
            else if (isClicked && prevIndex.Item1 == currTile.Index.Item1 && prevIndex.Item2 == currTile.Index.Item2)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (board[i, j].Image != board[i, j].ChessPiece.DefaultImage)
                        {
                            if (board[i, j].ChessPiece.Type != "Empty Piece")
                            {
                                board[i, j].Image = board[i, j].ChessPiece.DefaultImage;
                            } else
                            {
                                board[i, j].Image = null;
                            }
                        } 
                    }
                }
                isClicked = false;
            }
            else if (isClicked)
            {
                isClicked = false;
                var currentIndex = currTile.Index;
                if (kingAttacked)
                {
                    foreach(var move in piecesMovesKingAttacked)
                    {
                        if (currTile == move && board[prevIndex.Item1, prevIndex.Item2].ChessPiece.Type == "King")
                        {
                            MessageBox.Show("King is still attacked here.");
                            isClicked = true;
                            return;
                        } 
                    }
                }
                if (board[currTile.Index.Item1, currTile.Index.Item2].Image == board[currTile.Index.Item1, currTile.Index.Item2].ChessPiece.ImageAfterClick || 
                    board[currTile.Index.Item1, currTile.Index.Item2].Image == board[currTile.Index.Item1, currTile.Index.Item2].ChessPiece.SpecialImageAfterClick)
                {
                    if (board[prevIndex.Item1, prevIndex.Item2].ChessPiece.Type == "Pawn" || board[prevIndex.Item1, prevIndex.Item2].ChessPiece.Type == "King" || board[prevIndex.Item1, prevIndex.Item2].ChessPiece.Type == "Rook")
                    {
                        board[prevIndex.Item1, prevIndex.Item2].ChessPiece.hasMoved = true;
                        board[prevIndex.Item1, prevIndex.Item2].ChessPiece.FillPossibleMoves();
                    }
                    if (kingClicked && board[currTile.Index.Item1, currTile.Index.Item2].Image == board[currTile.Index.Item1, currTile.Index.Item2].ChessPiece.SpecialImageAfterClick && currentIndex.Item2 == 2)
                    {
                        var temp1 = board[currentIndex.Item1, 3];
                        board[currentIndex.Item1, 3] = board[currentIndex.Item1, 0];
                        board[currentIndex.Item1, 3].Location = new Point(3 * 90, currentIndex.Item1 * 90);
                        board[currentIndex.Item1, 3].Image = board[currentIndex.Item1, 3].ChessPiece.DefaultImage;
                        board[currentIndex.Item1, 3].BringToFront();
                        board[currentIndex.Item1, 0] = null;
                        board[currentIndex.Item1, 0] = temp1;
                        board[currentIndex.Item1, 0].ChessPiece = new EmptyPiece(Colour.Colorless, "Empty Piece");
                        board[currentIndex.Item1, 0].Index = Tuple.Create(currentIndex.Item1, 0);
                        board[currentIndex.Item1, 0].Location = new Point(0, currentIndex.Item1 * 90);
                        board[currentIndex.Item1, 0].Image = board[currentIndex.Item1, 0].ChessPiece.DefaultImage;
                        board[currentIndex.Item1, 0].BringToFront();
                    } else if (kingClicked && board[currTile.Index.Item1, currTile.Index.Item2].Image == board[currTile.Index.Item1, currTile.Index.Item2].ChessPiece.SpecialImageAfterClick && currentIndex.Item2 == 6)
                    {
                        var temp1 = board[currentIndex.Item1, 5];
                        board[currentIndex.Item1, 5] = board[currentIndex.Item1, 7];
                        board[currentIndex.Item1, 5].Location = new Point(5 * 90, currentIndex.Item1 * 90);
                        board[currentIndex.Item1, 5].Image = board[currentIndex.Item1, 5].ChessPiece.DefaultImage;
                        board[currentIndex.Item1, 5].BringToFront();
                        board[currentIndex.Item1, 7] = null;
                        board[currentIndex.Item1, 7] = temp1;
                        board[currentIndex.Item1, 7].ChessPiece = new EmptyPiece(Colour.Colorless, "Empty Piece");
                        board[currentIndex.Item1, 7].Index = Tuple.Create(currentIndex.Item1, 7);
                        board[currentIndex.Item1, 7].Location = new Point(7 * 90, currentIndex.Item1 * 90);
                        board[currentIndex.Item1, 7].Image = board[currentIndex.Item1, 7].ChessPiece.DefaultImage;
                        board[currentIndex.Item1, 7].BringToFront();
                    }

                    var temp = board[currTile.Index.Item1, currTile.Index.Item2];
                    board[currTile.Index.Item1, currTile.Index.Item2] = null;
                    board[currTile.Index.Item1, currTile.Index.Item2] = board[prevIndex.Item1, prevIndex.Item2];
                    board[currTile.Index.Item1, currTile.Index.Item2].Index = currentIndex;
                    board[currTile.Index.Item1, currTile.Index.Item2].Location = new Point(currentIndex.Item2 * 90, currentIndex.Item1 * 90);
                    board[currTile.Index.Item1, currTile.Index.Item2].Image = board[currentIndex.Item1, currentIndex.Item2].ChessPiece.DefaultImage;
                    board[currTile.Index.Item1, currTile.Index.Item2].BringToFront();
                    board[prevIndex.Item1, prevIndex.Item2] = null;
                    board[prevIndex.Item1, prevIndex.Item2] = temp;
                    board[prevIndex.Item1, prevIndex.Item2].ChessPiece = new EmptyPiece(Colour.Colorless, "Empty Piece");
                    board[prevIndex.Item1, prevIndex.Item2].Index = prevIndex;
                    board[prevIndex.Item1, prevIndex.Item2].Location = new Point(prevIndex.Item2 * 90, prevIndex.Item1 * 90);
                    board[prevIndex.Item1, prevIndex.Item2].Image = board[currentIndex.Item1, currentIndex.Item2].ChessPiece.DefaultImage;
                    board[prevIndex.Item1, prevIndex.Item2].BringToFront();


                    Invalidate();
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            board[i, j].Image = board[i, j].ChessPiece.DefaultImage;
                        }
                    }

                } else
                {
                    MessageBox.Show("Choose avaible position.");
                    isClicked = true;
                    return;
                }

                if (turnColor == Colour.White)
                {
                    turnColor = Colour.Black;
                } else 
                {
                    turnColor = Colour.White;
                }
            }
        }

		#endregion
	}
}
