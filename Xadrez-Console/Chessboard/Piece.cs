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

        public abstract bool[,] possibleMoves();
    }
}
