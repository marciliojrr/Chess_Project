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
        public Piece vulnerableEnPassant { get; private set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            checkmate = false;
            vulnerableEnPassant = null;
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
            // White pieces
            putNewPiece('a', 1, new Rook(board, Color.White));
            putNewPiece('b', 1, new Horse(board, Color.White));
            putNewPiece('c', 1, new Bishop(board, Color.White));
            putNewPiece('d', 1, new Queen(board, Color.White));
            putNewPiece('e', 1, new King(board, Color.White, this)); // 'this' = auto referencia para a partida, foi necessario para a criacao da jogada roque
            putNewPiece('f', 1, new Bishop(board, Color.White));
            putNewPiece('g', 1, new Horse(board, Color.White));
            putNewPiece('h', 1, new Rook(board, Color.White));
            putNewPiece('a', 2, new Pawn(board, Color.White, this));
            putNewPiece('b', 2, new Pawn(board, Color.White, this));
            putNewPiece('c', 2, new Pawn(board, Color.White, this));
            putNewPiece('d', 2, new Pawn(board, Color.White, this));
            putNewPiece('e', 2, new Pawn(board, Color.White, this));
            putNewPiece('f', 2, new Pawn(board, Color.White, this));
            putNewPiece('g', 2, new Pawn(board, Color.White, this));
            putNewPiece('h', 2, new Pawn(board, Color.White, this));

            // Black pieces
            putNewPiece('a', 8, new Rook(board, Color.Black));
            putNewPiece('b', 8, new Horse(board, Color.Black));
            putNewPiece('c', 8, new Bishop(board, Color.Black));
            putNewPiece('d', 8, new Queen(board, Color.Black));
            putNewPiece('e', 8, new King(board, Color.Black, this));
            putNewPiece('f', 8, new Bishop(board, Color.Black));
            putNewPiece('g', 8, new Horse(board, Color.Black));
            putNewPiece('h', 8, new Rook(board, Color.Black));
            putNewPiece('a', 7, new Pawn(board, Color.Black, this));
            putNewPiece('b', 7, new Pawn(board, Color.Black, this));
            putNewPiece('c', 7, new Pawn(board, Color.Black, this));
            putNewPiece('d', 7, new Pawn(board, Color.Black, this));
            putNewPiece('e', 7, new Pawn(board, Color.Black, this));
            putNewPiece('f', 7, new Pawn(board, Color.Black, this));
            putNewPiece('g', 7, new Pawn(board, Color.Black, this));
            putNewPiece('h', 7, new Pawn(board, Color.Black, this));

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

            // Special move: Little Castling (Roque pequeno)
            if (p is King && to.Column == from.Column + 2)
            {
                Position originTowerPosition = new Position(from.Row, from.Column + 3);
                Position destinationTowerPosition = new Position(from.Row, from.Column + 1);
                Piece rook = board.removePiece(originTowerPosition);
                rook.incrementMovementQuantity();
                board.putPiece(rook, destinationTowerPosition);
            }

            // Special move: Big Castling (Roque grande)
            if (p is King && to.Column == from.Column - 2)
            {
                Position originTowerPosition = new Position(from.Row, from.Column - 4);
                Position destinationTowerPosition = new Position(from.Row, from.Column - 1);
                Piece rook = board.removePiece(originTowerPosition);
                rook.incrementMovementQuantity();
                board.putPiece(rook, destinationTowerPosition);
            }

            // Special move: En Passant
            if (p is Pawn)
            {
                if (from.Column != to.Column && capturedPiece == null) // caracteriza o en passant
                {
                    Position posP;
                    if (p.color == Color.White)
                    {
                        posP = new Position(to.Row + 1, to.Column);
                    }
                    else
                    {
                        posP = new Position(to.Row - 1, to.Column);
                    }
                    capturedPiece = board.removePiece(posP);
                    captured.Add(capturedPiece);
                }
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

            // Special move: Little Castling (Roque pequeno)
            if (p is King && to.Column == from.Column + 2)
            {
                Position originTowerPosition = new Position(from.Row, from.Column + 3);
                Position destinationTowerPosition = new Position(from.Row, from.Column + 1);
                Piece rook = board.removePiece(destinationTowerPosition);
                rook.decreaseMovementQuantity();
                board.putPiece(rook, originTowerPosition);
            }

            // Special move: Big Castling (Roque grande)
            if (p is King && to.Column == from.Column - 2)
            {
                Position originTowerPosition = new Position(from.Row, from.Column - 4);
                Position destinationTowerPosition = new Position(from.Row, from.Column - 1);
                Piece rook = board.removePiece(destinationTowerPosition);
                rook.decreaseMovementQuantity();
                board.putPiece(rook, originTowerPosition);
            }

            // Special move: En Passant
            if (p is Pawn)
            {
                if (from.Column != to.Column && capturedPiece == vulnerableEnPassant)
                {
                    Piece pawn = board.removePiece(to);
                    Position posP;
                    if (p.color == Color.White)
                    {
                        posP = new Position(3, to.Column);
                    }
                    else
                    {
                        posP = new Position(4, to.Column);
                    }
                    board.putPiece(pawn, posP);
                }
            }
        }

        public void makeMove(Position from, Position to)
        {
            Piece capturedPiece = performMovement(from, to);

            if (isInCheck(currentPlayer))
            {
                undoMove(from, to, capturedPiece);
                throw new BoardException("You cannot put yourself in checkmate position.");
            }

            Piece p = board.piece(to);

            // Special move: Promotion
            if (p is Pawn)
            {
                if ((p.color == Color.White && to.Row == 0) || (p.color == Color.Black && to.Row == 7))
                {
                    p = board.removePiece(to);
                    pieces.Remove(p);
                    Piece queen = new Queen(board, p.color); // Depois implementar escolha entre Dama, Torre, Bispo ou Cavalo
                    board.putPiece(queen, to);
                    pieces.Add(queen);
                }
            }

            if (isInCheck(adversary(currentPlayer)))
            {
                checkmate = true;
            }
            else
            {
                checkmate = false;
            }

            if (checkMateTest(adversary(currentPlayer)))
            {
                finished = true;
            }
            else
            {
                turn++;
                changePlayer();
            }

            // Special move: En Passant
            if (p is Pawn && (to.Row == from.Row - 2 || to.Row == from.Row + 2))
            {
                vulnerableEnPassant = p;
            }
            else
            {
                vulnerableEnPassant = null;
            }
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

        public bool checkMateTest(Color color)
        {
            if (!isInCheck(color))
            {
                return false;
            }
            
            foreach(Piece x in piecesInGame(color))
            {
                bool[,] mat = x.possibleMoves();

                for (int i = 0; i < board.Rows; i++)
                {
                    for (int j = 0; j < board.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position from = x.position;
                            Position to = new Position(i, j);
                            Piece capturedPiece = performMovement(from, to);
                            bool checkTest = isInCheck(color);
                            undoMove(from, to, capturedPiece);

                            if (!checkTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
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
