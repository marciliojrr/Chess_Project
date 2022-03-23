using System;
using Chessboard;

namespace Chess
{
    internal class King : Piece
    {
        // AutoProps
        // Constructor
        public King(Board board, Color color) : base(board, color) { }

        // Methods
        public override string ToString()
        {
            return "K";
        }
    }
}
