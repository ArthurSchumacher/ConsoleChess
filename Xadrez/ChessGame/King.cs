using Xadrez.ChessBoard;
using Xadrez.ChessBoard.Enums;

namespace Xadrez.ChessGame;

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
