using Xadrez.ChessBoard;
using Xadrez.ChessBoard.Enums;
using Xadrez.ChessBoard.Exceptions;
using System.Collections.Generic;

namespace Xadrez.Chess;

public class ChessGame
{
    public Board ChessBoard { get; private set; }
    public int Turn { get; private set; }
    public Color Player { get; private set; }
    public bool isOver { get; set; }
    private HashSet<ChessPiece> Pieces;
    private HashSet<ChessPiece> CapturedPieces;

    public ChessGame()
    {
        ChessBoard = new Board(8, 8);
        Turn = 1;
        Player = Color.White;
        isOver = false;
        Pieces = new HashSet<ChessPiece>();
        CapturedPieces = new HashSet<ChessPiece>();
        PlacePieces();
    }

    public void placeNewPiece(char column, int line, ChessPiece piece)
    {
        ChessBoard.placePiece(piece, new ChessPosition(column, line).toPosition());
        Pieces.Add(piece);
    }

    public void PlacePieces()
    {
        BlackPieces();
        WhitePieces();        
    }

    private void BlackPieces()
    {
        placeNewPiece('a', 8, new Tower(Color.Black, ChessBoard));
        placeNewPiece('h', 8, new Tower(Color.Black, ChessBoard));
        placeNewPiece('e', 8, new King(Color.Black, ChessBoard));
    }

    private void WhitePieces()
    {
        placeNewPiece('a', 1, new Tower(Color.White, ChessBoard));
        placeNewPiece('h', 1, new Tower(Color.White, ChessBoard));
        placeNewPiece('e', 1, new King(Color.White, ChessBoard));
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

        if (capturedPiece != null)
        {
            CapturedPieces.Add(capturedPiece);
        }
    }

    public HashSet<ChessPiece> capturedPiecesByColor(Color color)
    {
        HashSet<ChessPiece> tmpHashSet = new HashSet<ChessPiece>();
        foreach (ChessPiece item in CapturedPieces)
        {
            if (item.Color == color)
            {
                tmpHashSet.Add(item);
            }
        }

        return tmpHashSet;
    }

    public HashSet<ChessPiece> piecesStillInGame(Color color)
    {
        HashSet<ChessPiece> tmpHashSet = new HashSet<ChessPiece>();
        foreach (ChessPiece item in Pieces)
        {
            if (item.Color == color)
            {
                tmpHashSet.Add(item);
            }
        }

        tmpHashSet.ExceptWith(capturedPiecesByColor(color));

        return tmpHashSet;
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
