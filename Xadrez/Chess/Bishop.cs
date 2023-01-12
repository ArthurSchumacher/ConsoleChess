using Xadrez.ChessBoard;
using Xadrez.ChessBoard.Enums;

namespace Xadrez.Chess;

public class Bishop : ChessPiece
{
    public Bishop(Color color, Board board) : base(color, board)
    {
    }

    public override string ToString()
    {
        return "B";
    }

    private bool canMove(Position pos)
    {
        ChessPiece tmpPiece = Board.piece(pos);
        return tmpPiece == null || tmpPiece.Color != Color;
    }

    public override bool[,] possibleMoves()
    {
        bool[,] tmpMatrix = new bool[Board.Lines, Board.Columns];
        Position pos = new Position(0, 0);

        // North East
        pos.setPosition(Position.Line - 1, Position.Column + 1);
        while (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;

            if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
            {
                break;
            }

            pos.setPosition(pos.Line - 1, pos.Column + 1);
        }

        // North West
        pos.setPosition(Position.Line - 1, Position.Column - 1);
        while (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;

            if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
            {
                break;
            }

            pos.setPosition(pos.Line - 1, pos.Column - 1);
        }

        // South East
        pos.setPosition(Position.Line + 1, Position.Column + 1);
        while (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;

            if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
            {
                break;
            }

            pos.setPosition(pos.Line + 1, pos.Column + 1);
        }

        // South West
        pos.setPosition(Position.Line + 1, Position.Column - 1);
        while (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;

            if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
            {
                break;
            }

            pos.setPosition(pos.Line + 1, pos.Column - 1);
        }

        return tmpMatrix;
    }
}
