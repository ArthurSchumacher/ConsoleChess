using Xadrez.ChessBoard;
using Xadrez.ChessBoard.Enums;
namespace Xadrez.Chess;

public class ChessGame
{
    public Board ChessBoard { get; private set; }
    private int Turn;
    private Color Player;
    public bool isOver { get; set; }

    public ChessGame()
    {
        ChessBoard = new Board(8, 8);
        Turn = 1;
        Player = Color.White;
        isOver = false;
        PlacePieces();
    }

    public void PlacePieces()
    {
        ChessBoard.placePiece(new Tower(Color.Black, ChessBoard), new ChessPosition('a', 8).toPosition());
    }

    public void MovePiece(Position origin, Position destiny)
    {
        ChessPiece p = ChessBoard.removePiece(origin);
        p.Moves();

        ChessPiece capturedPiece = ChessBoard.removePiece(destiny);
        ChessBoard.placePiece(p, destiny);
    }
}
