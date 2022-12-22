namespace Chess.BoardAndPieces
{
    internal abstract class Piece
    {
        public Position? position { get; set; }
        public Color color { get; protected set; }
        public int countMoves { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board board, Color color)
        {
            this.color = color;
            this.board = board;
            this.position = null;
            countMoves = 0;
        }
        public void increseCountMoves()
        {
            countMoves++;
        }

        public abstract bool[,] possibleMoves();
    }

}
