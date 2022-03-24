using Chessboard;

namespace Chess
{

    class Pawn : Piece
    {

        public Pawn(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "P";
        }

        private bool hasEnemy(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p.color != color;
        }

        private bool free(Position pos)
        {
            return board.piece(pos) == null;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.Rows, board.Columns];

            Position pos = new Position(0, 0);

            if (color == Color.White)
            {
                pos.defValues(position.Row - 1, position.Column);
                if (board.validPosition(pos) && free(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.defValues(position.Row - 2, position.Column);
                Position p2 = new Position(position.Row - 1, position.Column);
                if (board.validPosition(p2) && free(p2) && board.validPosition(pos) && free(pos) && numMovements == 0)
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.defValues(position.Row - 1, position.Column - 1);
                if (board.validPosition(pos) && hasEnemy(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.defValues(position.Row - 1, position.Column + 1);
                if (board.validPosition(pos) && hasEnemy(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
            }
            else
            {
                pos.defValues(position.Row + 1, position.Column);
                if (board.validPosition(pos) && free(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.defValues(position.Row + 2, position.Column);
                Position p2 = new Position(position.Row + 1, position.Column);
                if (board.validPosition(p2) && free(p2) && board.validPosition(pos) && free(pos) && numMovements == 0)
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.defValues(position.Row + 1, position.Column - 1);
                if (board.validPosition(pos) && hasEnemy(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.defValues(position.Row + 1, position.Column + 1);
                if (board.validPosition(pos) && hasEnemy(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
            }

            return mat;
        }
    }
}
