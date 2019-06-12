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
                        board[row, col] = new Tile(row, col, new Pawn(Colour.Black));
						board[row, col].Image = board[row, col].ChessPiece.DefaultImage;
					}
                    else if (row == 6)
                    {
                        board[row, col] = new Tile(row, col, new Pawn(Colour.White));
						board[row, col].Image = board[row, col].ChessPiece.DefaultImage;

					}
					else if (row == 0 && col == 0 || row == 0 && col == 7)
                    {
                        board[row, col] = new Tile(row, col, new Rook(Colour.Black));
						board[row, col].Image = board[row, col].ChessPiece.DefaultImage;

					}
					else if (row == 7 && col == 0 || row == 7 && col == 7)
                    {
                        board[row, col] = new Tile(row, col, new Rook(Colour.White));
						board[row, col].Image = board[row, col].ChessPiece.DefaultImage;

					}
					else if (row == 0 && col == 1 || row == 0 && col == 6)
                    {
                        board[row, col] = new Tile(row, col, new Knight(Colour.Black));
						board[row, col].Image = board[row, col].ChessPiece.DefaultImage;

					}
					else if (row == 7 && col == 1 || row == 7 && col == 6)
                    {
                        board[row, col] = new Tile(row, col, new Knight(Colour.White));
						board[row, col].Image = board[row, col].ChessPiece.DefaultImage;

					}
					else if (row == 0 && col == 2 || row == 0 && col == 5)
                    {
                        board[row, col] = new Tile(row, col, new Bishop(Colour.Black));
						board[row, col].Image = board[row, col].ChessPiece.DefaultImage;

					}
					else if (row == 7 && col == 2 || row == 7 && col == 5)
                    {
                        board[row, col] = new Tile(row, col, new Bishop(Colour.White));
						board[row, col].Image = board[row, col].ChessPiece.DefaultImage;

					}
					else if (row == 0 && col == 3)
                    {
                        board[row, col] = new Tile(row, col, new Queen(Colour.Black));
						board[row, col].Image = board[row, col].ChessPiece.DefaultImage;

					}
					else if (row == 7 && col == 3)
                    {
                        board[row, col] = new Tile(row, col, new Queen(Colour.White));
						board[row, col].Image = board[row, col].ChessPiece.DefaultImage;

					}
					else if (row == 0 && col == 4)
                    {
                        board[row, col] = new Tile(row, col, new King(Colour.Black));
						board[row, col].Image = board[row, col].ChessPiece.DefaultImage;

					}
					else if (row == 7 && col == 4)
                    {
                        board[row, col] = new Tile(row, col, new King(Colour.White));
						board[row, col].Image = board[row, col].ChessPiece.DefaultImage;

					}
					else
					{
						board[row, col] = new Tile(row, col, new EmptyPiece(Colour.Colorless));
						board[row, col].Image = board[row, col].ChessPiece.DefaultImage;

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
		bool check = false;

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
                }
				else if (check)
				{
					Tuple<int, int> currIndex = Tuple.Create(currTile.Index.Item1, currTile.Index.Item2);
					prevIndex = currIndex;
					Tile king = null;
					foreach (var tile in board)
					{
						if (tile.ChessPiece.Type == PieceType.King && tile.ChessPiece.Color == turnColor)
						{
							king = tile;
							break;
						}
					}

					king.ChessPiece.FillPossibleMoves();
					var possibleMoves = king.ChessPiece.GetPossibleMoves();
					var kingMoves = gameplay.GetPossibleMoves(king, turnColor, king.Index, board, possibleMoves, check);
					var enemyColor = gameplay.ChangeColor(turnColor);
					var attackedTiles = gameplay.GetTilesHitByColor(board, enemyColor);
					
					foreach (var attackMove in attackedTiles)
					{
						if (kingMoves.Count == 0)
						{
							break;
						}
						if (kingMoves.Exists(x => x == attackMove.Item1))
						{
							kingMoves.Remove(attackMove.Item1);
						}
					}

					foreach (var attackedTile in attackedTiles.ToArray())
					{
						if (attackedTile.Item1 != king)
						{
							attackedTiles.Remove(attackedTile);
						}
					}
					
					var allAllyMoves = new List<Tile>();
					foreach (var tile in board)
					{
						if (tile.ChessPiece.Color == turnColor && tile != king)
						{
							tile.ChessPiece.FillPossibleMoves();
							var allyPossibleMoves = tile.ChessPiece.GetPossibleMoves();
							var allyMoves = gameplay.GetPossibleMoves(tile, turnColor, tile.Index, board, allyPossibleMoves);
							foreach (var allyMove in allyMoves)
							{
								allAllyMoves.Add(allyMove);
							}
						}
					}
					foreach (var attacker in attackedTiles)
					{
						var tilesToCheck = gameplay.GetAttackedTiles(attacker, king, board);
						foreach (var allyMove in allAllyMoves.ToArray())
						{
							if (!tilesToCheck.Contains(allyMove))
							{
								allAllyMoves.Remove(allyMove);
							}
						}
					}
					
					if (allAllyMoves.Count == 0 && kingMoves.Count == 0)
					{
						var endGameMenu = new EndGame();
						endGameMenu.ShowDialog();
					}
					else if (attackedTiles.Count > 1)
					{
						if (currTile != king)
						{
							MessageBox.Show("Secure your king!");
						}
						else if (currTile == king && currTile.ChessPiece.Color == turnColor)
						{
							foreach (var move in kingMoves)
							{
								move.Image = move.ChessPiece.ImageAfterClick;
								isClicked = true;
								return;
							}
						}
					}
					else if (attackedTiles[0].Item2.ChessPiece.Type == PieceType.Knight)
					{
						if (currTile != king)
						{
							currTile.ChessPiece.FillPossibleMoves();
							var possibleMovesChessPiece = currTile.ChessPiece.GetPossibleMoves();
							var moves = gameplay.GetPossibleMoves(currTile, turnColor, currTile.Index, board, possibleMovesChessPiece);
							foreach (var move in moves)
							{
								if (move == attackedTiles[0].Item2)
								{
									move.Image = move.ChessPiece.ImageAfterClick;
									isClicked = true;
									break;
								}
							}
							if (!isClicked)
							{
								MessageBox.Show("You can't protect your King with this piece");
							}
						}
						else
						{
							foreach (var move in kingMoves)
							{
								move.Image = move.ChessPiece.ImageAfterClick;
							}
							isClicked = true;
						}
					}
					else if (currTile == king)
					{
						foreach (var move in kingMoves)
						{
							move.Image = move.ChessPiece.ImageAfterClick;
						}
						isClicked = true;
					}
					else
					{
						// Find positions between king and attacker
						Tuple<Tile, Tile> attacker = attackedTiles[0];
						var posToCheck = gameplay.GetAttackedTiles(attacker, king, board);
						// Check if clicked piece can protect King
						currTile.ChessPiece.FillPossibleMoves();
						var pieceDefaultMoves = currTile.ChessPiece.GetPossibleMoves();
						var pieceMoves = gameplay.GetPossibleMoves(currTile, turnColor, currTile.Index, board, pieceDefaultMoves);

						foreach(var move in pieceMoves.ToArray())
						{
							if (!posToCheck.Contains(move))
							{
								pieceMoves.Remove(move);
							}
						}



						if (pieceMoves.Count == 0)
						{
							MessageBox.Show("This piece can't protect your King");
						} 
						else
						{
							foreach(var move in pieceMoves)
							{
								move.Image = move.ChessPiece.ImageAfterClick;
							}
							isClicked = true;
						}
					}
				}
				else
                {
                    isClicked = true;
					Tuple<int, int> currIndex = Tuple.Create(currTile.Index.Item1, currTile.Index.Item2);
					prevIndex = currIndex;

					if (currTile.ChessPiece.Type == PieceType.King)
                    {
                        kingClicked = true;
						currTile.ChessPiece.FillPossibleMoves();
						var possibleMovesKing = currTile.ChessPiece.GetPossibleMoves();
						var kingMoves = gameplay.GetPossibleMoves(currTile, turnColor, currTile.Index, board, possibleMovesKing);
						var enemyColor = gameplay.ChangeColor(turnColor);
						var attackedTiles = gameplay.GetTilesHitByColor(board, enemyColor);


						foreach (var attackMove in attackedTiles)
						{
							if (kingMoves.Count == 0)
							{
								break;
							}
							if (kingMoves.Exists(x => x == attackMove.Item1))
							{
								kingMoves.Remove(attackMove.Item1);
							}
						}

						foreach (var move in kingMoves)
						{
							move.Image = move.ChessPiece.ImageAfterClick;
						}
					} else
					{
						currTile.ChessPiece.FillPossibleMoves();
						var possibleMoves = currTile.ChessPiece.GetPossibleMoves();
						if (gameplay.CheckIfCanBeMoved(board, currTile, turnColor))
						{
							gameplay.ShowPossibleMoves(currTile, turnColor, currIndex, board, possibleMoves);
						} 
						else
						{
							MessageBox.Show("You leave your king unprotected!");
						}
					}
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
							if (board[i, j].ChessPiece.Type != PieceType.EmptyPiece)
							{
								board[i, j].Image = board[i, j].ChessPiece.DefaultImage;
							}
							else
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
					if (board[prevRow, prevCol].ChessPiece.Type == PieceType.Pawn || board[prevRow, prevCol].ChessPiece.Type == PieceType.King || board[prevRow, prevCol].ChessPiece.Type == PieceType.Rook)
                    {
                        board[prevRow, prevCol].ChessPiece.hasMoved = true;
                        board[prevRow, prevCol].ChessPiece.FillPossibleMoves();
                    }

                    if (board[row, col].Image == board[row, col].ChessPiece.SpecialImageAfterClick && kingClicked)
                    {
						gameplay.Castling(board, row, col);
                    }

                    kingClicked = false;
                    gameplay.Move(board, row, col, prevRow, prevCol);

					if (board[row, col].ChessPiece.Type == PieceType.Pawn && (row == 0 || row == 7))
					{
						var pawnPromotion = new PawnPromotion(turnColor);
						pawnPromotion.ShowDialog();
						board[row, col].ChessPiece = pawnPromotion.clickedTile.ChessPiece;
					}

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

				check = false;
				if (gameplay.CheckForCheck(board, turnColor))
				{
					check = true;
					MessageBox.Show("You are in check.");
				}
				turnColor = gameplay.ChangeColor(turnColor);
            }
        }

		#endregion
	}
}
