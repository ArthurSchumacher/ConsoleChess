using Xadrez.ChessBoard.Exceptions;

namespace Xadrez.ChessBoard;

public class Board
{
    public int Lines { get; set; }
    public int Columns { get; set; }
    private ChessPiece[,] Pieces;

    public Board(int lines, int columns)
    {
        Lines = lines;
        Columns = columns;
        Pieces = new ChessPiece[lines, columns];
    }

    public ChessPiece piece(int line, int column)
    {
        return Pieces[line, column];
    }

    public ChessPiece piece(Position pos)
    {
        return Pieces[pos.Line, pos.Column];
    }

    public void placePiece(ChessPiece p, Position pos)
    {
        if (placedPiece(pos))
        {
            throw new BoardException("There is already a piece in this position.");
        }

        Pieces[pos.Line, pos.Column] = p;
        p.Position = pos;
    }

    public ChessPiece removePiece(Position pos)
    {
        if (piece(pos) == null)
        {
            return null;
        }

        ChessPiece tmpPiece = piece(pos);
        tmpPiece.Position = null;
        Pieces[pos.Line, pos.Column] = null;

        return tmpPiece;
    }

    public bool isValidPosition(Position pos)
    {
        if (pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns)
        {
            return false;
        }

        return true;
    }

    public void validatePosition(Position pos)
    {
        if (!isValidPosition(pos))
        {
            throw new BoardException("Invalid position!");
        }
    }

    public bool placedPiece(Position pos)
    {
        validatePosition(pos);
        return piece(pos) != null;
    }
}
