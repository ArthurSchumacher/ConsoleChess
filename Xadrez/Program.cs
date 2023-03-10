using Xadrez.ChessBoard;
using Xadrez.Chess;
using Xadrez.ChessBoard.Exceptions;

namespace Xadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessGame newChessGame = new ChessGame();

                while (!newChessGame.isOver)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintGame(newChessGame);

                        Console.Write("\nOrigem: ");
                        Position origin = Screen.readChessPosition().toPosition();

                        newChessGame.isValidOrigin(origin);
                        bool[,] possibleMoves = newChessGame.ChessBoard.piece(origin).possibleMoves();

                        Console.Clear();
                        Screen.PrintChessBoard(newChessGame.ChessBoard, possibleMoves);

                        Console.Write("\nDestino: ");
                        Position destiny = Screen.readChessPosition().toPosition();
                        newChessGame.isValidDestiny(origin, destiny);

                        newChessGame.Play(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }

                }

                Console.Clear();
                Screen.PrintGame(newChessGame);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}