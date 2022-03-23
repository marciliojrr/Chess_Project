using System;
using Chess;
using Chessboard;

namespace Xadrez_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8); // Cria um tabuleiro de 8x8 com todos os elementos nulos.

                board.putPiece(new Rook(board, Color.Black), new Position(0, 0));
                board.putPiece(new Rook(board, Color.Black), new Position(1, 9));
                board.putPiece(new King(board, Color.Black), new Position(0, 2));

                Screen.PrintBoard(board);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
