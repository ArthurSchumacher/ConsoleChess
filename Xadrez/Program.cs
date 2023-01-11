using Xadrez.ChessBoard;

namespace Xadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board newChessBoard = new Board(8, 8);
            
            Screen.PrintChessBoard(newChessBoard);
        }
    }
}