using System;
using Chessboard;
using Chessboard.Exceptions;

namespace Chess
{
    internal class ChessGame
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
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

        public void makeMove(Position from, Position to)
        {
            performMovement(from, to);
            turn++;
            changePlayer();
        }

        public void validateOriginPosition(Position pos)
        {
            if (board.piece(pos) == null)
            {
                throw new BoardException("There is no part in the chosen origin position.");
            }

            if (currentPlayer != board.piece(pos).color)
            {
                throw new BoardException("The original part chosen is not yours.");
            }

            if (!board.piece(pos).thereArePossibleMoves())
            {
                throw new BoardException("There are no possible moves for the chosen piece.");
            }
        }

        public void validateDestinyPosition(Position from, Position to)
        {
            if (!board.piece(from).canMoveToDestination(to))
            {
                throw new BoardException("Invalid target position.");
            }
        }

        private void changePlayer()
        {
            if (currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
        }
    }
}
