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

        public void putPiece(Piece p, Position pos)
        {
            pieces[pos.Row, pos.Column] = p;
            p.position = pos;
        }
    }
}
