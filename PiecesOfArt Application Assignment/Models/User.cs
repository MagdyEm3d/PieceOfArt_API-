using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PiecesOfArt_Application_Assignment.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage ="Please Enter Your Username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "Please Enter Your Age")]
        public int UserAge { get; set; }

        [ForeignKey("LoyaltyCardId")]
        public int LoyaltyCardId { get; set; }
        public LoyaltyCard LoyaltyCard { get; set; }

        [JsonIgnore]
        public List<PieceOfArt> pieceOfArts { get; set; } = new List<PieceOfArt>(); 
    }
}
