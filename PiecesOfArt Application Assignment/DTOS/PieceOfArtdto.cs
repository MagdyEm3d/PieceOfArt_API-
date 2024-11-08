using System.ComponentModel.DataAnnotations;

namespace PiecesOfArt_Application_Assignment.DTOS
{
    public class PieceOfArtdto
    {

        [Required(ErrorMessage = "Please Enter Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please Enter Price")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Please Enter PublicationDate")]
        public DateTime PublicationDate { get; set; }
        public int userid { get; set; }
        public int categoryid { get; set; }
    }
}
