using Xadrez.ChessBoard.Enums;
using Xadrez.ChessGame;
namespace Xadrez.ChessBoard;

public class ChessPiece
{
    public Position Position { get; set; }
    public Color Color { get; protected set; }
    public int MovesQTD { get; protected set; }
    public Board Board { get; protected set; }

    public ChessPiece(Color color, Board board)
    {
        Position = null;
        Color = color;
        Board = board;
        MovesQTD = 0;
    }
}
