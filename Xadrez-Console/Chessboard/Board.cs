namespace Chessboard
{
    internal class Board
    {
        // AutoProps
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        public Board(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            pieces = new Piece[rows, columns];
        }
    }
}
