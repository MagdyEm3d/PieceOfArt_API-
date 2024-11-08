using Microsoft.AspNetCore.Mvc;
using PiecesOfArt_Application_Assignment.DTOS;
using PiecesOfArt_Application_Assignment.Models;
using PiecesOfArt_Application_Assignment.Reposatories;

namespace PiecesOfArt_Application_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoyaltyCardController : ControllerBase
    {
        private readonly ILoyaltCardReposatoy _loyaltyCardRepository;

        public LoyaltyCardController(ILoyaltCardReposatoy loyaltyCardRepository)
        {
            _loyaltyCardRepository = loyaltyCardRepository;
        }

        [HttpPost("Add-LoyaltyCard")]
        public IActionResult AddLoyaltyCard(LoyaltyCarddto loyaltyCarddto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var loyaltyCard = new LoyaltyCard
            {
                LoyaltyCardName = loyaltyCarddto.LoyaltyCardName,
                LoyaltyCardDescription = loyaltyCarddto.LoyaltyCardDescription
            };

            _loyaltyCardRepository.AddLoyaltyCard(loyaltyCard);
            _loyaltyCardRepository.SaveChanges();

            return Ok("LoyaltyCard Added Successfully");
        }

        [HttpDelete("Delete-Secound-Recourd")]
        public IActionResult DeleteLoyaltyCard()
        {
            var loyaltyCard = _loyaltyCardRepository.GetSecondLoyaltyCard();
            if (loyaltyCard == null)
                return BadRequest("This LoyaltyCard Not Found");

            _loyaltyCardRepository.DeleteLoyaltyCard(loyaltyCard);
            _loyaltyCardRepository.SaveChanges();

            return Ok("LoyaltyCard Deleted Successfully");
        }
    }
}
