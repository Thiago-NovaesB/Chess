﻿namespace Chess.BoardAndPieces
{
    internal class Board
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[lines, columns];
        }
        public Piece piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece piece(Position pos)
        {
            return pieces[pos.line, pos.column];
        }

        public void addPiece(Piece p, Position pos)
        {
            if (existPiece(pos))
            {
                throw new BoardException("Already exists a piece");
            }
            pieces[pos.line, pos.column] = p;
            p.position = pos;
        }

        public bool existPiece(Position pos)
        {
            validatePosition(pos);
            return piece(pos) != null;
        }

        public bool positionIsValid(Position pos)
        {
            return !(pos.line < 0 || pos.line >= lines || pos.column < 0 || pos.column >= columns);
        }
        public void validatePosition(Position pos)
        {
            if (!positionIsValid(pos))
            {
                throw new BoardException("Invalid Position");
            }

        }

    }
}
