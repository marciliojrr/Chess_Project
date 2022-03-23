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
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.Row--;
            }

            // South
            pos.defValues(position.Row + 1, position.Column);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.Row++;
            }

            // East
            pos.defValues(position.Row, position.Column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.Column++;
            }

            // West
            pos.defValues(position.Row, position.Column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.Column--;
            }



            return mat;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
