namespace Xadrez.ChessBoard;

public class Position
{
    public int Line { get; set; }
    public int Column { get; set; }

    public Position(int line, int column)
    {
        Line = line;
        Column = column;
    }

    public void setPosition(int x, int y)
    {
        Line = x;
        Column = y;
    }

    public override string ToString()
    {
        return $"({Line}, {Column})";
    }
}
