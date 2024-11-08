using System.ComponentModel.DataAnnotations;

namespace PiecesOfArt_Application_Assignment.DTOS
{
    public class Userdto
    {
        [Required(ErrorMessage = "Please Enter Your Username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "Please Enter Your Age")]
        public int UserAge { get; set; }
        public int LoyaltyCardId { get; set; }
    }
}
