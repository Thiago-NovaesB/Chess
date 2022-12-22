using Chess.BoardAndPieces;

namespace Chess.Game
{
    internal class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
            { }
        public override string ToString()
        {
            return "K";
        }
    }
}
