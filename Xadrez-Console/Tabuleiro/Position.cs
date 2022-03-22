namespace Tabuleiro
{
    internal class Position
    {
        // AutoProps
        public int Linha { get; set; }
        public int Coluna { get; set; }

        // Constructors
        public Position(int linha, int coluna)
        {
            this.Linha = linha;
            this.Coluna = coluna;
        }

        public override string ToString()
        {
            return $"{Linha}, {Coluna}";
        }
    }

}
