using Xadrez.ChessBoard;
using Xadrez.ChessBoard.Enums;

namespace Xadrez.Chess;

public class Pawn : ChessPiece
{
    public Pawn(Color color, Board board) : base(color, board)
    {
    }

    public override string ToString()
    {
        return "P";
    }

    private bool thereIsAnEnemy(Position pos)
    {
        ChessPiece tmpPiece = Board.piece(pos);
        return tmpPiece != null && tmpPiece.Color != Color;
    }

    private bool isFree(Position pos)
    {
        return Board.piece(pos) == null;
    }

    public override bool[,] possibleMoves()
    {
        bool[,] tmpMatrix = new bool[Board.Lines, Board.Columns];
        Position pos = new Position(0, 0);

        if (Color == Color.White)
        {
            pos.setPosition(Position.Line - 1, Position.Column);
            if (Board.isValidPosition(pos) && isFree(pos))
            {
                tmpMatrix[pos.Line, pos.Column] = true;
            }

            pos.setPosition(Position.Line - 2, Position.Column);
            if (Board.isValidPosition(pos) && isFree(pos) && MovesQTD == 0)
            {
                tmpMatrix[pos.Line, pos.Column] = true;
            }

            pos.setPosition(Position.Line - 1, Position.Column - 1);
            if (Board.isValidPosition(pos) && thereIsAnEnemy(pos))
            {
                tmpMatrix[pos.Line, pos.Column] = true;
            }

            pos.setPosition(Position.Line - 1, Position.Column + 1);
            if (Board.isValidPosition(pos) && thereIsAnEnemy(pos))
            {
                tmpMatrix[pos.Line, pos.Column] = true;
            }
        }
        else
        {
            pos.setPosition(Position.Line + 1, Position.Column);
            if (Board.isValidPosition(pos) && isFree(pos))
            {
                tmpMatrix[pos.Line, pos.Column] = true;
            }

            pos.setPosition(Position.Line + 2, Position.Column);
            if (Board.isValidPosition(pos) && isFree(pos) && MovesQTD == 0)
            {
                tmpMatrix[pos.Line, pos.Column] = true;
            }

            pos.setPosition(Position.Line + 1, Position.Column - 1);
            if (Board.isValidPosition(pos) && thereIsAnEnemy(pos))
            {
                tmpMatrix[pos.Line, pos.Column] = true;
            }

            pos.setPosition(Position.Line + 1, Position.Column + 1);
            if (Board.isValidPosition(pos) && thereIsAnEnemy(pos))
            {
                tmpMatrix[pos.Line, pos.Column] = true;
            }
        }

        return tmpMatrix;
    }
}
