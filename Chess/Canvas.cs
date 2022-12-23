using System;
using System.Linq.Expressions;
using Chess.BoardAndPieces;
using Chess.Game;

namespace Chess
{
    internal class Canvas
    {
        public static void printMatch(Match match)
        {
            printBoard(match.board);
            Console.WriteLine();
            printCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.turn);
            Console.WriteLine("Waiting: " + match.currentPlayer);
            if (match.check)
            {
                Console.WriteLine("Check!");
            }
        }
        public static void printCapturedPieces(Match match)
        {
            Console.WriteLine("Captured Pieces:");
            Console.Write("White: ");
            printSet(match.capturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            printSet(match.capturedPieces(Color.Black));
            Console.ForegroundColor = temp;
            Console.WriteLine();
        }

        public static void printSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece p in set)
            {
                Console.Write(p + " ");
            }
            Console.Write("]");
        }

        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    Canvas.printPiece(board.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void printBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackGround = Console.BackgroundColor;
            ConsoleColor newBackGround = ConsoleColor.DarkGray;

            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = newBackGround;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackGround;
                    }
                    Canvas.printPiece(board.piece(i, j));
                    Console.BackgroundColor = originalBackGround;
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
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }
    }
}
