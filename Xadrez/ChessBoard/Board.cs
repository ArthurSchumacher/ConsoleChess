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
}
