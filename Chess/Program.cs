// See https://aka.ms/new-console-template for more information
using Chess;
using Chess.BoardAndPieces;
using Chess.Game;

try
{
    Match match = new Match();
    while (!match.finished)
    {
        Console.Clear();
        Canvas.printBoard(match.board);
        Console.WriteLine();
        Console.Write("Origin: ");
        Position origin = Canvas.readChessPosition().toPosition();
        Console.Write("Destiny: ");
        Position destiny = Canvas.readChessPosition().toPosition();

        match.executeMove(origin, destiny);

    }
}
catch (BoardException e)
{
    Console.WriteLine(e.Message);
}

