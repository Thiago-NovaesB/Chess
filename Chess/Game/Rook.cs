using Chess.BoardAndPieces;

namespace Chess.Game
{
    internal class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
            { }
        public override string ToString()
        {
            return "R";
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
            while (board.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.line--;
            }

            // down
            pos.setPosition(position.line + 1, position.column);
            while (board.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.line++;
            }

            // right
            pos.setPosition(position.line, position.column + 1);
            while (board.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.column++;
            }

            // left
            pos.setPosition(position.line, position.column - 1);
            while (board.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.column--;
            }
            return mat;
        }
    }
}
