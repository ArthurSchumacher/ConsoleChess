using Xadrez.ChessBoard;
using Xadrez.ChessBoard.Enums;

namespace Xadrez.Chess;

public class Rook : ChessPiece
{
    public Rook(Color color, Board board) : base(color, board)
    {
    }

    public override string ToString()
    {
        return "R";
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
        while (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;

            if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
            {
                break;
            }

            pos.Line -= 1;
        }

        // East
        pos.setPosition(Position.Line, Position.Column + 1);
        while (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;

            if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
            {
                break;
            }

            pos.Column += 1;
        }

        // South
        pos.setPosition(Position.Line + 1, Position.Column);
        while (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;

            if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
            {
                break;
            }

            pos.Line += 1;
        }

        // West
        pos.setPosition(Position.Line, Position.Column - 1);
        while (Board.isValidPosition(pos) && canMove(pos))
        {
            tmpMatrix[pos.Line, pos.Column] = true;

            if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
            {
                break;
            }

            pos.Column -= 1;
        }

        return tmpMatrix;
    }
}
