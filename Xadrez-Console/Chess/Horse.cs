using Chessboard;

namespace Chess
{

    internal class Horse : Piece
    {

        public Horse(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "H";
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

            pos.defValues(position.Row - 1, position.Column - 2);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.defValues(position.Row - 2, position.Column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.defValues(position.Row - 2, position.Column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.defValues(position.Row - 1, position.Column + 2);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.defValues(position.Row + 1, position.Column + 2);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.defValues(position.Row + 2, position.Column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.defValues(position.Row + 2, position.Column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.defValues(position.Row + 1, position.Column - 2);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            return mat;
        }
    }
}
