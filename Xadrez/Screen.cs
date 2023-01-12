using Xadrez.ChessBoard;
using Xadrez.ChessBoard.Enums;
using Xadrez.Chess;
using System.Collections.Generic;

namespace Xadrez;

public static class Screen
{
    public static void PrintGame(ChessGame game)
    {
        PrintChessBoard(game.ChessBoard);

        PrintCapturedPieces(game);

        Console.WriteLine($"\n\nTurno: {game.Turn}");
        if (!game.isOver)
        {
            Console.WriteLine($"Aguardando jogada: {game.Player}");

            if (game.CheckMate)
            {
                Console.WriteLine("Xeque!");
            }
        }
        else
        {
            Console.WriteLine("Xeque-mate!");
            Console.WriteLine($"Vencedor: {game.Player}");
        }
    }

    public static void PrintCapturedPieces(ChessGame game)
    {
        Console.WriteLine("\nPeças capturadas: ");
        Console.Write("Brancas: ");
        PrintSet(game.capturedPiecesByColor(Color.White));

        Console.Write("\nPretas: ");
        ConsoleColor tmpColor = Console.BackgroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        PrintSet(game.capturedPiecesByColor(Color.Black));
        Console.ForegroundColor = tmpColor;
    }

    public static void PrintSet(HashSet<ChessPiece> piecesSet)
    {
        Console.Write("[");
        foreach (ChessPiece item in piecesSet)
        {
            Console.Write($"{item}, ");
        }
        Console.Write("]");
    }

    public static void PrintChessBoard(Board board)
    {
        for (int i = 0; i < board.Lines; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < board.Columns; j++)
            {
                PrintChessPiece(board.piece(i, j));
            }

            Console.WriteLine();
        }

        Console.WriteLine("  A B C D E F G H");
    }

    public static void PrintChessBoard(Board board, bool[,] possibleMoves)
    {
        ConsoleColor ogConsoleColor = Console.BackgroundColor;
        ConsoleColor altConsoleColor = ConsoleColor.DarkGray;

        for (int i = 0; i < board.Lines; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < board.Columns; j++)
            {
                if (possibleMoves[i, j])
                {
                    Console.BackgroundColor = altConsoleColor;
                }
                else
                {
                    Console.BackgroundColor = ogConsoleColor;
                }

                PrintChessPiece(board.piece(i, j));
                Console.BackgroundColor = ogConsoleColor;
            }

            Console.WriteLine();
            Console.BackgroundColor = ogConsoleColor;
        }

        Console.WriteLine("  A B C D E F G H");
    }

    public static ChessPosition readChessPosition()
    {
        string tmpAnswer = Console.ReadLine();
        char column = tmpAnswer[0];
        int line = int.Parse(tmpAnswer[1] + "");

        return new ChessPosition(column, line);
    }

    public static void PrintChessPiece(ChessPiece piece)
    {
        if (piece == null)
        {
            Console.Write("- ");
        }
        else
        {
            if (piece.Color == ChessBoard.Enums.Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor tmpConsoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = tmpConsoleColor;
            }
            Console.Write(" ");
        }

    }
}
