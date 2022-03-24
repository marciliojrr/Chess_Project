using System.Collections.Generic;
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
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool checkmate { get; private set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            checkmate = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            putPieces();
        }

        // Methods
        public void putNewPiece(char column, int row, Piece piece)
        {
            board.putPiece(piece, new ChessPosition(column, row).toPosition());
            pieces.Add(piece);
        }

        private void putPieces()
        {
            putNewPiece('c', 1, new Rook(board, Color.White));
            putNewPiece('c', 2, new Rook(board, Color.White));
            putNewPiece('d', 2, new Rook(board, Color.White));
            putNewPiece('e', 2, new Rook(board, Color.White));
            putNewPiece('e', 1, new Rook(board, Color.White));
            putNewPiece('d', 1, new King(board, Color.White));

            putNewPiece('c', 7, new Rook(board, Color.Black));
            putNewPiece('c', 8, new Rook(board, Color.Black));
            putNewPiece('d', 7, new Rook(board, Color.Black));
            putNewPiece('e', 7, new Rook(board, Color.Black));
            putNewPiece('e', 8, new Rook(board, Color.Black));
            putNewPiece('d', 8, new King(board, Color.Black));

        }
        public Piece performMovement(Position from, Position to)
        {
            Piece p = board.removePiece(from);
            p.incrementMovementQuantity();
            Piece capturedPiece = board.removePiece(to);
            board.putPiece(p, to);

            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }

            return capturedPiece;
        }

        public void undoMove(Position from, Position to, Piece capturedPiece)
        {
            Piece p = board.removePiece(to);
            p.decreaseMovementQuantity();

            if (capturedPiece != null)
            {
                board.putPiece(capturedPiece, to);
                captured.Remove(capturedPiece);
            }
            board.putPiece(p, from);
        }

        public void makeMove(Position from, Position to)
        {
            Piece capturedPiece = performMovement(from, to);

            if (isInCheck(currentPlayer))
            {
                undoMove(from, to, capturedPiece);
                throw new BoardException("You cannot put yourself in checkmate position.");
            }

            if (isInCheck(adversary(currentPlayer)))
            {
                checkmate = true;
            }
            else
            {
                checkmate = false;
            }

            turn++;
            changePlayer();
        }


        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> piecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));

            return aux;
        }

        private Color adversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece king(Color color)
        {
            foreach (Piece x in piecesInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool isInCheck(Color color)
        {
            Piece K = king(color);
            if (K == null)
            {
                throw new BoardException($"There is no {color} king on the board.");
            }

            foreach (Piece x in piecesInGame(adversary(color)))
            {
                bool[,] mat = x.possibleMoves();

                if (mat[K.position.Row, K.position.Column])
                {
                    return true;
                }
            }
            return false;
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
