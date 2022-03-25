using Chessboard;

namespace Chess
{

    class Pawn : Piece
    {
        private ChessGame match;
        public Pawn(Board board, Color color, ChessGame match) : base(board, color)
        {
            this.match = match;
        }

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

                // Special move: En Passant
                if (position.Row == 3)
                {
                    Position leftPosition = new Position(position.Row, position.Column - 1);
                    if (board.validPosition(leftPosition) && hasEnemy(leftPosition) && board.piece(leftPosition) == match.vulnerableEnPassant)
                    {
                        mat[leftPosition.Row - 1, leftPosition.Column] = true;
                    }

                    Position rightPosition = new Position(position.Row, position.Column + 1);
                    if (board.validPosition(rightPosition) && hasEnemy(rightPosition) && board.piece(rightPosition) == match.vulnerableEnPassant)
                    {
                        mat[rightPosition.Row - 1, rightPosition.Column] = true;
                    }
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

                // Special move: En Passant
                if (position.Row == 4)
                {
                    Position leftPosition = new Position(position.Row, position.Column - 1);
                    if (board.validPosition(leftPosition) && hasEnemy(leftPosition) && board.piece(leftPosition) == match.vulnerableEnPassant)
                    {
                        mat[leftPosition.Row + 1, leftPosition.Column] = true;
                    }

                    Position rightPosition = new Position(position.Row, position.Column + 1);
                    if (board.validPosition(rightPosition) && hasEnemy(rightPosition) && board.piece(rightPosition) == match.vulnerableEnPassant)
                    {
                        mat[rightPosition.Row + 1, rightPosition.Column] = true;
                    }
                }
            }

            return mat;
        }
    }
}
