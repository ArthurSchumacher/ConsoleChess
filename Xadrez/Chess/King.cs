using Xadrez.ChessBoard;
using Xadrez.ChessBoard.Enums;

namespace Xadrez.Chess;

public class King : ChessPiece
{
    public King(Color color, Board board) : base(color, board)
    {
    }

    public override string ToString()
    {
        return "K";
    }
}
