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
        bool isClicked = false;
        Gameplay gameplay = new Gameplay();
        Tuple<int, int> prevIndex = Tuple.Create(0, 0);
        bool kingClicked = false;
        bool noKingPossibleMoves = false;   

        private void pic_Clicked(object sender, EventArgs e)
        {
            Tile currTile = (Tile)sender;

            // Handles the visualisation of the possible moves of the clicked chesspiece 
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

                    if (currTile.ChessPiece.Type == "King")
                    {
                        kingClicked = true;
                    }

                    Tuple<int, int> currIndex = Tuple.Create(currTile.Index.Item1, currTile.Index.Item2);
                    prevIndex = currIndex;
                    currTile.ChessPiece.FillPossibleMoves();
                    var possibleMoves = currTile.ChessPiece.GetPossibleMoves();
                    gameplay.ShowPossibleMoves(currTile, turnColor, currIndex, board, possibleMoves);
                }
            }
            // Handles when a player wants to see another chesspiece's possible moves 
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

                if (kingClicked)
                {
                    kingClicked = false;
                }

                isClicked = false;
            }
            // Handles visualisation of moves
            else if (isClicked)
            {
                isClicked = false;
                int row = currTile.Index.Item1;
                int col = currTile.Index.Item2;
                int prevRow = prevIndex.Item1;
                int prevCol = prevIndex.Item2;

                if (board[row, col].Image == board[row, col].ChessPiece.ImageAfterClick || board[row, col].Image == board[row, col].ChessPiece.SpecialImageAfterClick)
                {
                    if (board[prevRow, prevCol].ChessPiece.Type == "Pawn" || board[prevRow, prevCol].ChessPiece.Type == "King" || board[prevRow, prevCol].ChessPiece.Type == "Rook")
                    {
                        board[prevRow, prevCol].ChessPiece.hasMoved = true;
                        board[prevRow, prevCol].ChessPiece.FillPossibleMoves();
                    }

                    if (board[row, col].Image == board[row, col].ChessPiece.SpecialImageAfterClick && kingClicked)
                    {
						gameplay.Castling(board, currTile, row, col);
                    }

                    kingClicked = false;
                    gameplay.Move(board, row, col, prevRow, prevCol);
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

				turnColor = gameplay.ChangeColor(turnColor);
            }
        }

		#endregion
	}
}
