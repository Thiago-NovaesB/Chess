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

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }
        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            // up
            pos.setPosition(position.line - 1, position.column);
            if (board.positionIsValid(pos) && canMove(pos));
            {
                mat[pos.line, pos.column] = true;
            }
            // upleft
            pos.setPosition(position.line - 1, position.column - 1);
            if (board.positionIsValid(pos) && canMove(pos)) ;
            {
                mat[pos.line, pos.column] = true;
            }
            // left
            pos.setPosition(position.line, position.column - 1);
            if (board.positionIsValid(pos) && canMove(pos)) ;
            {
                mat[pos.line, pos.column] = true;
            }
            // downleft
            pos.setPosition(position.line + 1, position.column - 1);
            if (board.positionIsValid(pos) && canMove(pos)) ;
            {
                mat[pos.line, pos.column] = true;
            }
            // down
            pos.setPosition(position.line + 1, position.column);
            if (board.positionIsValid(pos) && canMove(pos)) ;
            {
                mat[pos.line, pos.column] = true;
            }
            // upright
            pos.setPosition(position.line + 1, position.column + 1);
            if (board.positionIsValid(pos) && canMove(pos)) ;
            {
                mat[pos.line, pos.column] = true;
            }
            // right
            pos.setPosition(position.line, position.column + 1);
            if (board.positionIsValid(pos) && canMove(pos)) ;
            {
                mat[pos.line, pos.column] = true;
            }
            // downright
            pos.setPosition(position.line - 1, position.column + 1);
            if (board.positionIsValid(pos) && canMove(pos)) ;
            {
                mat[pos.line, pos.column] = true;
            }
            return mat;
        }
    }
}
