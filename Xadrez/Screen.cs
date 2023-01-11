using Xadrez.ChessBoard;

namespace Xadrez;

public static class Screen
{
    public static void PrintChessBoard(Board board)
    {
        for (int i = 0; i < board.Lines; i++)
        {
            for (int j = 0; j < board.Columns; j++)
            {
                if (board.piece(i, j) != null)
                {
                    Console.Write($"{board.piece(i, j)} ");
                }
                else
                {
                    Console.Write($"- ");
                }
                
            }

            Console.WriteLine();
        }
    }
}
