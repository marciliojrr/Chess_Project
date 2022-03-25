using Chessboard;

namespace Chess
{
    internal class King : Piece
    {
        // AutoProps
        private ChessGame match;
        // Constructor
        public King(Board board, Color color, ChessGame match) : base(board, color)
        {
            this.match = match;
        }

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

        private bool rookTestCastling(Position pos)
        {
            Piece p = board.piece(pos);

            return p != null && p is Rook && p.color == this.color && p.numMovements == 0;
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

            // Special Move: Castling 
            if (numMovements == 0 && !match.checkmate)
            {
                // Little castling (Roque pequeno)
                Position rookPosition1 = new Position(position.Row, position.Column + 3);

                if (rookTestCastling(rookPosition1))
                {
                    Position p1 = new Position(position.Row, position.Column + 1);
                    Position p2 = new Position(position.Row, position.Column + 2);

                    if (board.piece(p1) == null && board.piece(p2) == null)
                    {
                        mat[position.Row, position.Column + 2] = true;  
                    }
                }

                // Big castling (Roque grande)
                Position rookPosition2 = new Position(position.Row, position.Column - 4);

                if (rookTestCastling(rookPosition2))
                {
                    Position p1 = new Position(position.Row, position.Column - 1);
                    Position p2 = new Position(position.Row, position.Column - 2);
                    Position p3 = new Position(position.Row, position.Column - 3);

                    if (board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null)
                    {
                        mat[position.Row, position.Column - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
