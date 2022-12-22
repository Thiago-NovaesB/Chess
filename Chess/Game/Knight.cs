using Chess.BoardAndPieces;

namespace Chess.Game
{
    internal class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
            { }
        public override string ToString()
        {
            return "N";
        }
    }
}
