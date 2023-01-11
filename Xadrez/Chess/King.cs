using Xadrez.ChessBoard;
using Xadrez.ChessBoard.Enums;

namespace Xadrez.Chess;

public class King : ChessPiece
{
    public King(Color color, Board board) : base(color, board)
    {
    }

    public override string ToString()
    {
        return "K";
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

        // North
        pos.setPosition(Position.Line - 1, Position.Column);
        if (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;
        }

        // North East
        pos.setPosition(Position.Line - 1, Position.Column + 1);
        if (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;
        }

        // East
        pos.setPosition(Position.Line, Position.Column + 1);
        if (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;
        }

        // South East
        pos.setPosition(Position.Line + 1, Position.Column + 1);
        if (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;
        }

        // South
        pos.setPosition(Position.Line + 1, Position.Column);
        if (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;
        }

        // South West
        pos.setPosition(Position.Line + 1, Position.Column - 1);
        if (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;
        }

        // West
        pos.setPosition(Position.Line, Position.Column - 1);
        if (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;
        }

        // North West
        pos.setPosition(Position.Line - 1, Position.Column - 1);
        if (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;
        }

        return tmpMatrix;
    }
}
