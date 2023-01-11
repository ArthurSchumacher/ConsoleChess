using Xadrez.ChessBoard;
using Xadrez.ChessBoard.Enums;
using Xadrez.ChessBoard.Exceptions;
namespace Xadrez.Chess;

public class ChessGame
{
    public Board ChessBoard { get; private set; }
    public int Turn { get; private set; }
    public Color Player { get; private set; }
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
        BlackPieces();
        WhitePieces();        
    }

    private void BlackPieces()
    {
        ChessBoard.placePiece(new Tower(Color.Black, ChessBoard), new ChessPosition('a', 8).toPosition());
        ChessBoard.placePiece(new Tower(Color.Black, ChessBoard), new ChessPosition('h', 8).toPosition());
        ChessBoard.placePiece(new King(Color.Black, ChessBoard), new ChessPosition('e', 8).toPosition());
    }

    private void WhitePieces()
    {
        ChessBoard.placePiece(new Tower(Color.White, ChessBoard), new ChessPosition('a', 1).toPosition());
        ChessBoard.placePiece(new Tower(Color.White, ChessBoard), new ChessPosition('h', 1).toPosition());
        ChessBoard.placePiece(new King(Color.White, ChessBoard), new ChessPosition('e', 1).toPosition());
    }

    public void isValidOrigin(Position pos)
    {
        if (ChessBoard.piece(pos) == null)
        {
            throw new BoardException("There is no piece in this origin.");
        }
        if (Player != ChessBoard.piece(pos).Color)
        {
            throw new BoardException("The origin piece is not yours.");
        }
        if (!ChessBoard.piece(pos).isAnyPossibleMoves())
        {
            throw new BoardException("The origin piece can not move.");
        }
    }

    public void isValidDestiny(Position origin, Position destiny)
    {
        if(!ChessBoard.piece(origin).canMoveToDestiny(destiny))
        {
            throw new BoardException("Destiny position is invalid.");
        }
    }

    public void MovePiece(Position origin, Position destiny)
    {
        ChessPiece p = ChessBoard.removePiece(origin);
        p.Moves();

        ChessPiece capturedPiece = ChessBoard.removePiece(destiny);
        ChessBoard.placePiece(p, destiny);
    }

    public void Play(Position origin, Position destiny)
    {
        MovePiece(origin, destiny);
        Turn++;
        ChangePlayer();
    }

    private void ChangePlayer()
    {
        if(Player == Color.White)
        {
            Player = Color.Black;
        }
        else
        {
            Player = Color.White;
        }
    }
}
