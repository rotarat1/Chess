﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
	public enum Direction
	{
		None,
		Forward,
		Backward,
		ForwardLeft,
		ForwardRight,
		BackwardLeft,
		BackwardRight,
		Left,
		Right,
        Special
	}
	public enum MovementType
	{
		None,
		Single,
		Multiple,
		Knight,
		Double,
        PawnTake,
		Castling
	}
	public enum Colour
	{
		Black,
		White,
		Colorless
	}
	public abstract class ChessPiece
	{
		public List<Tuple<Direction, MovementType>> possibleMoves;
		public Colour Color { get; protected set; }
        public bool hasMoved { get; set; }
        public string Type { get; set; }
        public Image DefaultImage { get; set; }
        public Image ImageAfterClick { get; protected set; }
        public Image SpecialImageAfterClick { get; protected set; }


        public ChessPiece(Colour color, string type)
		{
			Color = color;
            Type = type;
            possibleMoves = new List<Tuple<Direction, MovementType>>();

        }

        public abstract void FillPossibleMoves();
		public List<Tuple<Direction, MovementType>> GetPossibleMoves()
		{
			return possibleMoves;
		}
	}
}
