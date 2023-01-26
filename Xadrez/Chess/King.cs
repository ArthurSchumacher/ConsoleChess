using Xadrez.ChessBoard;
using Xadrez.ChessBoard.Enums;

namespace Xadrez.Chess;

public class King : ChessPiece
{
    private ChessGame Game;

    public King(Color color, Board board, ChessGame game) : base(color, board)
    {
        Game = game;
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

    private bool testRookCanRock(Position pos)
    {
        ChessPiece p = Board.piece(pos);

        return p != null && p is Rook && p.Color == Color && p.MovesQTD == 0;
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

        // Special moves

        if (MovesQTD == 0 && !Game.CheckMate)
        {
            // small rock
            Position posR1 = new Position(Position.Line, Position.Column + 3);

            if (testRookCanRock(posR1))
            {
                Position p1 = new Position(Position.Line, Position.Column + 1);
                Position p2 = new Position(Position.Line, Position.Column + 2);

                if (Board.piece(p1) == null && Board.piece(p2) == null)
                {
                    tmpMatrix[Position.Line, Position.Column + 2] = true;
                }
            }

            // big rock
            Position posR2 = new Position(Position.Line, Position.Column - 4);

            if (testRookCanRock(posR2))
            {
                Position p1 = new Position(Position.Line, Position.Column - 1);
                Position p2 = new Position(Position.Line, Position.Column - 2);
                Position p3 = new Position(Position.Line, Position.Column - 3);

                if (Board.piece(p1) == null && Board.piece(p2) == null && Board.piece(p3) == null)
                {
                    tmpMatrix[Position.Line, Position.Column - 2] = true;
                }
            }
        }

        return tmpMatrix;
    }
}
