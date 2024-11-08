using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PiecesOfArt_Application_Assignment.ConnectionDbContext;
using PiecesOfArt_Application_Assignment.Models;

namespace PiecesOfArt_Application_Assignment.Reposatories
{
    public class PieceOfArtRepository : IPieceOfArtReposatory
    {
        private readonly ApplicationDbContext _context;

        public PieceOfArtRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<PieceOfArt> GetAllPieces()
        {
            return _context.pieceOfArts
                .Include(x => x.category)
                .Include(x => x.User)
                .ToList();
        }

        public void AddPiece(PieceOfArt piece)
        {
            _context.pieceOfArts.Add(piece);
            _context.SaveChanges();
        }

        public void DeletePiece(int pieceOfArtId)
        {
            var piece = _context.pieceOfArts.FirstOrDefault(p => p.PieceOfArtId == pieceOfArtId);
            if (piece != null)
            {
                _context.pieceOfArts.Remove(piece);
                _context.SaveChanges();
            }
        }
    }
}
