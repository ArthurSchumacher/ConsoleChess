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

    public void placePiece(ChessPiece p, Position pos)
    {
        Pieces[pos.Line, pos.Column] = p;
        p.Position = pos;
    }
}
