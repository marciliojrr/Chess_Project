using System;

namespace Chessboard.Exceptions
{
    internal class BoardException : Exception
    {
        public BoardException(string msg) : base(msg) { }
    }
}
