using Chess.BoardAndPieces;

namespace Chess.Game
{
    internal class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
            { }
        public override string ToString()
        {
            return "Q";
        }
    }
}
