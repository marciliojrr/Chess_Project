using System;
using Chessboard;

namespace Xadrez_Console
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write($"{board.piece(i, j)} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
