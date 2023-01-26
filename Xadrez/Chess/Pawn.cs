using Xadrez.ChessBoard;
using Xadrez.ChessBoard.Enums;

namespace Xadrez.Chess;

public class Pawn : ChessPiece
{
    private ChessGame Game;

    public Pawn(Color color, Board board, ChessGame game) : base(color, board)
    {
        Game = game;
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

            if (Position.Line == 3)
            {
                Position leftPosition = new Position(Position.Line, Position.Column - 1);
                
                if (Board.isValidPosition(leftPosition) && thereIsAnEnemy(leftPosition) && Board.piece(leftPosition) == Game.isVunerableEnPassant)
                {
                    tmpMatrix[leftPosition.Line - 1, leftPosition.Column] = true;
                }

                Position rightPosition = new Position(Position.Line, Position.Column + 1);
                
                if (Board.isValidPosition(rightPosition) && thereIsAnEnemy(rightPosition) && Board.piece(rightPosition) == Game.isVunerableEnPassant)
                {
                    tmpMatrix[rightPosition.Line - 1, rightPosition.Column] = true;
                }
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

            if (Position.Line == 4)
            {
                Position leftPosition = new Position(Position.Line, Position.Column - 1);
                
                if (Board.isValidPosition(leftPosition) && thereIsAnEnemy(leftPosition) && Board.piece(leftPosition) == Game.isVunerableEnPassant)
                {
                    tmpMatrix[leftPosition.Line + 1, leftPosition.Column] = true;
                }

                Position rightPosition = new Position(Position.Line, Position.Column + 1);
                
                if (Board.isValidPosition(rightPosition) && thereIsAnEnemy(rightPosition) && Board.piece(rightPosition) == Game.isVunerableEnPassant)
                {
                    tmpMatrix[rightPosition.Line + 1, rightPosition.Column] = true;
                }
            }
        }

        return tmpMatrix;
    }
}
