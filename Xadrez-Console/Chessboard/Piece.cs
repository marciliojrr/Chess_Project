namespace Chessboard
{
    internal class Piece
    {
        // Props
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int numMovements { get; protected set; }
        public Board board { get; protected set; }

        // Constructors
        public Piece(Position position, Board board, Color color)
        {
            this.position = position;
            this.board = board;
            this.color = color;
            this.numMovements = 0;
        }
    }
}
