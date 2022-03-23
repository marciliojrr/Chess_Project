using Chessboard.Exceptions;

namespace Chessboard
{
    internal class Board
    {
        // AutoProps
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        // Constructor
        public Board(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            pieces = new Piece[rows, columns];
        }

        // Methods
        /*
         * Metodo para poder buscar uma peca da matriz
         * de pecas, uma vez que ela foi declarada como
         * 'private'. O metodo abaixo, por ser 'public',
         * fornece uma peca em determinada linha e coluna.
         */
        public Piece piece(int row, int column)
        {
            return pieces[row, column];
        }

        public Piece piece(Position pos)
        {
            return pieces[pos.Row, pos.Column];
        }

        public bool occupiedPosition(Position pos)
        {
            validatePosition(pos);
            return piece(pos) != null;
        }

        public void putPiece(Piece p, Position pos)
        {
            if (occupiedPosition(pos))
            {
                throw new BoardException("There is already a piece in that position.");
            }
            pieces[pos.Row, pos.Column] = p;
            p.position = pos;
        }

        public Piece removePiece(Position pos)
        {
            if (piece(pos) == null)
            {
                return null;
            }
            Piece aux = piece(pos);
            aux.position = null;
            pieces[pos.Row, pos.Column] = null;
            return aux;
        }

        public bool validPosition(Position pos)
        {
            if (pos.Row < 0 || pos.Row >= Rows || pos.Column < 0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void validatePosition(Position pos)
        {
            if (!validPosition(pos))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}
