using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PiecesOfArt_Application_Assignment.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Please Enter Your CategoryName")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Please Enter Your CategoryDescription")]
        public string CategoryDescription { get; set; }

        [JsonIgnore]
        public List<PieceOfArt> pieceOfArts { get; set; } = new List<PieceOfArt>();

    }
}
