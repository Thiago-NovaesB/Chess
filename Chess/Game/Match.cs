using Chess.BoardAndPieces;

namespace Chess.Game
{
    internal class Match
    {
        public Board board { get; private set ;}
        private int turn;
        private Color currentPlayer;
        public bool finished { get; private set; }

        public Match()
        {
            board = new Board(8,8);
            turn = 1;
            currentPlayer = Color.White;
            initialPosition();
            finished = false;
        }

        public void executeMove(Position origin, Position destiny)
        {
            Piece? p = board.removePiece(origin);
            p.increseCountMoves();
            Piece pieceRemoved = board.removePiece(destiny);
            board.addPiece(p, destiny);
        }
        private void initialPosition()
        {
            board.addPiece(new Rook(board, Color.White), new ChessPosition('A', 1).toPosition());
            board.addPiece(new Rook(board, Color.White), new ChessPosition('H', 1).toPosition());
            board.addPiece(new Knight(board, Color.White), new ChessPosition('B', 1).toPosition());
            board.addPiece(new Knight(board, Color.White), new ChessPosition('G', 1).toPosition());
            board.addPiece(new Bishop(board, Color.White), new ChessPosition('C', 1).toPosition());
            board.addPiece(new Bishop(board, Color.White), new ChessPosition('F', 1).toPosition());
            board.addPiece(new Queen(board, Color.White), new ChessPosition('D', 1).toPosition());
            board.addPiece(new King(board, Color.White), new ChessPosition('E', 1).toPosition());

            board.addPiece(new Pawn(board, Color.White), new ChessPosition('A', 2).toPosition());
            board.addPiece(new Pawn(board, Color.White), new ChessPosition('H', 2).toPosition());
            board.addPiece(new Pawn(board, Color.White), new ChessPosition('B', 2).toPosition());
            board.addPiece(new Pawn(board, Color.White), new ChessPosition('G', 2).toPosition());
            board.addPiece(new Pawn(board, Color.White), new ChessPosition('C', 2).toPosition());
            board.addPiece(new Pawn(board, Color.White), new ChessPosition('F', 2).toPosition());
            board.addPiece(new Pawn(board, Color.White), new ChessPosition('D', 2).toPosition());
            board.addPiece(new Pawn(board, Color.White), new ChessPosition('E', 2).toPosition());

            board.addPiece(new Rook(board, Color.Black), new ChessPosition('A', 8).toPosition());
            board.addPiece(new Rook(board, Color.Black), new ChessPosition('H', 8).toPosition());
            board.addPiece(new Knight(board, Color.Black), new ChessPosition('B', 8).toPosition());
            board.addPiece(new Knight(board, Color.Black), new ChessPosition('G', 8).toPosition());
            board.addPiece(new Bishop(board, Color.Black), new ChessPosition('C', 8).toPosition());
            board.addPiece(new Bishop(board, Color.Black), new ChessPosition('F', 8).toPosition());
            board.addPiece(new Queen(board, Color.Black), new ChessPosition('D', 8).toPosition());
            board.addPiece(new King(board, Color.Black), new ChessPosition('E', 8).toPosition());

            board.addPiece(new Pawn(board, Color.Black), new ChessPosition('A', 7).toPosition());
            board.addPiece(new Pawn(board, Color.Black), new ChessPosition('H', 7).toPosition());
            board.addPiece(new Pawn(board, Color.Black), new ChessPosition('B', 7).toPosition());
            board.addPiece(new Pawn(board, Color.Black), new ChessPosition('G', 7).toPosition());
            board.addPiece(new Pawn(board, Color.Black), new ChessPosition('C', 7).toPosition());
            board.addPiece(new Pawn(board, Color.Black), new ChessPosition('F', 7).toPosition());
            board.addPiece(new Pawn(board, Color.Black), new ChessPosition('D', 7).toPosition());
            board.addPiece(new Pawn(board, Color.Black), new ChessPosition('E', 7).toPosition());

        }
    }
}
