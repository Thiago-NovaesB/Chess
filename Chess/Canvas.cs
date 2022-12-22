using System;
using System.Linq.Expressions;
using Chess.BoardAndPieces;

namespace Chess
{
    internal class Canvas
    {
        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.lines; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    Piece p = board.piece(i, j);
                    if (p != null)
                    {
                        Console.Write(board.piece(i, j) + " ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
