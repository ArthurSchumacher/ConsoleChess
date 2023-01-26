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
    public bool CheckMate { get; private set; }
    public ChessPiece isVunerableEnPassant { get; private set; }

    public ChessGame()
    {
        ChessBoard = new Board(8, 8);
        Turn = 1;
        Player = Color.White;
        isVunerableEnPassant = null;
        isOver = false;
        CheckMate = false;
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
        placeNewPiece('a', 8, new Rook(Color.Black, ChessBoard));
        placeNewPiece('b', 8, new Knight(Color.Black, ChessBoard));
        placeNewPiece('c', 8, new Bishop(Color.Black, ChessBoard));
        placeNewPiece('d', 8, new Queen(Color.Black, ChessBoard));
        placeNewPiece('e', 8, new King(Color.Black, ChessBoard, this));
        placeNewPiece('f', 8, new Bishop(Color.Black, ChessBoard));
        placeNewPiece('g', 8, new Knight(Color.Black, ChessBoard));
        placeNewPiece('h', 8, new Rook(Color.Black, ChessBoard));

        placeNewPiece('a', 7, new Pawn(Color.Black, ChessBoard, this));
        placeNewPiece('b', 7, new Pawn(Color.Black, ChessBoard, this));
        placeNewPiece('c', 7, new Pawn(Color.Black, ChessBoard, this));
        placeNewPiece('d', 7, new Pawn(Color.Black, ChessBoard, this));
        placeNewPiece('e', 7, new Pawn(Color.Black, ChessBoard, this));
        placeNewPiece('f', 7, new Pawn(Color.Black, ChessBoard, this));
        placeNewPiece('g', 7, new Pawn(Color.Black, ChessBoard, this));
        placeNewPiece('h', 7, new Pawn(Color.Black, ChessBoard, this));
    }

    private void WhitePieces()
    {
        placeNewPiece('a', 1, new Rook(Color.White, ChessBoard));
        placeNewPiece('b', 1, new Knight(Color.White, ChessBoard));
        placeNewPiece('c', 1, new Bishop(Color.White, ChessBoard));
        placeNewPiece('d', 1, new Queen(Color.White, ChessBoard));
        placeNewPiece('e', 1, new King(Color.White, ChessBoard, this));
        placeNewPiece('f', 1, new Bishop(Color.White, ChessBoard));
        placeNewPiece('g', 1, new Knight(Color.White, ChessBoard));
        placeNewPiece('h', 1, new Rook(Color.White, ChessBoard));

        placeNewPiece('a', 2, new Pawn(Color.White, ChessBoard, this));
        placeNewPiece('b', 2, new Pawn(Color.White, ChessBoard, this));
        placeNewPiece('c', 2, new Pawn(Color.White, ChessBoard, this));
        placeNewPiece('d', 2, new Pawn(Color.White, ChessBoard, this));
        placeNewPiece('e', 2, new Pawn(Color.White, ChessBoard, this));
        placeNewPiece('f', 2, new Pawn(Color.White, ChessBoard, this));
        placeNewPiece('g', 2, new Pawn(Color.White, ChessBoard, this));
        placeNewPiece('h', 2, new Pawn(Color.White, ChessBoard, this));
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
        if (!ChessBoard.piece(origin).canMoveToDestiny(destiny))
        {
            throw new BoardException("Destiny position is invalid.");
        }
    }

    public ChessPiece MovePiece(Position origin, Position destiny)
    {
        ChessPiece p = ChessBoard.removePiece(origin);
        p.Moves();

        ChessPiece capturedPiece = ChessBoard.removePiece(destiny);
        ChessBoard.placePiece(p, destiny);

        if (capturedPiece != null)
        {
            CapturedPieces.Add(capturedPiece);
        }

        // Promotion
        if (p is Pawn)
        {
            if ((p.Color == Color.White && destiny.Line == 0) || (p.Color == Color.Black && destiny.Line == 7))
            {
                p = ChessBoard.removePiece(destiny);
                Pieces.Remove(p);

                ChessPiece queen = new Queen(p.Color, ChessBoard);
                ChessBoard.placePiece(queen, destiny);
                Pieces.Add(queen);
            }
        }

        // Special Moves
        // Small Rock

        if (p is King && destiny.Column == origin.Column + 2)
        {
            Position rookOrigin = new Position(origin.Line, origin.Column + 3);
            Position rookDestiny = new Position(origin.Line, origin.Column + 1);

            ChessPiece R = ChessBoard.removePiece(rookOrigin);
            R.Moves();

            ChessBoard.placePiece(R, rookDestiny);
        }

        // Big Rock

        if (p is King && destiny.Column == origin.Column - 2)
        {
            Position rookOrigin = new Position(origin.Line, origin.Column - 4);
            Position rookDestiny = new Position(origin.Line, origin.Column - 1);

            ChessPiece R = ChessBoard.removePiece(rookOrigin);
            R.Moves();

            ChessBoard.placePiece(R, rookDestiny);
        }

        // En Passant

        if (p is Pawn && origin.Column != destiny.Column && capturedPiece == null)
        {
            Position pawnPosition;

            if (p.Color == Color.White)
            {
                pawnPosition = new Position(destiny.Line + 1, destiny.Column);
            }
            else
            {
                pawnPosition = new Position(destiny.Line - 1, destiny.Column);
            }

            capturedPiece = ChessBoard.removePiece(pawnPosition);
            CapturedPieces.Add(capturedPiece);
        }

        return capturedPiece;
    }

    public bool testCheckMate(Color color)
    {
        if (!isInCheckMate(color))
        {
            return false;
        }

        foreach (ChessPiece item in piecesStillInGame(color))
        {
            bool[,] tmpMatrix = item.possibleMoves();

            for (int i = 0; i < ChessBoard.Lines; i++)
            {
                for (int j = 0; j < ChessBoard.Columns; j++)
                {
                    if (tmpMatrix[i, j])
                    {
                        Position origem = item.Position;
                        Position destiny = new Position(i, j);
                        ChessPiece capturedPiece = MovePiece(origem, destiny);
                        bool tmpTestCheckMate = isInCheckMate(color);
                        undoMove(origem, destiny, capturedPiece);

                        if (!tmpTestCheckMate)
                        {
                            return false;
                        }
                    }
                }
            }
        }

        return true;
    }

    public void undoMove(Position origin, Position destiny, ChessPiece capturedPiece)
    {
        ChessPiece piece = ChessBoard.removePiece(destiny);
        piece.UndoMoves();

        if (capturedPiece != null)
        {
            ChessBoard.placePiece(capturedPiece, destiny);
            CapturedPieces.Remove(capturedPiece);
        }

        ChessBoard.placePiece(piece, origin);

        // Special Moves
        // Small Rock

        if (capturedPiece is King && destiny.Column == origin.Column + 2)
        {
            Position rookOrigin = new Position(origin.Line, origin.Column + 3);
            Position rookDestiny = new Position(origin.Line, origin.Column + 1);

            ChessPiece R = ChessBoard.removePiece(rookDestiny);
            R.UndoMoves();

            ChessBoard.placePiece(R, rookOrigin);
        }

        // Big Rock

        if (capturedPiece is King && destiny.Column == origin.Column - 2)
        {
            Position rookOrigin = new Position(origin.Line, origin.Column - 4);
            Position rookDestiny = new Position(origin.Line, origin.Column - 1);

            ChessPiece R = ChessBoard.removePiece(rookDestiny);
            R.UndoMoves();

            ChessBoard.placePiece(R, rookOrigin);
        }

        // En Passant

        if (capturedPiece is Pawn && origin.Column != destiny.Column && capturedPiece == isVunerableEnPassant)
        {
            ChessPiece pawn = ChessBoard.removePiece(destiny);
            Position pawnPosition;

            if (capturedPiece.Color == Color.White)
            {
                pawnPosition = new Position(3, destiny.Column);
            }
            else
            {
                pawnPosition = new Position(4, destiny.Column);
            }

            ChessBoard.placePiece(pawn, pawnPosition);
        }
    }

    public void Play(Position origin, Position destiny)
    {
        ChessPiece capturedPiece = MovePiece(origin, destiny);

        if (isInCheckMate(Player))
        {
            undoMove(origin, destiny, capturedPiece);
            throw new BoardException("You can't put yourself in checkmate.");
        }

        if (isInCheckMate(Enemy(Player)))
        {
            CheckMate = true;
        }
        else
        {
            CheckMate = false;
        }

        if (testCheckMate(Enemy(Player)))
        {
            isOver = true;
        }
        else
        {
            Turn++;
            ChangePlayer();
        }

        ChessPiece p = ChessBoard.piece(destiny);

        // Special Move En Passant
        if (p is Pawn && (destiny.Line == origin.Line + 2 || destiny.Line == origin.Line - 2))
        {
            isVunerableEnPassant = p;
        }
        else
        {
            isVunerableEnPassant = null;
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

    private Color Enemy(Color color)
    {
        if (color == Color.White)
        {
            return Color.Black;
        }
        else
        {
            return Color.White;
        }
    }

    private ChessPiece King(Color color)
    {
        foreach (ChessPiece item in piecesStillInGame(color))
        {
            if (item is King)
            {
                return item;
            }
        }

        return null;
    }

    public bool isInCheckMate(Color color)
    {
        ChessPiece K;
        K = King(color);

        if (K == null)
        {
            throw new BoardException("King not found.");
        }

        foreach (ChessPiece item in piecesStillInGame(Enemy(color)))
        {
            bool[,] tmpMatrix = item.possibleMoves();

            if (tmpMatrix[K.Position.Line, K.Position.Column])
            {
                return true;
            }
        }

        return false;
    }

    private void ChangePlayer()
    {
        if (Player == Color.White)
        {
            Player = Color.Black;
        }
        else
        {
            Player = Color.White;
        }
    }
}
