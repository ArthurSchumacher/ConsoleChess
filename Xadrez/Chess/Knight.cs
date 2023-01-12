using Xadrez.ChessBoard;
using Xadrez.ChessBoard.Enums;

namespace Xadrez.Chess;

public class Knight : ChessPiece
{
    public Knight(Color color, Board board) : base(color, board)
    {
    }

    public override string ToString()
    {
        return "C";
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

        pos.setPosition(Position.Line - 1, Position.Column - 2);
        if (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;
        }

        pos.setPosition(Position.Line - 2, Position.Column - 1);
        if (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;
        }

        pos.setPosition(Position.Line - 2, Position.Column + 1);
        if (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;
        }

        pos.setPosition(Position.Line - 1, Position.Column + 2);
        if (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;
        }

        pos.setPosition(Position.Line + 1, Position.Column + 2);
        if (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;
        }

        pos.setPosition(Position.Line + 2, Position.Column + 1);
        if (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;
        }

        pos.setPosition(Position.Line + 2, Position.Column - 1);
        if (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;
        }

        pos.setPosition(Position.Line + 1, Position.Column - 2);
        if (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;
        }

        return tmpMatrix;
    }
}
