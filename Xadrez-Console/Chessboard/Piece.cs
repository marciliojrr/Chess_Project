namespace Chessboard
{
    internal abstract class Piece
    {
        // Props
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int numMovements { get; protected set; }
        public Board board { get; protected set; }

        // Constructors
        public Piece(Board board, Color color)
        {
            this.position = null;
            this.board = board;
            this.color = color;
            this.numMovements = 0;
        }

        // Methods
        public void incrementMovementQuantity()
        {
            this.numMovements++;
        }

        public bool thereArePossibleMoves()
        {
            bool[,] mat = possibleMoves();

            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool canMoveToDestination(Position pos)
        {
            return possibleMoves()[pos.Row, pos.Column];
        }

        public abstract bool[,] possibleMoves();
    }
}
