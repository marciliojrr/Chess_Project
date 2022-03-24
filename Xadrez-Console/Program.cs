using System;
using Chess;
using Chessboard;
using Chessboard.Exceptions;

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
                    try
                    {
                        Console.Clear();
                        Screen.PrintBoard(game.board);

                        Console.WriteLine("\n");
                        Console.WriteLine($"Turn: {game.turn}");
                        Console.WriteLine($"Waiting for player move: {game.currentPlayer}");

                        Console.WriteLine();
                        Console.Write("\nFrom: ");
                        Position from = Screen.readPosition().toPosition();
                        game.validateOriginPosition(from);

                        bool[,] possiblePosition = game.board.piece(from).possibleMoves();

                        Console.Clear();
                        Screen.PrintBoard(game.board, possiblePosition);

                        Console.WriteLine();
                        Console.Write("To: ");
                        Position to = Screen.readPosition().toPosition();
                        game.validateDestinyPosition(from, to);

                        game.makeMove(from, to);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.Write("Press ENTER to try again.");
                        Console.ReadLine();
                    }
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
