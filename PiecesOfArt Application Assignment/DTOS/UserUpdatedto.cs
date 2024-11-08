using System.ComponentModel.DataAnnotations;

namespace PiecesOfArt_Application_Assignment.DTOS
{
    public class UserUpdatedto
    {

        [Required(ErrorMessage = "Please enter your username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your age")]
        public int UserAge { get; set; }

        [Required(ErrorMessage = "Please enter the title of the Piece of Art")]
        public string PieceOfArtTitle { get; set; }

        [Required(ErrorMessage = "Please enter the category name")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Please enter the loyalty card name")]
        public string LoyaltyCardName { get; set; }
    }
}


