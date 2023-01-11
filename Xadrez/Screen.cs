using Xadrez.ChessBoard;
using Xadrez.Chess;

namespace Xadrez;

public static class Screen
{
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
