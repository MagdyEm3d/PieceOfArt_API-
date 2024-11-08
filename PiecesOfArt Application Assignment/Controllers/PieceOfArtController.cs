using Microsoft.AspNetCore.Mvc;
using PiecesOfArt_Application_Assignment.DTOS;
using PiecesOfArt_Application_Assignment.Models;
using PiecesOfArt_Application_Assignment.Reposatories;

namespace PiecesOfArt_Application_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PieceOfArtController : ControllerBase
    {
        private readonly IPieceOfArtReposatory _pieceOfArtRepository;

        public PieceOfArtController(IPieceOfArtReposatory pieceOfArtRepository)
        {
            _pieceOfArtRepository = pieceOfArtRepository;
        }

        [HttpGet("GetAllPieces")]
        public IActionResult GetAllPieces()
        {
            var pieces = _pieceOfArtRepository.GetAllPieces();
            return Ok(pieces);
        }

        [HttpPost("Add-PieceOfArt")]
        public IActionResult AddPieceOfArt(PieceOfArtdto pieceOfArtdto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var titlepiece = _pieceOfArtRepository.GetAllPieces().FirstOrDefault(x => x.Title == pieceOfArtdto.Title);
            if (titlepiece != null)
                return BadRequest($"The {titlepiece.Title} already exists.");

            var piece = new PieceOfArt
            {
                Title = pieceOfArtdto.Title,
                Price = pieceOfArtdto.Price,
                userid = pieceOfArtdto.userid,
                categoryid = pieceOfArtdto.categoryid,
                PublicationDate = pieceOfArtdto.PublicationDate
            };

            _pieceOfArtRepository.AddPiece(piece);
            return Ok("Piece added successfully");
        }

        [HttpDelete("Delete-Piece/{id}")]
        public IActionResult DeletePiece(int id)
        {
            var piece = _pieceOfArtRepository.GetAllPieces().FirstOrDefault(p => p.PieceOfArtId == id);
            if (piece == null)
                return BadRequest("Piece not found.");

            _pieceOfArtRepository.DeletePiece(id);
            return Ok("Piece deleted successfully.");
        }
    }
}
