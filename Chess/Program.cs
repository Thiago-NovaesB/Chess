// See https://aka.ms/new-console-template for more information
using Chess;
using Chess.BoardAndPieces;
using Chess.Game;

try
{
    Match match = new Match();
    while (!match.finished)
    {
        try
        {
            Console.Clear();
            Canvas.printBoard(match.board);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.turn);
            Console.WriteLine("Waiting: " + match.currentPlayer);


            Console.WriteLine();
            Console.Write("Origin: ");
            Position origin = Canvas.readChessPosition().toPosition();
            match.validateOriginPosition(origin);

            bool[,] possiblePositions = match.board.piece(origin).possibleMoves();

            Console.Clear();
            Canvas.printBoard(match.board, possiblePositions);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.turn);
            Console.WriteLine("Waiting: " + match.currentPlayer);

            Console.WriteLine();
            Console.Write("Destiny: ");
            Position destiny = Canvas.readChessPosition().toPosition();
            match.validateDestinyPosition(origin, destiny);

            match.playerTime(origin, destiny);
        }
        catch (BoardException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }

    }
}
catch (BoardException e)
{
    Console.WriteLine(e.Message);
}

