using Xadrez.ChessBoard;
using Xadrez.ChessGame;

namespace Xadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board newChessBoard = new Board(8, 8);

            newChessBoard.placePiece(new Tower(ChessBoard.Enums.Color.Black, newChessBoard), new Position(0, 0));
            
            Screen.PrintChessBoard(newChessBoard);
        }
    }
}