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
                ChessGame game = new ChessGame();

                while (!game.finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(game.board);

                    Console.Write("\nFrom: ");
                    Position from = Screen.readPosition().toPosition();
                    Console.Write("To: ");
                    Position to = Screen.readPosition().toPosition();

                    game.performMovement(from, to);
                }

                Screen.PrintBoard(game.board);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            Console.ReadLine();

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
