﻿using Chess.BoardAndPieces;

namespace Chess.Game
{
    internal class ChessPosition
    {
        public char column { get; set; }
        public int line { get; set; }


        public ChessPosition(char column, int line)
        {
            this.column = column;
            this.line = line;
        }
        public Position toPosition()
        {
            return new Position(8 - line, column - 'A');
        }
        public override string ToString()
        {
            return column.ToString() + line.ToString();
        }
    }
}
