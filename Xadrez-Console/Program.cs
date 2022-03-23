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
                board.putPiece(new Rook(board, Color.Black), new Position(1, 7));
                board.putPiece(new King(board, Color.Black), new Position(0, 2));
                board.putPiece(new Rook(board, Color.White), new Position(3, 4));
                board.putPiece(new King(board, Color.Black), new Position(2, 5));

                Screen.PrintBoard(board);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            /*
            ChessPosition pos = new ChessPosition('a', 1);
            ChessPosition pos1 = new ChessPosition('c', 7);
            Console.WriteLine(pos);
            Console.WriteLine(pos.toPosition());
            
            Console.WriteLine(pos1);
            Console.WriteLine(pos1.toPosition());
            */
        }
    }
}
