using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiecesOfArt_Application_Assignment.DTOS;
using PiecesOfArt_Application_Assignment.Models;
using PiecesOfArt_Application_Assignment.Reposatories;
using PiecesOfArt_Application_Assignment.Repositories;

namespace PiecesOfArt_Application_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserReposatory _userRepository;

        public UserController(IUserReposatory userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _userRepository.GetAllUsers(); // Using the repository method
            return Ok(users);
        }

        [HttpPost("Add-User")]
        public IActionResult AddUser(Userdto userdto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new User
            {
                UserName = userdto.UserName,
                UserEmail = userdto.UserEmail,
                UserAge = userdto.UserAge,
                LoyaltyCardId = userdto.LoyaltyCardId
            };

            _userRepository.AddUser(user); // Using the repository method
            return Ok("User Added Successfully");
        }

        [HttpPut("update-user/{id}")]
        public IActionResult UpdateUser(int id, UserUpdatedto userUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _userRepository.GetUserById(id); 

            if (user == null)
                return BadRequest("User not found.");

            user.UserName = userUpdateDto.UserName;
            user.UserAge = userUpdateDto.UserAge;

            var pieceOfArt = _userRepository.GetPieceOfArtByTitle(userUpdateDto.PieceOfArtTitle);
            var loyaltyCard = _userRepository.GetLoyaltyCardByName(userUpdateDto.LoyaltyCardName);

            if (pieceOfArt == null)
                return BadRequest("PieceOfArt not found.");
            if (loyaltyCard == null)
                return BadRequest("LoyaltyCard not found.");

            user.LoyaltyCardId = loyaltyCard.LoyaltyCardId;
            user.pieceOfArts.Add(pieceOfArt);

            try
            {
                _userRepository.UpdateUser(user); 
                return Ok("User updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while updating the user.", Details = ex.Message });
            }
        }

        [HttpDelete("Delete-Second-Record")]
        public IActionResult DeleteUser()
        {
            var user = _userRepository.GetUserById(4); 
            if (user == null)
                return BadRequest("User Not Found");

            _userRepository.DeleteUser(user); 
            return Ok("User Deleted Successfully");
        }
    }
}
