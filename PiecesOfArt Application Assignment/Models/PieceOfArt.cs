using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PiecesOfArt_Application_Assignment.Models
{
    public class PieceOfArt
    {
        [Key]
        public int PieceOfArtId { get; set; }

        [Required(ErrorMessage ="Please Enter Title")]
        public string Title {  get; set; }
        [Required(ErrorMessage = "Please Enter Price")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Please Enter PublicationDate")]
        public DateTime PublicationDate { get; set; }

        [ForeignKey("userid")]
        public int userid { get; set; }
        public User User { get; set; }

        [ForeignKey("categoryid")]
        public int categoryid { get; set; }
        public Category category { get; set; }

    }



}
