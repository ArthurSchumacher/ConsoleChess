using Xadrez.ChessBoard.Enums;
namespace Xadrez.ChessBoard;

public class ChessPiece
{
    public Position Position { get; set; }
    public Color Color { get; protected set; }
    public int MovesQTD { get; protected set; }
    public Board Board { get; protected set; }

    public ChessPiece(Position position, Color color, Board board)
    {
        Position = position;
        Color = color;
        Board = board;
        MovesQTD = 0;
    }
}
