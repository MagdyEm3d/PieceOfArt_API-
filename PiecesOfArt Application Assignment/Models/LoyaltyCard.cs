using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PiecesOfArt_Application_Assignment.Models
{
    public class LoyaltyCard
    {
        [Key]
        public int LoyaltyCardId { get; set; }
        [Required(ErrorMessage ="Please Enter Your LoyaltyCardName")]
        public string LoyaltyCardName { get; set; }
        [Required(ErrorMessage = "Please Enter Your LoyaltyCardDescription")]
        public string LoyaltyCardDescription { get; set; }

        [JsonIgnore]
        public List<User> users { get; set; }= new List<User>();
    }
}
