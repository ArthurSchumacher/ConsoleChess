using Xadrez.ChessBoard;
using Xadrez.ChessBoard.Enums;

namespace Xadrez.Chess;

public class Tower : ChessPiece
{
    public Tower(Color color, Board board) : base(color, board)
    {
    }

    public override string ToString()
    {
        return "T";
    }
}
