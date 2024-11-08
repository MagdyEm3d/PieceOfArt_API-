using System.Collections.Generic;
using PiecesOfArt_Application_Assignment.Models;

namespace PiecesOfArt_Application_Assignment.Reposatories
{
    public interface IPieceOfArtReposatory
    {
        List<PieceOfArt> GetAllPieces();
        void AddPiece(PieceOfArt piece);
        void DeletePiece(int pieceOfArtId);
    }
}
