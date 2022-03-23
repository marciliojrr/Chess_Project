using System;
using Chessboard;

namespace Xadrez_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8); // Cria um tabuleiro de 8x8 com todos os elementos nulos.
            Screen.PrintBoard(board);
        }
    }
}
