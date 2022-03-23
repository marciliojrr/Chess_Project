using System;
using Chessboard;

namespace Chess
{
    internal class ChessGame
    {
        public Board board { get; private set; }
        private int turno;
        private Color jogadorAtual;
        public bool finished { get; private set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            turno = 1;
            jogadorAtual = Color.White;
            finished = false;
            putPieces();
        }

        // Methods

        private void putPieces()
        {
            board.putPiece(new Rook(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('c', 2).toPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('d', 2).toPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('e', 2).toPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('e', 1).toPosition());
            board.putPiece(new King(board, Color.White), new ChessPosition('d', 1).toPosition());

            board.putPiece(new Rook(board, Color.Black), new ChessPosition('c', 7).toPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('c', 8).toPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('d', 7).toPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('e', 7).toPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('e', 8).toPosition());
            board.putPiece(new King(board, Color.Black), new ChessPosition('d', 8).toPosition());
        }
        public void performMovement(Position from, Position to)
        {
            Piece p = board.removePiece(from);
            p.incrementMovementQuantity();
            Piece capturedPiece = board.removePiece(to);
            board.putPiece(p, to);
        }
    }
}
