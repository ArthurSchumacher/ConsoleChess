﻿using Xadrez.ChessBoard;
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
                    Console.Clear();
                    Screen.PrintChessBoard(newChessGame.ChessBoard);

                    Console.Write("\nOrigem: ");
                    Position origin = Screen.readChessPosition().toPosition();

                    Console.Write("Destino: ");
                    Position destiny = Screen.readChessPosition().toPosition();

                    newChessGame.MovePiece(origin, destiny);
                }

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}