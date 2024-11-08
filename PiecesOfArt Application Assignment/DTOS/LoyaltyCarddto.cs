using System.ComponentModel.DataAnnotations;

namespace PiecesOfArt_Application_Assignment.DTOS
{
    public class LoyaltyCarddto
    {
        [Required(ErrorMessage = "Please Enter Your LoyaltyCardName")]
        public string LoyaltyCardName { get; set; }
        [Required(ErrorMessage = "Please Enter Your LoyaltyCardDescription")]
        public string LoyaltyCardDescription { get; set; }
    }
}
