using System;
using Chessboard;

namespace Chess
{
    internal class Rook : Piece
    {
        // AutoProps
        // Constructor
        public Rook(Board board, Color color) : base(board, color) { }

        // Methods
        public override string ToString()
        {
            return "R";
        }
    }
}
