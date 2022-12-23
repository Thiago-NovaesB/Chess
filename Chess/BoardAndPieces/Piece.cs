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

        public bool existPossibleMove()
        {
            bool[,] temp = possibleMoves();
            for (int i = 0; i < board.lines; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    if (temp[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool canMoveTo(Position pos)
        {
            return possibleMoves()[pos.line, pos.column];
        }

        public abstract bool[,] possibleMoves();
    }

}
