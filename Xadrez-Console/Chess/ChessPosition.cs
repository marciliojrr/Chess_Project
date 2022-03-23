using Chessboard;

namespace Chess
{
    internal class ChessPosition
    {
        // AutoProps
        public char Column { get; set; }
        public int Row { get; set; }

        // Constructor
        public ChessPosition(char column, int row)
        {
            this.Column = column;
            this.Row = row;
        }

        // Methods
        public Position toPosition() // Metodo para converter as posicoes do tabuleiro para posições válidas na matriz
        {
            return new Position(8 - Row, Column - 'a');   
        }

        public override string ToString()
        {
            return "" + Column + Row;
        }
    }
}
