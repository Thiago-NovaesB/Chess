// See https://aka.ms/new-console-template for more information
using Chess;
using Chess.BoardAndPieces;
using Chess.Game;

Board board = new Board(8, 8);
board.addPiece(new King(board, Color.Black), new Position(0, 0));
board.addPiece(new King(board, Color.White), new Position(1, 0));

Canvas.printBoard(board);
