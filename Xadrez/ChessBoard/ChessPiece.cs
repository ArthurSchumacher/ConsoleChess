using Xadrez.ChessBoard.Enums;
using Xadrez.Chess;
namespace Xadrez.ChessBoard;

public abstract class ChessPiece
{
    public Position Position { get; set; }
    public Color Color { get; protected set; }
    public int MovesQTD { get; protected set; }
    public Board Board { get; protected set; }

    public ChessPiece(Color color, Board board)
    {
        Position = null;
        Color = color;
        Board = board;
        MovesQTD = 0;
    }

    public void Moves()
    {
        MovesQTD++;
    }

    public void UndoMoves()
    {
        MovesQTD--;
    }

    public bool isAnyPossibleMoves()
    {
        bool[,] tmpMatrix = possibleMoves();

        for (int i = 0; i < Board.Lines; i++)
        {
            for (int j = 0; j < Board.Columns; j++)
            {
                if (tmpMatrix[i, j])
                {
                    return true;
                }
            }
        }

        return false;
    }

    public bool canMoveToDestiny(Position pos)
    {
        return possibleMoves()[pos.Line, pos.Column];
    }

    public abstract bool[,] possibleMoves();
}
