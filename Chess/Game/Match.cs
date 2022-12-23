using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using Chess.BoardAndPieces;

namespace Chess.Game
{
    internal class Match
    {
        public Board board { get; private set ;}
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool check { get; private set; }

        public Match()
        {
            board = new Board(8,8);
            turn = 1;
            currentPlayer = Color.White;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            initialPosition();
            finished = false;
            check = false;
        }

        public Piece executeMove(Position origin, Position destiny)
        {
            Piece? p = board.removePiece(origin);
            p.increaseCountMoves();
            Piece capturedPiece = board.removePiece(destiny);
            board.addPiece(p, destiny);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
            return capturedPiece;
        }
        public void undoMove(Position origin, Position destiny, Piece? capturedPiece)
        {
            Piece? p = board.removePiece(destiny);
            p.decreaseCountMoves();
            if (capturedPiece != null)
            {
                board.addPiece(capturedPiece, destiny);
                captured.Remove(capturedPiece);
            }
            board.addPiece(p, origin);
        }

        public void playerTime(Position origin, Position destiny)
        {
            Piece capturedPiece = executeMove(origin, destiny);
            if (isInCheck(currentPlayer))
            {
                undoMove(origin, destiny, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }
            if (isInCheck(opponent(currentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }
            turn++;
            changePlayer();
        }

        public void changePlayer()
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

        public void validateOriginPosition(Position pos)
        {
            if (board.piece(pos) == null)
            {
                throw new BoardException("Empty position!");
            }
            if (currentPlayer != board.piece(pos).color)
            {
                throw new BoardException("Can't move opponent piece!");
            }
            if (!board.piece(pos).existPossibleMove())
            {
                throw new BoardException("This piece can't move!");
            }
        }

        public void validateDestinyPosition(Position origin, Position destiny)
        {
            if (!board.piece(origin).canMoveTo(destiny))
            {
                throw new BoardException("Destiny position invalid!");
            }
           
        }

        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> temp = new HashSet<Piece>();
            foreach (Piece p in captured)
            {
                if (p.color == color)
                {
                    temp.Add(p);
                }
            }
            return temp;
        }
        public HashSet<Piece> inGamePieces(Color color)
        {
            HashSet<Piece> temp = new HashSet<Piece>();
            foreach (Piece p in pieces)
            {
                if (p.color == color)
                {
                    temp.Add(p);
                }
            }
            temp.ExceptWith(capturedPieces(color));
            return temp;
        }

        private Color opponent(Color color)
        {
            if (color == Color.White)
                return Color.Black;
            else
            {
                return Color.White;
            }
        }

        private Piece? king(Color color)
        {
            foreach (Piece p in inGamePieces(color))
            {
                if (p is King)
                {
                    return p;
                }
            }
            return null;
        }

        public bool isInCheck(Color color)
        {
            Piece K = king(color);
            if (K == null)
            {
                throw new BoardException("Missing King!");
            }
            foreach (Piece p in inGamePieces(opponent(color)))
            {
                bool[,] temp = p.possibleMoves();
                if (temp[K.position.line, K.position.column])
                {
                    return true;
                }
            }
            return false;
        }

        public void addNewPiece(Piece piece, char column, int line)
        {
            board.addPiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void initialPosition()
        {
            addNewPiece(new Rook(board, Color.White), 'A', 1);
            addNewPiece(new Rook(board, Color.White), 'H', 1);
            addNewPiece(new Knight(board, Color.White),'B', 1);
            addNewPiece(new Knight(board, Color.White), 'G', 1);
            addNewPiece(new Bishop(board, Color.White), 'C', 1);
            addNewPiece(new Bishop(board, Color.White), 'F', 1);
            addNewPiece(new Queen(board, Color.White), 'D', 1);
            addNewPiece(new King(board, Color.White), 'E', 1);

            /*addNewPiece(new Pawn(board, Color.White), 'A', 2);
            addNewPiece(new Pawn(board, Color.White), 'H', 2);
            addNewPiece(new Pawn(board, Color.White), 'B', 2);
            addNewPiece(new Pawn(board, Color.White), 'G', 2);
            addNewPiece(new Pawn(board, Color.White), 'C', 2);
            addNewPiece(new Pawn(board, Color.White), 'F', 2);
            addNewPiece(new Pawn(board, Color.White), 'D', 2);
            addNewPiece(new Pawn(board, Color.White), 'E', 2);*/

            addNewPiece(new Rook(board, Color.Black), 'A', 8);
            addNewPiece(new Rook(board, Color.Black), 'H', 8);
            addNewPiece(new Knight(board, Color.Black), 'B', 8);
            addNewPiece(new Knight(board, Color.Black), 'G', 8);
            addNewPiece(new Bishop(board, Color.Black), 'C', 8);
            addNewPiece(new Bishop(board, Color.Black), 'F', 8);
            addNewPiece(new Queen(board, Color.Black), 'D', 8);
            addNewPiece(new King(board, Color.Black), 'E', 8);

            /*addNewPiece(new Pawn(board, Color.Black), 'A', 7);
            addNewPiece(new Pawn(board, Color.Black), 'H', 7);
            addNewPiece(new Pawn(board, Color.Black), 'B', 7);
            addNewPiece(new Pawn(board, Color.Black), 'G', 7);
            addNewPiece(new Pawn(board, Color.Black), 'C', 7);
            addNewPiece(new Pawn(board, Color.Black), 'F', 7);
            addNewPiece(new Pawn(board, Color.Black), 'D', 7);
            addNewPiece(new Pawn(board, Color.Black), 'E', 7);*/
        }
    }
}
