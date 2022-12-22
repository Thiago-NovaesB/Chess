using System;
using System.Linq.Expressions;
using Chess.BoardAndPieces;
using Chess.Game;

namespace Chess
{
    internal class Canvas
    {
        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    Piece p = board.piece(i, j);
                    if (p != null)
                    {
                        Canvas.printPiece(board.piece(i, j));
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static ChessPosition readChessPosition()
        {
            string? s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1].ToString());
            return new ChessPosition(column, line);
        }

        public static void printPiece(Piece piece)
        {
            if (piece.color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor temp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = temp;
            }
        }
    }
}
