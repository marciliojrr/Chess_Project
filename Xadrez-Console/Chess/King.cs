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

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != this.color; 
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.Rows, board.Columns];

            Position pos = new Position(0, 0);

            // North
            pos.defValues(position.Row - 1, position.Column);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // Northeast
            pos.defValues(position.Row - 1, position.Column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // East
            pos.defValues(position.Row, position.Column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // Southeast
            pos.defValues(position.Row + 1, position.Column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // South
            pos.defValues(position.Row + 1, position.Column);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // South-west
            pos.defValues(position.Row + 1, position.Column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // West
            pos.defValues(position.Row, position.Column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // Northwest
            pos.defValues(position.Row - 1, position.Column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            
            return mat;
        }
    }
}
