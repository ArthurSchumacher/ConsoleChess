using Xadrez.ChessBoard;
using Xadrez.ChessGame;
using Xadrez.ChessBoard.Exceptions;

namespace Xadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board newChessBoard = new Board(8, 8);

                newChessBoard.placePiece(new Tower(ChessBoard.Enums.Color.Black, newChessBoard), new Position(0, 0));
                newChessBoard.placePiece(new King(ChessBoard.Enums.Color.White, newChessBoard), new Position(0, 1));

                Screen.PrintChessBoard(newChessBoard);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}