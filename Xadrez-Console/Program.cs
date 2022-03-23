using System;
using Chess;
using Chessboard;

namespace Xadrez_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8); // Cria um tabuleiro de 8x8 com todos os elementos nulos.

            board.putPiece(new Rook(board, Color.Black), new Position(0, 0));
            board.putPiece(new Rook(board, Color.Black), new Position(1, 3));
            board.putPiece(new King(board, Color.Black), new Position(2, 4));

            Screen.PrintBoard(board);
        }
    }
}
