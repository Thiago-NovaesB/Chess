using System;

namespace Chess.BoardAndPieces
{
    internal class BoardException : Exception
    {
        public BoardException(string msg) : base(msg)
        { }
    }
}
