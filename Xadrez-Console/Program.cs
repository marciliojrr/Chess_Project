﻿using System;
using Chessboard;

namespace Xadrez_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Position P = new Position(3, 4);
            Console.WriteLine($"Position: {P}");

            Board board = new Board(8, 8);
            Console.WriteLine();
        }
    }
}
