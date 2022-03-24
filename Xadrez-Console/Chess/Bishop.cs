using Chessboard;

namespace Chess
{
    internal class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "B";
        }

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.Rows, board.Columns];

            Position pos = new Position(0, 0);

            // NO
            pos.defValues(position.Row - 1, position.Column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.defValues(pos.Row - 1, pos.Column - 1);
            }

            // NE
            pos.defValues(position.Row - 1, position.Column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.defValues(pos.Row - 1, pos.Column + 1);
            }

            // SE
            pos.defValues(position.Row + 1, position.Column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.defValues(pos.Row + 1, pos.Column + 1);
            }

            // SO
            pos.defValues(position.Row + 1, position.Column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.defValues(pos.Row + 1, pos.Column - 1);
            }

            return mat;
        }
    }
}
