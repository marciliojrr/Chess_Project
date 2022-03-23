namespace Chessboard
{
    internal class Position
    {
        // AutoProps
        public int Row { get; set; }
        public int Column { get; set; }

        // Constructors
        public Position(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public void defValues(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
        public override string ToString()
        {
            return $"{Row}, {Column}";
        }
    }
}
