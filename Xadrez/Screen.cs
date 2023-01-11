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
                if (board.piece(i, j) != null)
                {
                    PrintChessPiece(board.piece(i, j));
                    Console.Write(" ");
                }
                else
                {
                    Console.Write($"- ");
                }
                
            }

            Console.WriteLine();
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
    }
}
